using System;

namespace DashProject.Web.DataSourceView
{
    public class RawMediaDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public RawMediaDataSourceViewBase(DashProject.Web.DataSource.RawMediaDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.RawMedia entity = GetEntityByKeys(keys);

            if (values.Contains("ContainerTypeId"))
                entity.ContainerTypeId = System.Int32.Parse(values["ContainerTypeId"].ToString());

            if (values.Contains("InputMedia"))
                entity.InputMedia = values["InputMedia"].ToString();

            if (values.Contains("RawMediaSourceTypeId"))
                entity.RawMediaSourceTypeId = System.Byte.Parse(values["RawMediaSourceTypeId"].ToString());

            if (DashProject.Repository.Factory.RawMedia.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.RawMedia entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.RawMedia.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.RawMedia GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.RawMedia entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.RawMedia.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}