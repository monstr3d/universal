
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunPosition
{
    class Class1
    {
        void t()
        {
            Microsoft.Scripting.Hosting.ScriptEngine engine = IronPython.Hosting.Python.CreateEngine();
            Microsoft.Scripting.Hosting.ScriptSource script = engine.CreateScriptSourceFromString("");
            Microsoft.Scripting.Hosting.ScriptScope scope = engine.CreateScope();
        }
    }
}
