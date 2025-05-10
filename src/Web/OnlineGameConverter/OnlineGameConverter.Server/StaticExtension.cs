namespace OnlineGameConverter.Server
{
    internal static class StaticExtension
    {
        static StaticExtension()
        {
            //  Abstract3DConverters.StaticExtensionAbstract3DConverters.Init();
            // InitOrbital();
            AssemblyService.StaticExtensionAssemblyService.Init();
            var p = new Performer();
            p.Calculate(null, new CancellationToken());
        }

        internal static void Init()
        {

        }

        static void InitOrbital()
        {

        }
    }
}
