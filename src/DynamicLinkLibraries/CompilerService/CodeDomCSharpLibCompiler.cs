using CompilerService.Interfaces;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CompilerService
{
    /// <summary>
    /// С# Compiler
    /// </summary>
    public class CodeDomCSharpLibCompiler : ICompiler
    {
        private CodeDomProvider compiler = CodeDomProvider.CreateProvider("cs");

        static public readonly ICompiler Compiler = new CodeDomCSharpLibCompiler();
        private CodeDomCSharpLibCompiler()
        {
        }

        /// <summary>
        /// Creates assembly from code
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns>The assembly</returns>
        Assembly ICompiler.this[string code] => Create(code);

        Assembly Create(string code)
        {
            CompilerParameters compileParams = new CompilerParameters();
            compileParams.IncludeDebugInformation = true;
            compileParams.GenerateExecutable = false;
            compileParams.GenerateInMemory = true;
            /*   var netstandard = Assembly.Load("System.Core");
               compileParams.ReferencedAssemblies.Add(netstandard.Location);*/
        //    List<string> la = new List<string>() { "BaseTypes.dll", "FormulaEditor.dll" };
            Assembly[] assemb = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assemb)
            {
                try
                {
                    string l = ass.Location;
                    string fn = System.IO.Path.GetFileName(l);
                    {
                        compileParams.ReferencedAssemblies.Add(l);
                    }
                }
                catch (Exception)
                {
                }
            }
            CompilerResults results =
               compiler.CompileAssemblyFromSource(compileParams, code);
            return results.CompiledAssembly;
        }

    }
}
