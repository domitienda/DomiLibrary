using System;

namespace DomiLibrary.Utility.GenericException
{
    /// <summary>
    /// Excepcion de negocio
    /// </summary>
    public class BusinessException : Exception
    {
        public BusinessException()
        {
        }

        public BusinessException(string message) : base(message)
        {
        }

        public BusinessException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
