using System.Collections.Generic;

using Diagram.Attributes;
using Diagram.UI;
using Diagram.UI.Interfaces;


namespace DinAtm.Portable.CodeCreators
{
    [Language("C#")]
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCodeCreator();
        }


        #region IClassCodeCreator Members

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            if (!(obj is Atmosphere))
            {
                return null;
            }
            Atmosphere atmosphere = obj as Atmosphere;
            string str = "DinAtm.Portable.Atmosphere";
            List<string> l = new List<string>();
            l.Add(str);
            l.Add("{");
            l.Add("internal CategoryObject()");
            l.Add("{");
            int[] iff = atmosphere.If;
            l.Add("\tint[] iff = new int[] { " + iff[0].StringValue() + "," +   
                iff[1].StringValue() + "," + iff[2].StringValue() + "};");
            l.Add("\tIf = iff;");
            l.Add("}");
            l.Add("}");
            return l;
        }

        #endregion
    }
}
