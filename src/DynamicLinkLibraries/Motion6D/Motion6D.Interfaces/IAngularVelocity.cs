namespace Motion6D.Interfaces
{
    /// <summary>
    /// Object that have angular velocity
    /// </summary>
    public interface IAngularVelocity
    {
        /// <summary>
        /// Angular velocity of object
        /// </summary>
        double[] Omega
        {
            get;
        }
    }
}
