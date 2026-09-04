namespace Vector3D.Interfaces
{
    /// <summary>
    /// Angular velocity
    /// </summary>
    public interface IAngularVelocity
    {
        /// <summary>
        /// Angular velocity along X - axis
        /// </summary>
        double AngularVelocityX { get; }

        /// <summary>
        /// Angular velocity along Y - axis
        /// </summary>
        double AngularVelocityY { get; }

        /// <summary>
        /// Angular velocity along Z - axis
        /// </summary>
        double AngularVelocityZ { get; }

    }
}
