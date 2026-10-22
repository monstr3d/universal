using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vector2D.Interfaces
{
    public interface IFloatRotationAngle
    {
        float Angle
        {
            get;
        }

        void SetMatrix(IFloatRotationMatrix2D m);
    }
}
