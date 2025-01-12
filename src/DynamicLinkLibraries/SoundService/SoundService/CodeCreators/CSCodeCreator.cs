using Diagram.UI;
using Diagram.UI.Interfaces;

using System.Collections.Generic;

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

        void Process(MultiSound multiSound, List<string> code)
        {
            code.Add(typeof(MultiSound).FullName);
            code.Add("{");
            code.Add("\tinternal CategoryObject()");
            code.Add("\t{");
            code.Add("\t\tconditionName = \"" + multiSound.Condition + "\";");
            code.Add("\t\tsoundName = \"" + multiSound.Sound + "\";");
        }


        void Process(Object2SoundName object2SoundName, List<string> l)
        {
            l.Add(typeof(Object2SoundName).FullName);
            l.Add("{");
            l.Add("\tinternal CategoryObject()");
            l.Add("\t{");
            l.Add("\t\tinputs = new string[] {\n");
            for (int i = 0; i < object2SoundName.Inputs.Length; i++)
            {
                var s = "\t\t\t\"" + object2SoundName.Inputs[i] + "\"";
                if (i < (object2SoundName.Inputs.Length - 1))
                {
                    s += ",";
                }
                l.Add(s);
            }
            l.Add("\t\t};");
        }

        void Process(SoundCollection soundCollection, List<string> l)
        {
            l.Add(typeof(SoundCollection).FullName);
            l.Add("{");
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
            l.Add("\t}");
            l.Add("}");
        }
    }
}
