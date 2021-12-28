using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace Bitmap.FormulaEditior.UnaryDetectors
{
    class BinaryBitmapAcceptor : IOperationAcceptor, IObjectOperation
    {
        static readonly internal BinaryBitmapAcceptor Sinleton = new BinaryBitmapAcceptor();

        private BinaryBitmapAcceptor()
        {

        }

        Tuple<object, object, object> input;

        object[] inputs = new object[]
            {new Tuple<object, object>(typeof(System.Drawing.Bitmap), (double)0) };


        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                object[] o = arguments[0] as object[];
                System.Drawing.Bitmap b = o[0] as System.Drawing.Bitmap;
                double a = (double)o[1];
                return b;
            }
        }

        object[] IObjectOperation.InputTypes
        {
            get
            {
                return inputs;
            }
        }

        object IObjectOperation.ReturnType
        {
            get
            {
                return typeof(System.Drawing.Bitmap);
            }
        }

        IObjectOperation IOperationAcceptor.Accept(object type)
        {
            if (type is Tuple<object, object>)
            {
                Tuple<object, object> t = type as Tuple<object, object>;
                if (t.Item1.Equals(typeof(System.Drawing.Bitmap)) & t.Item2.Equals((double)0) )
                {

                    return new BinaryBitmapAcceptor();
                }
            }
            return null;
        }
    }
}

