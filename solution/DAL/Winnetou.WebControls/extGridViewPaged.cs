using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Reflection;
using System.ComponentModel;

namespace Winnetou.WebControls
{
    public class extGridViewPaged : extGridView
    {
        private const string const_FirstSortValue = "FirstSortValue";
        private const string const_LastSortValue = "LastSortValue";
        private const string const_PageSortIndex = "PageSortIndex";
        private bool firstSortValueInited;
        private bool clickedPrevNext;

        #region Properties
        /// <summary>
        /// Sets / Gets Paging Column Name
        /// </summary>
        [Description("Sets / Gets Paging Column Name"), Category("Behavior"), DefaultValue(""),]
        public string PagingColumnName { get; set; }

        public object PagingPrevValue { get; protected set; }
        public object PagingNextValue { get; protected set; }

        protected object FirstSortValue
        {
            get
            {
                return ViewState[const_FirstSortValue];
            }
            set
            {
                ViewState[const_FirstSortValue] = value;
            }
        }

        protected object LastSortValue
        {
            get
            {
                return ViewState[const_LastSortValue];
            }
            set
            {
                ViewState[const_LastSortValue] = value;
            }
        }

        protected int PageSortIndex
        {
            get
            {
                if (ViewState[const_PageSortIndex] == null)
                    ViewState[const_PageSortIndex] = 0;
                return Manitou.Helper.Converter.ToInt32(ViewState[const_PageSortIndex], true);
            }
            set
            {
                ViewState[const_PageSortIndex] = value;
            }
        }
        #endregion

        protected override void OnRowCreated(GridViewRowEventArgs e)
        {
            base.OnRowCreated(e);

            if (!string.IsNullOrEmpty(PagingColumnName) && e.Row.RowType == DataControlRowType.DataRow && e.Row.DataItem != null)
            {
                Type dataType = e.Row.DataItem.GetType();
                MemberInfo[] members = dataType.GetMember(PagingColumnName);
                if (members != null && members.Length > 0)
                {
                    object sortValue = null;
                    if (members[0].MemberType == MemberTypes.Property)
                        sortValue = ((PropertyInfo)members[0]).GetValue(e.Row.DataItem, null);
                    else if (members[0].MemberType == MemberTypes.Field)
                        sortValue = ((FieldInfo)members[0]).GetValue(e.Row.DataItem);

                    if (sortValue != null)
                    {
                        if (!firstSortValueInited)
                        {
                            FirstSortValue = sortValue;
                            firstSortValueInited = true;
                        }

                        LastSortValue = sortValue;
                    }
                }
            }

        }

        protected override void DisplayPrevNextPageButtons(GridViewRowEventArgs e)
        {
            TableCell cell = new TableCell();
            cell.EnableViewState = false;

            if (PageSortIndex != 0)
            {
                LinkButton prevButton = new LinkButton();
                prevButton.Text = "<&nbsp;Назад";
                prevButton.Click += new EventHandler(prevButton_Click);
                cell.Controls.Add(prevButton);

                SetSpacer(cell);
                e.Row.Cells[0].Controls[0].Controls[0].Controls.AddAt(0, cell);
            }

            cell = new TableCell();
            cell.EnableViewState = false;
            SetSpacer(cell);

            LinkButton nextButton = new LinkButton();
            nextButton.Text = "Вперед&nbsp;>";
            nextButton.Click += new EventHandler(nextButton_Click);
            cell.Controls.Add(nextButton);

            e.Row.Cells[0].Controls[0].Controls[0].Controls.AddAt(e.Row.Cells[0].Controls[0].Controls[0].Controls.Count, cell);
        }

        private void prevButton_Click(object sender, EventArgs e)
        {
            PageSortIndex--;
            PagingPrevValue = FirstSortValue;
            clickedPrevNext = true;
            DataBind();
            clickedPrevNext = false;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            PageSortIndex++;
            PagingNextValue = LastSortValue;
            clickedPrevNext = true;
            DataBind();
            clickedPrevNext = false;
        }

        protected override void OnDataBinding(EventArgs e)
        {
            if (!clickedPrevNext)
                PageSortIndex = 0;
            base.OnDataBinding(e);
        }
    }
}