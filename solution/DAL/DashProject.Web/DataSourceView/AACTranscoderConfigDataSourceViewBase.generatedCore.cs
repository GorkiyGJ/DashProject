using System;

namespace DashProject.Web.DataSourceView
{
    public class AACTranscoderConfigDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public AACTranscoderConfigDataSourceViewBase(DashProject.Web.DataSource.AACTranscoderConfigDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.AACTranscoderConfig entity = GetEntityByKeys(keys);

            if (values.Contains("BitrateKbps"))
                entity.BitrateKbps = (values["BitrateKbps"] == null || string.IsNullOrEmpty(values["BitrateKbps"].ToString())) ? null : (System.Int32?)System.Int32.Parse(values["BitrateKbps"].ToString());

            if (values.Contains("IsUseConstrainedBitRate"))
                entity.IsUseConstrainedBitRate = (values["IsUseConstrainedBitRate"] == null || string.IsNullOrEmpty(values["IsUseConstrainedBitRate"].ToString())) ? null : (System.Boolean?)System.Boolean.Parse(values["IsUseConstrainedBitRate"].ToString());

            if (values.Contains("Channels"))
                entity.Channels = (values["Channels"] == null || string.IsNullOrEmpty(values["Channels"].ToString())) ? null : (System.Byte?)System.Byte.Parse(values["Channels"].ToString());

            if (DashProject.Repository.Factory.AACTranscoderConfig.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.AACTranscoderConfig entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.AACTranscoderConfig.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.AACTranscoderConfig GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.AACTranscoderConfig entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.AACTranscoderConfig.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}