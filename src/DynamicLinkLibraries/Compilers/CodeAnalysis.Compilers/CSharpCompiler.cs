using CompilerService.Interfaces;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace CodeAnalysis.Compilers
{
    /// <summary>
    /// С# Compiler
    /// </summary>
    public class CSharpCompiler : ICompiler
    {
        #region Ctor

        public CSharpCompiler()
        {

        }

        #endregion

        #region ICompiler implemebtation

        /// <summary>
        /// Creates assembly from code
        /// </summary>
        /// <param name="code">The code</param>
        /// <returns>The assembly</returns>
        Assembly ICompiler.this[string code] => Create(code);

        #endregion

        #region Private members

        Assembly Create(string codeToCompile)
        {
            var refPaths1 = new[] {
                typeof(object).GetTypeInfo().Assembly.Location,
                typeof(Console).GetTypeInfo().Assembly.Location,
                Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "System.Runtime.dll")
            };
            var ll = new LinkedList<string>(refPaths1);
            Assembly[] assemb = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assemb)
            {
                try
                {
                    string l = ass.Location;
                    if (!ll.Contains(l) & l.Length > 0)
                    {
                        ll.AddLast(l);
                    }
                }
                catch 
                { 
                
                }
                finally
                {

                }
            }
            var refPaths = ll.ToArray();
            MetadataReference[] references = refPaths.Select(r => MetadataReference.CreateFromFile(r)).ToArray();

            SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(codeToCompile);
            string assemblyName = Path.GetRandomFileName();
               CSharpCompilation compilation = CSharpCompilation.Create(
                assemblyName,
        syntaxTrees: new[] { syntaxTree },
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));
            Assembly assembly = null;
            using (var ms = new MemoryStream())
            {
                EmitResult result = compilation.Emit(ms);

                if (!result.Success)
                {
                    IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                        diagnostic.IsWarningAsError ||
                        diagnostic.Severity == DiagnosticSeverity.Error);

                    foreach (Diagnostic diagnostic in failures)
                    {
                        // Console.Error.WriteLine("\t{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
                    }
                }
                else
                {
                    ms.Seek(0, SeekOrigin.Begin);
                    assembly = AssemblyLoadContext.Default.LoadFromStream(ms);
                }
            }
            return assembly;
        }

        #endregion

    }
}
