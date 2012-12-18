using System.Runtime.Remoting.Messaging;
using DomiLibrary.Utility.Aop.Attributes.Interceptors;

namespace DomiLibrary.Utility.Aop.Attributes.Exception
{
    /// <summary>
    /// Clase que maneja la excepcion implementando la interfaz IHandler
    /// </summary>
    public class ExceptionHandler : IHandler
    {
        #region Methods

        public virtual void ManageProcess(IMethodReturnMessage returnMessage, InterceptableAttribute processable)
        {
            throw returnMessage.Exception;
        }

        #endregion
    }
}
