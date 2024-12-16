using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using Motion6D.Interfaces;
using Motion6D.Portable.Interfaces;
using Motion6D.Portable;
using AssemblyService.Attributes;

namespace Motion6D
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionMotion6D
    {

        static StaticExtensionMotion6D()
        {
            new Binder();
            try

            {
                if (PositionObjectFactory.BaseFactory == null)
                {
                    PositionObjectFactory.BaseFactory =
                        AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IPositionObjectFactory>();
                }
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }


        #region Fields

        /// <summary>
        /// AnimationStaticExtensionMotion6D
        /// </summary>
        static public IProcess Animation
        { get; set; }

        #endregion

        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        #endregion

        //BINDER
        class Binder : System.Runtime.Serialization.SerializationBinder
        {
            internal Binder()
            {
                this.Add();
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                if (typeName.Equals("Motion6D.CameraLink"))
                {
                    return typeof(VisibleConsumerLink);
                }
                return null;
            }

        }


    }
}
