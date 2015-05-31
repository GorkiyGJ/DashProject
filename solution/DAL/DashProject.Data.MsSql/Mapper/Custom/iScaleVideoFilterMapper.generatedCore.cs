using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item.Custom;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper.Custom
{
    public abstract class iScaleVideoFilterMapperBase : DashProject.Data.Providers.Custom.iScaleVideoFilterProvider
    {
        protected string connectionString;

        public iScaleVideoFilterMapperBase()
        {
        }

        public iScaleVideoFilterMapperBase(string connectionString)
        {
            this.connectionString = connectionString;
        }
        
        public override List<DashProject.Data.Item.Custom.iScaleVideoFilter> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            return null;
        }  
        
        public override List<DashProject.Data.Item.Custom.iScaleVideoFilter> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            count = 0;
            return null;
        }        
        
    
    public override List<DashProject.Data.Item.Custom.iScaleVideoFilter> Get_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[c_iScaleVideoFilter_Get_By_DashMediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashMediaId, "DashMediaId", SqlDbType.Int);
IDataReader dr = null;
            
            List<DashProject.Data.Item.Custom.iScaleVideoFilter> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_By_DashMediaId"));

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
OnDataRequested(new ItemEventArgs(sm, sc, "Get_By_DashMediaId", rows));
 
            return rows;
             
        
    }
                  
    }
}