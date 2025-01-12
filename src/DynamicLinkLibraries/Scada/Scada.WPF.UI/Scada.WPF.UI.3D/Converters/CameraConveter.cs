using System.ComponentModel;

using Scada.Interfaces;

using Scada.Wpf.Common;
using Scada.Wpf.Common.Convertes;

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
              StaticExtensionScadaWpfCommon.Scada.GetObjectList<global::Motion6D.Camera>());
        }
    }
}
