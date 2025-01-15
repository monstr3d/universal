using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters.Creators
{
    public abstract class StreamMeshCrearor : AbstractMeshCreator
    {

        protected StreamMeshCrearor(string filename, Stream stream)
        {
            if (File.Exists(filename))
            {
                directory = Path.GetDirectoryName(filename);
                this.filename = filename;
            }
            ext = Path.GetExtension(filename);
            Load(stream);
        }
     }
}
