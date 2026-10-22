using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2D.Interfaces;

namespace Vector2D
{
    class FloatRotationMatrix2D : IFloatRotationMatrix2D
    {
        #region Fields

        float M11;

        float M12;

        float M21;

        float M22;

        #endregion

        float IFloatRotationMatrix2D.M11
        {
            get
            {
                return M11;
            }
        }

        float IFloatRotationMatrix2D.M12
        {
            get
            {
                return M12;
            }
        }

        float IFloatRotationMatrix2D.M21
        {
            get
            {
                return M21;
            }
        }

        float IFloatRotationMatrix2D.M22
        {
            get
            {
                return M22;
            }
        }

        void IFloatRotationMatrix2D.SetAngle(IFloatRotationAngle angle)
        {
            angle.CalculateRotationMatrix(out M11, out M12, out M21, out M22);
        }
    }
}
