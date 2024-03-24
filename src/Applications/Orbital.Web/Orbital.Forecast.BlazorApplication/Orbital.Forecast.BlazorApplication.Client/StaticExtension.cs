
namespace BlazorApp
{
    internal static class StaticExtension
    {
        static StaticExtension()
        {
            AssemblyService.StaticExtensionAssemblyService.Init();
            DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor =
                DataPerformer.Portable.DifferentialEquationProcessors.RungeProcessor.Processor;

        }

        internal static void Init()
        {

        }
    }
}
