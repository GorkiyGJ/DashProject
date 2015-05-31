using System;

namespace DashProject.Web.DataSourceView
{
    public class MediaDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public MediaDataSourceViewBase(DashProject.Web.DataSource.MediaDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.Media entity = GetEntityByKeys(keys);

            if (values.Contains("RawMediaId"))
                entity.RawMediaId = System.Int32.Parse(values["RawMediaId"].ToString());

            if (values.Contains("ProgramIndex"))
                entity.ProgramIndex = (values["ProgramIndex"] == null || string.IsNullOrEmpty(values["ProgramIndex"].ToString())) ? null : (System.Byte?)System.Byte.Parse(values["ProgramIndex"].ToString());

            if (values.Contains("Name"))
                entity.Name = values["Name"].ToString();

            if (values.Contains("IsActive"))
                entity.IsActive = System.Boolean.Parse(values["IsActive"].ToString());

            if (values.Contains("DateTimeCreated"))
                entity.DateTimeCreated = System.DateTime.Parse(values["DateTimeCreated"].ToString());

            if (DashProject.Repository.Factory.Media.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.Media entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.Media.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.Media GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.Media entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.Media.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}