using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item.Custom;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public abstract class iDashMediaInfoMapperBase : DashProject.Data.Providers.Custom.iDashMediaInfoProvider
    {
        protected string connectionString;

        public iDashMediaInfoMapperBase()
        {
        }

        public iDashMediaInfoMapperBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public override List<DashProject.Data.Item.Custom.iDashMediaInfo> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            return null;
        }  
        
        public override List<DashProject.Data.Item.Custom.iDashMediaInfo> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
    
    public override List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_By_MainDashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[c_iDashMediaInfo_Get_By_MainDashMediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashMediaId, "DashMediaId", SqlDbType.Int);
IDataReader dr = null;
            
            List<DashProject.Data.Item.Custom.iDashMediaInfo> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_By_MainDashMediaId"));

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
OnDataRequested(new ItemEventArgs(sm, sc, "Get_By_MainDashMediaId", rows));
 
            return rows;
             
        
    }
    
    public override List<DashProject.Data.Item.Custom.iDashMediaInfo> Get_IsMain_By_MediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? MediaId)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[c_iDashMediaInfo_Get_IsMain_By_MediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, MediaId, "MediaId", SqlDbType.Int);
IDataReader dr = null;
            
            List<DashProject.Data.Item.Custom.iDashMediaInfo> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_IsMain_By_MediaId"));

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
OnDataRequested(new ItemEventArgs(sm, sc, "Get_IsMain_By_MediaId", rows));
 
            return rows;
             
        
    }
                  
    }
}