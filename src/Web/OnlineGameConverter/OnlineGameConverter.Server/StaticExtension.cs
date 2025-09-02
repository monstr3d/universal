using OnlineGameConverter.Server.Classes;

namespace OnlineGameConverter.Server
{
    internal static class StaticExtension
    {
        static StaticExtension()
        {
            //  Abstract3DConverters.StaticExtensionAbstract3DConverters.Init();
            // InitOrbital();
            AssemblyService.StaticExtensionAssemblyService.Init();
         /* !!! DELETE   var p = new Performer();
            var cond = new ForecastCondition(DateTime.Now, DateTime.Now + TimeSpan.FromDays(1), -5448.34815324,
                 -4463.93698421, 0, -0.985394777432, 1.21681893834, 7.45047785592);
            p.Calculate(cond, new CancellationToken());*/
        }

        internal static void Init()
        {

        }

        static void InitOrbital()
        {

        }
    }
}
