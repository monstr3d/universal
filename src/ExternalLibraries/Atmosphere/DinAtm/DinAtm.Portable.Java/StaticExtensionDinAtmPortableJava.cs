using AssemblyService.Attributes;

namespace DinAtm.Portable.Java
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDinAtmPortableJava
    {
        static StaticExtensionDinAtmPortableJava()
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
