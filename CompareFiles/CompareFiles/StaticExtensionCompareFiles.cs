using System.Globalization;
using System.Xml.Linq;

namespace CompareFiles
{
    public static class StaticExtensionCompareFiles
    {
        /// <summary>
        /// Compares streams
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="destination">Target</param>
        /// <returns>Comparison result</returns>
        public static long[] Compare(this Stream source, Stream destination)
        {
            long k = 128;
            long a = 0;
            var l = source.Length;
            byte[] buffer = new byte[l];
            source.Read(buffer);
            for (long i = 0; i < destination.Length - l; i++)
            {
                var b = destination.ReadByte();
                if (b == buffer[0])
                {
                    for (long j = 1; j < l; j++)
                    {
                        if (buffer[j] != destination.ReadByte())
                        {
                            if (j > a)
                            {
                                a = j;
                                if (a == (l - 1))
                                {
                                    return new long[] { a + 1, l };
                                }
                            }
                            destination.Position = i;
                        }
                    }
                }
            }
            return new long[] { a + 1, l };
        }

        /// <summary>
        /// Compares files
        /// </summary>
        /// <param name="source">Source</param>
        /// <param name="destination">Target</param>
        /// <returns>Comparison result</returns>
        public static long[] Compare(this string source, string destination)
        {
            using (var s = File.OpenRead(source))
            {
                using (var t = File.OpenRead(destination))
                {
                    return s.Compare(t);
                }
            }
        }
    }
}