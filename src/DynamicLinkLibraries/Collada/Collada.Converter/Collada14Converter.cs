using Abstract3DConverters;

namespace Collada.Converter
{
    public partial class Collada14Converter : AbstractMeshCreator
    {
        public Collada14Converter() : base(".dae")
        {
        }

  
        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            Collada141.COLLADA collada = Collada141.COLLADA.Load(filename);
            return Create(collada);
        }
    }
}
