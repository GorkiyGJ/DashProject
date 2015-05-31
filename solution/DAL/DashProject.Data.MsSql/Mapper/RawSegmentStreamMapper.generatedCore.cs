using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper
{
    public abstract class RawSegmentStreamMapperBase : DashProject.Data.Providers.RawSegmentStreamProvider
    {
        protected string connectionString;

        public RawSegmentStreamMapperBase()
        {
                
        }
        
        public RawSegmentStreamMapperBase(string connectionString) : this()
        {
            this.connectionString = connectionString;
        }

                
        
        public override List<DashProject.Data.Item.RawSegmentStream> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_SelectTop]" );
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, count, "@RowCount", SqlDbType.Int);

            IDataReader dr = null;
            List<DashProject.Data.Item.RawSegmentStream> rows = null;

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
        
        public override List<DashProject.Data.Item.RawSegmentStream> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_GetPaged]" );

            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, whereClause, "@WhereClause", SqlDbType.VarChar, 2000);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, orderBy, "@OrderBy", SqlDbType.VarChar, 2000);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, pageIndex, "@PageIndex", SqlDbType.Int);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, pageSize, "@PageSize", SqlDbType.Int);

            IDataReader dr = null;
            List<DashProject.Data.Item.RawSegmentStream> rows = null;

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

        public override bool Insert(SessionManager sm, DashProject.Data.Item.RawSegmentStream item)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_Insert]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddOutParametr(sc, item.Id, "@Id", SqlDbType.BigInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.SegmentId, "@SegmentId", SqlDbType.BigInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.MediaId, "@MediaId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.StreamId, "@StreamId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.FileName, "@FileName", SqlDbType.NVarChar);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DurationS, "@DurationS", SqlDbType.Decimal);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.GlobalStartTimeS, "@GlobalStartTimeS", SqlDbType.Decimal);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.GlobalEndTimeS, "@GlobalEndTimeS", SqlDbType.Decimal);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DateTimeCreated, "@DateTimeCreated", SqlDbType.DateTime);


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

        item.Id = (System.Int64)sc.Parameters["@Id"].Value;
            

            OnDataRequested(new ItemEventArgs(sm, sc, "Insert", item));

            return Convert.ToBoolean(result);
        }
        public override bool Update(SessionManager sm, DashProject.Data.Item.RawSegmentStream item )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_Update]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Id, "@Id", SqlDbType.BigInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.SegmentId, "@SegmentId", SqlDbType.BigInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.MediaId, "@MediaId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.StreamId, "@StreamId", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.FileName, "@FileName", SqlDbType.NVarChar);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DurationS, "@DurationS", SqlDbType.Decimal);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.GlobalStartTimeS, "@GlobalStartTimeS", SqlDbType.Decimal);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.GlobalEndTimeS, "@GlobalEndTimeS", SqlDbType.Decimal);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.DateTimeCreated, "@DateTimeCreated", SqlDbType.DateTime);

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

        public override bool Delete(SessionManager sm, DashProject.Data.Item.RawSegmentStream item)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_Delete]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Id, "@Id", SqlDbType.BigInt);

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
    public override DashProject.Data.Item.RawSegmentStream GetById(Manitou.Data.Provider.SessionManager sm, System.Int64 Id )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_GetById]" );
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, Id, "@Id", SqlDbType.BigInt);
            
            IDataReader dr = null;
            DashProject.Data.Item.RawSegmentStream row = null;

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
    
    ///
    /// Fetch first N ordered records 
    public override DashProject.Data.Item.RawSegmentStream GetByIdMediaIdSegmentIdStreamIdFileName(Manitou.Data.Provider.SessionManager sm, System.Int64 Id, System.Int32 MediaId, System.Int64 SegmentId, System.Int32 StreamId, System.String FileName )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_RawSegmentStream_GetByIdMediaIdSegmentIdStreamIdFileName]" );
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, Id, "@Id", SqlDbType.BigInt);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, MediaId, "@MediaId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, SegmentId, "@SegmentId", SqlDbType.BigInt);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, StreamId, "@StreamId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, FileName, "@FileName", SqlDbType.NVarChar);
            
            IDataReader dr = null;
            DashProject.Data.Item.RawSegmentStream row = null;

            OnDataRequesting(new ItemEventArgs(sm, sc, "GetByIdMediaIdSegmentIdStreamIdFileName"));

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

            OnDataRequested(new ItemEventArgs(sm, sc, "GetByIdMediaIdSegmentIdStreamIdFileName", row));

            return row;
        }                

 
    
    public override void Get_GlobalEndTimeS_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Decimal? GlobalEndTimeS)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[_RawSegmentStream_Get_GlobalEndTimeS_By_DashMediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashMediaId, "DashMediaId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, GlobalEndTimeS, "GlobalEndTimeS", SqlDbType.Decimal, ParameterDirection.Output);

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_GlobalEndTimeS_By_DashMediaId"));

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
GlobalEndTimeS = Manitou.Helper.SqlUtils.GetParameterValue<System.Decimal?>(sc.Parameters["@GlobalEndTimeS"].Value);
OnDataRequested(new ItemEventArgs(sm, sc, "Get_GlobalEndTimeS_By_DashMediaId"));
             
        
    }
    
    public override void Get_GlobalStartTimeS_By_DashMediaId(Manitou.Data.Provider.SessionManager sm , System.Int32? DashMediaId, ref System.Decimal? GlobalStartTimeS)
    {
        sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

        SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[_RawSegmentStream_Get_GlobalStartTimeS_By_DashMediaId]" );        
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, DashMediaId, "DashMediaId", SqlDbType.Int);
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, GlobalStartTimeS, "GlobalStartTimeS", SqlDbType.Decimal, ParameterDirection.Output);

            OnDataRequesting(new ItemEventArgs(sm, sc, "Get_GlobalStartTimeS_By_DashMediaId"));

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
GlobalStartTimeS = Manitou.Helper.SqlUtils.GetParameterValue<System.Decimal?>(sc.Parameters["@GlobalStartTimeS"].Value);
OnDataRequested(new ItemEventArgs(sm, sc, "Get_GlobalStartTimeS_By_DashMediaId"));
             
        
    }
     
    }
}