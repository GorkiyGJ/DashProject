using System;
using System.Data;
using System.Collections.Generic;
using Manitou.Data.Provider;
using DashProject.Data.Item;

namespace DashProject.Data.Providers
{
    public abstract class DashMediaProviderBase : Manitou.Data.Provider.ItemProviderBase<DashProject.Data.Item.DashMedia>
    {
        public static List<DashProject.Data.Item.DashMedia> Fill(IDataReader dr)
        {
            List<DashProject.Data.Item.DashMedia> result = null;

            while (dr.Read())
            {
                if(result == null)
                    result = new List<DashProject.Data.Item.DashMedia>();
            
                DashProject.Data.Item.DashMedia row = new DashProject.Data.Item.DashMedia();

                row.Id = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.Id - 1)];
                row.MediaId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.MediaId - 1)];
                row.StreamId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.StreamId - 1)];
                row.DashInitSegmentId = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.DashInitSegmentId - 1))) ? null : (System.Int32?)dr[((byte)DashMediaBase.DashMediaColumn.DashInitSegmentId - 1)];
                row.DashTypeId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.DashTypeId - 1)];
                row.CodecTypeId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.CodecTypeId - 1)];
                row.Width = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.Width - 1))) ? null : (System.Int16?)dr[((byte)DashMediaBase.DashMediaColumn.Width - 1)];
                row.Height = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.Height - 1))) ? null : (System.Int16?)dr[((byte)DashMediaBase.DashMediaColumn.Height - 1)];
                row.Channels = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.Channels - 1))) ? null : (System.Byte?)dr[((byte)DashMediaBase.DashMediaColumn.Channels - 1)];
                row.BitrateKbps = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.BitrateKbps - 1)];
                row.IsActive = (System.Boolean)dr[((byte)DashMediaBase.DashMediaColumn.IsActive - 1)];
                row.FragmentDurationS = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.FragmentDurationS - 1)];

                result.Add(row);
            }

            return result;
        }	
        
       public static DashProject.Data.Item.DashMedia FillItem(IDataReader dr)
        {
            DashProject.Data.Item.DashMedia row = null;

            if (dr.Read())
            {
                row = new DashProject.Data.Item.DashMedia();
                row.Id = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.Id - 1)];
                row.MediaId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.MediaId - 1)];
                row.StreamId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.StreamId - 1)];
                row.DashInitSegmentId = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.DashInitSegmentId - 1))) ? null : (System.Int32?)dr[((byte)DashMediaBase.DashMediaColumn.DashInitSegmentId - 1)];
                row.DashTypeId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.DashTypeId - 1)];
                row.CodecTypeId = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.CodecTypeId - 1)];
                row.Width = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.Width - 1))) ? null : (System.Int16?)dr[((byte)DashMediaBase.DashMediaColumn.Width - 1)];
                row.Height = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.Height - 1))) ? null : (System.Int16?)dr[((byte)DashMediaBase.DashMediaColumn.Height - 1)];
                row.Channels = (dr.IsDBNull(((byte)DashMediaBase.DashMediaColumn.Channels - 1))) ? null : (System.Byte?)dr[((byte)DashMediaBase.DashMediaColumn.Channels - 1)];
                row.BitrateKbps = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.BitrateKbps - 1)];
                row.IsActive = (System.Boolean)dr[((byte)DashMediaBase.DashMediaColumn.IsActive - 1)];
                row.FragmentDurationS = (System.Int32)dr[((byte)DashMediaBase.DashMediaColumn.FragmentDurationS - 1)];
            }

            return row;
        }  
        
        public virtual bool Update(DashProject.Data.Item.DashMedia item )
        {
            return Update(null, item );
        }

        public abstract bool Update(SessionManager sm, DashProject.Data.Item.DashMedia item );        
        

   

     
        public virtual DashProject.Data.Item.DashMedia GetById(System.Int32 Id )
        {
            return GetById(null,  Id );
        }                     
        
        public abstract DashProject.Data.Item.DashMedia GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id );                       
  

  

   
    public virtual void Get_DashType_ById(ref System.Int32? DashMediaId, ref System.Int32? DashTypeId)
    {               
Get_DashType_ById(null , DashMediaId, ref DashTypeId);
      
    }
    
    public abstract void Get_DashType_ById(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Int32? DashTypeId);
        
   
    public virtual void Get_MediaId_ById(ref System.Int32? DashMediaId, ref System.Int32? MediaId)
    {               
Get_MediaId_ById(null , DashMediaId, ref MediaId);
      
    }
    
    public abstract void Get_MediaId_ById(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Int32? MediaId);
        
 
    
    }                       
}