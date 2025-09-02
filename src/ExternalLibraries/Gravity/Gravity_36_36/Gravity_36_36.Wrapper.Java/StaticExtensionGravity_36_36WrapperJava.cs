using AssemblyService.Attributes;

namespace Gravity_36_36.Wrapper.Java
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionGravity_36_36WrapperJava
    {
        static StaticExtensionGravity_36_36WrapperJava()
        {
            new ClassCodeCreator();
        }

        #region Public Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

        #endregion



    }
}
