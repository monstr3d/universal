using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;
using FormulaEditor.Interfaces;

namespace Bitmap.FormulaEditior.TernaryDetectors
{
    class TernaryBitmapAcceptor : IOperationAcceptor, IObjectOperation
    {
        static readonly internal TernaryBitmapAcceptor Sinleton = new TernaryBitmapAcceptor();

        private TernaryBitmapAcceptor()
        {

        }

        Tuple<object, object, object> input;

        object[] inputs = new object[]
            {new Tuple<object, object, object>(typeof(System.Drawing.Bitmap), (double)0, typeof(System.Drawing.Bitmap)) };

        Tuple<object, object, object> retType;

        object IObjectOperation.this[object[] arguments]
        {
            get
            {
                object[] o = arguments[0] as object[];
                System.Drawing.Bitmap b1 = o[0] as System.Drawing.Bitmap;
                double a = (double)o[1];
                System.Drawing.Bitmap b2 = o[2] as System.Drawing.Bitmap;
                return b2;
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
           if (type is Tuple<object, object, object>)
            {
                Tuple<object, object, object> t = type as Tuple<object, object, object>;
                //Detect !!! whatever operation
                bool op1 = t.Item1.Equals(typeof(System.Drawing.Bitmap)) & t.Item2.Equals((double)0) & t.Item3.Equals(typeof(System.Drawing.Bitmap));

                //Detect resize operation !!! Realized in NeuralNetwork.FormulaEditor
 //               bool resize = t.Item1.Equals(typeof(System.Drawing.Bitmap)) & t.Item2.Equals((int)0) & t.Item3.Equals((int)0);


                if (t.Item1.Equals(typeof(System.Drawing.Bitmap)) & t.Item2.Equals((double)0) & t.Item3.Equals(typeof(System.Drawing.Bitmap)))
                {                    
                    return new TernaryBitmapAcceptor();
                }
            }
            return null;
        }
    }
}
