using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Common.UI
{
    /// <summary>
    /// Creator of comments
    /// </summary>
    public interface ICommentsCreator
    {
        /// <summary>
        /// Creates comments
        /// </summary>
        /// <param name="stream">Stream</param>
        /// <param name="control">Control</param>
        void CreateComments(Stream stream, Control control);
    }
}
