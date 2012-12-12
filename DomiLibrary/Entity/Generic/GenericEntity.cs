using System;

namespace DomiLibrary.Entity.Generic
{
    [Serializable]
    public class GenericEntity : GenericBaseEntity<Int32>, IComparable<GenericEntity>
    {
        protected bool Equals(GenericEntity entity)
        {
            if (entity == null) return false;
            if (!Equals(Id, entity.Id)) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as GenericEntity);
        }

        public override int GetHashCode()
        {
            var result = base.GetHashCode();
            result = 29 * result + _Id.GetHashCode();
            return result;
        }

        public virtual object Clone()
        {
            return MemberwiseClone();
        }

        #region Miembros de IComparable<GenericEntity>

        public virtual int CompareTo(GenericEntity other)
        {
            return other.Id.CompareTo(Id);
        }

        #endregion
    }
}
