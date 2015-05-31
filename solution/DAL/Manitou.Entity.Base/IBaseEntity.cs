using System;

namespace Manitou.Entity.Base
{
    public interface IBaseEntity<TKey> : ICloneable, IComparable
     where TKey : IBaseEntityKey, new()
    {
        void AcceptChanges();
        EntityState EntityState { get; set; }
        bool IsDeleted { get; }
        bool IsDirty { get; }
        bool IsNew { get; }
        TKey Key { get; }
    }
}
