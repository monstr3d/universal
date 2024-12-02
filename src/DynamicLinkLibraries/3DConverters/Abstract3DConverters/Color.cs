using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class Color : ICloneable
    {
        public float[] Value { get; private set; }

        private Color(float[] value)
            { this.Value = value; }

        public Color(string[] strings)
        {
            List<float> values = new List<float>();
            foreach (var v in strings)
            {
                if (v.Length == 0)
                { 
                    continue; 
                }
                var d = ToFloat(v);
                values.Add(d);
            }
            Value = values.ToArray();

        }

        public Color(string color) : this(color.Split(' '))
        {
        }


        private float ToFloat(string str)
        {
            return float.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }

        public object Clone()
        {
            return new Color(Value);
        }
    }
}
