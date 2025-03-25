using Abstract3DConverters;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using TGAConverter.TGA;

namespace ImageDetector
{
    [Init]
    public static class StaticExtensionImageDetector
    {
        static StaticExtensionImageDetector()
        {
            new ImageDetector();
            new ImageConverter();
        }


        public static void Init(InitAttribute initAttribute)
        {

        }

        class ImageDetector : IImageDetector
        {
            internal ImageDetector()
            {
                this.Set();
            }

            bool IImageDetector.Detect(string imagePath)
            {
                try
                {
                    var im = System.Drawing.Image.FromFile(imagePath);
                    return im != null;
                }
                catch (Exception e)
                {
                }
                return true;
            }

            bool IImageDetector.Detect(byte[] imageData)
            {
                using var stream = new MemoryStream(imageData);
                return System.Drawing.Image.FromStream(stream: stream) != null;
            }
        }


        class ImageConverter : IImageConverter
        {
            internal ImageConverter()
            {
                this.Set();
            }

            Tuple<string, byte[]> IImageConverter.Convert(string filename)
            {
                return Convert(filename);
            }

            Tuple<string, byte[]> Convert(string filename)
            {
                var ext = Path.GetExtension(filename);
                switch (ext)
                {
                    case ".tga":
                        return ConvertTGA(filename);

                }
                return null;
            }

            Tuple<string, byte[]> ConvertTGA(string filename)
            {
                var tga = TGAReader.ReadTGAFile(filename);
                var bmp = tga.PixelData;
                using var stream = new MemoryStream();
                bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                var fn = Path.GetFileName(filename) + ".png";
                return new Tuple<string, byte[]>(fn, stream.ToArray());
            }
        }

    }
}
