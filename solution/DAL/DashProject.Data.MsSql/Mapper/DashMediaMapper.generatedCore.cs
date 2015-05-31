using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper
{
    public abstract class DashMediaMapperBase : DashProject.Data.Providers.DashMediaProvider
    {
        protected string connectionString;

        public DashMediaMapperBase()
        {
                
        }
        
        public DashMediaMapperBase(string connectionString) : this()
        {
            this.connectionString = connectionString;
        }

                
        
        public override List<DashProject.Data.Item.DashMedia> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_DashMedia_SelectTop]" );
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, count, "@RowCount", SqlDbType.Int);

            IDataReader dr = null;
            List<DashProject.Data.Item.DashMedia> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "GetList"));

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

            OnDataRequested(new ItemEventArgs(sm, sc, "GetList", rows));

            return rows;
        }
        
        public override List<DashProject.Data.Item.DashMedia> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_DashMedia_GetPaged]" );

            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, whereClause, "@WhereClause", SqlDbType.VarChar, 2000);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, orderBy, "@OrderBy", SqlDbType.VarChar, 2000);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, pageIndex, "@PageIndex", SqlDbType.Int);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, pageSize, "@PageSize", SqlDbType.Int);

            IDataReader dr = null;
            List<DashProject.Data.Item.DashMedia> rows = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "GetPaged"));

            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                dr = Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteReader(sc);

                rows = Fill(dr);                
                if(rows != null)              
                    count = rows.Count;
                else
                    count = 0;

				if(dr.NextResult())
				{
					if(dr.Read())
					{
						count = dr.GetInt32(0);
					}
				}
            }
            finally
            {
                if (dr != null)
                    dr.Close();

                if (!sm.IsTransactionOpen)
                    sm.Close();
            }

            OnDataRequested(new ItemEventArgs(sm, sc, "GetPaged", rows));

            return rows;
        }        

        public override bool Insert(SessionManager sm, DashProject.Data.Item.DashMedia item)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_DashMedia_Insert]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddOutParametr(sc, item.Id, "@Id", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.MediaId, "@MediaId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.StreamId, "@StreamId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DashInitSegmentId, "@DashInitSegmentId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DashTypeId, "@DashTypeId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.CodecTypeId, "@CodecTypeId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Width, "@Width", SqlDbType.SmallInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Height, "@Height", SqlDbType.SmallInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Channels, "@Channels", SqlDbType.TinyInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.BitrateKbps, "@BitrateKbps", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.IsActive, "@IsActive", SqlDbType.Bit);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.FragmentDurationS, "@FragmentDurationS", SqlDbType.Int);


            OnDataRequesting(new ItemEventArgs(sm, sc, "Insert"));

            int result = 0;
            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                result = Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteNonQuery(sc);
            }
            finally
            {
                if (!sm.IsTransactionOpen)
                    sm.Close();
            }

        item.Id = (System.Int32)sc.Parameters["@Id"].Value;
            

            OnDataRequested(new ItemEventArgs(sm, sc, "Insert", item));

            return Convert.ToBoolean(result);
        }
        public override bool Update(SessionManager sm, DashProject.Data.Item.DashMedia item )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_DashMedia_Update]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Id, "@Id", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.MediaId, "@MediaId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.StreamId, "@StreamId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DashInitSegmentId, "@DashInitSegmentId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DashTypeId, "@DashTypeId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.CodecTypeId, "@CodecTypeId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Width, "@Width", SqlDbType.SmallInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Height, "@Height", SqlDbType.SmallInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Channels, "@Channels", SqlDbType.TinyInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.BitrateKbps, "@BitrateKbps", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.IsActive, "@IsActive", SqlDbType.Bit);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.FragmentDurationS, "@FragmentDurationS", SqlDbType.Int);

            OnDataRequesting(new ItemEventArgs(sm, sc, "Update"));

            int result = 0;
            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                result = Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteNonQuery(sc);
            }
            finally
            {
                if (!sm.IsTransactionOpen)
                    sm.Close();
            }

            OnDataRequested(new ItemEventArgs(sm, sc, "Update", item));

            return Convert.ToBoolean(result);
        }

        public override bool Delete(SessionManager sm, DashProject.Data.Item.DashMedia item)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_DashMedia_Delete]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Id, "@Id", SqlDbType.Int);

            OnDataRequesting(new ItemEventArgs(sm, sc, "Delete"));
            
            int result = 0;
            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                result = Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteNonQuery(sc);
            }
            finally
            {
                if (!sm.IsTransactionOpen)
                    sm.Close();
            }

            OnDataRequested(new ItemEventArgs(sm, sc, "Delete"));

            return Convert.ToBoolean(result);
        }                                               
     
    

   

     
    ///
    /// Fetch first N ordered records 
    public override DashProject.Data.Item.DashMedia GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_DashMedia_GetById]" );
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, Id, "@Id", SqlDbType.Int);
            
            IDataReader dr = null;
            DashProject.Data.Item.DashMedia row = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "GetById"));

            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                dr = Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteSingleRowReader(sc);

                row = FillItem(dr);
            }
            finally
            {
                if (dr != null)
                    dr.Close();

                if (!sm.IsTransactionOpen)
                    sm.Close();
            }

            OnDataRequested(new ItemEventArgs(sm, sc, "GetById", row));

            return row;
        }                

 
    
    public override void Get_DashType_ById(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Int32? DashTypeId)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[_DashMedia_Get_DashType_By_DashMediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashMediaId, "DashMediaId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashTypeId, "DashTypeId", SqlDbType.Int, ParameterDirection.Output);

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_DashType_ById"));

            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                
Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteNonQuery(sc);
                
            }
            finally
            {
                    
                if (!sm.IsTransactionOpen)
                    sm.Close();
            }                                                                 
DashTypeId = Manitou.Helper.SqlUtils.GetParameterValue<System.Int32?>(sc.Parameters["@DashTypeId"].Value);
OnDataRequested(new ItemEventArgs(sm, sc, "Get_DashType_ById"));
             
        
    }
    
    public override void Get_MediaId_ById(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Int32? MediaId)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[_DashMedia_Get_MediaId_By_DashMediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashMediaId, "DashMediaId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, MediaId, "MediaId", SqlDbType.Int, ParameterDirection.Output);

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_MediaId_ById"));

            try
            {
                Manitou.Data.MsSql.Helper.DbConnectionUtils.Open(sm);
                
Manitou.Data.MsSql.Helper.DbExecuteUtils.ExecuteNonQuery(sc);
                
            }
            finally
            {
                    
                if (!sm.IsTransactionOpen)
                    sm.Close();
            }                                                                 
MediaId = Manitou.Helper.SqlUtils.GetParameterValue<System.Int32?>(sc.Parameters["@MediaId"].Value);
OnDataRequested(new ItemEventArgs(sm, sc, "Get_MediaId_ById"));
             
        
    }
     
    }
}