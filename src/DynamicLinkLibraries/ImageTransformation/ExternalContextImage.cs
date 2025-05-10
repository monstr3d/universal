using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI;
using System.Net;
using ErrorHandler;

namespace ImageTransformations
{
    /// <summary>
    /// Context internet image intended for dynamic images like
    /// http://www.nwra.com/spawx/f10.html
    /// </summary>
    [Serializable()]
    public class ExternalContextImage : ExternalImage
    {
        #region Fields

        /// <summary>
        /// Context url
        /// </summary>
        string contextURL;

        /// <summary>
        /// Context
        /// </summary>
        string context;

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public ExternalContextImage()
        {
            fUrl = GetUrl;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        public ExternalContextImage(string type)
            : base(type)
        {
            fUrl = GetUrl;
        }




       /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public ExternalContextImage(SerializationInfo info, StreamingContext context)
        {
            try
            {
                type = info.GetString("Type");
                fUrl = GetUrl;
                this.context = info.GetString("Context");
                contextURL = info.GetString("ContextURL");
                CreateBitmap();
            }
            catch (Exception exception)
            {
                exception.HandleException(10);
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
            base.GetObjectData(info, context);
            info.AddValue("Context", this.context);
            info.AddValue("ContextURL", contextURL);

        }

        #endregion

        #region Public Members

        /// <summary>
        /// Context
        /// </summary>
        public string Context
        {
            get
            {
                return context;
            }
            set
            {
                context = value;
                base.LoadWeb();
            }
        }

        /// <summary>
        /// Context URL
        /// </summary>
        public string ContextURL
        {
            get
            {
                return contextURL;
            }
            set
            {
                contextURL = value;
                base.LoadWeb();
            }
        }

        #endregion

        #region Private

        /// <summary>
        /// Gets url of the image
        /// </summary>
        /// <returns>Url if found and null otherwise</returns>
        private string GetUrl()
        {
            try
            {
                if (string.IsNullOrEmpty(context) | string.IsNullOrEmpty(ContextURL))
                {
                    return null;
                }
                string ctx = context.ToLower();
                WebRequest req = WebRequest.Create(contextURL);
                req.Timeout = 10000;
                WebResponse rs = req.GetResponse();
                System.IO.TextReader reader = new System.IO.StreamReader(rs.GetResponseStream());
                IEnumerable<string> en = reader.ToEnumerable();
                foreach (string str in en)
                {
                    string ss = str.ToLower();
                    string url = str + "";
                    // If string contains context
                    if (str.ToLower().Contains(ctx))
                    {
                        int n = ss.IndexOf(ctx);
                        url = url.Substring(n);
                        ss = ss.Substring(n);
                        n = ss.IndexOf("src");
                        url = url.Substring(n);
                        ss = ss.Substring(n);
                        n = ss.IndexOf("\"") + 1;
                        url = url.Substring(n);
                        ss = ss.Substring(n);
                        n = ss.IndexOf("\"");
                        url = url.Substring(0, n);
                        ss = ss.Substring(0, n);
                        if (!ss.Contains("http:"))
                        {
                            string bb = contextURL.Substring(0, contextURL.LastIndexOf("/") + 1);
                            url = bb + url;
                        }
                        // Returns url
                        return url;
                    }
                }
                // Returns null
                return null;
            }
            catch (Exception ex)
            {
                // Error indication
                ex.HandleException();
            }
            return null;
        }

        #endregion
    }
}
