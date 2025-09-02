using ErrorHandler;

namespace Abstract3DConverters.ConsoleTest
{
    internal class ConsoleExceptionHandler : IExceptionHandler
    {
        void IExceptionHandler.HandleException<T>(T exception, params object[] obj)
        {
            if (exception.IsFiction())
            {
                return;
            }
            Console.WriteLine("++++++ERROR+++++++++");
            Console.WriteLine(exception.Message);
            Console.WriteLine();
        }

        void IExceptionHandler.Log(string message, params object[] obj)
        {
            Console.WriteLine("+++++++MESSAGE++++++++");
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
