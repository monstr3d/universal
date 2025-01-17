using System;
using System.Collections.Generic;

using ErrorHandler;

namespace DataPerformer.TestInterface
{
    /// <summary>
    /// Test error handler for data performer
    /// </summary>
    public class DataPerformerTestEventHandler : IErrorHandler
    {

        #region Fields

        public static readonly IErrorHandler Singleton = new DataPerformerTestEventHandler();

 


        private static readonly Dictionary<Type, Action<Exception, object>> exceptionTypes = new Dictionary<Type, Action<Exception, object>>()
        {
           { typeof(System.Runtime.Serialization.SerializationException), Serialization}
        };

        #endregion

        #region Ctor

        private DataPerformerTestEventHandler()
        {
        }

        #endregion

        #region IErrorHandler Members

        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            int level = -1;
            if (obj != null)
            {
                if (obj.GetType().Equals(typeof(int)))
                {
                    level = (int)obj;
                }
            }
            if (level < 0)
            {
                return;
            }
            Type t = exception.GetType();
            if (exceptionTypes.ContainsKey(t))
            {
                exceptionTypes[t](exception, obj);
                return;
            }
            throw exception;
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
        }

        #endregion

        #region Exception Event Handlers

        private static void Serialization(Exception e, object o)
        {
            System.Runtime.Serialization.SerializationException se = e as
                System.Runtime.Serialization.SerializationException;
            if (se.Message.Contains("Comments"))
            {
                return;
            }
         }

        #endregion

    }
}
