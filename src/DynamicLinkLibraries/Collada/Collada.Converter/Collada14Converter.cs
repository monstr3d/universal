using Abstract3DConverters;

namespace Collada.Converter
{
    public partial class Collada14Converter : AbstractMeshCreator
    {

        private Collada141.COLLADA collada;
        public Collada14Converter() : base(".dae")
        {
        }

  
        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            collada = Collada141.COLLADA.Load(filename);
            return Create();
        }
    }
}
