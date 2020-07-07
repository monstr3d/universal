
namespace Vector3D
{
    /// <summary>
    /// Euler angles
    /// </summary>
    public class EulerAngles
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public EulerAngles()
        {
            roll = 0;
            pitch = 0;
            yaw = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="roll">Roll</param>
        /// <param name="pitch">Pitch</param>
        /// <param name="yaw">Yaw</param>
        public EulerAngles(double  roll, double pitch, double yaw)
        {
            this.roll = roll;
            this.pitch = pitch;
            this.yaw = yaw;
        }

        /// <summary>
        /// Roll 
        /// </summary>
        public double roll { get; set; }

        /// <summary>
        /// Pitch
        /// </summary>
        public double pitch { get; set; }

        /// <summary>
        /// Yaw
        /// </summary>
        public double yaw { get; set; }

 
    }
}
