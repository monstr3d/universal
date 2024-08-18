using AssemblyService.Attributes;

using Gravity_36_36.Wrapper.UI.Factory;

namespace Gravity_36_36.Wrapper.UI
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionGravityUI
    {
      
        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {
        
        }

        static StaticExtensionGravityUI()
        {
            new UIFactory();
        }

    }
}
