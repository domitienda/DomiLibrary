using System;

namespace DomiLibrary.Utility.Aop.Attributes.Interceptors
{
    /// <summary>
    /// Decora la clase como interceptable
    /// </summary>
    public abstract class InterceptableAttribute : Attribute
    {
        #region Properties

        /// <summary>
        /// Manejador
        /// </summary>
        public IHandler Handler { get; set; }

        /// <summary>
        /// Prioridad
        /// </summary>
        public int Priority { get; set; }

        #endregion
    }
}
