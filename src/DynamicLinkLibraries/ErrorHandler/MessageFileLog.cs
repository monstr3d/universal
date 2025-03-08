namespace ErrorHandler
{
    public class MessageFileLog : IExceptionHandler, IDisposable
    {

        #region Filds

        List<string> l = new List<string>();

        string filename;


        #endregion

        public MessageFileLog(string filename)
        {
            this.filename = filename;
        }

        void IDisposable.Dispose()
        {
            if (l == null)
            {
                return;
            }
            using var writer = new StreamWriter(filename);
            foreach (var s in l)
            {
                writer.WriteLine(s);
            }
            l = null;
        }


        #region IExceptionHandler Members

        /// <summary>
        /// Handles an exception
        /// </summary>
        /// <typeparam name="T">Type of exception</typeparam>
        /// <param name="exception">The exception</param>
        void IExceptionHandler.HandleException<T>(T exception, object? obj)
        {
        }

        /// <summary>
        /// Shows message
        /// </summary>
        /// <param name="message">The message to show</param>
        /// <param name="obj">Attached object</param>
        void IExceptionHandler.Log(string message, object? obj)
        {
            if (obj != null)
            {
                l.Add(message);
            }
        }

        #endregion


    }
}
