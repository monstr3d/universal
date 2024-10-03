using AssemblyService.Attributes;

namespace BitmapConsumer.TestIntefface
{
    [InitAssembly]
    public static class StaticExtensionBitmapConsumerTestInterface
    {
        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionBitmapConsumerTestInterface()
        {
            new TestCreator();
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init(InitAssemblyAttribute attr)
        {

        }

    }
}