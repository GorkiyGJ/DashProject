using System;

namespace DashProject.Web.DataSourceView
{
    public class RawSegmentStreamDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public RawSegmentStreamDataSourceViewBase(DashProject.Web.DataSource.RawSegmentStreamDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.RawSegmentStream entity = GetEntityByKeys(keys);

            if (values.Contains("SegmentId"))
                entity.SegmentId = System.Int64.Parse(values["SegmentId"].ToString());

            if (values.Contains("MediaId"))
                entity.MediaId = System.Int32.Parse(values["MediaId"].ToString());

            if (values.Contains("StreamId"))
                entity.StreamId = System.Int32.Parse(values["StreamId"].ToString());

            if (values.Contains("FileName"))
                entity.FileName = values["FileName"].ToString();

            if (values.Contains("DurationS"))
                entity.DurationS = System.Decimal.Parse(values["DurationS"].ToString());

            if (values.Contains("GlobalStartTimeS"))
                entity.GlobalStartTimeS = System.Decimal.Parse(values["GlobalStartTimeS"].ToString());

            if (values.Contains("GlobalEndTimeS"))
                entity.GlobalEndTimeS = System.Decimal.Parse(values["GlobalEndTimeS"].ToString());

            if (values.Contains("DateTimeCreated"))
                entity.DateTimeCreated = System.DateTime.Parse(values["DateTimeCreated"].ToString());

            if (DashProject.Repository.Factory.RawSegmentStream.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.RawSegmentStream entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.RawSegmentStream.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.RawSegmentStream GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.RawSegmentStream entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int64 _Id = System.Int64.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.RawSegmentStream.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}