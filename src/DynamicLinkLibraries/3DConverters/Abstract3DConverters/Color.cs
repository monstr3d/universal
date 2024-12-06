using System.Linq.Expressions;
using System.Transactions;

namespace Abstract3DConverters
{
    public class Color : ICloneable
    {
        public float[] Value { get; private set; }

        public Color(float[] value)
            { this.Value = value; }

        public Color(double[] value)
        {
            Value = Transform(value);
        }

        private float[] Transform(double[] x)
        {
            var c = new float[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                c[i] = (float)x[i];
            }
            return c;
        }

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
