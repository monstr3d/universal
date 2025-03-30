using Conversion3D.WebApplication.Interfacers;

namespace Conversion3D.WebApplication.Classes
{
    public class BytesSingleton : IBytesSingleton
    {
        public BytesSingleton()
        {

        }

        public Tuple<byte[], string, string> Tuple { get ; set; }
    }
}
