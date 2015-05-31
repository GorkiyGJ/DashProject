using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Security.Permissions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System;

namespace Winnetou.WebControls.DataSources
{
    [DefaultEventAttribute("Selecting")]
    [DefaultPropertyAttribute("TypeName")]
    [ParseChildrenAttribute(true)]
    [PersistChildrenAttribute(false)]
    [AspNetHostingPermissionAttribute(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    [AspNetHostingPermissionAttribute(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    public class extObjectDataSource : ObjectDataSource
    {
        protected extObjectDataSourceView defaultView = null;

        public extObjectDataSource()
        {
            this.Selected += new System.Web.UI.WebControls.ObjectDataSourceStatusEventHandler(ss_Selected);          
        }

        public extObjectDataSource(string typeName, string selectMethod)
        {
            SelectMethod = selectMethod;
            TypeName = typeName;
        }

        extObjectDataSourceView DefaultView
        {
            get
            {
                if (defaultView == null)
                    defaultView = new extObjectDataSourceView(this, "DefaultView", Context);
                return defaultView;
            }
        }

        public event ObjectDataSourceStatusEventHandler Deleted
        {
            add { DefaultView.Deleted += value; }
            remove { DefaultView.Deleted -= value; }
        }

        public event ObjectDataSourceMethodEventHandler Deleting
        {
            add { DefaultView.Deleting += value; }
            remove { DefaultView.Deleting -= value; }
        }

        public event ObjectDataSourceFilteringEventHandler Filtering
        {
            add { DefaultView.Filtering += value; }
            remove { DefaultView.Filtering -= value; }
        }

        public event ObjectDataSourceStatusEventHandler Inserted
        {
            add { DefaultView.Inserted += value; }
            remove { DefaultView.Inserted -= value; }
        }

        public event ObjectDataSourceMethodEventHandler Inserting
        {
            add { DefaultView.Inserting += value; }
            remove { DefaultView.Inserting -= value; }
        }

        public event ObjectDataSourceObjectEventHandler ObjectCreated
        {
            add { DefaultView.ObjectCreated += value; }
            remove { DefaultView.ObjectCreated -= value; }
        }

        public event ObjectDataSourceObjectEventHandler ObjectCreating
        {
            add { DefaultView.ObjectCreating += value; }
            remove { DefaultView.ObjectCreating -= value; }
        }

        public event ObjectDataSourceDisposingEventHandler ObjectDisposing
        {
            add { DefaultView.ObjectDisposing += value; }
            remove { DefaultView.ObjectDisposing -= value; }
        }

        /*		public event ObjectDataSourceResolvingMethodEventHandler ResolvingMethod {
                add { DefaultView.ResolvingMethod += value; }
                remove { DefaultView.ResolvingMethod -= value; }
                }
        */
        public event ObjectDataSourceStatusEventHandler Selected
        {
            add { DefaultView.Selected += value; }
            remove { DefaultView.Selected -= value; }
        }

        public event ObjectDataSourceSelectingEventHandler Selecting
        {
            add { DefaultView.Selecting += value; }
            remove { DefaultView.Selecting -= value; }
        }

        public event ObjectDataSourceStatusEventHandler Updated
        {
            add { DefaultView.Updated += value; }
            remove { DefaultView.Updated -= value; }
        }

        public event ObjectDataSourceMethodEventHandler Updating
        {
            add { DefaultView.Updating += value; }
            remove { DefaultView.Updating -= value; }
        }

        [DefaultValue(0)]
        public virtual int CacheDuration
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        [DefaultValue(DataSourceCacheExpiry.Absolute)]
        public virtual DataSourceCacheExpiry CacheExpirationPolicy
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        [DefaultValue("")]
        public virtual string CacheKeyDependency
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        [DefaultValueAttribute(ConflictOptions.OverwriteChanges)]
        public ConflictOptions ConflictDetection
        {
            get { return DefaultView.ConflictDetection; }
            set { DefaultView.ConflictDetection = value; }
        }

        [DefaultValue(false)]
        public bool ConvertNullToDBNull
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        [DefaultValueAttribute("")]
        public string DataObjectTypeName
        {
            get { return DefaultView.DataObjectTypeName; }
            set { DefaultView.DataObjectTypeName = value; }
        }

        [DefaultValueAttribute("")]
        public string DeleteMethod
        {
            get { return DefaultView.DeleteMethod; }
            set { DefaultView.DeleteMethod = value; }
        }

        [MergablePropertyAttribute(false)]
        [DefaultValueAttribute(null)]
        [PersistenceModeAttribute(PersistenceMode.InnerProperty)]
        public ParameterCollection DeleteParameters
        {
            get { return DefaultView.DeleteParameters; }
        }

        [DefaultValue(false)]
        public virtual bool EnableCaching
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        [DefaultValueAttribute(false)]
        public bool EnablePaging
        {
            get { return DefaultView.EnablePaging; }
            set { DefaultView.EnablePaging = value; }
        }

        [DefaultValueAttribute("")]
        public string FilterExpression
        {
            get { return DefaultView.FilterExpression; }
            set { DefaultView.FilterExpression = value; }
        }

        [MergablePropertyAttribute(false)]
        [DefaultValueAttribute(null)]
        [PersistenceModeAttribute(PersistenceMode.InnerProperty)]
        public ParameterCollection FilterParameters
        {
            get { return DefaultView.FilterParameters; }
        }

        [DefaultValueAttribute("")]
        public string InsertMethod
        {
            get { return DefaultView.InsertMethod; }
            set { DefaultView.InsertMethod = value; }
        }

        [MergablePropertyAttribute(false)]
        [DefaultValueAttribute(null)]
        [PersistenceModeAttribute(PersistenceMode.InnerProperty)]
        public ParameterCollection InsertParameters
        {
            get { return DefaultView.InsertParameters; }
        }

        [DefaultValueAttribute("maximumRows")]
        public string MaximumRowsParameterName
        {
            get { return DefaultView.MaximumRowsParameterName; }
            set { DefaultView.MaximumRowsParameterName = value; }
        }

        [DefaultValueAttribute("{0}")]
        public string OldValuesParameterFormatString
        {
            get { return DefaultView.OldValuesParameterFormatString; }
            set { DefaultView.OldValuesParameterFormatString = value; }
        }

        [DefaultValueAttribute("")]
        public string SelectCountMethod
        {
            get { return DefaultView.SelectCountMethod; }
            set { DefaultView.SelectCountMethod = value; }
        }

        [DefaultValueAttribute("")]
        public string SelectMethod
        {
            get { return DefaultView.SelectMethod; }
            set { DefaultView.SelectMethod = value; }
        }

        [MergablePropertyAttribute(false)]
        [DefaultValueAttribute(null)]
        [PersistenceModeAttribute(PersistenceMode.InnerProperty)]
        public ParameterCollection SelectParameters
        {
            get { return DefaultView.SelectParameters; }
        }

        [DefaultValueAttribute("")]
        public string SortParameterName
        {
            get { return DefaultView.SortParameterName; }
            set { DefaultView.SortParameterName = value; }
        }

        [DefaultValue("")]
        public virtual string SqlCacheDependency
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        [DefaultValueAttribute("startRowIndex")]
        public string StartRowIndexParameterName
        {
            get { return DefaultView.StartRowIndexParameterName; }
            set { DefaultView.StartRowIndexParameterName = value; }
        }

        [DefaultValueAttribute("")]
        public string TypeName
        {
            get { return DefaultView.TypeName; }
            set { DefaultView.TypeName = value; }
        }

        [DefaultValueAttribute("")]
        public string UpdateMethod
        {
            get { return DefaultView.UpdateMethod; }
            set { DefaultView.UpdateMethod = value; }
        }

        [MergablePropertyAttribute(false)]
        [DefaultValueAttribute(null)]
        [PersistenceModeAttribute(PersistenceMode.InnerProperty)]
        public ParameterCollection UpdateParameters
        {
            get { return DefaultView.UpdateParameters; }
        }

        protected override DataSourceView GetView(string viewName)
        {
            return DefaultView;
        }

        protected override ICollection GetViewNames()
        {
            return new string[] { "DefaultView" };
        }

        public IEnumerable Select()
        {
            return DefaultView.Select(DataSourceSelectArguments.Empty);
        }

        public int Update()
        {
            Hashtable empty = new Hashtable();
            return DefaultView.Update(empty, empty, null);
        }

        public int Delete()
        {
            Hashtable empty = new Hashtable();
            return DefaultView.Delete(empty, null);
        }

        public int Insert()
        {
            Hashtable empty = new Hashtable();
            return DefaultView.Insert(empty);
        }

        //protected internal override void OnInit(EventArgs e)
        //{
        //    Page.LoadComplete += OnPageLoadComplete;
        //}

        void OnPageLoadComplete(object sender, EventArgs e)
        {
            DeleteParameters.UpdateValues(Context, this);
            FilterParameters.UpdateValues(Context, this);
            InsertParameters.UpdateValues(Context, this);
            SelectParameters.UpdateValues(Context, this);
            UpdateParameters.UpdateValues(Context, this);
        }

        protected override void LoadViewState(object savedState)
        {
            if (savedState == null)
            {
                base.LoadViewState(null);
                ((IStateManager)DefaultView).LoadViewState(null);
            }
            else
            {
                Pair p = (Pair)savedState;
                base.LoadViewState(p.First);
                ((IStateManager)DefaultView).LoadViewState(p.Second);
            }
        }

        protected override object SaveViewState()
        {
            object baseState = base.SaveViewState();
            object viewState = ((IStateManager)DefaultView).SaveViewState();
            if (baseState != null || viewState != null) return new Pair(baseState, viewState);
            else return null;
        }

        protected override void TrackViewState()
        {
            ((IStateManager)DefaultView).TrackViewState();
        }

        protected void ss_Selected(object sender, System.Web.UI.WebControls.ObjectDataSourceStatusEventArgs e)
        {
            VirtualPageSize = 0;
            if (e.OutputParameters != null)
                foreach (System.Collections.DictionaryEntry d in e.OutputParameters)
                {
                    System.Web.UI.WebControls.Parameter p = GetParamert(sender, Manitou.Helper.Converter.ToString(d.Key));
                    if (p != null)
                    {
                        p.DefaultValue = Manitou.Helper.Converter.ToString(d.Value);

                        if (d.Key != null && d.Key.ToString() == "count")
                            VirtualPageSize = Manitou.Helper.Converter.ToInt32(d.Value, true);
                    }
                }
        }

        public int VirtualPageSize { get; set; }

        public System.Web.UI.WebControls.Parameter GetParamert(object sender, string name)
        {
            foreach (System.Web.UI.WebControls.Parameter p in ((System.Web.UI.WebControls.ObjectDataSourceView)sender).SelectParameters)
            {
                if (p.Name == name && (p.Direction == System.Data.ParameterDirection.Output || p.Direction == System.Data.ParameterDirection.InputOutput))
                {
                    return p;
                }
            }

            return null;
        }
    }
}
