using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BaseTypes.Attributes;

using Diagram.UI;


namespace Celestrak.NORAD.Satellites
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionCelestrakNORADSatellites
    {
        #region Fields

        internal static List<int> Nums = new List<int>();

        internal static List<string> Full = new List<string>();

        internal static List<string> ListAlias;

        private static readonly Dictionary<object, Func<string, int[], object>> Functions
            = new Dictionary<object, Func<string, int[], object>>()
            {
                {"", ToString},
               {(int)0, ToInt},
               {(double)0, ToDouble}
            };


        private static readonly object[][] Types = new object[][]
        {
            new object[] {null, "", (int)0, (int)0, "",
                (int)0, (double)0, (double)0, (double)0, (double)0, 
                (int)0, (int)0, null},
            new object[]    {
                null, (int)0, (double)0, (double)0, (double)0, 
                (double)0, (double)0, (double)0, (int)0, null}
        };


        public static readonly string[] Names = new string[]
        {
            "Satellite parameters"
        };

        internal static Dictionary<int, Tuple<int[], object>>[] Dictionary =
            new Dictionary<int, Tuple<int[], object>>[2];

        internal static List<string>[] List = new List<string>[2];

        /// <summary>
        /// Physical unit dictionary
        /// </summary>
        internal static readonly Dictionary<string, Dictionary<Type, int>> AliasNames =
         new Dictionary<string, Dictionary<Type, int>>()
       {
            {"Eccentricity", null},
            {"Inclination", new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Ascending Node",  new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Argument Of Periapsis",  new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Mean Anomaly At Epoch",  new Dictionary<Type, int>(){{typeof(AngleType), 1}}},
            {"Mean Motion", new Dictionary<Type, int>{{typeof(AngleType), 1}, {typeof(TimeType), -1}}},
            {"FD MeanMotion", null},
            {"SD MeanMotion", null},
            {"Perturbation", null},
            {"Mass", new Dictionary<Type, int>(){{typeof(MassType), 1}}},
            {"Epoch",  null}
        };

        internal static Dictionary<string, string> AliasesParametes = new Dictionary<string, string>();

        #endregion

        static StaticExtensionCelestrakNORADSatellites()
        {
            ListAlias = new List<string>(AliasNames.Keys);
             string[] ss = Properties.Resources.orb2des.Split("\n".ToCharArray());
            /* !!! File version
                 string fileName = typeof(StaticExtensionCelestrakNORADSatellites).Assembly.Location;

            		fileName = fileName.Replace("Celestrak.NORAD.Satellites.dll", "Files" + System.IO.Path.DirectorySeparatorChar + "orb2des.txt");

            using (System.IO.TextReader reader = new System.IO.StreamReader(fileName))
            {
                ss = reader.ReadToEnd().Split("\n".ToCharArray());
            }
             */
            int i = 0;

            bool read = false;
            Dictionary<int, Tuple<int[], object>> d = null;
            List<string> l = null;
            int j = 0;
            i = -1;
            foreach (string s in ss)
            {
                if (read)
                {
                    if (s.Length < 7)
                    {
                        read = false;
                        if (i == 1)
                        {
                            break;
                        }
                        j = 0;
                        continue;
                    }
                    object type = Types[i][j];
                    ++j;
                    if (type == null)
                    {
                        continue;
                    }
                    string dec = s.Substring(0, 7).Trim();
                    string[] sdec = dec.Split("-".ToCharArray());
                    int[] k = new int[] { Int32.Parse(sdec[0]), Int32.Parse(sdec[1]) };
                    string comment = s.Substring(8).Trim();

                    Tuple<int[], object> t = new Tuple<int[], object>(k, type);
                    d[l.Count] = t;
                    l.Add(comment);
                }
                if (s.Contains("Column     Description"))
                {
                    if (i == 2)
                    {
                        break;
                    }
                    ++i;
                    d = new Dictionary<int, Tuple<int[], object>>();
                    l = new List<string>();
                    List[i] = l;
                    j = 0;
                    Dictionary[i] = d;
                    read = true;
                }
            }
            for (int ii = 0; ii < 2; ii++)
            {
                Dictionary<int, Tuple<int[], object>> dt = Dictionary[ii];
                List<string> li = List[ii];
                for (int jj = 0; jj < dt.Count; jj++)
                {
                    Nums.Add(Full.Count);
                    Full.Add(li[jj]);
                }

            }
            List<string>[] list = List;

            string[] aliasNames = new string[]
       {
        "Eccentricity",
        "Inclination",
        "Ascending Node",
        "Argument Of Periapsis",
        "Mean Anomaly At Epoch",
        "Mean Motion",
        "FD MeanMotion",
        "SD MeanMotion",
        "Perturbation",
        "Mass",
        "Epoch"
        };

            AliasesParametes[list[1][1]] = aliasNames[1];
            AliasesParametes[list[1][2]] = aliasNames[2];
            AliasesParametes[list[1][3]] = aliasNames[0];
            AliasesParametes[list[1][4]] = aliasNames[3];
            AliasesParametes[list[1][5]] = aliasNames[4];
            AliasesParametes[list[1][6]] = aliasNames[5];
            AliasesParametes[list[0][6]] = aliasNames[6];
            AliasesParametes[list[0][7]] = aliasNames[7];
            AliasesParametes[list[0][8]] = aliasNames[8];
        }

        internal static object ToObject(this string s, int[] k, object o)
        {
            return Functions[o](s, k);
        }

        internal static string Substring(this string str, int[] n)
        {
            return str.Substring(n[0] - 1, n[1] - n[0] + 1);
        }


        private static object ToString(this string str, int[] n)
        {
            return str.Substring(n);
        }

        private static object ToDouble(this string str, int[] n)
        {
            string s = str.Substring(n);
            if (s[0] == '0' & !s.Contains("."))
            {
                s = "0." + s;
            }
            int k = s.LastIndexOf("-");
            if (k > 0)
            {
                if (s[0] == '-')
                {
                    s = '-' + s.Substring(1).Replace("-", "E-");
                }
                else
                {
                    s = s.Replace("-", "E-");
                }
            }
            k = s.LastIndexOf("+");
            if (k > 0)
            {
                s = s.Replace("+", "E+");
            }
            return double.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        }

        private static object ToInt(this string str, int[] n)
        {
            string s = str.Substring(n);
            return int.Parse(s, System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}