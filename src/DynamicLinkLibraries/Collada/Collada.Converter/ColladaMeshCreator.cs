using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Abstract3DConverters;

namespace Collada.Converter
{
    public abstract class ColladaMeshCreator : AbstractMaterialCreator
    {
        private Collada141.COLLADA collada;
        public ColladaMeshCreator()
        {
            collada = new Collada141.COLLADA();
        }

        public override Assembly Assembly => typeof(Collada141.COLLADA).Assembly;

        public override object Create(Color color)
        {
            throw new NotImplementedException();
        }
    }
}
