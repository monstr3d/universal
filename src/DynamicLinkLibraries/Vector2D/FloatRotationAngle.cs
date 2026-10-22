using System;
using System.Collections.Generic;
using System.Linq;
using Vector2D.Interfaces;

namespace Vector2D
{
    class FloatRotationAngle : IFloatRotationAngle
    {
        #region Fields

        float angle;

        #endregion

        float IFloatRotationAngle.Angle
        {
            get
            {
                return angle;
            }
        }

        public void SetMatrix(IFloatRotationMatrix2D m)
        {
            m.CalculateRotationAngle(out angle);            
        }
    }
}
