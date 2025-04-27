using System.Text;

namespace FbxConverter
{
    public  class ReEncodingOperation
    {
       // [SkipLocalsInit]
        public  TResult Func<TArg, TResult>(string str, TArg arg, Func<byte[], TArg, TResult> func, Func<TResult> fallback)
        {
            if (string.IsNullOrEmpty(str))
            {
                return func(new byte[0], arg);
            }
            var byteCount = Encoding.ASCII.GetByteCount(str);
            if (byteCount != str.Length)
            {
                // The string contains non-ASCII charactors.
                return fallback();
            }

            if (byteCount <= 128)
            {
                var buf = new byte[byteCount];
                /*   fixed (char* c = str)
                   {
                       Encoding.ASCII.GetBytes(c, str.Length, buf, byteCount);
                   }*/
                //Encoding.ASCII.GetBytes(str.ToCharArray(), str.Length, buf, byteCount);
                var buff = Encoding.ASCII.GetBytes(str);
                return func(buff,  arg);
            }
            else
            {
                var buf = new byte[byteCount];
                try
                {
                   // buf = (byte*)Marshal.AllocHGlobal(byteCount);
                   // fixed (char* c = str)
                   // {
                    //    Encoding.ASCII.GetBytes(c, str.Length, buf, byteCount);
                    //}n
                    var buff = Encoding.ASCII.GetBytes(str);
                    return func(buf, arg);
                }
                finally
                {
                    //Marshal.FreeHGlobal(new IntPtr(buf));
                }
            }
        }
    }
}
