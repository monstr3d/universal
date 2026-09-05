using AssemblyService.Attributes;

namespace DataPerformer.Portable.Java
{
    [InitAssembly]
    public static class StaticExtensionDataPerformerPortableJava
    {

        static StaticExtensionDataPerformerPortableJava()
        {
            new ClassCodeCreator();
        }

        /// <summary>
        /// Initialize itself
        /// </summary>
        /// <param name="attr">Initialization attribute</param>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
