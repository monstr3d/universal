using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //new CodeCreators.CSCodeCreator();
        }

        #endregion

        #region Binder Class

        //!!!BINDER
        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            static readonly Type type = typeof(Wrapper.Gravity);

            static readonly string tn = type.FullName;

            internal Binder()
            {
                    this.Add();
            }
            readonly string[] types = new string[] { "DataPerformerUI", "DataPerformer.UI" };
            public override Type BindToType(string assemblyName, string typeName)
            {
               if (typeName == tn)
                {
                    return type;
                }
                return null;

            }
        }

        #endregion


    }
}
