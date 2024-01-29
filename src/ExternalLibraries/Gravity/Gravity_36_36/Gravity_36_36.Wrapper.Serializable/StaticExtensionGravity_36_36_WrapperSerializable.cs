using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AssemblyService.Attributes;
using CategoryTheory;

using Diagram.UI;

namespace Gravity_36_36.Wrapper.Serializable
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public class StaticExtensionGravity_36_36_WrapperSerializable
    {

        #region Public Members

        /// <summary>
        /// Inits itself
        /// </summary>
        public static void Init()
        {

        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionGravity_36_36_WrapperSerializable()
        {
            new CodeCreators.CSCodeCreator();
        }

        #endregion

        #region Binder Class

        //!!!BINDER
        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            static readonly Type type = typeof(Binder);


            static string ass;
            internal Binder()
            {
                ass = type.Assembly.FullName;
                this.Add();
            }
             public override Type BindToType(string assemblyName, string typeName)
            {
                if(assemblyName.Contains("Gravity_36_36.Wrapper.Serializable"))
                {
                    return Type.GetType(string.Format("{0}, {1}",
                            typeName, ass));
                }
                 return null;

            }
        }

        #endregion


    }
}
