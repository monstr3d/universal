using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI;

namespace Diagram.UI.Labels
{
    /// <summary>
    /// Pure arrow label
    /// </summary>
    public class PureArrowLabel : IArrowLabel, IDisposable
    {

        #region Fields

        bool isDisposed = false;

        /// <summary>
        /// Name
        /// </summary>
        protected string name;

        /// <summary>
        /// Kind
        /// </summary>
        protected string kind;

        /// <summary>
        /// Type
        /// </summary>
        protected string type;

        /// <summary>
        /// The x - coordinate
        /// </summary>
        protected int x;

        /// <summary>
        /// The y - coordinate
        /// </summary>
        protected int y;

        /// <summary>
        /// Parent desktop
        /// </summary>
        protected IDesktop desktop;

        /// <summary>
        /// Source
        /// </summary>
        protected PureObjectLabel source;

        /// <summary>
        /// Target
        /// </summary>
        protected PureObjectLabel target;

        /// <summary>
        /// Associated arrow
        /// </summary>
        protected ICategoryArrow arrow;

        /// <summary>
        /// Number os source object
        /// </summary>
        protected object sourceNumber;

        /// <summary>
        /// Number of target object
        /// </summary>
        protected object targetNumber;

        /// <summary>
        /// Parent component
        /// </summary>
        public INamedComponent parent;


        #endregion
   
        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected PureArrowLabel()
        {
        }

        /// <summary>
        /// Constructot
        /// </summary>
        /// <param name="name">Name</param>
        /// <param name="kind">Kind</param>
        /// <param name="type">Type</param>
        /// <param name="x">X - coordinate</param>
        /// <param name="y">Y - coordinate</param>
        public PureArrowLabel(string name, string kind, string type, int x, int y)
        {
            this.name = name;
            this.kind = kind;
            this.type = type;
            this.x = x;
            this.y = y;
        }

        #endregion

        #region IArrowLabel Members

        /// <summary>
        /// Associated arrow
        /// </summary>
        public ICategoryArrow Arrow
        {
            get
            {
                return arrow;
            }
            set
            {
                arrow = value;
            }
        }

        /// <summary>
        /// Source label
        /// </summary>
        public IObjectLabel Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value as PureObjectLabel;
            }
        }

        /// <summary>
        /// Target label
        /// </summary>
        public IObjectLabel Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value as PureObjectLabel;
            }
        }

        /// <summary>
        /// Number of source object
        /// </summary>
        public object SourceNumber
        {
            get
            {
                return sourceNumber;
            }
            set
            {
                sourceNumber = value;
            }
        }

        /// <summary>
        /// Number of target object
        /// </summary>
        public object TargetNumber
        {
            get
            {
                return targetNumber;
            }
            set
            {
                targetNumber = value;
            }
        }

        #endregion

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return RootName + " (" + base.ToString() + ")";
        }

        #region INamedComponent Members

        /// <summary>
        /// Name
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }

        /// <summary>
        /// Kind
        /// </summary>
        public string Kind
        {
            get
            {
                return kind;
            }
        }

        /// <summary>
        /// Type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
        }

        /// <summary>
        /// Removes itself
        /// </summary>
        public void Remove()
        {
        }

        /// <summary>
        /// X - coordinate
        /// </summary>
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }

        /// <summary>
        /// Y - coordinate
        /// </summary>
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }

        /// <summary>
        /// Desktop
        /// </summary>
        public IDesktop Desktop
        {
            get
            {
                return desktop;
            }
            set
            {
                desktop = value;
            }
        }

        /// <summary>
        /// Order
        /// </summary>
        public int Ord
        {
            get
            {
                return StaticExtensionDiagramUI.GetOrder<object>(desktop.Components, this);
            }
        }

        /// <summary>
        /// Parent component
        /// </summary>
        public INamedComponent Parent
        {
            get
            {
                return parent;
            }
            set
            {
                parent = value;
            }
        }

        /// <summary>
        /// Gets root component
        /// </summary>
        /// <param name="desktop">Desktop of root</param>
        /// <returns>Root</returns>
        public INamedComponent GetRoot(IDesktop desktop)
        {
            return PureObjectLabel.GetRoot(this, desktop);
        }


        /// <summary>
        /// Gets component name relatively desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <returns>Relalive name</returns>
        public virtual string GetName(IDesktop desktop)
        {
            return PureObjectLabel.GetName(this, desktop);
        }

        /// <summary>
        /// Gets name relatively root
        /// </summary>
        public string RootName
        {
            get
            {
                return GetName(Desktop.Root);
            }
        }


        /// <summary>
        /// Root control
        /// </summary>
        public INamedComponent Root
        {
            get
            {
                return PureObjectLabel.GetRoot(this);
            }
        }


        #endregion

        #region Specific members



        /// <summary>
        /// Sets type
        /// </summary>
        public void SetType()
        {
            type = Arrow.GetType().ToString();
        }

        /// <summary>
        /// Sets types of collection
        /// </summary>
        /// <param name="c">The collection</param>
        public static void SetType(ICollection c)
        {
            foreach (PureArrowLabel l in c)
            {
                l.SetType();
            }
        }

        /// <summary>
        /// Sets labels
        /// </summary>
        /// <param name="c">Collection of arrows</param>
        static public void SetLabels(IEnumerable<IArrowLabel> c)
        {
            foreach (IArrowLabel l in c)
            {
                ICategoryArrow a = l.Arrow;
                a.SetAssociatedObject(l);
            }
        }



        void IDisposable.Dispose()
        {
            if (isDisposed)
            {
                return;
            }
            isDisposed = true;
            this.DisposeArrow();
        }

        
        #endregion


    }

}
