using CategoryTheory;
using DataPerformer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPerformer.Portable
{
    public class ObjectTransformerLink :  ICategoryArrow, IRemovableObject
    {
        IObjectTransformer target;

        IObjectTransformerConsumer source;

        object obj;

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ObjectTransformerLink()
        {
        }

 
        #endregion

        #region ICategoryArrow Members

        ICategoryObject ICategoryArrow.Source
        {
            get
            {
                return source as ICategoryObject;
            }
            set
            {
                source = value.GetSource<IObjectTransformerConsumer>();
            }
        }

        ICategoryObject ICategoryArrow.Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                target = value.GetTarget<IObjectTransformer>();
                source.Add(target);
            }
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

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            source.Remove(target);
        }

        #endregion
    }
}