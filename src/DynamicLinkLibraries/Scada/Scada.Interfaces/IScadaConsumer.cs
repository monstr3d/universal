namespace Scada.Interfaces
{
    /// <summary>
    /// Consumer of SCADA
    /// </summary>
    public interface IScadaConsumer
    {
        /// <summary>
        /// Scada interface
        /// </summary>
        IScadaInterface Scada
        {
            get;
            set;
        }

        /// <summary>
        /// Is enabled
        /// </summary>
        bool IsEnabled
        {
            get;
            set;
        }
    }
}
