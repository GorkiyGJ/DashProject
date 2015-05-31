using System;

namespace DashProject.Web.DataSourceView
{
    public class AspectRatioDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public AspectRatioDataSourceViewBase(DashProject.Web.DataSource.AspectRatioDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.AspectRatio entity = GetEntityByKeys(keys);

            if (values.Contains("Type1"))
                entity.Type1 = (values["Type1"] == null || string.IsNullOrEmpty(values["Type1"].ToString())) ? null : values["Type1"].ToString();

            if (values.Contains("Type2"))
                entity.Type2 = (values["Type2"] == null || string.IsNullOrEmpty(values["Type2"].ToString())) ? null : (System.Single?)System.Single.Parse(values["Type2"].ToString());

            if (DashProject.Repository.Factory.AspectRatio.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.AspectRatio entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.AspectRatio.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.AspectRatio GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.AspectRatio entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.AspectRatio.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}