namespace Abstract3DConverters
{
    /// <summary>
    /// Color
    /// </summary>
    public class Color : ICloneable, IEquatable<Color>
    {
        /// <summary>
        /// The value
        /// </summary>
        public float[] Value { get; private set; }

        /// <summary>
        /// Hex symbols
        /// </summary>
        private readonly string s_hex = "0123456789abcdef";

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The float value</param>
        public Color(float[] value)
            { this.Value = value; }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="value">The double value</param>
        public Color(double[] value)//, bool inverse = false)
        {
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

        public Color(string[] strings, bool hex = false)
        {
            if (hex)
            {
                var bt = GetBytes(strings[0]);
                Value = new float[bt.Length];
                for (var i = 0; i < bt.Length; i++)
                {
                    float f = (float)bt[i];
                    Value[i] = f / 255f;
                }
                return;
            }
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

        public Color(string color, bool hex = false) : this(color.Split(' '), hex)
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

       


        public string ByteValue
        {
            get
            {
                var s = "";
                for (int i = 0; i < Value.Length; i++)
                {
                    var b = (byte)(Value[i] * 255);
                    for (int j = 1; j >= 0; j--)
                    {
                        string s_hex = "0123456789abcdef";
                        var c = (int)((b >> (j * 4)) & 0xF);
                        s += s_hex[c];
                    }
                }
                return s.ToUpper();
            }
        }

        byte GetByte(string s)
        {
            int b = 0;
            for (int i = 0; i < 2; i++)
            {
                b = b << 4;
                b += s_hex.IndexOf(s[i]);
            }
            return BitConverter.GetBytes(b)[0];
        }

        byte[] GetBytes(string s)
        {
            var l = s.Length / 2;
            byte[] b = new byte[l];
            for (int i = 0; i < l; i++)
            {
                b[i] = GetByte(s.Substring(2 * i));
            }
            return b;
        }

        bool IEquatable<Color>.Equals(Color? other)
        {
            if (other == null)
            {
                return false;
            }
            if (other.Value.Length != Value.Length)
            {
                return false;
            }
            for (var i = 0; i < Value.Length; i++)
            {
                if (Value[i] != other.Value[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
