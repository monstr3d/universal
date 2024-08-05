using CategoryTheory;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Http.Meteo.UI.Labels
{
    [Serializable]
    public class MeteoLabel : UserControlBaseLabel
    {

        #region Fields

        UserControls.UserControlLabel uc;

        Serializable.MeteoService meteo;

        Form form = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MeteoLabel()
                : base(typeof(Serializable.MeteoService), "",
                      Properties.Resources.AtmosphereWeb.ToBitmap())
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public MeteoLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MeteoLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                uc = new UserControls.UserControlLabel();
                return uc;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return meteo;
            }
            set
            {
                meteo = value.GetObject<Serializable.MeteoService>();
                uc.Object = meteo;
            }
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {

        }

        #endregion


    }
}
