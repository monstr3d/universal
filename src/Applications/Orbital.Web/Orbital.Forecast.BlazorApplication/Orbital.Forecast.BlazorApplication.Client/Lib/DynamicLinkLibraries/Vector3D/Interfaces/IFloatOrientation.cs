using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3D.Interfaces
{
    /// <summary>
    /// IFloat quatenion
    /// </summary>
    public interface IFloatOrientation
    {
        IFloatQuaternion Quaternion { get; }
        IFloatRotationMatrix RotationMatrix { get; }

    }
}
