using ErrorHandler;

namespace Abstract3DConverters.ErrorHandlers
{
    public class TextWiterErrorHandler :  IExceptionHandler
    {
        TextWriter writer;

        Action<Exception, TextWriter> stop;

        public TextWiterErrorHandler(TextWriter writer, Action<Exception, TextWriter> stop = null)
        {
            this.writer = writer;
            this.stop = stop;
        }

        void IExceptionHandler.HandleException<T>(T exception, object? obj)
        {
            if (Check(obj))
            {
                writer.WriteLine(exception.Message);
                stop?.Invoke(exception, writer);
               
            }
        }

        void IExceptionHandler.ShowMessage(string message, object? obj)
        {
            if (Check(obj))
            {
                writer.WriteLine(message);
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
    }
}
