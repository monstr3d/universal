using AssemblyService.Attributes;

using DinAtm.Forms.Factory;

namespace DinAtm.Forms
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExStaticExtensionAtmosphereForms
    {

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExStaticExtensionAtmosphereForms()
        {
            new UIFactory();
        }

    }
}
