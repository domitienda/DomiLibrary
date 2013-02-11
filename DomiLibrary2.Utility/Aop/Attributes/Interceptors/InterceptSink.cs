using System;
using System.Runtime.Remoting.Messaging;

namespace DomiLibrary.Utility.Aop.Attributes.Interceptors
{
    internal class InterceptSink : IMessageSink
    {
        #region Properties

        private readonly IMessageSink _nextSink;
        
        private static readonly object SyncRoot = new Object();

        public IMessageSink NextSink
        {
            get { return _nextSink; }
        }

        #endregion

        #region Constructor

        public InterceptSink(IMessageSink nextSink)
        {
            lock (SyncRoot)
            {
                _nextSink = nextSink;
            }
        }

        #endregion

        #region Methods

        public IMessageCtrl AsyncProcessMessage(IMessage msg, IMessageSink replySink)
        {
            return _nextSink.AsyncProcessMessage(msg, replySink);
        }

        public IMessage SyncProcessMessage(IMessage msg)
        {
            var callMessage = (msg as IMethodCallMessage);

            if (callMessage != null)
            {
                var processables = (InterceptableAttribute[])(msg as IMethodMessage).MethodBase.GetCustomAttributes(typeof(InterceptableAttribute), true);

                Array.Sort(processables, (a, b) => a.Priority.CompareTo(b.Priority));
                
                var returnMessage = (_nextSink.SyncProcessMessage(callMessage) as IMethodReturnMessage);

                if (returnMessage != null)
                {
                    foreach (var process in processables)
                    {
                        process.Handler.ManageProcess(returnMessage, process);
                    }

                    return returnMessage;
                }
            }

            return msg;
        }

        #endregion
    }
}
