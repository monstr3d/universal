using ErrorHandler;

namespace Abstract3DConverters.ConsoleTest
{
    internal class ConsoleExceptionHandler : IExceptionHandler
    {
        void IExceptionHandler.HandleException<T>(T exception, object? obj)
        {
            Console.WriteLine("++++++ERROR+++++++++");
            Console.WriteLine(exception.Message);
            Console.WriteLine();
        }

        void IExceptionHandler.Log(string message, object? obj)
        {
            Console.WriteLine("+++++++MESSAGE++++++++");
            Console.WriteLine(message);
            Console.WriteLine();
        }
    }
}
