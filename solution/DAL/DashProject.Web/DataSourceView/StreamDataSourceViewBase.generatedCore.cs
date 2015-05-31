using System;

namespace DashProject.Web.DataSourceView
{
    public class StreamDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public StreamDataSourceViewBase(DashProject.Web.DataSource.StreamDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.Stream entity = GetEntityByKeys(keys);

            if (values.Contains("RawMediaId"))
                entity.RawMediaId = System.Int32.Parse(values["RawMediaId"].ToString());

            if (values.Contains("StreamTypeId"))
                entity.StreamTypeId = System.Int32.Parse(values["StreamTypeId"].ToString());

            if (values.Contains("Index"))
                entity.Index = System.Byte.Parse(values["Index"].ToString());

            if (values.Contains("CodecTypeId"))
                entity.CodecTypeId = System.Int32.Parse(values["CodecTypeId"].ToString());

            if (values.Contains("Channels"))
                entity.Channels = (values["Channels"] == null || string.IsNullOrEmpty(values["Channels"].ToString())) ? null : (System.Byte?)System.Byte.Parse(values["Channels"].ToString());

            if (values.Contains("LanguageId"))
                entity.LanguageId = (values["LanguageId"] == null || string.IsNullOrEmpty(values["LanguageId"].ToString())) ? null : (System.Int32?)System.Int32.Parse(values["LanguageId"].ToString());

            if (values.Contains("Width"))
                entity.Width = (values["Width"] == null || string.IsNullOrEmpty(values["Width"].ToString())) ? null : (System.Int16?)System.Int16.Parse(values["Width"].ToString());

            if (values.Contains("Height"))
                entity.Height = (values["Height"] == null || string.IsNullOrEmpty(values["Height"].ToString())) ? null : (System.Int16?)System.Int16.Parse(values["Height"].ToString());

            if (DashProject.Repository.Factory.Stream.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.Stream entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.Stream.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.Stream GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.Stream entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.Stream.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}