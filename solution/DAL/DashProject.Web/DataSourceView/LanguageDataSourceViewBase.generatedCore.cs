using System;

namespace DashProject.Web.DataSourceView
{
    public class LanguageDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public LanguageDataSourceViewBase(DashProject.Web.DataSource.LanguageDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.Language entity = GetEntityByKeys(keys);

            if (values.Contains("Code1"))
                entity.Code1 = (values["Code1"] == null || string.IsNullOrEmpty(values["Code1"].ToString())) ? null : values["Code1"].ToString();

            if (values.Contains("Code2"))
                entity.Code2 = (values["Code2"] == null || string.IsNullOrEmpty(values["Code2"].ToString())) ? null : values["Code2"].ToString();

            if (values.Contains("Code3"))
                entity.Code3 = (values["Code3"] == null || string.IsNullOrEmpty(values["Code3"].ToString())) ? null : values["Code3"].ToString();

            if (values.Contains("Name"))
                entity.Name = values["Name"].ToString();

            if (DashProject.Repository.Factory.Language.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.Language entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.Language.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.Language GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.Language entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.Language.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}