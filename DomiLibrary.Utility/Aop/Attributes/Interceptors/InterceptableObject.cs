using System;

namespace DomiLibrary.Utility.Aop.Attributes.Interceptors
{
    /// <summary>
    /// Toda clase que quiera utilizar el AOP por atributo deberá de heredar de esta clase.
    /// </summary>
    [InterceptContextAttribute]
    public abstract class InterceptableObject : ContextBoundObject
    {
    }
}
