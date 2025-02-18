using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using CategoryTheory;
using DataWarehouse;
using Diagram.UI.Labels;
using ErrorHandler;
using FormulaEditor.UI;
using Motion6D;
using WpfInterface.Objects3D;
using WpfInterface.UI.UserControls;

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

        internal Tuple<string, string, string, bool, int, int> ConversionData
        {
            get;
            set;
        } = new Tuple<string, string, string, bool, int, int>("", "", "", true, 0, 0);
        
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



        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ConversionData", ConversionData, typeof(Tuple<string, string, string, bool, int, int>));
        }

        #endregion


        #region Overriden Members

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                ConversionData =  info.GetValue("ConversionData",  typeof(Tuple<string, string, string, bool, int, int>)) 
                    as Tuple<string, string, string, bool, int, int>;
            }
            catch (Exception ex)
            {
                ex.ShowError(-1);
            }
        }

        internal void LoadFile(string filename)
        {
            if (shape == null)
            {
                return;
            }
            try
            {
                shape.Load(filename);
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
        }



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
