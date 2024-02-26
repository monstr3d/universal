using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vector3D.Interfaces;

namespace Vector3D
{
    public class FloatOrientation : IFloatOrientation
    {
        #region Fields

        protected IFloatQuaternion quaternion;

        protected FloatRotationMatrix rotationMatrix;


        #endregion

        #region Ctor

        public FloatOrientation(IFloatQuaternion quaternion)
        {
            this.quaternion = new FloatQuaternion(quaternion);
            rotationMatrix = new FloatRotationMatrix();
            this.SetQuaternion(); 
        }

   


        protected FloatOrientation()
        {

        }

        #endregion


        IFloatQuaternion IFloatOrientation.Quaternion
        {
            get
            {
                return quaternion;
            }
        }

        IFloatRotationMatrix IFloatOrientation.RotationMatrix
        {
            get
            {
                return rotationMatrix;
            }
        }

    }
}
