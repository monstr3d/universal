using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Configuration.Assemblies;
using System.Threading;
using System.Xml.Serialization;
using System.Xml;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;
using ErrorHandler;




namespace Diagram.UI
{
	/// <summary>
	/// Pair of objects
	/// </summary>
	public class ObjectsPair : IObjectsPair
	{
		/// <summary>
		/// Distance between arrow labels
		/// </summary>
		const double DISTANCE = 40;

		/// <summary>
		/// The objects
		/// </summary>
		private IObjectLabel[] objects;

		/// <summary>
		/// List of arrows between objects
		/// </summary>
		private ArrayList arrows = new ArrayList();

		/// <summary>
		/// The desktop
		/// </summary>
		private PanelDesktop desktop;

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="l1">First object</param>
		/// <param name="l2">Second object</param>
		public ObjectsPair(IObjectLabel l1, IObjectLabel l2)
		{
			objects = new IObjectLabel[]{l1, l2};
		}

		/// <summary>
		/// The i - th object
		/// </summary>
		public IObjectLabel this[int i]
		{
			get
			{
				return objects[i];
			}
		}

		/// <summary>
		/// Checks whether object belongs to this pair
		/// </summary>
		/// <param name="label">The object label</param>
		/// <returns>True if belongs and false otherwise</returns>
		public bool Belongs(IObjectLabel label)
		{
			return (label == objects[0]) | (label == objects[1]);
		}
		
		/// <summary>
		///  Checks whether two objects belong to this pair
		/// </summary>
		/// <param name="l1">The label of first object</param>
		/// <param name="l2">The label of second object</param>
		/// <returns>True if belong and false otherwise</returns>
		public bool Belongs(IObjectLabel l1, IObjectLabel l2)
		{
			return Belongs(l1) & Belongs(l2);
		}

		
		
		/// <summary>
		/// Checks whether arrow belongs to this pair
		/// </summary>
		/// <param name="l">The arrow label</param>
		/// <returns>True if belongs and false otherwise</returns>
		public bool Belongs(IArrowLabel l)
		{
			return Belongs(l.Source) & Belongs(l.Target);
		}

		/// <summary>
		/// Adds arrow to this pair
		/// </summary>
		/// <param name="label">The label of arrow to add</param>
		public void Add(IArrowLabelUI label)
		{
            label.Pair = this;
			arrows.Add(label);
		}

		/// <summary>
		/// Removes label from pair
		/// </summary>
		/// <param name="label">The label to remove</param>
		public void Remove(IArrowLabelUI label)
		{
			arrows.Remove(label);
			try
			{
				desktop.Tools.RemoveArrowNode(label);
			}
			catch (Exception ex)
			{
                ex.ShowError(10);
            }
		}

		/// <summary>
		/// Refreshs this pair
		/// </summary>
		public void Refresh()
		{
			if (arrows.Count == 0)
			{
				desktop.Remove(this);
			}
		}

		/// <summary>
		/// Clears selection
		/// </summary>
		public void ClearSelection()
		{
			foreach (IArrowLabelUI lab in arrows)
			{
				lab.Selected = false;
			}
		}

		/// <summary>
		/// Updates arrows forms
		/// </summary>
		public void UpdateForms()
		{
			for (int i = 0; i < arrows.Count; i++)
			{
				IArrowLabelUI lab = arrows[i] as IArrowLabelUI;
				lab.UpdateForm();
			}
		}

		/// <summary>
		/// The desktop
		/// </summary>
		public PanelDesktop Desktop
		{
			set
			{
				desktop = value;
			}
		}
		
		/// <summary>
		/// Removes itself
		/// </summary>
		public void Remove()
		{
			foreach (IArrowLabelUI label in arrows)
			{
                label.RemoveFromComponent();
                label.RemoveForm();
 
               // label.RemoveFromComponent();
			//	label.RemoveForm();
				desktop.Tools.RemoveArrowNode(label);
				if (label.Arrow is IDisposable d)
				{
					d.Dispose();
				}
			}
			arrows = null;
			desktop.Remove(this);
			GC.Collect();
		}

		/// <summary>
		/// Draws all arrows of this pair
		/// </summary>
		/// <param name="g">The graphics to draw</param>
        public void SetArrows(Graphics g)
        {
            object[] arrs = arrows.ToArray();
            int n = arrs.Length;
            int xs = 0;
            int ys = 0;
            int xt = 0;
            int yt = 0;
            Control p = null;
            if (objects[0] is Panel | objects[0] is UserControl)
            {
                p = objects[0] as Control;
            }
            else
            {
                p = ContainerPerformer.GetPanel(objects[0]) as Control;
            }
            xs = p.Left + p.Width / 2;
            ys = p.Top + p.Height / 2;
            if (objects[1] is Panel | objects[1] is UserControl)
            {
                p = objects[1] as Control;
            }
            else
            {
                p = ContainerPerformer.GetPanel(objects[1]) as Control;
            }
            if (p == null)
            {
                return;
            }
            xt = p.Left + p.Width / 2;
            yt = p.Top + p.Height / 2;
            int xc = (xt + xs) / 2;
            int yc = (yt + ys) / 2;
            int dx = (xt - xs) / 2;
            int dy = (yt - ys) / 2;
            double d = Math.Sqrt((double)(dx * dx + dy * dy));
            double px = -DISTANCE * ((double)dy) / d;
            double py = DISTANCE * ((double)dx) / d;
            int posX = xc - (int)((n - 1) * px / 2);
            int posY = yc - (int)((n - 1) * py / 2);
            for (int i = 0; i < n; i++)
            {
                IArrowLabelUI lab = arrs[i] as IArrowLabelUI;
                Control control = lab.Control as Control;
                lab.X = posX + i * (int)px - control.Width / 2;
                lab.Y = posY + i * (int)py - control.Height / 2;
                if (g == null)
                {
                    continue;
                }
                lab.Draw(g);
            }
        }

		/// <summary>
		/// Checks whether object belongs to this pair
		/// </summary>
		/// <param name="label">The object label</param>
		/// <returns>True if belongs and false otherwise</returns>
		internal bool belongs(IChildObjectLabel label)
		{
			return (label.Label == objects[0]) | (label.Label == objects[1]);
		}
	}
}
