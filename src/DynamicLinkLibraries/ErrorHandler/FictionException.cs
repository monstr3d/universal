
namespace ErrorHandler
{
    public class FictionException : Exception, IFictionException
    {
        [FictionExceptionAttribute()]
        public FictionException(string message) : base(message)
        {

        }
    }
}
