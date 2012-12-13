using System;
using DomiLibrary.Entity.Interface;
using System.Runtime.Serialization;

namespace DomiLibrary.Entity.Generic
{
    [Serializable]
    public class GenericBaseEntity<TKEY> : IEntity<TKEY>, IComparable<GenericBaseEntity<TKEY>>
    {
        protected TKEY _Id;

        [DataMember(EmitDefaultValue = false)]
        public virtual TKEY Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        
        protected bool Equals(GenericBaseEntity<TKEY> entity)
        {
            if (entity == null) return false;
            if (GetType() != entity.GetType())
                return false;
            return _Id.Equals(entity.Id);
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            return Equals(obj as GenericBaseEntity<TKEY>);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 29 * result + (_Id != null ? _Id.GetHashCode() : 0);
            return result;
        }

        #region Miembros de IComparable<GenericEntity>

        public virtual int CompareTo(GenericBaseEntity<TKEY> other)
        {
            return other.Id.GetHashCode().CompareTo(Id.GetHashCode());
        }

        #endregion
    }
}
