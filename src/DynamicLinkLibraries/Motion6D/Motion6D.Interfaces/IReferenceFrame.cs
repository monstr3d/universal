namespace Motion6D.Interfaces
{
    /// <summary>
    /// Reference frame holder
    /// </summary>
    public interface IReferenceFrame : IPosition
    {
        /// <summary>
        /// Own frame
        /// </summary>
        ReferenceFrame Own
        {
            get;
        }

    }
}
