using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CategoryTheory;
using Diagram.UI.Labels;
using Motion6D.Image.UI.UserControls;

namespace Motion6D.Image.UI.Labels
{
    [Serializable()]
    public class FigureImageLabel : UserControlBaseLabel
    {
        #region Fields

        new UserControlMotionImage control;

        MotionImageFigure figure;

        protected Form form = null;

        #endregion

       #region Ctor

        public FigureImageLabel(string kind, System.Drawing.Image image)  : 
            base(typeof(SerializablePosition), kind, image)
        {
        }


        protected FigureImageLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden Members

        protected override UserControl Control
        {
            get 
            {
                control = new UserControlMotionImage();
                if (figure != null)
                {
                    control.Figure = figure;
                }
                return control;
            }
        }

        public override ICategoryObject Object
        {
            get
            {
                return figure;
            }
            set
            {
                figure = value.GetObject<MotionImageFigure>();
                if (control != null)
                {
                    control.Figure = figure;
                }
                figure.Object = this;
            }
        }

        public override void Post()
        {
            control.Post();
        }

        /*!!! LATER
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
        */
 
        #endregion
 
    }
}
