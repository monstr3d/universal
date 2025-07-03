using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Forms;
using CategoryTheory;
using DataPerformer.UI.UserControls;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using ErrorHandler;
using NamedTree;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for F distribution
    /// </summary>
    [Serializable()]
    public class FisherLabel : UserControlFisherComparator,
        ISerializable, IObjectLabel, INonstandardLabel
    {

        #region Fields

        private IDesktop desktop = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FisherLabel()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected FisherLabel(SerializationInfo info, StreamingContext context)
            : this()
        {
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }

        #endregion

        #region IObjectLabel Members

        ICategoryObject IObjectLabel.Object
        {
            get
            {
                return collection;
            }
            set
            {
                if (!(value is ObjectsCollection))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                ObjectsCollection coll = value as ObjectsCollection;
                if (!coll.Type.Equals(typeof(Regression.AliasRegression)))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                Collection = coll;
            }
        }

        #endregion

        #region INamedComponent Members

        string INamed.Name
        {
            get => this.GetRootLabel().Name;
            set => throw new IllegalSetPropetryException("LABEL");
        }

        string INamedComponent.Kind
        {
            get { return "Regression.AliasRegression,AliasRegression"; }
        }

        string INamedComponent.Type
        {
            get { return typeof(Diagram.UI.ObjectsCollection).FullName; }
        }

        void INamedComponent.Remove()
        {
        }

        int INamedComponent.X
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        int INamedComponent.Y
        {
            get
            {
                return 0;
            }
            set
            {
            }
        }

        IDesktop INamedComponent.Desktop
        {
            get
            {
                if (desktop != null)
                {
                    return desktop;
                }
                return this.GetRootLabel().Desktop;
            }
            set
            {
            }
        }

        int INamedComponent.Ord
        {
            get
            {
                INamedComponent nc = this;
                Control c = nc.Desktop as Control;
                return c.Controls.GetChildIndex(this);
            }
        }


        INamedComponent INamedComponent.Parent
        {
            get
            {
                return null;
            }
            set
            {
                throw new ErrorHandler.OwnException("You should not set parent to UI component");
            }
        }

        /// <summary>
        /// Root
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <returns>Root</returns>
        public INamedComponent GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }

        string INamedComponent.GetName(IDesktop desktop)
        {
            return PureObjectLabel.GetName(this, desktop);
        }

        string INamedComponent.RootName
        {
            get
            {
                INamedComponent nc = this;
                return nc.GetName(nc.Desktop.Root);
            }
        }

        INamedComponent INamedComponent.Root
        {
            get { return PureObjectLabel.GetRoot(this); }
        }


        INamedComponent INamedComponent.GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }


        #endregion

        #region INonstandardLabel Members

        void INonstandardLabel.Initialize()
        {
        }

        void INonstandardLabel.Post()
        {
            base.Update();
        }

        void INonstandardLabel.Resize()
        {
        }

        void INonstandardLabel.CreateForm()
        {
        }

        object INonstandardLabel.Form
        {
            get { return null; }
        }

        object INonstandardLabel.Image
        {
            get { return ResourceImage.Fisher.ToBitmap(); }
        }

       

        #endregion
    }
}
