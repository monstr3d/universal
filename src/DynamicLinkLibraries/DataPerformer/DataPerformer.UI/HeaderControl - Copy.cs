using System;
using System.Windows.Forms;
using System.Collections;

//using SpatialUI;
using Diagram.UI;
using DataPerformer;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.UserControls;

using DataPerformer.Interfaces;


namespace DataPerformer.UI
{
    /// <summary>
    /// Control for headers of measurements
    /// </summary>
	public class HeaderControl
	{
        /// <summary>
        /// Global header
        /// </summary>
		protected static HeaderControl header;

        /// <summary>
        /// Gets header control
        /// </summary>
        /// <param name="cons">Data consumer</param>
        /// <param name="mea">Measurements</param>
        /// <returns>Header control</returns>
		public virtual Control GetHeaderControl(IDataConsumer cons, IMeasurements mea)
		{
            Control c = null;// GetHeaderControlStatic(cons, mea);
            IAssociatedObject ob = cons as IAssociatedObject;
            IAssociatedObject o = mea as IAssociatedObject;
            if (c == null)
			{
                return new UserControlObject(ob.Object as IObjectLabel, o.Object as IObjectLabel);
			}
			return c;
		}

        /// <summary>
        /// Crates header control
        /// </summary>
        /// <param name="b">Base object</param>
        /// <param name="ao">Associasted object</param>
        /// <returns>The header control</returns>
        static public Control GetHeaderControl(IAssociatedObject b, IAssociatedObject ao)
        {
            return new UserControlObject(b.Object as IObjectLabel, ao.Object as IObjectLabel);

        }


       /* static protected Control GetHeaderControlStatic(IDataConsumer cons, IMeasurements mea)
		{
			IAssociatedObject o = mea as IAssociatedObject;
            IAssociatedObject ob = cons as IAssociatedObject;
            /*if (o is FormulaDataConsumer)
            {
                FormulaDataConsumer fdc = o as FormulaDataConsumer;
                return new FormulaControl(fdc);
            }*/
        /*    return GetHeaderControl(ob, o);
		}*/

        /// <summary>
        /// Global header
        /// </summary>
        public static HeaderControl Object
		{
			get
			{
				return header;
			}
			set
			{
				header = value;
			}
		}
	}
}