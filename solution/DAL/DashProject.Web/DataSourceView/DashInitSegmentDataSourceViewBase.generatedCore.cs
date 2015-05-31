using System;

namespace DashProject.Web.DataSourceView
{
    public class DashInitSegmentDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public DashInitSegmentDataSourceViewBase(DashProject.Web.DataSource.DashInitSegmentDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DashInitSegment entity = GetEntityByKeys(keys);

            if (values.Contains("ContainerFormatId"))
                entity.ContainerFormatId = System.Int32.Parse(values["ContainerFormatId"].ToString());

            if (values.Contains("FileName"))
                entity.FileName = values["FileName"].ToString();

            if (values.Contains("DateTimeCreated"))
                entity.DateTimeCreated = System.DateTime.Parse(values["DateTimeCreated"].ToString());

            if (DashProject.Repository.Factory.DashInitSegment.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DashInitSegment entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.DashInitSegment.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.DashInitSegment GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.DashInitSegment entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.DashInitSegment.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}