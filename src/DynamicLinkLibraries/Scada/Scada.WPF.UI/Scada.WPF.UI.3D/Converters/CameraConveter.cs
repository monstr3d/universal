using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Scada.Motion6D;

using Scada.Interfaces;
using Scada.WPF.UI.Convertes;

namespace Scada.WPF.UI._3D.Converters
{
    /// <summary>
    /// Converter of camera
    /// </summary>
    public class CameraConverter : ConverterBase
    {

        /// <summary>
        /// Overriden
        /// </summary>
        /// <param name="context">Context</param>
        /// <returns>Standard values</returns>
        public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(
                StaticExtensionScadaWpfUI.Scada.GetObjectList<global::Motion6D.Camera>());
        }
    }
}
