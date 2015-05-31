using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item.Custom;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public abstract class iMediaInfoMapperBase : DashProject.Data.Providers.Custom.iMediaInfoProvider
    {
        protected string connectionString;

        public iMediaInfoMapperBase()
        {
        }

        public iMediaInfoMapperBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public override List<DashProject.Data.Item.Custom.iMediaInfo> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            return null;
        }  
        
        public override List<DashProject.Data.Item.Custom.iMediaInfo> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
    
    public override List<DashProject.Data.Item.Custom.iMediaInfo> Get_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[c_iMediaInfo_Get_By_MediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, MediaId, "MediaId", SqlDbType.Int);
IDataReader dr = null;
            
            List<DashProject.Data.Item.Custom.iMediaInfo> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_By_MediaId"));

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
OnDataRequested(new ItemEventArgs(sm, sc, "Get_By_MediaId", rows));
 
            return rows;
             
        
    }
    
    public override List<DashProject.Data.Item.Custom.iMediaInfo> Get(Manitou.Data.Provider.SessionManager sm )
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[c_iMediaInfo_Get]" );        
IDataReader dr = null;
            
            List<DashProject.Data.Item.Custom.iMediaInfo> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get"));

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
OnDataRequested(new ItemEventArgs(sm, sc, "Get", rows));
 
            return rows;
             
        
    }
                  
    }
}