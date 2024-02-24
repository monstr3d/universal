using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    /// <summary>
    /// Combined class code creator
    /// </summary>
    public class CombinedCodeCreator : IClassCodeCreator
    {
        #region Fields

        List<IClassCodeCreator> list = new List<IClassCodeCreator>();

        #endregion


        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            foreach (IClassCodeCreator creator in list)
            {
                List<string> l = creator.CreateCode(preffix, obj);
                if (l != null)
                {
                    return l;
                }
            }
            return null;
        }

        #endregion

        #region Public Members

        public void Add(IClassCodeCreator creator)
        {
            list.Add(creator);
        }

        #endregion
    }
}
