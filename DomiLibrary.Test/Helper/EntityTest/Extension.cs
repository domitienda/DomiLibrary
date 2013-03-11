namespace DomiLibrary.Test.Helper.EntityTest
{
    public class Extension
    {
        public int Id { get; set; }

        public string Nombre { get; set; }

        public Extension(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        protected bool Equals(Extension entity)
        {
            if (entity == null) return false;
            if (!Equals(Id, entity.Id)) return false;
            return true;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj)) return true;
            return Equals(obj as Extension);
        }

        public override int GetHashCode()
        {
            var result = base.GetHashCode();
            result = 29 * result + Id.GetHashCode();
            return result;
        }
    }
}
