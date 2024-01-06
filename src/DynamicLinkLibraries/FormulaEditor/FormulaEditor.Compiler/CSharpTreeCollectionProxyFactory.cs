using System;
using System.Reflection;
using FormulaEditor.Interfaces;

namespace FormulaEditor.Compiler
{
    /// <summary>
    /// Proxy factory for C#
    /// </summary>
    public class CSharpTreeCollectionProxyFactory : CSharp.CSharpTreeCollectionProxyFactory
    {
        #region Fields

 

        #endregion

        #region Overriden

        /// <summary>
        /// Proxy
        /// </summary>
        protected override ITreeCollectionProxy Proxy
        {
            get
            {
                try
                {
                    var ass = StaticExtensionFormulaEditorCompiler.Compiler[code];
                    if (ass == null)
                    {
                        /// Check point
                    }
                    collection.CreateProxy(code);
                    Type[] types = ass.GetTypes();
                    Type[] inp = (checkValue == null) ? [ typeof(ObjectFormulaTree[]) ] :
                       [ typeof(ObjectFormulaTree[]), typeof(Func<object, bool>) ];
                    foreach (Type t in types)
                    {
                        if (t.GetInterface(typeof(ITreeCollectionProxy).FullName) != null)
                        {
                            if (checkValue == null)
                            {
                                ConstructorInfo constructor = t.GetConstructor(inp);
                                return constructor.Invoke(new object[] { local.Trees }) as ITreeCollectionProxy;
                            }
                            ConstructorInfo ci = t.GetConstructor(inp);
                            return ci.Invoke(new object[] { local.Trees, checkValue }) as ITreeCollectionProxy;
                        }
                    }
                }
                catch (Exception ex)
                {
                    collection.CreateProxy("BAD " + code);
                }
                return null;
            }
        }

        #endregion

    }
 }
