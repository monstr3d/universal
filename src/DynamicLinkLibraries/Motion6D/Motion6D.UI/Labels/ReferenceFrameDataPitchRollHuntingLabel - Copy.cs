using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Motion6D;
using Motion6D.UI.UserControls;

namespace Motion6D.UI.Labels
{
    /// <summary>
    ///  UI Label of "ReferenceFrameDataPitchRollHunting" object
    /// </summary>
    [Serializable()]
    public class ReferenceFrameDataPitchRollHuntingLabel : ReferenceFrameDataLabel
    {

        
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ReferenceFrameDataPitchRollHuntingLabel()
           : base(typeof(ReferenceFrameDataPitchRollHunting), "", ResourceImage.DataFrameEuler.ToBitmap())
        {
        }



        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ReferenceFrameDataPitchRollHuntingLabel(SerializationInfo info, StreamingContext context)
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
                userControlFrameData = new UserControlFrameDataPitchRollHunting();
                return userControlFrameData;
            }
        }

        #endregion
    }
}
