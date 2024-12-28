namespace Abstract3DConverters
{
    public class Color : ICloneable
    {
        public float[] Value { get; private set; }



        public Color(float[] value)
            { this.Value = value; }

        public Color(double[] value)//, bool inverse = false)
        {
            /*
            if (!inverse)
            {
           
            }*/
            Value = Transform(value, false);
        }

        private float[] Transform(double[] x, bool inverse)
        {
            var c = new float[x.Length];
            for (int i = 0; i < x.Length; i++)
            {
                c[i] = (float)x[i];
            }
            if (c.Length == 4)
            {
                if (inverse)
                {
                    var a = c[0];
                    var b = c[3];
                    c[0] = b;
                    c[3] = a;
                }
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

        public string StringValue(string sep = " ")
        {
            var s = "";
            foreach (var a in Value)
            {
                s += a + sep;
            }
            s = s.Substring(0, s.Length - sep.Length);
            return s;
        }

    }
}
