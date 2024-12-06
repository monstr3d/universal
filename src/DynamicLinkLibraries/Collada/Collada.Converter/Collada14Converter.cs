using Abstract3DConverters;
using Collada141;

namespace Collada.Converter
{
    public partial class Collada14Converter : AbstractMeshCreator
    {

        private Collada141.COLLADA collada;

        Dictionary<Type, List<object>> dic = new Dictionary<Type, List<object>>();
        public Collada14Converter() : base(".dae")
        {
        }

  
        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            collada = Collada141.COLLADA.Load(filename);
            collada.Add(dic, collada.GetType().Assembly);
           
            return Create();
        }
    }
}
