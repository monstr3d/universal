using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class MeshTextReaderCreator: IAbstractMeshCreator

    {

        #region Fields

        public ITextReaderMeshCreator TextReaderMeshCreator { get; private set; }

        string IAbstractMeshCreator.Extension => TextReaderMeshCreator.Extension;

        #endregion

        public virtual List<AbstractMesh> Create(string filename)
        {
            using (var reader = new StreamReader(filename))
            {
                return TextReaderMeshCreator.Create(reader);
            }
        }
    }
}
