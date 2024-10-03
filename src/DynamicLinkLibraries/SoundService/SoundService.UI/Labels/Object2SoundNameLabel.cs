using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using SoundService.UI.UserControls;
using SoundService.UI.Factory;

namespace SoundService.UI.Labels
{
    [Serializable()]
    public class Object2SoundNameLabel : UserControlBaseLabel
    {
       #region Fields


        Object2SoundName conv;

        UserControlObject2SoundName userControlDigit2SoundName;

       #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Object2SoundNameLabel()
            : base(typeof(MultiSound), "", Properties.Resources.pcdrsounddigit.ToBitmap())
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Object2SoundNameLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
       /* public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info
        }
*/

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                userControlDigit2SoundName = new UserControlObject2SoundName();
                return userControlDigit2SoundName;
            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return conv;
            }
            set
            {
                if (!(value is Object2SoundName))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                conv = value as Object2SoundName;
                if (userControlDigit2SoundName != null)
                {
                    userControlDigit2SoundName.Converter = conv;
                }
             }
        }

        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            userControlDigit2SoundName.Post();
        }

        #endregion

        #region Public Members

        #endregion
     }
}
