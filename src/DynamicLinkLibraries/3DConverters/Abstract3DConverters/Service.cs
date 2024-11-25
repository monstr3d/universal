using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collada;

namespace Abstract3DConverters
{
    public class Service
    {

        protected static readonly char[] sep = "\r\n ".ToCharArray();

        public Service() 
        { 
        
        }


        #region Service

        public string ToString(string str, string shift)
        {
            if (str.StartsWith(shift))
            {
                return str.Substring(shift.Length).Replace("\"", "").Trim();
            }
            return null;
        }

        public T? ToReal<T>(string str, string shift) where T : struct
        {
            var s = ToString(str, shift);
            if (s == null)
            {
                return null;
            }
            return ToReal<T>(s);
        }

        private float ToFloat(string str)
        {
            return float.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }

        private double ToDouble(string str)
        {
            return double.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }

        private int ToInt(string str)
        {
            return int.Parse(str, System.Globalization.CultureInfo.InvariantCulture);
        }


        public T[] ToRealArray<T>(string str) where T : struct
        {
            string[] ss = str.Split(sep);
            var l = new List<T>();
            foreach (string s in ss)
            {
                if (s.Length > 0)
                {
                    T a = s.ToReal<T>();
                    l.Add(a);
                }
            }
            return l.ToArray();
        }

        public T ToReal<T>(string s) where T : struct
        {
            object obj = null;
            var t = typeof(T);
            if (t == typeof(double))
            {
                obj = ToDouble(s);
            }
            else if (t == typeof(float))
            {
                obj = ToFloat(s);
            }
            else if (t == typeof(int))
            {
                obj = ToInt(s);
            }
            return (T)obj;
        }


        public IEnumerable<S> Convert<S, T>(IEnumerable<T> input, Func<T, S> func)
        {
            foreach (var item in input)
            {
                yield return func(item);
            }
        }

        public double[] Convert(float[] array)
        {
            return Convert(array, x => (double)x).ToArray();
        }

        public string[] Split(string str)
        {
            return str.Split(sep);
        }

        #endregion

    }
}
