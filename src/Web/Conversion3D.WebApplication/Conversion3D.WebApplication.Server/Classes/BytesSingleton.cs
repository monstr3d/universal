using Conversion3D.WebApplication.Server.Interfaces;

namespace Conversion3D.WebApplication.Server.Classes
{
    public class BytesSingleton : IBytesSingleton
    {
        public BytesSingleton()
        {

        }

        public Tuple<byte[], string, string> Tuple { get ; set; }
    }
}
