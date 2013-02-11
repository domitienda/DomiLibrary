using System;
using System.Runtime.Remoting.Activation;
using System.Runtime.Remoting.Contexts;

namespace DomiLibrary.Utility.Aop.Attributes.Interceptors
{
    /// <summary>
    /// Clase que decora la clase InterceptableObject
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    internal sealed class InterceptContextAttribute : ContextAttribute
    {
        #region Constructor

        public InterceptContextAttribute() : base(Guid.NewGuid().ToString()) { }

        #endregion

        #region Methods

        public override void Freeze(Context newContext) { }
        
        public override void GetPropertiesForNewContext(IConstructionCallMessage ctorMsg)
        {
            ctorMsg.ContextProperties.Add(new InterceptProperty(Name));
        }
                
        public override bool IsContextOK(Context ctx, IConstructionCallMessage ctorMsg)
        {
            return (ctx.GetProperty(Name) as InterceptProperty) != null;
        }
        
        public override bool IsNewContextOK(Context newCtx)
        {
            return (newCtx != null) && (newCtx.GetProperty(Name) as InterceptProperty) != null;
        }

        #endregion
    }
}
