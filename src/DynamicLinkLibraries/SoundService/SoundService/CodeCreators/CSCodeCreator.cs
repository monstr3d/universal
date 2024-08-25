using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundService.CodeCreators
{
    /// <summary>
    /// Code creator
    /// </summary>
    class CSCodeCreator : IClassCodeCreator
    {

        internal CSCodeCreator()
        {
            this.AddCSharpCodeCreator();
        }

        List<string> IClassCodeCreator.CreateCode(string preffix, object obj)
        {
            var code = new List<string>();
            code.Add(obj.GetType().FullName);
            code.Add("{");
            code.Add("\tinternal CategoryObject()");
            code.Add("\t{");

            switch (obj)
            {
                case MultiSound multiSound:
                    Process(multiSound, code);
                    break;
                case Object2SoundName object2SoundName:
                    Process(object2SoundName, code);
                    break;
                case SoundCollection soundCollection:
                    Process(soundCollection, code);
                    break;
                default:
                    return null;
            }
            code.Add("\t}");
            code.Add("}");
            return code;
        }

        void Process(MultiSound multiSound, List<string> l)
        {
            l.Add("\t\tconditionName = \"" + multiSound.Condition + "\";");
            l.Add("\t\tsoundName = \"" + multiSound.Sound + "\";");
        }


        void Process(Object2SoundName object2SoundName, List<string> l)
        {
            l.Add("\t\tinputs = [\n");
            for (int i = 0; i < object2SoundName.Inputs.Length; i++)
            {
                var s = "\t\t\t\"" + object2SoundName.Inputs[i] + "\"";
                if (i < ( object2SoundName.Inputs.Length - 1))
                {
                    s += ",";
                }
                l.Add(s);  
            }
        }

        void Process(SoundCollection soundCollection, List<string> l)
        {
            l.Add("\t\tsounds = new new Dictionary<string, string>()");
            l.Add("\t\t\t{");
            var d = soundCollection.Sounds;
            var n = d.Count - 1;
            var i = 0;
            foreach (var key in d.Keys)
            {
                var s = "\t\t\t\t{\"" + key + "\", \"" + d[key] + "\"}";
                ++i;
                if (i < n)
                {
                    s += ",";
                }
                l.Add(s);
            }
            l.Add("\t\t\t}");

        }

    }
}
