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
                    Assembly ass = StaticExtensionFormulaEditorCompiler.Compiler[code];
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
