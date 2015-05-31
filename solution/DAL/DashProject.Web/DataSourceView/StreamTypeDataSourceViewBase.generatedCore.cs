using System;

namespace DashProject.Web.DataSourceView
{
    public class StreamTypeDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public StreamTypeDataSourceViewBase(DashProject.Web.DataSource.StreamTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.StreamType entity = GetEntityByKeys(keys);

            if (values.Contains("Name"))
                entity.Name = values["Name"].ToString();

            if (DashProject.Repository.Factory.StreamType.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.StreamType entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.StreamType.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.StreamType GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.StreamType entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.StreamType.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}