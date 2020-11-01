using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Media.Media3D;

using CategoryTheory;
using Diagram.UI;

using SerializationInterface;

using BitmapConsumer;

using WpfInterface.Objects3D;

using Web.Interfaces;

namespace Motion6D.Image
{
    /// <summary>
    /// 3D object with digital image processing interoperability
    /// </summary>
    [Serializable()]
    public class MotionImageFigure : WpfShape, IBitmapConsumer, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Textures - Names of providers
        /// </summary>
        Dictionary<string, string> dTextures = new Dictionary<string, string>();

        /// <summary>
        /// Textures - Bitmap poviders
        /// </summary>
        Dictionary<string, IBitmapProvider> providers = new Dictionary<string, IBitmapProvider>();

        IAssociatedObject th;

        bool isSerialized = false;

        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
 
 
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MotionImageFigure()
        {
            th = this;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MotionImageFigure(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            th = this;
            isSerialized = true;
        }

        #endregion

        #region Overriden


        /// <summary>
        /// Loads textures
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected override void LoadTextures(System.Runtime.Serialization.SerializationInfo info)
        {
            base.LoadTextures(info);
            dTextures = info.Deserialize<Dictionary<string, string>>("dTextures");
        }
      
        /// <summary>
        /// Saves textures
        /// </summary>
        /// <param name="info">Serialization info</param>
        protected override void SaveTextures(System.Runtime.Serialization.SerializationInfo info)
        {
            base.SaveTextures(info);
            info.Serialize<Dictionary<string, string>>("dTextures", dTextures);
        }

        #endregion

        #region IBitmapConsumer Members

        void IBitmapConsumer.Process()
        {
        }

        IEnumerable<IBitmapProvider> IBitmapConsumer.Providers
        {
            get 
            {
                foreach (IBitmapProvider p in providers.Values)
                {
                    yield return p;
                }
            }
        }

        void IBitmapConsumer.Add(IBitmapProvider provider)
        {
            providers[GetName(provider)] = provider;
            addRemove(provider, true);
        }

        void IBitmapConsumer.Remove(IBitmapProvider provider)
        {
            try
            {
                providers.Remove(GetName(provider));
                addRemove(provider, false);
            }
            catch (Exception exception)
            {
                exception.ShowError(-1);
            }
        }


        /// <summary>
        /// Add remove event of provider. If "bool" is true then adding
        /// </summary>
        event Action<IBitmapProvider, bool> IBitmapConsumer.AddRemove
        {
            add { addRemove += value; }
            remove { addRemove -= value; }
        }


        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            Post();
        }

        #endregion

        #region Overriden

        public override Visual3D GetVisual(Portable.Camera camera)
        {
            if (isSerialized)
            {
                return null;
            }
            return base.GetVisual(camera);
        }

        #endregion

        #region Own Methods


        public Dictionary<string, string> TextureDictionary 
        {
            get
            {
                return dTextures;
            }
            set
            {
                dTextures = value;
                Post();
            }
        }
   


        /// <summary>
        /// Ges name of provider
        /// </summary>
        /// <param name="provider">Provider</param>
        /// <returns>Name</returns>
        protected string GetName(IBitmapProvider provider)
        {
            IAssociatedObject ao = provider as IAssociatedObject;
            return th.GetRelativeName(ao);
        }

        /// <summary>
        /// Post method
        /// </summary>
        protected virtual void Post()
        {
            if (!isSerialized)
            {
                return;
            }
            isSerialized = false;
            urls.Clear();
            foreach (string textureName in dTextures.Keys)         // Textures cycle
            {
                string providerName = dTextures[textureName];      // Name of provider
                if (providers.ContainsKey(providerName))
                {
                   IBitmapProvider p = providers[providerName];    // Bitmap provider
                   if (p is IUrlProvider)
                   {
                       urls[textureName] = (p as IUrlProvider).Url;
                       Bitmap bp = new System.Drawing.Bitmap(5, 5);
                       paths.Remove(textureName);
                       using (MemoryStream stream = new MemoryStream())
                       {
                           bp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp); // Saving bitmap to bypes
                           textures[textureName] = stream.GetBuffer();               // Replace texture by bitmap 
                       }
                       continue;
                   }
                   Bitmap bmp = p.Bitmap;                          // Bitmap of provider
                   paths.Remove(textureName);
                   using (MemoryStream stream = new MemoryStream())
                   {
                       bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp); // Saving bitmap to bypes
                       textures[textureName] = stream.GetBuffer();               // Replace texture by bitmap 
                   }
                }
            }
        }

        #endregion

    }
}
