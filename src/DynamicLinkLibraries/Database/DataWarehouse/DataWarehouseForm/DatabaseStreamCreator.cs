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

        IDataAsync async;


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="leaf">Leaf</param>
        public DatabaseStreamCreator(ILeaf leaf)
        {
            this.leaf = leaf;
            if (leaf is IDataAsync async)
            {
                this.async = async;
            }
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

        IDataAsync IStreamCreator.DataAsync => async;

        #endregion
    }
}
