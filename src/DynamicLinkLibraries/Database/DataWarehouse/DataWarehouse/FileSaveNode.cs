using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using DataWarehouse;

using DataWarehouse.Interfaces;
using ErrorHandler;


namespace DataWarehouse
{
    /// <summary>
    /// Saves node to file
    /// </summary>
    public class FileSaveNode : ISaveNode
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static ISaveNode Singleton = new FileSaveNode();

        #endregion

        #region Ctor

        private FileSaveNode()
        {
        }

        #endregion

        #region ISaveNode Members

        void ISaveNode.Save(INode node)
        {
            if (node == null)
            {
                return;
            }
            if (!(node is ILeaf))
            {
                return;
            }
            string path = AppDomain.CurrentDomain.BaseDirectory + "Acrhive";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += Path.DirectorySeparatorChar + node.Name + ".cfa";
            path = path.Replace("\"", "QUOTES");
            if (File.Exists(path))
            {
                throw new OwnException("File \"" + path + " \"already exists");
            }
            using (Stream s = File.OpenWrite(path))
            {
                byte[] data = (node as ILeaf).Data;
                s.Write(data, 0, data.Length);
                node.Remove();
            }
            
        }

        #endregion
    }
}
