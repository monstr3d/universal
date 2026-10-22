using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector2D.Interfaces
{
    public interface IFloatRotationMatrix2D
    {
        float M11 { get; }
        float M12 { get; }
        float M21 { get; }
        float M22 { get; }

        void SetAngle(IFloatRotationAngle a);

    }
}
