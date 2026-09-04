using System;
using System.Collections.Generic;

using CategoryTheory;
using Diagram.UI.Interfaces;
using ErrorHandler;
using Motion6D.Interfaces;
using NamedTree.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Serializable position
    /// </summary>
    public class SerializablePosition : Position,  ICategoryObject,
       IPostSetArrow, IProperties, IAllowCodeCreation, IChildren<ICategoryObject>
    {

        #region Fields

        CategoryTheory.Performer performer = new();


        /// <summary>
        /// Associated object
        /// </summary>
        protected object obj;

        protected object properties;

        private byte[] bytes;

        ICategoryObject[] objects = new ICategoryObject[1];

        /// <summary>
        /// Allows code creation
        /// </summary>
        protected bool allowCodeCreation = false;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SerializablePosition()
            : base()
        {
        }

 
        #endregion

        #region IAssociatedObject Members

        object IAssociatedObject.Object
        {
            get
            {
                return obj;
            }
            set
            {
                obj = value;
            }
        }

        #endregion

        #region IAllowCodeCreation Members

        bool IAllowCodeCreation.AllowCodeCreation => allowCodeCreation;

        #endregion

        #region IChildren<ICategoryObject>
        IEnumerable<ICategoryObject> IChildren<ICategoryObject>.Children => objects;

        event Action<ICategoryObject> IChildren<ICategoryObject>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<ICategoryObject> IChildren<ICategoryObject>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        void IChildren<ICategoryObject>.AddChild(ICategoryObject child)
        {
        }

        void IChildren<ICategoryObject>.RemoveChild(ICategoryObject child)
        {
        }

        #endregion


        #region Overriden Members

        /// <summary>
        /// Overriden to string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return this.ObjectArrowName() + base.ToString() + ")";
        }

        /// <summary>
        /// Position parameters
        /// </summary>
        public override object Parameters
        {
            get
            {
                return base.Parameters;
            }
            set
            {
                base.Parameters = value;
                if (value is ICategoryObject co)
                {
                    objects[0] = co;
                }
                SetObject();
                if (Parameters is IPositionObject)
                {
                    IPositionObject po = Parameters as IPositionObject;
                    po.Position = this;
                }
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            object o = Parameters;
            SetObject();
            /*          if (o != null)
                      {
                          if (o is IPostSetArrow)
                          {
                              IPostSetArrow p = o as IPostSetArrow;
                              p.PostSetArrow();
                          }
                      }*/
        }

        #endregion

        #region IProperties Members

        object IProperties.Properties { get => Properties; set => Properties = value; }
        protected virtual object Properties { get => properties; set => properties = value; }
        string INamed.Name { get => performer.GetAssociatedName(this); set => throw new OwnNotImplemented("Position"); }

        #endregion

        #region Specific Members

        void SetObject()
        {
            object o = Parameters;
            if (o == null)
            {
                return;
            }
            if (o is IPositionObject)
            {
                IPositionObject po = o as IPositionObject;
                po.Position = this;
            }
        }

        #endregion
    }
}