using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace Bitmap.FormulaEditior.UnaryDetectors
{
    class UnaryOperation : IObjectOperation
    {
        static readonly object[] types = new object[] { typeof(System.Drawing.Bitmap) };

       static readonly object type = typeof(System.Drawing.Bitmap);

        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                return arguments[0] as System.Drawing.Bitmap;
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get
            {
                return types;
            }
        }

        object IObjectOperation.ReturnType
        {
            get
            {
                return type;
            }
        }
    }
}
