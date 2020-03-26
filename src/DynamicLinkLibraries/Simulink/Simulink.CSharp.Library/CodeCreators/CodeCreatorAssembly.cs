using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.CodeDom.Compiler;



using Simulink.Parser.Library.Interfaces;
using Simulink.Parser.Library.DiagramElements;

using Simulink.CSharp.Library.Interfaces;


namespace Simulink.CSharp.Library.CodeCreators
{
    partial class CodeCreator
    {
        static Assembly CreateAssembly(IList<string> text, out CodeCreator cc)
        {
            cc = new CodeCreator(text);
            ICodeCreator icc = cc;
            IList<string> lcode = icc.CreateCode(cc.subsystem);
            StringBuilder sb = new StringBuilder();
            foreach (string s in lcode)
            {
                sb.Append(s + "\r\n");
            }
            string code = sb.ToString();
            CompilerParameters compileParams = new CompilerParameters();
            compileParams.IncludeDebugInformation = true;
            compileParams.GenerateExecutable = false;
            compileParams.GenerateInMemory = true;
            string dir = AppDomain.CurrentDomain.BaseDirectory;
            compileParams.ReferencedAssemblies.Add(dir + "Simulink.CSharp.Library.dll");
            CompilerResults results =
                compiler.CompileAssemblyFromSource(compileParams, code);
            try
            {
                Assembly ass = results.CompiledAssembly;
                return ass;
             }
            catch (Exception)
            {
            }
            return null;
  
        }

        /// <summary>
        /// Creates proxy
        /// </summary>
        /// <param name="text">Source Simulink text</param>
        /// <param name="input">Inputs</param>
        /// <param name="output">Outputs</param>
        /// <param name="blocks">Blocks</param>
        /// <returns>Proxy object obtained from dynamically created assembly</returns>
        public static IStateCalculation CreateInterface(IList<string> text, 
            out Dictionary<string, Type> input, out Dictionary<string, Type> output, 
            out Block[] blocks)
        {
            CodeCreator cc;
            Assembly ass = CreateAssembly(text, out cc);
            input = cc.input;
            output = cc.output;
            blocks = cc.subsystem.AllBlocks.ToArray();
            Type[] types = ass.GetTypes();
            foreach (Type t in types)
            {
                if (t.GetInterface(typeof(IStateCalculation).FullName) != null)
                {
                    ConstructorInfo constructor = t.GetConstructor(new Type[0]);
                    return constructor.Invoke(new object[] { }) as IStateCalculation;
                }
            }
            return null;
        }
    }
}
