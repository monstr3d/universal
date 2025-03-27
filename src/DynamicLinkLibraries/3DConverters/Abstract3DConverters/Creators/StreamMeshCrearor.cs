using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Abstract3DConverters.Creators
{
    public abstract class StreamMeshCrearor : AbstractMeshCreator
    {

        protected StreamMeshCrearor(string filename,  params object[] objects) : base(filename, objects)
        {
            Load(objects[0] as byte[]);
        }
     }
}
