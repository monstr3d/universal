using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diagram.UI.Interfaces;
using Diagram.UI;

namespace DataPerformer.Portable
{
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCSharpCodeCreator();
        }


        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            if (!(obj is DataLink))
            {
                return null;
            }
            List<string> l = new List<string>();
            l.Add("DataPerformer.Portable.DataLink");
            l.Add("{");
            l.Add("}");
            return l;
        }

        #endregion
    }
}
