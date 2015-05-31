using System;

namespace DashProject.Entity
{
    public class ApplicationConfiguration : ApplicationConfigurationBase
    {
        public ApplicationConfiguration()
            : base()
        { 
        }

        public ApplicationConfiguration(DashProject.Data.Item.ApplicationConfiguration item)
            : base(item)
        { 
        }
    }
}