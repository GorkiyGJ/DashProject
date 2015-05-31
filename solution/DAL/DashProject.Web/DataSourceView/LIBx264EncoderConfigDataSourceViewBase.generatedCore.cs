using System;

namespace DashProject.Web.DataSourceView
{
    public class LIBx264EncoderConfigDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public LIBx264EncoderConfigDataSourceViewBase(DashProject.Web.DataSource.LIBx264EncoderConfigDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.LIBx264EncoderConfig entity = GetEntityByKeys(keys);

            if (values.Contains("DashMediaId"))
                entity.DashMediaId = System.Int32.Parse(values["DashMediaId"].ToString());

            if (values.Contains("LIBx264EncoderPresetTypeId"))
                entity.LIBx264EncoderPresetTypeId = System.Int32.Parse(values["LIBx264EncoderPresetTypeId"].ToString());

            if (values.Contains("X264ProfileId"))
                entity.X264ProfileId = System.Int32.Parse(values["X264ProfileId"].ToString());

            if (values.Contains("X264ProfileLevelId"))
                entity.X264ProfileLevelId = System.Int32.Parse(values["X264ProfileLevelId"].ToString());

            if (values.Contains("ThreadsCount"))
                entity.ThreadsCount = System.Byte.Parse(values["ThreadsCount"].ToString());

            if (values.Contains("BitrateKbps"))
                entity.BitrateKbps = (values["BitrateKbps"] == null || string.IsNullOrEmpty(values["BitrateKbps"].ToString())) ? null : (System.Int32?)System.Int32.Parse(values["BitrateKbps"].ToString());

            if (values.Contains("IsUseConstantBitRate"))
                entity.IsUseConstantBitRate = System.Boolean.Parse(values["IsUseConstantBitRate"].ToString());

            if (values.Contains("ConstantRateFactor"))
                entity.ConstantRateFactor = System.Byte.Parse(values["ConstantRateFactor"].ToString());

            if (values.Contains("isUseConstantRateFactorForQualityManagement"))
                entity.isUseConstantRateFactorForQualityManagement = System.Boolean.Parse(values["isUseConstantRateFactorForQualityManagement"].ToString());

            if (DashProject.Repository.Factory.LIBx264EncoderConfig.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.LIBx264EncoderConfig entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.LIBx264EncoderConfig.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.LIBx264EncoderConfig GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.LIBx264EncoderConfig entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.LIBx264EncoderConfig.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}