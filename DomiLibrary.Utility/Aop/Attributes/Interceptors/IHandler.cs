using System.Runtime.Remoting.Messaging;

namespace DomiLibrary.Utility.Aop.Attributes.Interceptors
{
    /// <summary>
    /// Interfaz que define el metodo que contendrá la lógica que se aplicara tras interceptar el metodo/atributo
    /// </summary>
    public interface IHandler
    {
        /// <summary>
        /// Método que contiene la logica de proceso tras interceptar el metodo/atributo
        /// </summary>
        /// <param name="returnMessage"></param>
        /// <param name="processable"></param>
        void ManageProcess(IMethodReturnMessage returnMessage, InterceptableAttribute processable);
    }
}
