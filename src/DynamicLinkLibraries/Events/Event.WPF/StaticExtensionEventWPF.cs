using AssemblyService.Attributes;

using Event.Interfaces;

namespace Event.WPF
{
    /// <summary>
    /// Static extension methods
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionEventWPF
    {

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        static StaticExtensionEventWPF()
        {
            StaticExtensionEventInterfaces.TimerEventFactory = WpfTimerEventFactory.Singleton;
            StaticExtensionEventInterfaces.TimerFactory = WpfTimerFactory.Singleton;
        }
    }
}
