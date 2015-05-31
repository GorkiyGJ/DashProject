using System;

namespace DashProject.Web.DataSourceView
{
    public class VideoSizeDataSourceViewBase : Winnetou.WebControls.DataSources.extObjectDataSourceView
    {
        public VideoSizeDataSourceViewBase(DashProject.Web.DataSource.VideoSizeDataSourceBase owner, string name, System.Web.HttpContext context)
            : base(owner, name, context) { }
        
        protected override int ExecuteUpdate(System.Collections.IDictionary keys, System.Collections.IDictionary values, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.VideoSize entity = GetEntityByKeys(keys);

            if (values.Contains("Name"))
                entity.Name = values["Name"].ToString();

            if (values.Contains("Width"))
                entity.Width = System.Int16.Parse(values["Width"].ToString());

            if (values.Contains("Height"))
                entity.Height = System.Int16.Parse(values["Height"].ToString());

            if (DashProject.Repository.Factory.VideoSize.Update(entity))
                return 1;
            else
                return 0;
        }

        protected override int ExecuteDelete(System.Collections.IDictionary keys, System.Collections.IDictionary oldValues)
        {
            DashProject.Entity.VideoSize entity = GetEntityByKeys(keys);
            if (DashProject.Repository.Factory.VideoSize.Delete(entity))
                return 1;
            else
                return 0;
        }

        protected DashProject.Entity.VideoSize GetEntityByKeys(System.Collections.IDictionary keys)
        {
            DashProject.Entity.VideoSize entity;
            if (!keys.Contains("Id"))
                throw new System.Collections.Generic.KeyNotFoundException("Key not found.");

            System.Int32 _Id = System.Int32.Parse(keys["Id"].ToString());

            entity = DashProject.Repository.Factory.VideoSize.GetById(_Id);
            if (entity == null)
                throw new System.Data.RowNotInTableException("Object does not exists.");

            return entity;
        }
    }
}