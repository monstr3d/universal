using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using Dynamic.Atmosphere.UI.UserControls;

namespace Dynamic.Atmosphere.UI.Labels
{
    /// <summary>
    /// Label for delay accumulator
    /// </summary>
    [Serializable()]
    public class AtmosphereLabel : UserControlBaseLabel
    {

        #region Fields

        UserControlAtmosphere uc;

        Portable.Atmosphere atmosphere;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AtmosphereLabel()
            : base(typeof(Serializable.Atmosphere), "", Properties.Resources.Atmosphere.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected AtmosphereLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

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
                uc = new UserControlAtmosphere();
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
                return atmosphere;
            }
            set
            {
                if (!(value is Portable.Atmosphere))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                atmosphere = value as Portable.Atmosphere;
                uc.Atmosphere = atmosphere;
            }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {

        }

        #endregion
    }
}
