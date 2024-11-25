using System;
using System.Windows.Media.Media3D;
using System.Xml;

namespace Collada.Wpf.Classes
{
    [Tag("matrix", true)]
    public class Matrix : XmlHolder
    {

        public Matrix3D Matrix3D 
        { 
            get; 
            private set; 
        }

        private Matrix(XmlElement element) : base(element)
        {
            double[] x = element.InnerText.ToRealArray<double>();
            Matrix3D = new Matrix3D(x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15]);
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element)
        {
            var a = new Matrix(element);
            return a.Get();
        }
    }
}