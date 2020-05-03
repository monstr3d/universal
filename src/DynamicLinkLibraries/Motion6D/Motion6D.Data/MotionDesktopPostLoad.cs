using System;
using System.Collections.Generic;
using System.Text;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer;

using Motion6D.Portable;

namespace Motion6D
{
    /// <summary>
    /// Post load operation
    /// </summary>
    public class MotionDesktopPostLoad : DataDesktopPostLoad
    {

        #region Fields
        /// <summary>
        /// Singleton
        /// </summary>
        new public static readonly MotionDesktopPostLoad Object = new MotionDesktopPostLoad();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected MotionDesktopPostLoad()
        {
        }

        #endregion

        #region Overriden Members

        /// <summary>
        /// Post load operation
        /// </summary>
        /// <param name="desktop">The desktop for post load</param>
        public override void PostLoad(IDesktop desktop)
        {
            base.PostLoad(desktop);
            desktop.PostLoadPositions();
            RelativeMeasurements[] rm = desktop.GetAll<RelativeMeasurements>();
            foreach (IPostSetArrow p in rm)
            {
                p.PostSetArrow();
            }
            
        }

        #endregion
    }
}
