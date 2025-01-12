using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;
using System.Drawing;


using CategoryTheory;


using Diagram.UI.Labels;

using Motion6D;

using WpfInterface.UI.UserControls;
using WpfInterface.Objects3D;

namespace WpfInterface.UI.Labels
{
    [Serializable()]
    public class ShapeLabel : UserControlBaseLabel
    {
        #region Fields

        new UserControlShape control;

        WpfShape shape;

        ICategoryObject obj;

        protected Form form = null;
        
        #endregion

        #region Ctor

        public ShapeLabel(string kind, Image image)  : base(typeof(SerializablePosition), kind, image)
        {
        
        }


        protected ShapeLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden Members

        protected override UserControl Control
        {
            get 
            {
                control = new UserControlShape();
                if (shape != null)
                {
                    control.Shape = shape;
                }
                return control;
            }
        }

        public override ICategoryObject Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
                shape = value.GetObject<WpfShape>();
                if (control != null)
                {
                    control.Shape = shape;
                }
            }
        }

        public override void CreateForm()
        {
           form = new Motion6D.UI.Forms.FormFieldShape(this);
        }

        public override object Form
        {
            get
            {
                return form;
            }
        }

 
        #endregion
    }
}
