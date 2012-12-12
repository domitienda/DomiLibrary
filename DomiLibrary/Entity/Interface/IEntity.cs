namespace DomiLibrary.Entity.Interface
{
    /// <summary>
    /// Interface que decora las entidades de negocio.
    /// </summary>
    public interface IEntity
    {}

    /// <summary>
    /// Interface que decora la entidad de negocio con un tipo para su Id específico.
    /// </summary>
    /// <typeparam name="TK"></typeparam>
    public interface IEntity<TK> : IEntity
    {
        TK Id { get; set; }
    }
}
