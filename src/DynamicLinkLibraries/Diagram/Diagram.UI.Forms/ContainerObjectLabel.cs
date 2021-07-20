using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;

using CategoryTheory;

using MathGraph;

using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

namespace Diagram.UI.Labels
{
	/// <summary>
	/// Object label of container
	/// </summary>
	public class ContainerObjectLabel : ObjectLabel, IContainerObjectLabel
	{
		private ArrayList inter = new ArrayList();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="button">Associated button</param>
		public ContainerObjectLabel(IPaletteButton button) : base(button)
		{
			Move += new EventHandler(onMove);
			type = button.Type;
		}

		#region Specific Members

		/// <summary>
		/// Overriden to string
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return RootName + " (" + base.ToString() + ")";
		}

		/// <summary>
		/// Expands children
		/// </summary>
		public void Expand()
		{
 			IObjectContainer cont = Object as IObjectContainer;
            cont.Load();
            cont.PostLoad();
            if (cont is ICategoryObject)
            {
                ICategoryObject ca = cont as ICategoryObject;
                ca.Object = this;
            }
 			Dictionary<string,object> table = cont.Interface;
			foreach (string name in table.Keys)
			{
				INamedComponent c = cont[name];
				object[] o = table[name] as object[];
				ChildObjectLabel l = new ChildObjectLabel(this, name, c, o);
				inter.Add(l);
                ContainerPerformer.Children[c as IObjectLabel] = l;
			}
 		}

        /// <summary>
        /// Removes itself
        /// </summary>
        /// <param name="formRemove">The "Remove Form" sign</param>
        public override void Remove(bool formRemove)
		{
			base.Remove(formRemove);
			foreach (ChildObjectLabel l in inter)
			{
				l.remove();
                ContainerPerformer.Children.Remove(l.Label);
			}
		}


		private void onMove(object sender, EventArgs e)
		{
/*			if (!isMoved)
			{
				return;
			}*/
			foreach (ChildObjectLabel l in inter)
			{
				l.move();
			}
		}
		#endregion
	}
}
