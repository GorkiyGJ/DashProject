using System;

namespace DashProject.Web.DataSourceView
{
    public class RawMediaSourceTypeDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public RawMediaSourceTypeDataSourceViewBase(DashProject.Web.DataSource.RawMediaSourceTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.RawMediaSourceType entity = GetEntityByKeys(keys);

            if (values.Contains("Name"))
                entity.Name = values["Name"].ToString();

            if (DashProject.Repository.Factory.RawMediaSourceType.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.RawMediaSourceType entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.RawMediaSourceType.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.RawMediaSourceType GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.RawMediaSourceType entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Byte _Id = System.Byte.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.RawMediaSourceType.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}