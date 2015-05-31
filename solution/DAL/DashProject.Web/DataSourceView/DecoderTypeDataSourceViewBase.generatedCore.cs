using System;

namespace DashProject.Web.DataSourceView
{
    public class DecoderTypeDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public DecoderTypeDataSourceViewBase(DashProject.Web.DataSource.DecoderTypeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DecoderType entity = GetEntityByKeys(keys);

            if (values.Contains("Name"))
                entity.Name = values["Name"].ToString();

            if (values.Contains("Description"))
                entity.Description = (values["Description"] == null || string.IsNullOrEmpty(values["Description"].ToString())) ? null : values["Description"].ToString();

            if (DashProject.Repository.Factory.DecoderType.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.DecoderType entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.DecoderType.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.DecoderType GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.DecoderType entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.DecoderType.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}