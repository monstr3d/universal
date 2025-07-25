using Diagram.UI;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace BitmapConsumer
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionBitmapConsumer
    {


        public static Icon IconFromBitmap(this Bitmap bmp)
        {
            IntPtr Hicon = bmp.GetHicon();
            Icon myIcon = Icon.FromHandle(Hicon);
            return myIcon;
        }


        /// <summary>
        /// Gets names of providers
        /// </summary>
        /// <param name="consumer">Consumer</param>
        /// <returns>Names of providers</returns>
        public static IEnumerable<string> GetProviders(this IBitmapConsumer consumer)
        {
            IAssociatedObject ao = consumer as IAssociatedObject;
            foreach (IBitmapProvider p in consumer.Providers)
            {
                yield return ao.GetRelativeName(p as IAssociatedObject);
            }
        }

        /// <summary>
        /// Comparers bitmaps
        /// </summary>
        /// <param name="x">First bitmap<param>
        /// <param name="y">Second bitmap</param>
        /// <returns>True if equals</returns>
        public static bool CompareBitmaps(this Bitmap x, Bitmap y)
        {
           return BitmapComparer.Instance.Equals(x, y);      
        }

        /// <summary>
        /// Comparers bitmap providers
        /// </summary>
        /// <param name="x">First bitmap<param>
        /// <param name="y">Second bitmap</param>
        /// <returns>True if equals</returns>
        public static bool CompareBitmaps(this IBitmapProvider x, IBitmapProvider y)
        {
            return x.Bitmap.CompareBitmaps(y.Bitmap);
        }



        /// <summary>
        /// Gets bitmap of bitmap provider
        /// </summary>
        /// <param name="provider">The provider</param>
        /// <returns>The bitmap</returns>
        public static Bitmap GetBitmap(this IBitmapProvider provider)
        {
            return provider.Bitmap;
        }

        class BitmapComparer : IEqualityComparer<Bitmap>
        {
            internal static readonly IEqualityComparer<Bitmap> Instance = new BitmapComparer();
            private BitmapComparer()
            {

            }

            bool IEqualityComparer<Bitmap>.Equals(Bitmap x, Bitmap y)
            {
                if ((x.Width != y.Width) | (x.Height != y.Height))
                {
                    return false;
                }
                for (int i = 0; i < x.Width; i++)
                {
                    for (int j = 0; j < x.Height; j++)
                    {
                        var cx = x.GetPixel(i, j);
                        var cy = x.GetPixel(i, j);
                        if (!cx.Equals(cy))
                        {
                            return false;
                        }
                    }
                }
                return true;
            }

            int IEqualityComparer<Bitmap>.GetHashCode(Bitmap obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
