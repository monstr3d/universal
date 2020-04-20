using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Labels;

using Event.Basic.Events;
using Event.Basic.Data.Events;

using Event.UI.UserControls;


namespace Event.UI.Labels
{
    /// <summary>
    /// Label of forced event circilar control
    /// </summary>
    [Serializable()]
    public class Circular2DControlLabel : UserControlBaseLabel
    {
        #region Fields

        new UserControlCircular2DControl control;

        ForcedEventData forced;

 
        double x1 = 0;

        double y1 = 0;

        double x2 = 1;

        double y2 = 1;

        Event.UI.Forms.FormCircular2DControl form;

        #endregion

       #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public Circular2DControlLabel()
            : base(typeof(ForcedEventData), "", Properties.Resources.JoystickCircular)
        {
        }

 
        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Circular2DControlLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
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
            info.AddValue("x1", x1);
            info.AddValue("y1", y1);
            info.AddValue("x2", x2);
            info.AddValue("y2", y2);
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                control = new UserControlCircular2DControl();
                control.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                Set();
                return control;
            }
        }


        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return forced;
            }
            set
            {
                ForcedEventData f = value.GetObject<ForcedEventData>();
                if (f == null)
                {
                    return;
                }
                forced = f;
                Set();
            }
        }

        /// <summary>
        /// Creates editor form
        /// </summary>
        public override void CreateForm()
        {
            form = new Forms.FormCircular2DControl(this);
        }

        /// <summary>
        /// Editor form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            x1 = info.GetDouble("x1");
            y1 = info.GetDouble("y1");
            x2 = info.GetDouble("x2");
            y2 = info.GetDouble("y2");
        }

        #endregion

        #region Internal Members

        internal double X1
        {
            get
            {
                return x1;
            }
            set
            {
                x1 = value;
            }
        }

        internal double Y1
        {
            get
            {
                return y1;
            }
            set
            {
                y1 = value;
            }
        }

        internal double X2
        {
            get
            {
                return x2;
            }
            set
            {
                x2 = value;
            }
        }

        internal double Y2
        {
            get
            {
                return y2;
            }
            set
            {
                y2 = value;
            }
        }

        #endregion

        #region Private Members

        void Set()
        {
            if ((control == null) | (forced == null))
            {
                return;
            }
            control.Set(forced, x1, y1, x2, y2);
        }

        #endregion
    }
}
