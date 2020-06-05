using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;


using DataPerformer.Interfaces;

namespace Regression.Portable
{

    /// <summary>
    /// Link of selection
    /// </summary>
    public class SelectionLink : CategoryArrow, IRemovableObject
    {
        #region Fields



        /// <summary>
        /// Source
        /// </summary>
        private IStructuredSelectionConsumer source;

        /// <summary>
        /// Target
        /// </summary>
        private IStructuredSelectionCollection target;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SelectionLink()
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
                source = value.GetSource<IStructuredSelectionConsumer>();
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
                IStructuredSelectionCollection c =
                    value.GetTarget<IStructuredSelectionCollection>();
                /*              ICategoryObject s = c as ICategoryObject;
                              INamedComponent ns = s.Object as INamedComponent;
                              INamedComponent nt = value.Object as INamedComponent;
                              if (nt != null & ns != null)
                              {
                                  if (nt.Desktop == ns.Desktop)
                                  {
                                      if (nt.Ord >= ns.Ord)
                                      {
                                          throw new Exception(DataLink.SetProviderBefore);
                                      }
                                  }
                                  else
                                  {
                                      if (nt.Root.Ord >= ns.Root.Ord)
                                      {
                                          throw new Exception(DataLink.SetProviderBefore);
                                      }
                                  }
                              }*/
                target = c;
                source.Add(target);
            }
        }


        #endregion

        #region IRemovableObject Members

        /// <summary>
        /// The post remove operation
        /// </summary>
        public void RemoveObject()
        {
            source.Remove(target);
        }

        #endregion

    }
}
