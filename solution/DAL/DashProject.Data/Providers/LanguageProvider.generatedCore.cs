using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class LanguageProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.Language>
    {
        public static List<DashProject.Data.Item.Language> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Language> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Language>();
            
                DashProject.Data.Item.Language row = new DashProject.Data.Item.Language();

                row.Id = (System.Int32)dr[((byte)LanguageBase.LanguageColumn.Id - 1)];
                row.Code1 = (dr.IsDBNull(((byte)LanguageBase.LanguageColumn.Code1 - 1))) ? null : (System.String)dr[((byte)LanguageBase.LanguageColumn.Code1 - 1)];
                row.Code2 = (dr.IsDBNull(((byte)LanguageBase.LanguageColumn.Code2 - 1))) ? null : (System.String)dr[((byte)LanguageBase.LanguageColumn.Code2 - 1)];
                row.Code3 = (dr.IsDBNull(((byte)LanguageBase.LanguageColumn.Code3 - 1))) ? null : (System.String)dr[((byte)LanguageBase.LanguageColumn.Code3 - 1)];
                row.Name = (System.String)dr[((byte)LanguageBase.LanguageColumn.Name - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Language FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Language row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.Language();
                row.Id = (System.Int32)dr[((byte)LanguageBase.LanguageColumn.Id - 1)];
                row.Code1 = (dr.IsDBNull(((byte)LanguageBase.LanguageColumn.Code1 - 1))) ? null : (System.String)dr[((byte)LanguageBase.LanguageColumn.Code1 - 1)];
                row.Code2 = (dr.IsDBNull(((byte)LanguageBase.LanguageColumn.Code2 - 1))) ? null : (System.String)dr[((byte)LanguageBase.LanguageColumn.Code2 - 1)];
                row.Code3 = (dr.IsDBNull(((byte)LanguageBase.LanguageColumn.Code3 - 1))) ? null : (System.String)dr[((byte)LanguageBase.LanguageColumn.Code3 - 1)];
                row.Name = (System.String)dr[((byte)LanguageBase.LanguageColumn.Name - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.Language item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.Language item );        
        

   

     
        public virtual DashProject.Data.Item.Language GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.Language GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

 
    
    }                       
}