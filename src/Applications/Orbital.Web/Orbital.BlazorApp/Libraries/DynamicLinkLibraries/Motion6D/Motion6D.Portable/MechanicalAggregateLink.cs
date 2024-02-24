using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;
using Diagram.UI;
using Motion6D.Interfaces;

namespace Motion6D.Portable
{
    /// <summary>
    /// Link of mechanical aggregates
    /// </summary>
     public class MechanicalAggregateLink : CategoryArrow, 
        IAggregableMechanicalFactory, IRemovableObject
    {
        #region Fields

        /// <summary>
        /// Sinleton
        /// </summary>
        new static public readonly MechanicalAggregateLink Object = new MechanicalAggregateLink();

        /// <summary>
        /// List of links
        /// </summary>
        static private List<MechanicalAggregateLink> links = new List<MechanicalAggregateLink>();

 
        /// <summary>
        /// Number of connections
        /// </summary>
        protected int[] connection = new int[] { 0, 0 };

        /// <summary>
        /// Source object
        /// </summary>
        private IAggregableMechanicalObject source;

        /// <summary>
        /// Target object
        /// </summary>
        private IAggregableMechanicalObject target;

        /// <summary>
        /// Factory
        /// </summary>
        private static IAggregableMechanicalFactory factory = Object;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public MechanicalAggregateLink()
        {

        }

        #endregion

        #region ICategoryArrow Members

        /// <summary>
        /// The source of this arrow
        /// </summary>
        public override ICategoryObject Source
        {

            get
            {
                return source as ICategoryObject;
            }
            set
            {
                IAggregableMechanicalObject s = factory.GetObject(value);
                if (s == null)
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                if (s.Parent != null)
                {
                    throw new Exception("Parent");
                }
                source = s;
            }
        }

        /// <summary>
        /// The target of this arrow
        /// </summary>
        public override ICategoryObject Target
        {
            get
            {
                return target as ICategoryObject;
            }
            set
            {
                IAggregableMechanicalObject t = factory.GetObject(value);
                if (t == null)
                {
                    CategoryException.ThrowIllegalTargetException();
                }
                if (t == source)
                {
                    CategoryException.ThrowSourceTargetCoincidenceException();
                }
                target = t;
                target.Children[source] = connection;
                source.Parent = target;
                links.Add(this);
            }
        }

 
        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (links.Contains(this))
            {
                links.Remove(this);
            }
            source.Parent = null;
            target.Children.Remove(source);
        }

        #endregion

        #region IAggregableMechanicalFactory Members

        IAggregableMechanicalObject IAggregableMechanicalFactory.GetObject(object obj)
        {
            if (obj is IAssociatedObject)
            {
                IAssociatedObject ao = obj as IAssociatedObject;
                return ao.GetObject<IAggregableMechanicalObject>();
            }
            return null;
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// All links
        /// </summary>
        public static List<MechanicalAggregateLink> Links
        {
            get
            {
                List<MechanicalAggregateLink> l = new List<MechanicalAggregateLink>();
                l.AddRange(links);
                return l;
            }
        }

        /// <summary>
        /// Source object
        /// </summary>
        public IAggregableMechanicalObject SourceObject
        {
            get
            {
                return source;
            }
        }

        /// <summary>
        /// Target object
        /// </summary>
        public IAggregableMechanicalObject TargetObject
        {
            get
            {
                return target;
            }
        }

        /// <summary>
        /// Factory
        /// </summary>
        public static IAggregableMechanicalFactory Factory
        {
            get
            {
                return factory;
            }
            set
            {
                factory = value;
            }
        }


        /// <summary>
        /// Connection of source
        /// </summary>
        public int SourceConnection
        {
            get
            {
                return connection[0];
            }
            set
            {
                if (value < 0 | value >= source.NumberOfConnections)
                {
                    throw new Exception();
                }
                target.Children[source][0] = value;
                connection[0] = value;
            }
        }

        /// <summary>
        /// Connection of target
        /// </summary>
        public int TargetConnection
        {
            get
            {
                return connection[1];
            }
            set
            {
                if (value < 0 | value >= target.NumberOfConnections)
                {
                    throw new Exception();
                }
                target.Children[source][1] = value;
                connection[1] = value;

            }
        }




        #endregion

    }
}
