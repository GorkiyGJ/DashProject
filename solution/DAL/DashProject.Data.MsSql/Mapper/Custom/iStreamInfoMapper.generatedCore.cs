using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item.Custom;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public abstract class iStreamInfoMapperBase : DashProject.Data.Providers.Custom.iStreamInfoProvider
    {
        protected string connectionString;

        public iStreamInfoMapperBase()
        {
        }

        public iStreamInfoMapperBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public override List<DashProject.Data.Item.Custom.iStreamInfo> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            return null;
        }  
        
        public override List<DashProject.Data.Item.Custom.iStreamInfo> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
    
    public override List<DashProject.Data.Item.Custom.iStreamInfo> Get_By_MediaId_StreamIndex(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId, System.Int32? StreamIndex)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[c_iStreamInfo_Get_By_MediaId_StreamIndex]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, MediaId, "MediaId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, StreamIndex, "StreamIndex", SqlDbType.Int);
IDataReader dr = null;
            
            List<DashProject.Data.Item.Custom.iStreamInfo> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_By_MediaId_StreamIndex"));

            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                
dr = Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteReader(sc);
rows = Fill(dr);
                
            }
            finally
            {
            
                if (dr != null)
                    dr.Close();                    
                    
                if (!sm.IsTransactionOpen)
                    sm.Close();
            }                                                                 
OnDataRequested(new ItemEventArgs(sm, sc, "Get_By_MediaId_StreamIndex", rows));
 
            return rows;
             
        
    }
                  
    }
}