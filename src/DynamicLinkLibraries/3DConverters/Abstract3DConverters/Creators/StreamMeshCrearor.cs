using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Abstract3DConverters.Creators
{
    public abstract class StreamMeshCrearor : AbstractMeshCreator
    {

        protected StreamMeshCrearor(string filename,  byte[] bytes) : base(filename)
        {
            if (true | StaticExtensionAbstract3DConverters.UseDirectory)
            {
                if (s.FileExists(filename))
                {
                    directory = Path.GetDirectoryName(filename);
                }
            }
            ext = Path.GetExtension(filename);
            Load(bytes);
        }
     }
}
