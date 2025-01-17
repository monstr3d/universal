using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using ErrorHandler;

namespace Diagram.UI.Labels
{
	/// <summary>
	/// 
	/// </summary>
	internal class ChildObjectLabel : Panel, IChildObjectLabel
	{
		static private readonly int width = 10;
		static private readonly int height = 10;
		static private readonly Color back = Color.Black;
		private INamedComponent nc;
		private ContainerObjectLabel parent;
		private int x;
		private int y;
		private Form form;


		internal ChildObjectLabel(ContainerObjectLabel parent, string name, INamedComponent nc, object[] o)
		{
			this.nc = nc;
			Height = height;
			Width = width;
			BackColor = back;
			ToolTip t = new ToolTip();
			t.ShowAlways = true;
			t.SetToolTip(this, name + " :: " + o[2]);
			x = (int) o[0];
			y = (int) o[1];
			this.parent = parent;
			parent.Parent.Controls.Add(this);
			move();
			MouseUp += new MouseEventHandler(onMouseUpShow) + new MouseEventHandler(onMouseUpArrow);
			MouseDown += new MouseEventHandler(onMouseDownMoveEventHandler);
			MouseMove += new MouseEventHandler(onMouseMoveArrow);

		}


		#region Specific Members

		internal void move()
		{
			Left = parent.Left + x;
			Top = parent.Top + y;
		}

		internal void remove()
		{
			RemoveForm();
			PanelDesktop desktop = Parent as PanelDesktop;
            if (desktop != null)
            {
                desktop.remove(this);
            }
            if (nc != null)
            {
                nc.Remove();
            }
		}

		public void RemoveForm()
		{
			if (form != null)
			{
                if (!form.IsDisposed)
				{
					form.Dispose();
				}
				form = null;
				GC.Collect();
			}
		}

		/// <summary>
		/// The on mouse up event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onMouseUpShow(object sender, MouseEventArgs e)
		{

			if (e.Button != MouseButtons.Right)
			{
				return;
			}
			ShowForm();
		}

		/// <summary>
		/// Shows form
		/// </summary>
        public void ShowForm()
		{
			PanelDesktop desktop = Parent as PanelDesktop;
            bool init = false;
            try
            {
                if (form == null)
                {
                    form = desktop.Tools.Factory.CreateForm(nc) as Form;
                    init = true;
                }
                if (form != null)
                {
                    if (form.IsDisposed)
                    {
                        form = desktop.Tools.Factory.CreateForm(nc) as Form;
                        init = true;
                    }
                    if (init)
                    {
                        form.FormClosing += (object sender, FormClosingEventArgs e) =>
                        {
                            form.Prepare();
                        };
                        if (form is IUpdatableForm)
                        {
                            (form as IUpdatableForm).UpdateFormUI();
                        }
                        Action<Form> act = StaticExtensionDiagramUIForms.PostFormLoad;
                        if (act != null)
                        {
                            act(form);
                        }
                    }
                    form.Show();
                    form.BringToFront();
                    form.Activate();
                    form.Focus();
                    form.Show();
                }
           }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
		}

        /// <summary>
        /// The on mouse up event handler
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event arguments</param>
        protected void onMouseUpArrow(object sender, MouseEventArgs e)
		{
			//isMoved = false;
			PanelDesktop desktop = Parent as PanelDesktop;
			ICategoryArrow arrow = desktop.ActiveArrow;
            if (!StaticExtensionDiagramUIForms.IsArrowClick(e))
			{
				return;
			}
			if (!(nc is IObjectLabel))
			{
				return;
			}
			IObjectLabel ol = nc as IObjectLabel;
			ICategoryObject obj = ol.Object;
			try
			{
				if (arrow == null)
				{
					return;
				}
				int x = Left + e.X;
				int y = Top + e.Y;
				for (int i = 0; i < desktop.Controls.Count; i++)
				{
					if (!(desktop.Controls[i] is ChildObjectLabel) & !(desktop.Controls[i] is ObjectLabel))
					{
						continue;
					}
					Control c = desktop.Controls[i];
					bool hor = x < c.Left | x > c.Left + c.Width;
					bool vert = y < c.Top | y > c.Top + c.Height;
					if (hor | vert)
					{
						continue;
					}
					IObjectLabel label = null;
					if (desktop.Controls[i] is IObjectLabel)
					{
						label = desktop.Controls[i] as IObjectLabel;
					}
					else
					{
						ChildObjectLabel child = desktop.Controls[i] as ChildObjectLabel;
						label = child.Label;
					}
					arrow.Target = label.Object;
					ArrowLabel lab = 
                        desktop.Tools.Factory.CreateArrowLabel(desktop.Tools.Active, 
                        arrow, ol, label) as ArrowLabel;
					lab.Arrow.Object = lab;
					desktop.AddArrowLabel(lab);
					break;
				}
			}
			catch (Exception ex)
			{
                ex.ShowError(10);
                if (arrow != null)
				{
					if (arrow is IDisposable d)
					{
						d.Dispose();
					}
				}
                ex.ShowError(1);
			}
			desktop.ActiveArrow = null;
			desktop.Redraw();
		}

		public IObjectLabel Label
		{
			get
			{
				if (nc is IObjectLabel)
				{
					return nc as IObjectLabel;
				}
				return null;
			}
		}

		/// <summary>
		/// The on mouse down event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onMouseDownMoveEventHandler(object sender, MouseEventArgs e)
		{
            if (!e.IsArrowClick())
			{
				return;
			}
			IObjectLabel lab = Label;
			if (lab == null)
			{
				return;
			}
			PanelDesktop desktop = Parent as PanelDesktop;
			PaletteButton active = desktop.Tools.Active;
			if (active != null)
			{
				if (active.IsArrow & !(active.ReflectionType == null))
				{
					try
					{
						ICategoryArrow arrow = desktop.Tools.Factory.CreateArrow(active);
						arrow.Source = lab.Object;
						desktop.ActiveArrow = arrow;
						desktop.ActiveObjectLabel = lab;
						return;
					}
					catch (Exception ex)
					{
                        ex.ShowError(10);
 					}
				}
			}
		}

		/// <summary>
		/// The on mouse move event handler
		/// Draws correspond arrows
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		protected void onMouseMoveArrow(object sender, MouseEventArgs e)
		{
			PanelDesktop desktop = Parent as PanelDesktop;
            if (!e.IsArrowClick())
			{
				return;
			}
			if (desktop.ActiveArrow == null)
			{
				return;
			}
			desktop.DrawArrow(this, e);
		}






		#endregion

 
        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            StaticExtensionDiagramUIForms.Action(form, type, actionType);
        }

        #endregion
    }
}
