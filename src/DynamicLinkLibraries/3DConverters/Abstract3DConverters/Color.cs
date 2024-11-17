using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract3DConverters
{
    public class Color
    {
        public float[] Value { get; private set; }

        public Color(string color)
        {
            List<float> values = new List<float>();
            var ss = color.Split(' ');
            foreach (var v in ss)
            {
                if (v.Length == 0)
                {  continue; }
                var d = ToFloat(v);
                values.Add(d);
            }
            Value = values.ToArray();
        }


        private float ToFloat(string str)
        {
            return float.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }


    }
}
