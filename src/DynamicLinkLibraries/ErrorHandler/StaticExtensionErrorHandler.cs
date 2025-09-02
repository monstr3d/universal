using System.Reflection;

namespace ErrorHandler
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionErrorHandler
    {


        /// <summary>
        /// Empty handles exception for debug
        /// </summary>
        static void HandleException()
        {

        }

        #region Fields

        static Guid Fiction = Guid.Parse("84943245-0934-4AF0-8F51-DDE2FB42D2DC");


        /// <summary>
        /// Error handler
        /// </summary>
        static IExceptionHandler? exceptionHandler = null;

        

        #endregion

        #region Members

        /// <summary>
        /// Sets error handler
        /// </summary>
        /// <param name="handler">The error handler</param>
        public static void Set(this IExceptionHandler handler)
        {
            exceptionHandler = handler;
        }

        /// <summary>
        /// Error handler
        /// </summary>
        public static IExceptionHandler? ErrorHandler => exceptionHandler;

        /// <summary>
        /// Shows exception (extension method)
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void HandleException(this Exception exception, params object[] obj)
        {
            HandleException();
            if (!exception.IsFiction(obj))
            {

            }
            exceptionHandler?.HandleException(exception, obj);
        }

        /// <summary>
        /// Shows exception (extension method)
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void HandleFictionException(this Exception exception)
        {
            HandleException();
            exceptionHandler?.HandleException(exception, Fiction);
        }

        private static T GetAttribute<T>(object obj) where T : Attribute
        {
            if (obj == null)
            {
                return null;
            }
            Type type = (obj is Type) ? obj as Type : obj.GetType();
#pragma warning disable CS8603 // Possible null reference return.
#pragma warning disable CS8604 // Possible null reference argument.
            var ti = IntrospectionExtensions.GetTypeInfo(type);
            var at = CustomAttributeExtensions.GetCustomAttribute<T>(ti);
            return at;
           
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8603 // Possible null reference return.
        }


        public static bool IsFiction(this Exception exception, params object[] obj)
        {
            if (obj != null)
            {
                if (obj.Length == 1)
                {

                    if (obj[0].Equals(Fiction))
                    {
                        return true;
                    }
                }
            }
            var at = GetAttribute<FictionExceptionAttribute>(exception);
            return exception is IFictionException;
        }

        /// <summary>
        /// Shows exception double
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        static public void HandleExceptionDouble(this Exception exception, params object[] obj)
        {
            HandleException();
            exceptionHandler?.HandleException(exception, obj);
            throw IncludedException.Get(exception, GetErrorString(obj));
        }

        /// <summary>
        /// Gets error string
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>Error string</returns>
        public static string GetErrorString(params object[] obj)
        {
            var s = "";
            foreach (var item in obj)
            {
                s += item.ToString() + " ";
            }
            return s;
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        static public void Log(this string message, params object[] obj)
        {
            HandleException();
            exceptionHandler?.Log(message, obj);
        }

        #endregion
    }
}