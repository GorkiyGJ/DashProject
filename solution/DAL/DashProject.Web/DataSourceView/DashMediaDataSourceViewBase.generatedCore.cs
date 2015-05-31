using System;

namespace DashProject.Web.DataSourceView
{
    public class DashMediaDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public DashMediaDataSourceViewBase(DashProject.Web.DataSource.DashMediaDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DashMedia entity = GetEntityByKeys(keys);

            if (values.Contains("MediaId"))
                entity.MediaId = System.Int32.Parse(values["MediaId"].ToString());

            if (values.Contains("StreamId"))
                entity.StreamId = System.Int32.Parse(values["StreamId"].ToString());

            if (values.Contains("DashInitSegmentId"))
                entity.DashInitSegmentId = (values["DashInitSegmentId"] == null || string.IsNullOrEmpty(values["DashInitSegmentId"].ToString())) ? null : (System.Int32?)System.Int32.Parse(values["DashInitSegmentId"].ToString());

            if (values.Contains("DashTypeId"))
                entity.DashTypeId = System.Int32.Parse(values["DashTypeId"].ToString());

            if (values.Contains("CodecTypeId"))
                entity.CodecTypeId = System.Int32.Parse(values["CodecTypeId"].ToString());

            if (values.Contains("Width"))
                entity.Width = (values["Width"] == null || string.IsNullOrEmpty(values["Width"].ToString())) ? null : (System.Int16?)System.Int16.Parse(values["Width"].ToString());

            if (values.Contains("Height"))
                entity.Height = (values["Height"] == null || string.IsNullOrEmpty(values["Height"].ToString())) ? null : (System.Int16?)System.Int16.Parse(values["Height"].ToString());

            if (values.Contains("Channels"))
                entity.Channels = (values["Channels"] == null || string.IsNullOrEmpty(values["Channels"].ToString())) ? null : (System.Byte?)System.Byte.Parse(values["Channels"].ToString());

            if (values.Contains("BitrateKbps"))
                entity.BitrateKbps = System.Int32.Parse(values["BitrateKbps"].ToString());

            if (values.Contains("IsActive"))
                entity.IsActive = System.Boolean.Parse(values["IsActive"].ToString());

            if (values.Contains("FragmentDurationS"))
                entity.FragmentDurationS = System.Int32.Parse(values["FragmentDurationS"].ToString());

            if (DashProject.Repository.Factory.DashMedia.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DashMedia entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.DashMedia.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.DashMedia GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.DashMedia entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.DashMedia.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}