namespace Paths.Service
{
    public class Service
    {
        /// <summary>
        /// Finds end string
        /// </summary>
        /// <param name="s">The string</param>
        /// <param name="enu">The collection</param>
        /// <returns>The results</returns>
        public string FindEnd(string s, IEnumerable<string> enu)
        {
            var d = new Dictionary<int, string>();
            foreach (var item in enu)
            {
                if (s.EndsWith(item))
                {
                    d[item.Length] = item;
                }
            }
            var l = new List<int>(d.Keys);
            if (l.Count == 0)
            {
                return null;
            }
            l.Sort();
            return d[l[l.Count-1]];

        }
    }
}
