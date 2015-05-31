using System;

namespace DashProject.Web.DataSourceView
{
    public class DashMediaSegmentDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public DashMediaSegmentDataSourceViewBase(DashProject.Web.DataSource.DashMediaSegmentDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DashMediaSegment entity = GetEntityByKeys(keys);

            if (values.Contains("DashMediaId"))
                entity.DashMediaId = System.Int32.Parse(values["DashMediaId"].ToString());

            if (values.Contains("ContainerFormatId"))
                entity.ContainerFormatId = System.Int32.Parse(values["ContainerFormatId"].ToString());

            if (values.Contains("TimeScale"))
                entity.TimeScale = System.Int32.Parse(values["TimeScale"].ToString());

            if (values.Contains("DecodeTimeTS"))
                entity.DecodeTimeTS = System.Int64.Parse(values["DecodeTimeTS"].ToString());

            if (values.Contains("DurationTS"))
                entity.DurationTS = System.Int32.Parse(values["DurationTS"].ToString());

            if (values.Contains("DurationS"))
                entity.DurationS = System.Decimal.Parse(values["DurationS"].ToString());

            if (values.Contains("DateTimeCreated"))
                entity.DateTimeCreated = System.DateTime.Parse(values["DateTimeCreated"].ToString());

            if (DashProject.Repository.Factory.DashMediaSegment.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DashMediaSegment entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.DashMediaSegment.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.DashMediaSegment GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.DashMediaSegment entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.DashMediaSegment.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}