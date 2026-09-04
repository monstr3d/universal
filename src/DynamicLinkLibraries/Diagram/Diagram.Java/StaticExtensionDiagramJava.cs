using AssemblyService.Attributes;
using Diagram.Java;

namespace Diagram.UI.Java
{
    [InitAssembly]
    public static class StaticExtensionDiagramJava
    {
        static  StaticExtensionDiagramJava()
        {
            new DesktopCodeCreator();
            new TypeCreator();
        }


        /// <summary>
        /// Initializes itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
