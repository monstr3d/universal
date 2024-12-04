using Abstract3DConverters;

namespace EarClipperSplitter
{
    [Init]
    public static class StaticExtensionEarSplitter
    {

        static StaticExtensionEarSplitter()
        {
            StaticExtensionAbstract3DConverters.PolygonSplitterFactory = Splitter.Instance;

        }

        public static void Init(InitAttribute initAttribute)
        {

        }



    }
}
