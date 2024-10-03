using ICSharpCode.SharpZipLib.Zip;
using Zip.Service;

namespace ZipSharp
{
    public class ZipInterface : IZipInterface
    {
        byte[] IZipInterface.this[string filename]
        {
            get => Unzip(filename);
            set => CreateZip(value, filename, "a");
        }
        void CreateZip(byte[] buff, string outFile, string name)
        {
            if (File.Exists(outFile))
            {
                try
                {
                    File.Delete(outFile);
                }
                catch
                {

                }
            }
            using (ZipOutputStream s = new ZipOutputStream(File.Create(outFile)))
            {
                s.Write(buff, 0, buff.Length);
            }
        }

        byte[] Unzip(string filename)
        {
            using (var s = File.OpenRead(filename))
            {
                using (var stream = new ZipInputStream(s))
                {
                    byte[] buffer = new byte[stream.Length];
                    stream.Read(buffer, 0, buffer.Length);
                    return buffer;
                }
            }
        }
    }
}
