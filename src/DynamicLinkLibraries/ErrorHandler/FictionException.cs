
namespace ErrorHandler
{
    public class FictionException : Exception, IFictionException
    {
        [FictionException()]
        public FictionException(string message) : base(message)
        {

        }
    }
}
