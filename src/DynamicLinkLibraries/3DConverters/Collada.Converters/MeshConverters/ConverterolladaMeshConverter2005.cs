
using Abstract3DConverters.Attributes;

namespace Collada.Converters.MeshConverters
{
    public class ConverterolladaMeshConverter2005 : ColladaMeshConverter
    {
        #region Fields


        Dictionary<string, int> dm = new();


        #endregion

        #region Constructor

        public ConverterolladaMeshConverter2005() : base("http://www.collada.org/2008/03/COLLADASchema")
        {
        }


        #endregion


        protected override void Load()
        {
            doc.LoadXml(Properties.Resources.etalon2005);
        }

    }
}