using Diagram.UI.Interfaces;

namespace Aviation.Web
{
    public static class StaticExtensionAviationWeb
    {
        static StaticExtensionAviationWeb()
        {
            AssemblyService.StaticExtensionAssemblyService.Init();

            // FormulaMeasurement.CheckValue = (o)                            => o == null;
            FormulaEditor.StaticExtensionFormulaEditor.CheckValue = Check;

            var desktop = StaticExtensionAviationWeb.Desktop;

        }

        static bool Check(object o)
        {
            if (o == null)
            {
                return true;
            }
            return false;
        }

        static internal IDesktop Desktop => GeneratedProject.OrbitalMotion.Desktop;


        internal static void Init()
        {

        }
    }
}
