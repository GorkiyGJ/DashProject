using System;
using System.Text;
using System.Data.Common;
using System.Data;

namespace Manitou.Data.Provider
{
    public class SessionManager : IDisposable
    {
        #region Fields          
        protected string _connectionString;
        protected bool disposed = false;

        protected static object syncRoot = new object();

        #endregion

        #region Properties
        protected bool _isTransactionOpen;
        public bool IsTransactionOpen
        {
            get { return _isTransactionOpen; }
        }
        #endregion

        #region Constructors
        public SessionManager()
        {
            _isTransactionOpen = false;
        }

        public SessionManager(string connectionString)
            : this(connectionString, "System.Data.SqlClient")
        {            
        }

        public SessionManager(string connectionString, string providerName)
            : this()
        {
            this._connectionString = connectionString;

            DbProviderFactory db = DbProviderFactories.GetFactory(providerName);
            _dbConnection = db.CreateConnection();
            _dbConnection.ConnectionString = connectionString;
        }

        public SessionManager(DbCommand dbCommand)
            : this()
        {
            _connectionString = dbCommand.Connection.ConnectionString;

            _dbConnection = dbCommand.Connection;
            _dbTransaction = dbCommand.Transaction;
        }
        #endregion

        #region Properties
        protected DbConnection _dbConnection;
        public DbConnection ConnectionObject
        {
            get { return _dbConnection; }
        }

        protected DbTransaction _dbTransaction;
        public DbTransaction TransactionObject
        {
            get { return _dbTransaction; }
        }
        #endregion

        #region Public methods

        public void Open()
        {
            if(_dbConnection != null && _dbConnection.State != ConnectionState.Open)
                _dbConnection.Open();
        }

        public void Close()
        {
            try
            {
                if(IsTransactionOpen)
                    _dbTransaction.Rollback(); // SqlClient could throw Exception or InvalidOperationException
            }
            finally
            {
                if (_dbConnection != null)
                    _dbConnection.Close();
            }
        }

        public void BeginTransaction()
        {
            BeginTransaction(IsolationLevel.ReadCommitted);
        }

        public void BeginTransaction(IsolationLevel isolationLevel)
        {
            if (IsTransactionOpen)
                throw new InvalidOperationException("Transaction already open.");

            try
            {
                if (_dbConnection.State != ConnectionState.Open)
                    _dbConnection.Open();

                _dbTransaction = _dbConnection.BeginTransaction(isolationLevel);
                _isTransactionOpen = true;
            }
            catch
            {
                _isTransactionOpen = false;

                if (_dbConnection != null)
                    _dbConnection.Close();

                if (_dbTransaction != null)
                    _dbTransaction.Dispose();                
                
                throw;
            }
        }

        public void Commit()
        {
            if (!IsTransactionOpen)
            {
                if (_dbConnection != null)
                    _dbConnection.Close();

                throw new InvalidOperationException("Transaction needs to begin first.");
            }

            try
            {
                _dbTransaction.Commit(); // SqlClient could throw Exception or InvalidOperationException
            }
            finally
            {
                if (_dbConnection != null)
                    _dbConnection.Close();

                if (_dbTransaction != null)
                    _dbTransaction.Dispose();

                _isTransactionOpen = false;
            }
        }

        public void Rollback()
        {
            if (!IsTransactionOpen)
            {
                if (_dbConnection != null)
                    _dbConnection.Close();

                throw new InvalidOperationException("Transaction needs to begin first.");
            }

            try
            {
                _dbTransaction.Rollback(); // SqlClient could throw Exception or InvalidOperationException
            }
            finally
            {
                if (_dbConnection != null)
                    _dbConnection.Close();

                if (_dbTransaction != null)
                    _dbTransaction.Dispose();

                _isTransactionOpen = false;
            }
        }
        #endregion 

        #region IDisposable methods
        public void Dispose()
        {
            if (!disposed)
            {
                lock (syncRoot)
                {
                    disposed = true;

                    if (IsTransactionOpen)
                        this.Rollback();
                    else
                        this.Close();
                }
            }
        }
        #endregion 
    }
}
