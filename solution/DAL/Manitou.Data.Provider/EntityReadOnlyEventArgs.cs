using System;
using System.Collections.Generic;
using System.Collections;


namespace Manitou.Data.Provider
{
    public class EntityReadOnlyEventArgs
    {        
        #region Constructor
        private EntityReadOnlyEventArgs() 
        {
        }

        public EntityReadOnlyEventArgs(SessionManager session, string methodName, Data.Item.Base.IBaseItem item, IList list)
            : this()
        {
            Session = session;
            MethodName = methodName;
            CurrentItem = item;
            CurrentListItem = list;
        }

        public EntityReadOnlyEventArgs(SessionManager session, string methodName, IList list)
            : this(session, methodName, null, list)
        { 
        }

        public EntityReadOnlyEventArgs(SessionManager session, string methodName)
            : this(session, methodName, null, null)
        { 
        }

        public EntityReadOnlyEventArgs(SessionManager session, string methodName, Data.Item.Base.IBaseItem item)
            : this(session, methodName, item, null)
        { 
        }
        #endregion 

        #region Properties

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
