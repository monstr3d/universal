using OnlineGameConverter.Server.Interfaces;

namespace OnlineGameConverter.Server.Classes
{
    public class BytesSingleton : IBytesSingleton
    {
        public BytesSingleton()
        {

        }

        public Tuple<byte[], string, string> Tuple { get ; set; }
    }
}
