using System.IO;

using Common.UI;
using DataWarehouse.Interfaces;
using NamedTree;

namespace DataWarehouse
{
    /// <summary>
    /// Creator of stream
    /// </summary>
    public class DatabaseStreamCreator : IStreamCreator
    {
        #region Fields

        ILeaf leaf;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="leaf">Leaf</param>
        public DatabaseStreamCreator(ILeaf leaf)
        {
            this.leaf = leaf;
        }

        #endregion

        #region IStreamCreator Members

        Stream IStreamCreator.Stream
        {
            get 
            {
                return new MemoryStream((leaf as IData).Data);
            }
        }

        #endregion
    }
}
