using AssemblyService.Attributes;

namespace DinAtm.Portable.TypeScript
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public class StaticExtensionDinAtmPortableTypeScript
    {
        #region Ctor

        static StaticExtensionDinAtmPortableTypeScript()
        {
            new ClassCodeCreator();
        }

        #endregion

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
