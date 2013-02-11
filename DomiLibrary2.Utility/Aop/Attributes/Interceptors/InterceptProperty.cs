using System.Runtime.Remoting.Contexts;
using System.Runtime.Remoting.Messaging;

namespace DomiLibrary.Utility.Aop.Attributes.Interceptors
{
    /// <summary>
    /// Clase que intercepta la propiedad
    /// </summary>
    internal class InterceptProperty : IContextProperty, IContributeClientContextSink, IContributeServerContextSink
    {
        #region Properties

        public string Name { get; set; }

        #endregion

        #region Constructor

        public InterceptProperty(string name) : base()
        {
            Name = name;
        }

        #endregion

        #region Methods

        public void Freeze(Context newContext) { }

        public bool IsNewContextOK(Context newCtx)
        {
            return (newCtx != null) && (newCtx.GetProperty(Name) as InterceptProperty) != null;
        }
        
        public IMessageSink GetClientContextSink(IMessageSink nextSink)
        {
            return new InterceptSink(nextSink);
        }
        
        public IMessageSink GetServerContextSink(IMessageSink nextSink)
        {
            return new InterceptSink(nextSink);
        }

        #endregion
    }
}
