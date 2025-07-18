using Diagram.UI.Interfaces;

namespace DataPerformer.Formula.TypeScript
{
    public class Performer
    {

        public string DoubleToString(double a)
        {
            return a.ToString("G17", System.Globalization.CultureInfo.InvariantCulture);
        }

        public string StringValue(object o)
        {
            Type t = o.GetType();
            if (t.Equals(typeof(double)))
            {
                double a = (double)o;
                return DoubleToString(a);
            }
            if (t.Equals(typeof(bool)))
            {
                return ((bool)o) ? "true" : "false";
            }
            return o + "";
        }


        /// <summary>
        /// Any to string
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public string AnyToString(object obj)
        {
            Type t = obj.GetType();
            string s = StringValue(obj);
            if (t.Equals(typeof(double)))
            {
                return "(double)" + s;
            }
            if (t.Equals(typeof(string)))
            {
                return "\"" + s + "\"";
            }
            return s;
        }
        /*
			let map = new Map<string, any>(
			[
				["a", 5],
				["b", 1]

				]);
			this.performer.SetAliasMap(map, this);

         */

        public List<string> CreateTSAliasList(string id, IAlias alias)
        {
            List<string> l = new List<string>();
            var al = alias.AliasNames;
            l.Add("let " + id + " = new Map<string, any>(");
            int n = al.Count;
            l.Add("[");
            if (n == 0)
            {
                l.Add("]);");
            }
            else
            {
                for (int i = 0; i < n; i++)
                {
                    string s = al[i];
                    s = "\t[\"" + s + "\", " +  StringValue(alias[al[i]]) + " ]";
                    if (i < (n - 1))
                    {
                        s += ',';
                    }
                    l.Add(s);
                }
                l.Add("]);");
            }
            return l;
        }
    }
}