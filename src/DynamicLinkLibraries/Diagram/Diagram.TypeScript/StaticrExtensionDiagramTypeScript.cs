using AssemblyService.Attributes;

namespace Diagram.TypeScript
{
    [InitAssembly]
    public static class StaticrExtensionDiagramTypeScript
    {
        static StaticrExtensionDiagramTypeScript()
        {
            new ObjectContainerClassCodeCreator();
            new DesktopCodeCreator();
        }

        /// <summary>
        /// Initializes itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}
