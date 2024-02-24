using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3D.Interfaces
{
    /// <summary>
    /// Float rotation matrix
    /// </summary>
    public interface IFloatRotationMatrix
    {
        float M11 { get; }
        float M12 { get; }
        float M13 { get; }
        float M21 { get; }
        float M22 { get; }
        float M23 { get; }
        float M31 { get; }
        float M32 { get; }
        float M33 { get; }

        void SetQuaternion(IFloatQuaternion quatertion);

    }
}
