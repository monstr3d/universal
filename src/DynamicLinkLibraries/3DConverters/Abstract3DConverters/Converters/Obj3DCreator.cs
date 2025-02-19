using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;

namespace Abstract3DConverters.Converters
{
    [Converter(".obj")]
    public abstract class Obj3DCreator : LinesMeshConverter
    {
        protected Obj3DCreator(IMaterialCreator materialCreator) : base(materialCreator)
        {

        }
    }
}
