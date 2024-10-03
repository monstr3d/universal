using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Net;


using Diagram.UI;

using Web.Interfaces;

namespace ImageTransformations
{
    /// <summary>
    /// External web image
    /// </summary>
    [Serializable()]
    public class ExternalImage : SourceImage, IUrlConsumer, IUrlProvider
    {
        #region Fields

        static protected readonly string[] types = new string[] { "Web" };

        protected string type = "";

        protected string url = "";

        protected Action<string> changeInput = (string s) => { };
        
        protected Action<string> changeOutput = (string s) => { };



        protected Func<string> fUrl = null;

        #endregion

        #region Constructors


        /// <summary>
        /// Default constructor
        /// </summary>
        public ExternalImage()
        {
        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        public ExternalImage(string type)
        {
            this.type = type;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ExternalImage(SerializationInfo info, StreamingContext context)
        {
            try
            {
                type = info.GetString("Type");
                url = info.GetString("Url");
                CreateBitmap();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
        }


        #endregion

        #region ISerializable Members
 
        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Type", type);
            info.AddValue("Url", url);
        }

        #endregion

        #region Public

        /// <summary>
        /// Function which calculates URL
        /// </summary>
        public Func<string> FuncUrl
        {
            get
            {
                return fUrl;
            }
            set
            {
                fUrl = value;
            }
        }


        /// <summary>
        /// Url
        /// </summary>
        public string Url
        {
            get
            {
                if (fUrl != null)
                {
                    return fUrl();
                }
                return url;
            }
            set
            {
                if (fUrl != null)
                {
                    throw new Exception("Url should be calculated");
                }
                url = value;
                try
                {
                    CreateBitmap();
                    changeInput(url);
                }
                catch (Exception e)
                {
                    url = "";
                    throw e;
                }
            }
        }

        /// <summary>
        /// Loads Web
        /// </summary>
        public void LoadWeb()
        {
            if (image != null)
            {
                if (fUrl != null)
                {
                    string str = fUrl();
                    if (str == null)
                    {
                        return;
                    }
                    if (str.Equals(url))
                    {
                        return;
                    }
                    url = str;
                }
            }
            else
            {
                try
                {
                    if (url.Length == 0)
                    {
                        if (fUrl != null)
                        {
                            url = fUrl();
                            if (url == null)
                            {
                                url = "";
                                return;
                            }
                        }
                    }
                    WebClient wc = new WebClient();
                    Stream s = wc.OpenRead(url);
                    image = System.Drawing.Image.FromStream(s);
                }
                catch (Exception ex)
                {
                    ex.ShowError(10);
                }
            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Creates Bitmap
        /// </summary>
        protected override void CreateBitmap()
        {
            try
            {
                if (type.Equals(types[0]))
                {
                    LoadWeb();
                }
                base.CreateBitmap();
            }
            catch (Exception exception)
            {
                exception.ShowError(10);
            }
        }

        #endregion

        event Action<string> IUrlConsumer.Change
        {
            add { changeInput += value; }
            remove { changeInput -= value; }
        }

   
        event Action<string> IUrlProvider.Change
        {
            add { changeOutput += value; }
            remove { changeOutput -= value; }
        }
    }

    #region Helper Class
    class ExtendedWebClient : WebClient
    {

        private int timeout;
        public int Timeout
        {
            get
            {
                return timeout;
            }
            set
            {
                timeout = value;
            }
        }
        public ExtendedWebClient(Uri address)
        {
            this.timeout = 600000;//In Milli seconds
            var objWebClient = GetWebRequest(address);
        }

        protected override WebRequest GetWebRequest(Uri address)
        {
            var objWebRequest = base.GetWebRequest(address);
            objWebRequest.Timeout = this.timeout;
            return objWebRequest;
        }
    }
    #endregion
}
