using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using DashProject.Data.Item;
using Manitou.Data.Provider;

namespace DashProject.Data.MsSql.Mapper
{
    public abstract class VideoSizeMapperBase : DashProject.Data.Providers.VideoSizeProvider
    {
        protected string connectionString;

        public VideoSizeMapperBase()
        {
                
        }
        
        public VideoSizeMapperBase(string connectionString) : this()
        {
            this.connectionString = connectionString;
        }

                
        
        public override List<DashProject.Data.Item.VideoSize> GetList(Manitou.Data.Provider.SessionManager sm, int count)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_VideoSize_SelectTop]" );
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, count, "@RowCount", SqlDbType.Int);

            IDataReader dr = null;
            List<DashProject.Data.Item.VideoSize> rows = null;

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
        
        public override List<DashProject.Data.Item.VideoSize> GetPaged(Manitou.Data.Provider.SessionManager sm, string whereClause, string orderBy, int pageIndex, int pageSize, out int count)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_VideoSize_GetPaged]" );

            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, whereClause, "@WhereClause", SqlDbType.VarChar, 2000);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, orderBy, "@OrderBy", SqlDbType.VarChar, 2000);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, pageIndex, "@PageIndex", SqlDbType.Int);
            Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, pageSize, "@PageSize", SqlDbType.Int);

            IDataReader dr = null;
            List<DashProject.Data.Item.VideoSize> rows = null;

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

        public override bool Insert(SessionManager sm, DashProject.Data.Item.VideoSize item)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_VideoSize_Insert]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddOutParametr(sc, item.Id, "@Id", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Name, "@Name", SqlDbType.NVarChar);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Width, "@Width", SqlDbType.SmallInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Height, "@Height", SqlDbType.SmallInt);


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
        public override bool Update(SessionManager sm, DashProject.Data.Item.VideoSize item )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_VideoSize_Update]");

        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Id, "@Id", SqlDbType.Int);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Name, "@Name", SqlDbType.NVarChar);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Width, "@Width", SqlDbType.SmallInt);
        Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, item.Height, "@Height", SqlDbType.SmallInt);

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

        public override bool Delete(SessionManager sm, DashProject.Data.Item.VideoSize item)
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_VideoSize_Delete]");

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
    public override DashProject.Data.Item.VideoSize GetById(Manitou.Data.Provider.SessionManager sm, System.Int32 Id )
        {
            sm = Manitou.Data.MsSql.Helper.DbConnectionUtils.GetConnection(connectionString, sm);

            SqlCommand sc = Manitou.Data.MsSql.Helper.DbCommandUtils.GetCommand(sm, "[dbo].[i_VideoSize_GetById]" );
Manitou.Data.MsSql.Helper.DbParameterUtils.AddParametr(sc, Id, "@Id", SqlDbType.Int);
            
            IDataReader dr = null;
            DashProject.Data.Item.VideoSize row = null;

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

 
     
    }
}