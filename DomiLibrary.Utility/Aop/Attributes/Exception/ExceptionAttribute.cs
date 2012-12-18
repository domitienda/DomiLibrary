using System;
using DomiLibrary.Utility.Aop.Attributes.Interceptors;

namespace DomiLibrary.Utility.Aop.Attributes.Exception
{
    /// <summary>
    /// Decora la clase como interceptable para el manejo de excepciones
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ExceptionAttribute : InterceptableAttribute
    {
        #region Methods

        public ExceptionAttribute()
        {
            //Creamos la instancia del manejador de la excepcion
            Handler = Activator.CreateInstance(typeof(ExceptionHandler)) as IHandler;

        }

        #endregion
    }
}
