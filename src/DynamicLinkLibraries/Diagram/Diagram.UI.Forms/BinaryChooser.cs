using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Diagram.UI
{
    /// <summary>
    /// Chooser of Binary
    /// </summary>
    public abstract class BinaryChooser
    {
        /// <summary>
        /// Singleton
        /// </summary>
        static private BinaryChooser obj;

        /// <summary>
        /// Singleton
        /// </summary>
        static public BinaryChooser Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        /// <summary>
        /// Shows itself
        /// </summary>
        /// <param name="form">Parent form</param>
        /// <param name="ext">Extension</param>
        public abstract void Show(Form form, string ext);

        /// <summary>
        /// The id
        /// </summary>
        public abstract string Id
        {
            get;
        }

        /// <summary>
        /// The name
        /// </summary>
        public abstract string Name
        {
            get;
        }
    }
}
