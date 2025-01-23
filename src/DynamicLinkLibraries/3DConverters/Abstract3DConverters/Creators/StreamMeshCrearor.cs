using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ErrorHandler;

namespace Abstract3DConverters.Creators
{
    public abstract class StreamMeshCrearor : AbstractMeshCreator
    {

        protected StreamMeshCrearor(string filename,  byte[] bytes)
        {
            if (StaticExtensionAbstract3DConverters.UseDirectory)
            {
                if (File.Exists(filename))
                {
                    directory = Path.GetDirectoryName(filename);
                    this.filename = filename;
                }
            }
            ext = Path.GetExtension(filename);
            Load(bytes);
        }
     }
}
