using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D.Interfaces;

namespace Vector3D
{
    /// <summary>
    /// Float rotation matrix
    /// </summary>
    public class FloatRotationMatrix : IFloatRotationMatrix
    {
        #region Fields

        protected float m11;
        protected float m12;
        protected float m13;
        protected float m21;
        protected float m22;
        protected float m23;
        protected float m31;
        protected float m32;
        protected float m33;

        protected Vector3DProcessor vp = new();

        float IFloatRotationMatrix.M11
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M12
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M13
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M21
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M22
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M23
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M31
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M32
        {
            get
            {
                return m11;
            }
        }

        float IFloatRotationMatrix.M33
        {
            get
            {
                return m11;
            }
        }

        void IFloatRotationMatrix.SetQuaternion(IFloatQuaternion quatertion)
        {
           vp.CalculateRotationMatrix(quatertion, out m11, out m12, out m13, 
                out m21, out m22, out m23,
                out m31, out m32, out m33);
        }

        #endregion
    }
}
