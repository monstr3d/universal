
namespace ErrorHandler
{
    /// <summary>
    /// Pure exception handler
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        /// Handles an exception
        /// </summary>
        /// <typeparam name="T">Type of exception</typeparam>
        /// <param name="exception">The exception</param>
        void HandleException<T>(T exception, params object[] ? obj) where T : Exception;

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        void Log(string message, params object[] ? obj);

    }

    /// <summary>
    /// Parametrized exception handler
    /// </summary>
    /// <typeparam name="T">Type of exception</typeparam>
    public interface IExceptionHandler<T> where T : Exception
    {
        void Handle(T exception, params object[]? obj);
    }
}
    /// <summary>
    /// The error handler
    /// </summary>
/*    public interface IErrorHandler
    {
        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <param name="obj">Attached object</param>
        void ShowError(Exception exception, object? obj);

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        void ShowMessage(string message, object? obj);
    }*/
    /*
    public class FileSystemExceptionHandler : IExceptionHandler,
    IExceptionHandler<Exception>,
    IExceptionHandler<IOException>,
    IExceptionHandler<FileNotFoundException>
    {
        public void HandleException<T>(T exception) where T : Exception
        {
            var handler = this as IExceptionHandler<T>;
            if (handler != null)
                handler.Handle(exception);
            else
                this.Handle((dynamic)exception);
        }

        public void Handle(Exception exception)
        {
            OnFallback(exception);
        }

        protected virtual void OnFallback(Exception exception)
        {
            // rest of implementation
            Console.WriteLine("Fallback: {0}", exception.GetType().Name);
        }

        public void Handle(IOException exception)
        {
            // rest of implementation
            Console.WriteLine("IO spec");
        }

        public void Handle(FileNotFoundException exception)
        {
            // rest of implementation
            Console.WriteLine("FileNotFoundException spec");
        }
 
    }
}
*/

