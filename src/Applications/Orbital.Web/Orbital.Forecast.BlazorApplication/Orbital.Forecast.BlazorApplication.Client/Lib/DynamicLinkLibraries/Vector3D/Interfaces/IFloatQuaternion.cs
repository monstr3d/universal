using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector3D.Interfaces
{
    /// <summary>
    /// Float quaternion
    /// </summary>
    public interface IFloatQuaternion
    {

        float W { get; }
        float X { get; }
        float Y { get; }
        float Z { get; }

        void Copy(IFloatQuaternion quatetrnion);
    }
}

