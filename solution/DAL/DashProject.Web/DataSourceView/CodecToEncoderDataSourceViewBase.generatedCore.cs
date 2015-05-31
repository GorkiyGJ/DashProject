using System;

namespace DashProject.Web.DataSourceView
{
    public class CodecToEncoderDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public CodecToEncoderDataSourceViewBase(DashProject.Web.DataSource.CodecToEncoderDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.CodecToEncoder entity = GetEntityByKeys(keys);

            if (values.Contains("CodecTypeId"))
                entity.CodecTypeId = System.Int32.Parse(values["CodecTypeId"].ToString());

            if (values.Contains("EncoderTypeId"))
                entity.EncoderTypeId = System.Int32.Parse(values["EncoderTypeId"].ToString());

            if (values.Contains("IsMain"))
                entity.IsMain = System.Boolean.Parse(values["IsMain"].ToString());

            if (DashProject.Repository.Factory.CodecToEncoder.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.CodecToEncoder entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.CodecToEncoder.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.CodecToEncoder GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.CodecToEncoder entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.CodecToEncoder.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}