using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using CategoryTheory;


using Diagram.UI.Labels;
using ErrorHandler;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// User control associated to object
    /// </summary>
    public partial class UserControlObject : UserControl
    {
        #region Fields

        /// <summary>
        /// Associated object
        /// </summary>
        private IObjectLabel theObject;

        /// <summary>
        /// Base object
        /// </summary>
        private IObjectLabel theBase;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constuctor
        /// </summary>
        public UserControlObject()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theBase">Base object</param>
        /// <param name="theObject">Associated object</param>
        public UserControlObject(IObjectLabel theBase, IObjectLabel theObject)
            : this()
        {
            Set(theBase, theObject);
        }

        #endregion


        #region Members

        /// <summary>
        /// Sets labels
        /// </summary>
        /// <param name="theBase">Base label</param>
        /// <param name="theObject">Associated label</param>
        public void Set(IObjectLabel theBase, IObjectLabel theObject)
        {
            this.theObject = theObject;
            this.theBase = theBase;
            Initialize();
        }

        /// <summary>
        /// Sets objects
        /// </summary>
        /// <param name="baseObject">Base object</param>
        /// <param name="theObject">Associated object</param>
        public void SetObjects(object baseObject, object theObject)
        {
            IObjectLabel b = Detect(baseObject);
            IObjectLabel t = Detect(theObject);
            if (t != null)
            {
                Set(b, t);
            }
        }

        /// <summary>
        /// Initialization
        /// </summary>
        private void Initialize()
        {
            int ho = Height;
            int ph = pictureBoxObject.Height;
            try
            {
                Image im = theObject.GetImage();
                pictureBoxObject.Width = im.Width;
                pictureBoxObject.Height = im.Height;
                pictureBoxObject.Image = im;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            if (theBase != null)
            {
                labelObject.Text = theBase.GetRelativeName(theObject);
            }
            else
            {
                labelObject.Text = theObject.RootName;
            }
            int dh = pictureBoxObject.Height - ph;
            panelTop.Height = panelTop.Height + dh;
            Height = Height + dh;
        }


        private IObjectLabel Detect(object o)
        {
            if (o is IObjectLabel)
            {
                return o as IObjectLabel;
            }
            if (o is IAssociatedObject)
            {
                IAssociatedObject ao = o as IAssociatedObject;
                object ob = ao.Object;
                if (ob is IObjectLabel)
                {
                    return ob as IObjectLabel;
                }
            }
            return null;
        }


        #endregion
    }
}
