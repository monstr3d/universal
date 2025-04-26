

using ErrorHandler;

namespace Abstract3DConverters.ErrorHandlers
{
    public class TextWiterErrorHandler :  ErrorHandler.IExceptionHandler, IDisposable
    {
        TextWriter writer;

        Action<Exception, TextWriter> stop;
        List<string> l = new List<string>();

        public TextWiterErrorHandler(TextWriter writer, Action<Exception, TextWriter> stop = null)
        {
            this.writer = writer;
            this.stop = stop;
        }

        void IExceptionHandler.HandleException<T>(T exception, params object[]? obj)
        {
            if (exception.IsFiction())
            {
                return;
            }
            if (Check(obj))
            {
                l.Add(exception.Message);
                stop?.Invoke(exception, writer);
            }
        }

        void ErrorHandler.IExceptionHandler.Log(string message, params object[]? obj)
        {
            if (Check(obj))
            {
                l.Add(message);
            }
        }

        bool Check(object obj)
        {
            if (obj != null)
            {
                if (obj.GetType() == typeof(int))
                {
                    int i = (int)obj;
                    return i >= 0;
                }
            }
            return true;
        }

        void IDisposable.Dispose()
        {
            foreach (var s in l)
            {
                writer.WriteLine(s);
            }
            writer.Flush();
            writer.Dispose();
        }
    }
}
