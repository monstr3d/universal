using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector2D.Interfaces;

namespace Vector2D
{
    public static class StaticExtensionVector2D
    {
        public static void CalculateRotationMatrix(this IFloatRotationAngle a, out float m11, out float m12, out float m21, out float m22)
        {
            m11 = (float) Math.Cos(a.Angle);
            m21 = (float) Math.Sin(a.Angle);
            m12 = - m21;
            m22 = m11;
        }

        public static void CalculateRotationAngle(this IFloatRotationMatrix2D m, out float angle)
        {
            angle = (float) Math.Asin(m.M11);
            if (m.M21 < 0)
            {
                angle += (float)(Math.PI / 2);
            }
        }
    }
}
