using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

namespace Diagram.UI
{
    /// <summary>
    /// Container of objects
    /// </summary>
    /// </summary>
    public class ObjectContainerPortable : CategoryObject, IObjectContainer, IPostSetArrow
    {


        #region Fields


        /// <summary>
        /// Interface
        /// </summary>
        protected Dictionary<string, object> inter = new Dictionary<string, object>();

   
        /// <summary>
        /// Type
        /// </summary>
        protected string type;

     
        /// <summary>
        /// Child desktop
        /// </summary>
        protected PureDesktop desktop = new PureDesktop();

        /// <summary>
        /// The "is loaded" sign
        /// </summary>
        protected bool isLoaded = false;

        /// <summary>
        /// The "is post loaded" sign
        /// </summary>
        protected bool isPostLoaded = false;



        #endregion


        #region Constructors

        /// <summary>
        /// Main constructor
        /// </summary>
        /// <param name="desktop">The parent desktop</param>
        protected ObjectContainerPortable(PureDesktop desktop)
        {
            this.desktop = desktop;
        }


        #endregion

        #region IPostSetArrow Members

        public virtual void PostSetArrow()
        {
     //       Load();
     //       PostLoad();
        }

        #endregion

        #region IObjectCollection Members

        string[] IObjectCollection.Names
        {
            get { return desktop.GetNames(); }
        }

        object IObjectCollection.this[string name]
        {
            get
            {
                return desktop.GetObject(name);
            }
        }

        #endregion

        #region IComponentCollection Members

        IEnumerable<object> IComponentCollection.AllComponents
        {
            get { return desktop.AllComponents; }
        }

        #endregion

        #region Public Members

        public virtual IDesktop LoadDesktop()
        {
            return desktop;
        }

        /// <summary>
        /// The desktop
        /// </summary>
        public IDesktop Desktop
        {
            get
            {
                return desktop;
            }
        }

        /// <summary>
        /// The interface
        /// </summary>
        public Dictionary<string, object> Interface
        {
            get
            {
                return inter;
            }
        }


        /// <summary>
        /// Loads itself
        /// </summary>
        /// <returns>True in success</returns>
        public virtual bool Load()
        {
            if (isLoaded)
            {
                return false;
            }
            isLoaded = true;
            desktop.HasParent = true;
            LoadProtected();
            return true;
        }

        /// <summary>
        /// The post load operation
        /// </summary>
        public virtual bool PostLoad()
        {
            if (!isLoaded)
            {
                return false;
            }
            if (isPostLoaded)
            {
                return true;
            }
            isPostLoaded = true;
            return desktop.PostLoad();
        }

        /// <summary>
        /// Gets relative name of component
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The relative name</returns>
        public string GetName(INamedComponent comp)
        {
            return comp.GetName(desktop);
        }

        /// <summary>
        /// All child objects
        /// </summary>
        public ICollection<object> AllObjects
        {
            get
            {
                return desktop.GetAllObjects();
            }
        }

        /// <summary>
        /// The type
        /// </summary>
        public string Type
        {
            get
            {
                return type;
            }
            set
            {
                type = value;
            }
        }

        /// <summary>
        /// Access to child by name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The child</returns>
        public INamedComponent this[string name]
        {
            get
            {
                return desktop[name];
            }
        }




        #endregion


        #region Public Members

        /// <summary>
        /// Sets parents of objects
        /// </summary>
        /// <param name="desktop">The desktop</param>
        public void SetParents(IDesktop desktop)
		{
			IEnumerable<IObjectLabel> objs = desktop.Objects;
			INamedComponent comp = null;
			foreach (IObjectLabel ol in objs)
			{
				if (ol.Object == this)
				{
					comp = ol;
					break;
				}
			}
			IEnumerable<object> objects = this.desktop.Components;
			foreach (INamedComponent nc in objects)
			{
				if (nc is IObjectLabel)
				{
					IObjectLabel l = nc as IObjectLabel;
					if (l.Object is IObjectContainer)
					{
						IObjectContainer oc = l.Object as IObjectContainer;
                        oc.Desktop.SetParents();
					}
				}
				nc.Parent = comp;
			}
		}


        #endregion

        #region Protected Members

        /// <summary>
        /// Protected load
        /// </summary>
        protected void LoadProtected()
        {
            foreach (INamedComponent nc in desktop.Components)
            {
                if (nc.Parent == null)
                {
                    nc.Parent = Object as INamedComponent;
                }
                nc.Desktop = desktop;
            }
            desktop.setParent(this);
        }

        #endregion

    }
}
