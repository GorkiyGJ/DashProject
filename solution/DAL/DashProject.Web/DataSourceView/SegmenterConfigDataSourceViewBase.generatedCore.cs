using System;

namespace DashProject.Web.DataSourceView
{
    public class SegmenterConfigDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public SegmenterConfigDataSourceViewBase(DashProject.Web.DataSource.SegmenterConfigDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.SegmenterConfig entity = GetEntityByKeys(keys);

            if (values.Contains("MediaId"))
                entity.MediaId = System.Int32.Parse(values["MediaId"].ToString());

            if (values.Contains("IsForceKeyFrames"))
                entity.IsForceKeyFrames = System.Boolean.Parse(values["IsForceKeyFrames"].ToString());

            if (values.Contains("SegmentTime"))
                entity.SegmentTime = System.Byte.Parse(values["SegmentTime"].ToString());

            if (values.Contains("ResetTimeStamps"))
                entity.ResetTimeStamps = System.Boolean.Parse(values["ResetTimeStamps"].ToString());

            if (values.Contains("IsUseSegmentTimeDelta"))
                entity.IsUseSegmentTimeDelta = System.Boolean.Parse(values["IsUseSegmentTimeDelta"].ToString());

            if (values.Contains("SegmentTimeDelta"))
                entity.SegmentTimeDelta = System.Single.Parse(values["SegmentTimeDelta"].ToString());

            if (values.Contains("IsUseFastStart"))
                entity.IsUseFastStart = System.Boolean.Parse(values["IsUseFastStart"].ToString());

            if (values.Contains("FastStartDurationS"))
                entity.FastStartDurationS = System.Int32.Parse(values["FastStartDurationS"].ToString());

            if (values.Contains("DurationSLimit"))
                entity.DurationSLimit = System.Int32.Parse(values["DurationSLimit"].ToString());

            if (values.Contains("UseDurationSLimit"))
                entity.UseDurationSLimit = System.Boolean.Parse(values["UseDurationSLimit"].ToString());

            if (values.Contains("IsDone"))
                entity.IsDone = System.Boolean.Parse(values["IsDone"].ToString());

            if (DashProject.Repository.Factory.SegmenterConfig.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.SegmenterConfig entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.SegmenterConfig.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.SegmenterConfig GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.SegmenterConfig entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.SegmenterConfig.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}