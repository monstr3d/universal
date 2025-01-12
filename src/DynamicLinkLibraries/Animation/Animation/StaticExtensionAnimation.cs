using Animation.Interfaces;

using AssemblyService.Attributes;

namespace Animation
{
    /// <summary>
    /// Static extension
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionAnimationInterfaces
    {
        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        #region Private

        static StaticExtensionAnimationInterfaces()
        {
            Interfaces.StaticExtensionAnimationInterfaces.Driver =
                AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IAnimationDriver>();
        }

        #endregion

    }
}
