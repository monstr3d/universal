
namespace ErrorHandler
{
    public class FictiveException : Exception
    {
        [FictionException()]
        public FictiveException(string message) : base(message)
        {

        }
    }
}
