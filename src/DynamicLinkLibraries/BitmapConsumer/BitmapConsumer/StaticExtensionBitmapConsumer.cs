using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CategoryTheory;
using Diagram.UI;

namespace BitmapConsumer
{
    /// <summary>
    /// Static extensions
    /// </summary>
    public static class StaticExtensionBitmapConsumer
    {
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
        /// Gets bitmap of bitmap provider
        /// </summary>
        /// <param name="provider">The provider</param>
        /// <returns>The bitmap</returns>
        public static Bitmap GetBitmap(this IBitmapProvider provider)
        {
            return provider.Bitmap;
        }
    }
}
