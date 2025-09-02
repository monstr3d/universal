namespace Scada.Interfaces
{
    /// <summary>
    /// Factory of SCADA
    /// </summary>
    public interface  IScadaFactory
    {
        /// <summary>
        /// Gets 
        /// </summary>
        /// <param name="id">Identifief</param>
        /// <param name="unique">The "unique" sign</param>
        /// <returns>The scada</returns>
        IScadaInterface this[object id, bool unique = true] { get; }
    }
}
