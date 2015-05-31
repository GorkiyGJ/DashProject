using System;
using System.Collections.Generic;
using System.Collections;

namespace Manitou.Data.Provider
{
    public class ItemEventArgs
    {
        #region Constructor
        private ItemEventArgs() 
        {
        }

        public ItemEventArgs(SessionManager session, System.Data.Common.DbCommand command, string methodName, Data.Item.Base.IBaseItem item, IList list)
            : this()
        {
            Session = session;
            Command = command;
            MethodName = methodName;
            CurrentItem = item;
            CurrentListItem = list;
        }

        public ItemEventArgs(SessionManager session, System.Data.Common.DbCommand command, string methodName, IList list)
            : this(session, command, methodName, null, list)
        { 
        }

        public ItemEventArgs(SessionManager session, System.Data.Common.DbCommand command, string methodName)
            : this(session, command, methodName, null, null)
        { 
        }

        public ItemEventArgs(SessionManager session, System.Data.Common.DbCommand command, string methodName, Data.Item.Base.IBaseItem item)
            : this(session, command, methodName, item, null)
        { 
        }
        #endregion 

        #region Properties
        private System.Data.Common.DbCommand _command;
        public System.Data.Common.DbCommand Command
        {
            get { return _command; }
            set { _command = value; }
        }

        public SessionManager _session;
        public SessionManager Session
        {
            get { return _session; }
            set { _session = value; }
        }

        private string _methodName = null;
        public string MethodName
        {
            get { return _methodName; }
            set { _methodName = value; }
        }

        private Data.Item.Base.IBaseItem _currentItem = null;
        public Data.Item.Base.IBaseItem CurrentItem
        {
            get { return _currentItem; }
            set { _currentItem = value; }
        }

        private IList _currentListItem = null;
        public IList CurrentListItem
        {
            get { return _currentListItem; }
            set { _currentListItem = value; }
        }
        #endregion 
    }
}
