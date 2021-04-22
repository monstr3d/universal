using CategoryTheory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using WebCamCapture.UI.Factory;

namespace WebCamCapture.UI
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionWebCamCaptureUI
    {
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionWebCamCaptureUI()
        {
            (new UIFactory()).Add();
        }

    }
}
