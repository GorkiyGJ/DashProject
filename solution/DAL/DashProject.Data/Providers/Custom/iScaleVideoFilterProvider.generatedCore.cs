using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item.Custom;

namespace DashProject.Data.Providers.Custom
{
    public abstract class iScaleVideoFilterProviderBase : Manitou.Data.Provider.ReadOnlyItemProviderBase<DashProject.Data.Item.Custom.iScaleVideoFilter>
    {
        public static List<DashProject.Data.Item.Custom.iScaleVideoFilter> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.Custom.iScaleVideoFilter> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.Custom.iScaleVideoFilter>();
                    
                DashProject.Data.Item.Custom.iScaleVideoFilter row = new DashProject.Data.Item.Custom.iScaleVideoFilter();

                row.Width = (dr.IsDBNull(((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Width))) ? null : (System.Int16?)dr[((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Width)];
                row.Height = (dr.IsDBNull(((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Height))) ? null : (System.Int16?)dr[((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Height)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.Custom.iScaleVideoFilter FillItem(IDataReader dr)
        {
            DashProject.Data.Item.Custom.iScaleVideoFilter row = null;

            if(dr.Read())
            {
                row = new DashProject.Data.Item.Custom.iScaleVideoFilter();
                row.Width = (dr.IsDBNull(((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Width))) ? null : (System.Int16?)dr[((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Width)];
                row.Height = (dr.IsDBNull(((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Height))) ? null : (System.Int16?)dr[((byte)iScaleVideoFilterBase.iScaleVideoFilterColumn.Height)];
            }

            return row;
        }         
        
   
    public virtual List<DashProject.Data.Item.Custom.iScaleVideoFilter> Get_By_DashMediaId(ref System.Int32? DashMediaId)
    {               
return Get_By_DashMediaId(null , DashMediaId);
      
    }
    
    public abstract List<DashProject.Data.Item.Custom.iScaleVideoFilter> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId);
        
        
    }                       
}