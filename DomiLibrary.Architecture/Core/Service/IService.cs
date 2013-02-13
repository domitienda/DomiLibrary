using NHibernate;

namespace DomiLibrary.Architecture.Core.Service
{
    /// <summary>
    /// Interface que nos ayuda a saber si una clase es un Servicio.
    /// </summary>
    public interface IService
    {
        /// <summary>
        /// Propiedad que contiene la factoría de la sesión.
        /// </summary>
        ISessionFactory SessionFactory { get; set; }
    }
}
