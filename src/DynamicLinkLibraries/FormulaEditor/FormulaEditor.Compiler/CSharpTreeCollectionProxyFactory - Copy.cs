using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BaseTypes;
using FormulaEditor.Interfaces;

namespace FormulaEditor.Compiler
{
    /// <summary>
    /// Proxy factory for C#
    /// </summary>
    public class CSharpTreeCollectionProxyFactory : CSharp.CSharpTreeCollectionProxyFactory
    {
        #region Fields

        public static readonly CodeDomProvider compiler = CodeDomProvider.CreateProvider("cs");

        #endregion

        #region Overriden

        /// <summary>
        /// Proxy
        /// </summary>
        protected override ITreeCollectionProxy Proxy
        {
            get
            {
                CompilerParameters compileParams = new CompilerParameters();
                compileParams.IncludeDebugInformation = true;
                compileParams.GenerateExecutable = false;
                compileParams.GenerateInMemory = true;
                List<string> la = new List<string>() { "BaseTypes.dll", "FormulaEditor.dll" };
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
                try
                {
                    Assembly ass = results.CompiledAssembly;
                    collection.CreateProxy(code);
                    Type[] types = ass.GetTypes();
                    Type[] inp = (checkValue == null) ? new Type[] { typeof(ObjectFormulaTree[]) } :
                        new Type[] { typeof(ObjectFormulaTree[]), typeof(ObjectAction) };
                    foreach (Type t in types)
                    {
                        if (t.GetInterface(typeof(ITreeCollectionProxy).FullName) != null)
                        {
                            if (checkValue == null)
                            {
                                ConstructorInfo constructor = t.GetConstructor(inp);
                                return constructor.Invoke(new object[] { local.Trees }) as ITreeCollectionProxy;
                            }
                            ObjectAction act = new ObjectAction(checkValue);
                            ConstructorInfo ci = t.GetConstructor(inp);
                            return ci.Invoke(new object[] { local.Trees, act }) as ITreeCollectionProxy;
                        }
                    }
                }
                catch (Exception)
                {
                    collection.CreateProxy("BAD " + code);
                }
                return null;
            }
        }

        #endregion

    }
 }
