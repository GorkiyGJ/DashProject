using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Winnetou.WebControls.DataSources;

namespace Winnetou.WebControls
{
    public class extGridView : GridView
    {
        private const string const_SettingPageInCookies = "const_SettingPageInCookies";
        private const string const_RecordsCount = "_recordsCount";
        private const string const_RecordsPerPageText = "RecordsPerPageText";
        private const string const_EnableMultiColumnSorting = "EnableMultiColumnSorting";
        private const string const_SortImageDesc = "SortImageDesc";
        private const string const_SortImageAsc = "SortImageAsc";
        private const string const_ShowEmptyTable = "ShowEmptyTable";
        private const string const_PageSizeLocal = "PageSizeLocal";        

        protected string _defaultSortColumnName = string.Empty;
        protected SortDirection _defaultSortDirection = SortDirection.Ascending;

        /// <summary>
        /// PageSizeChanged event raised whenever the Page Size Changes
        /// </summary>
        public event EventHandler PageSizeChanged;

        #region Properties

        /// <summary>
        /// Sets / Gets Default Sort Column Name
        /// </summary>
        [Description("Sets / Gets Default Sort Column Name"), Category("Behavior"), DefaultValue(""),]
        public string DefaultSortColumnName
        {
            get
            {
                return (_defaultSortColumnName == string.Empty) ? GetDefaultSortColumn() : _defaultSortColumnName;

            }
            set { _defaultSortColumnName = value; }
        }

        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [Description("Image to display for Ascending Sort"),Category("Misc"),Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),DefaultValue(""),]
        public string SortAscImageUrl
        {
            get
            {
                object o = ViewState[const_SortImageAsc];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState[const_SortImageAsc] = value;
            }
        }
        /// <summary>
        /// Get or Set Image location to be used to display Ascending Sort order.
        /// </summary>
        [Description("Image to display for Descending Sort"),Category("Misc"),Editor("System.Web.UI.Design.UrlEditor", typeof(System.Drawing.Design.UITypeEditor)),DefaultValue(""),]
        public string SortDescImageUrl
        {
            get
            {
                object o = ViewState[const_SortImageDesc];
                return (o != null ? o.ToString() : "");
            }
            set
            {
                ViewState[const_SortImageDesc] = value;
            }
        }

        /// <summary>
        /// Setting the default sort order direction 
        /// </summary>
        [Description("Default Sort Order Direction"), Category("Misc"), Editor("System.Web.UI.WebControls.SortDirection", typeof(SortDirection)), DefaultValue("SortDirection.Ascending"),]
        public SortDirection DefaultSortDirection
        {
            get { return _defaultSortDirection; }
            set { _defaultSortDirection = value; }
        }

        /// <summary>
        /// Enable/Disable MultiColumn Sorting.
        /// </summary>
        [Description("Whether Sorting On more than one column is enabled"), Category("Behavior"), DefaultValue("false"),]
        public bool AllowMultiColumnSorting
        {
            get
            {
                object o = ViewState[const_EnableMultiColumnSorting];
                return (o != null ? (bool)o : false);
            }
            set
            {
                AllowSorting = true;
                ViewState[const_EnableMultiColumnSorting] = value;
            }
        }

        /// <summary>
        /// Gets/Sets Records Per Page
        /// </summary>
        [Description("Gets / Sets Records Per Page Text"), Category("Misc"), DefaultValue("Records Per Page"),]
        public string RecordsPerPageText
        {
            get
            {
                object o = ViewState[const_RecordsPerPageText];
                return (o != null ? (string)o : "Records Per Page");
            }
            set
            {
                ViewState[const_RecordsPerPageText] = value;
            }
        }

        /// <summary>
        /// Total Records Count being assigned the value in the DataSource_Selected event
        /// </summary>
        public int RecordsCount
        {
            get
            {
                if (ViewState[const_RecordsCount] != null)
                    return (int)ViewState[const_RecordsCount];
                else
                    return 0;
            }
            set
            {
                ViewState[const_RecordsCount] = value;
            }
        }

        public bool SettingPageInCookies
        {
            get
            {
                if (ViewState[const_SettingPageInCookies] == null)
                    ViewState[const_SettingPageInCookies] = true;

                return (bool)ViewState[const_SettingPageInCookies];
                
            }
            set { ViewState[const_SettingPageInCookies] = value; }
        }

        [Description("Enable or disable generating an empty table with headers if no data rows in source"), Category("Misc"), DefaultValue("true")]
        public bool ShowEmptyTable
        {
            get
            {
                object o = ViewState[const_ShowEmptyTable];
                return (o != null ? (bool)o : true);
            }
            set
            {
                ViewState[const_ShowEmptyTable] = value;
            }
        }
        #endregion

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            LoadSettingPageSize();
        }

        protected virtual void LoadSettingPageSize()
        {
            if (!DesignMode)
            {
                HttpCookie cIn = HttpContext.Current.Request.Cookies.Get(ClientID);
                if (cIn != null)
                {
                    int? pageSize = Manitou.Helper.Converter.ToInt32Nullable(cIn.Value);
                    if (pageSize != null && pageSize > 0 && (((pageSize / 5) * 5) == pageSize || pageSize == 1 || pageSize == 2 || pageSize == 3))
                    {
                        PageSize = (int) pageSize;
                    }
                    else
                    {
                        PageSize = PageSizeLocal;
                    }
                }
                else
                {
                    PageSize = PageSizeLocal;
                }
            }
        }

        protected virtual int PageSizeLocal
        {
            get
            {
                if (ViewState[const_PageSizeLocal] == null)
                    ViewState[const_PageSizeLocal] = PageSize;// UMH.Settings.SettingItem.Item.SiteSettings.PageSize;

                return (int)ViewState[const_PageSizeLocal];
            }

            set { ViewState[const_PageSizeLocal] = value; }
        }

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (SortExpression != String.Empty)
                    DisplaySortOrderImages(SortExpression, e.Row);
            }
            else
                if (e.Row.RowType == DataControlRowType.EmptyDataRow)
                {
                    e.Row.Cells[0].Attributes.Add("style", "text-align:center;height:40px;");

                }
                else if (e.Row.RowType == DataControlRowType.Pager)
                {
                    DisplayPageSizeSelector(e);

                    SaveSettingPageSize();
                }
        }

        private void SaveSettingPageSize()
        {
            if (!DesignMode && SettingPageInCookies)
            {
                HttpCookie cOut = HttpContext.Current.Response.Cookies.Get(ClientID);
                if (cOut != null)
                {
                    cOut.Value = PageSize.ToString();
                }
                else
                {
                    HttpContext.Current.Response.Cookies.Add(new HttpCookie(ClientID, PageSize.ToString()));
                }

                PageSizeLocal = PageSize;
            }
        }

        #region Help Methods
        /// <summary>
        /// Determine the first column in the column collection that has SortExpression value set, and using this column as a default sort column
        /// </summary>
        /// <returns></returns>
        protected string GetDefaultSortColumn()
        {
            string SortColumnName = string.Empty;

            for (int i = 0; i < Columns.Count; i++)
            {
                SortColumnName = Columns[i].SortExpression;
                if (SortColumnName != string.Empty)
                {
                    break;
                }
            }

            return SortColumnName;
        }

        protected static void SetSpacer(Control cell)
        {
            Literal spacer = new Literal();
            spacer.Text = "&nbsp;";

            cell.Controls.Add(spacer);
        }

        protected virtual void ddl_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageIndex = 0;
            DropDownList cboPageSize = (DropDownList)sender;
            PageSize = int.Parse(cboPageSize.SelectedValue);

            if (PageSizeChanged != null) 
                PageSizeChanged(sender, e);

            SaveSettingPageSize();
        }

        protected override void OnPageIndexChanging(GridViewPageEventArgs e)
        {
            base.OnPageIndexChanging(e);
        }

        protected override void OnPageIndexChanged(EventArgs e)
        {
            base.OnPageIndexChanged(e);
        }

        public override int PageCount
        {
            get
            {
                if (DataSourceObject is extObjectDataSource && ((extObjectDataSource)DataSourceObject).VirtualPageSize != null)
                    return ((extObjectDataSource)DataSourceObject).VirtualPageSize;// / PageSize;
                else
                    return base.PageCount;
            }
        }

        protected override void InitializePager(GridViewRow row, int columnSpan, PagedDataSource pagedDataSource)
        {
            if (DataSourceObject is extObjectDataSource && ((extObjectDataSource)DataSourceObject).VirtualPageSize != null)
                pagedDataSource.VirtualCount = ((extObjectDataSource)DataSourceObject).VirtualPageSize;

            base.InitializePager(row, columnSpan, pagedDataSource);
        }

        protected virtual void DisplayPrevNextPageButtons(GridViewRowEventArgs e)
        {
            if (PageIndex != 0)
            {
                TableCell cell = new TableCell();
                cell.EnableViewState = false;

                LinkButton prevButton = new LinkButton();
                prevButton.Text = "<<";
                prevButton.Click += prevButton_Click;
                cell.Controls.Add(prevButton);

                SetSpacer(cell);

                HyperLink myButton = new HyperLink();
                myButton.Text = "<";
                myButton.NavigateUrl = Page.ClientScript.GetPostBackClientHyperlink(this, "Page$Prev");
                cell.Controls.Add(myButton);

                SetSpacer(cell);

                e.Row.Cells[0].Controls[0].Controls[0].Controls.AddAt(0, cell);
            }

            int ost = (PageCount % PageSize > 0) ? 1 : 0;
            ost += PageCount / PageSize;
            if (PageIndex != ost - 1)
            {
                TableCell cell = new TableCell();
                cell.EnableViewState = false;
                SetSpacer(cell);

                HyperLink myButton = new HyperLink();
                myButton.EnableViewState = false;
                myButton.Text = ">";
                myButton.NavigateUrl = Page.ClientScript.GetPostBackClientHyperlink(this, "Page$Next");
                cell.Controls.Add(myButton);

                SetSpacer(cell);

                if (DataSourceObject is extObjectDataSource)
                {
                    HyperLink nextButton = new HyperLink();
                    nextButton.EnableViewState = false;
                    nextButton.Text = ">>";
                    nextButton.NavigateUrl = Page.ClientScript.GetPostBackClientHyperlink(this, string.Format("Page${0}", ost));
                    cell.Controls.Add(nextButton);
                }
                else
                {
                    LinkButton nextButton = new LinkButton();
                    nextButton.EnableViewState = false;
                    nextButton.Text = ">>";
                    nextButton.Click += nextButton_Click;
                    cell.Controls.Add(nextButton);
                }

                // remove the line wrap
                e.Row.Cells[0].Controls[0].Controls[0].Controls.AddAt(e.Row.Cells[0].Controls[0].Controls[0].Controls.Count, cell);
            }
        }

        protected virtual void DisplayPageSizeSelector(GridViewRowEventArgs e)
        {
            DropDownList ddl = new DropDownList();

            for (int i = 1; i < 4; i ++)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }
            
            for (int i = 5; i < 55; i += 5)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            for (int i = 100; i < 250; i += 50)
            {
                ddl.Items.Add(new ListItem(i.ToString(), i.ToString()));
            }

            ddl.AutoPostBack = true;
            ddl.SelectedIndexChanged += ddl_SelectedIndexChanged;

            int count = ddl.Items.Count;
            string pageSize = PageSize.ToString();

            bool isOk = false;
            for (int i = 0; i < count; i++)
            {
                if (ddl.Items[i].Value == pageSize)
                {
                    isOk = true;
                    break;
                }
            }

            if(isOk)
                ddl.SelectedValue = PageSize.ToString();

            TableCell pcell = new TableCell();
            pcell.Width = Unit.Percentage(100);
            pcell.HorizontalAlign = HorizontalAlign.Right;
            pcell.Controls.Add(ddl);

            DisplayPrevNextPageButtons(e);

            //if (PageIndex != 0)
            e.Row.Cells[0].Controls[0].Controls[0].Controls.AddAt(e.Row.Cells[0].Controls[0].Controls[0].Controls.Count, pcell);
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            PageIndex = PageCount - 1;
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            PageIndex = 0;
        }

        #endregion

        #region Controls Events
        #region cboPageSize_SelectedIndexChanged
        ///// <summary> 
        ///// Occurs when the value of the SelectedIndex property changes. 
        ///// </summary> 
        //private void cboPageSize_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // -- reset current page index to 0, that is nessessary so that there won't be a situation when gridview's current page index is off causing an exception
        //    PageIndex = 0;
        //    DropDownList cboPageSize = (DropDownList)sender;
        //    PageSize = int.Parse(cboPageSize.SelectedValue);

        //    if (PageSizeChanged != null) PageSizeChanged(sender, e);
        //}
        #endregion

        protected void DisplaySortOrderImages(string sortExpression, GridViewRow dgItem)
        {
            DisplaySortOrderImages(sortExpression, dgItem, SortDirection);
        }

        protected void DisplaySortOrderImages(string sortExpression, GridViewRow dgItem, SortDirection sd)
        {
            string[] sortColumns = sortExpression.Split(",".ToCharArray());

            for (int i = 0; i < dgItem.Cells.Count; i++)
            {
                if (dgItem.Cells[i].Controls.Count > 0 && dgItem.Cells[i].Controls[0] is LinkButton)
                {
                    string sortOrder;
                    int sortOrderNo;
                    string column = ((LinkButton)dgItem.Cells[i].Controls[0]).CommandArgument;
                    SearchSortExpression(sortColumns, column, out sortOrder, out sortOrderNo, sd);
                    if (sortOrderNo > 0)
                    {
                        string sortImgLoc = (sortOrder.Equals("ASC") ? SortAscImageUrl : SortDescImageUrl);

                        if (sortImgLoc != String.Empty)
                        {
                            Image imgSortDirection = new Image();
                            imgSortDirection.ImageUrl = sortImgLoc;
                            dgItem.Cells[i].Controls.Add(imgSortDirection);

                            imgSortDirection = new Image();
                            imgSortDirection.ImageUrl = sortImgLoc;
                            dgItem.Cells[i].Controls.AddAt(0, imgSortDirection);
                        }
                        else
                        {
                            Label lblSortDirection = new Label();
                            lblSortDirection.Font.Size = FontUnit.XSmall;
                            lblSortDirection.EnableTheming = false;
                            lblSortDirection.Text = (sortOrder.Equals("ASC") ? "&#9650;" : "&#9660;");
                            dgItem.Cells[i].Controls.Add(lblSortDirection);

                            lblSortDirection = new Label();
                            lblSortDirection.Font.Size = FontUnit.XSmall;
                            lblSortDirection.EnableTheming = false;
                            lblSortDirection.Text = (sortOrder.Equals("ASC") ? "&#9650;" : "&#9660;");
                            dgItem.Cells[i].Controls.AddAt(0, lblSortDirection);
                        }
                    }
                }
            }
        }

        protected void SearchSortExpression(string[] sortColumns, string sortColumn, out string sortOrder, out int sortOrderNo)
        {
            SearchSortExpression(sortColumns, sortColumn, out sortOrder, out sortOrderNo, SortDirection);
        }

        protected void SearchSortExpression(string[] sortColumns, string sortColumn, out string sortOrder, out int sortOrderNo, SortDirection sd)
        {
            sortOrder = "";
            sortOrderNo = -1;
            for (int i = 0; i < sortColumns.Length; i++)
            {
                if (sortColumns[i].StartsWith(sortColumn))
                {
                    sortOrderNo = i + 1;
                    if (AllowMultiColumnSorting)
                        sortOrder = sortColumns[i].Substring(sortColumn.Length).Trim();
                    else
                        sortOrder = ((sd == SortDirection.Ascending) ? "ASC" : "DESC");
                }
            }
        }

        #endregion

        //private string SortImageAsc
        //{
        //    get
        //    {
        //        return Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extGridView.sortascending.gif");
        //    }
        //}

        //private string SortImageDesc
        //{
        //    get
        //    {
        //        return Page.ClientScript.GetWebResourceUrl(typeof(extOperationButton), "Winnetou.WebControls.Images.extGridView.sortdescending.gif");
        //    }
        //}

        protected struct enSort
        {
            public const string SortDirect = "SortDirect";
            public const string SortName = "SortName";
        }

        /// <summary>
        /// Вид сортировки
        /// </summary>
        protected SortDirection SortDirect
        {
            get
            {
                return SortDirection;
            }
        }

        /// <summary>
        /// Имя поля что сортируем
        /// </summary>
        protected string SortName
        {
            get
            {
                return SortExpression;
            }           
        }

        /// <summary>
        /// Сиквел представление вида сортировки
        /// </summary>
        public string SQLSortDirection
        {
            get
            {
                if (SortDirect == SortDirection.Ascending)
                    return " asc";
                else
                    return " desc";
            }
        }

         /// <summary>
         /// Возвращаем готовый Order by...
         /// </summary>
        public string SQLOrderBy
        {
            get
            {
                if (SortName != "")
                    return SortName + SQLSortDirection;
                else
                    return "";
            }
        }

        public string SQLOrderByNoViewState
        {
            get
            {
                string str = SortExpression;

                if (str.Trim().Length > 0)
                    str += SortDirection.ToString() == "Ascending" ? " asc" : " desc";

                return str;
            }
        }

        //public override int PageCount
        //{
        //    get
        //    {
        //        if (DataSourceObject is ObjectDataSource && ((ObjectDataSource)DataSourceObject).SelectParameters["count"] != null)
        //            return Manitou.Helper.Converter.ToInt32(((ObjectDataSource)DataSourceObject).SelectParameters["count"].DefaultValue, true);
        //        else
        //            return base.PageCount;
        //    }
        //}

        protected override int CreateChildControls(IEnumerable dataSource, bool dataBinding)
        {
            int numRows;
            try
            {
                numRows = base.CreateChildControls(dataSource, dataBinding);
            }
            catch
            {
                    numRows = 0;
            }

            if (numRows == 0 && ShowEmptyTable)
            {
                Table table = new Table();
                table.ID = ID;
                DataControlField[] fields = new DataControlField[Columns.Count];
                Columns.CopyTo(fields, 0);
                if (ShowHeader)
                {
                    GridViewRow headerRow = base.CreateRow(-1, -1, DataControlRowType.Header, DataControlRowState.Normal);

                    InitializeRow(headerRow, fields);
                    table.Rows.Add(headerRow);
                }
                GridViewRow emptyRow = new GridViewRow(-1, -1, DataControlRowType.EmptyDataRow, DataControlRowState.Normal);

                TableCell cell = new TableCell();
                cell.ColumnSpan = Columns.Count;
                cell.Width = Unit.Percentage(100);
                if (!String.IsNullOrEmpty(EmptyDataText))
                    cell.Controls.Add(new LiteralControl(EmptyDataText));

                if (EmptyDataTemplate != null)
                    EmptyDataTemplate.InstantiateIn(cell);

                emptyRow.Cells.Add(cell);
                table.Rows.Add(emptyRow);

                if (ShowFooter)
                {
                    GridViewRow footerRow = base.CreateRow(-1, -1, DataControlRowType.Footer, DataControlRowState.Normal);

                    InitializeRow(footerRow, fields);
                    table.Rows.Add(footerRow);
                }
                Controls.Clear();
                Controls.Add(table);
            }
            return numRows;
        }
    }
}