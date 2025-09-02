using System;
using System.Xml;
using Abstract3DConverters.Interfaces;
using Collada;

namespace Collada.Converters.Classes.Elementary
{
    [Tag("matrix", true)]
    public class Matrix : XmlHolder
    {

        public static IClear Clear => StaticExtensionCollada.GetClear<Matrix>();


        public double[] Matrix3D 
        { 
            get; 
            private set; 
        }

        private Matrix(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            double[] x = element.InnerText.ToRealArray<double>();
            Matrix3D = [x[0], x[1], x[2], x[3], x[4], x[5], x[6], x[7], x[8], x[9], x[10], x[11], x[12], x[13], x[14], x[15]];
        }

        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Matrix(element, meshCreator);
            return a.Get();
        }
    }
}