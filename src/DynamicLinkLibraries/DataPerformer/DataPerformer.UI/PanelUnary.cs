using System;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Configuration.Assemblies;
using System.Collections;
using System.Drawing;
using System.ComponentModel;
using System.Xml;


using CategoryTheory;
using Diagram.UI.Labels;

using BaseTypes.Interfaces;


using FormulaEditor;
using FormulaEditor.Interfaces;
using FormulaEditor.UI;


namespace DataPerformer.UI
{
    /// <summary>
    /// Panel for unary element
    /// </summary>
	public class PanelUnary : Panel
	{
		private IObjectOperation operation;
		private IObjectLabel label;
		private ComboBox cb = new ComboBox();

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="operation">Operation</param>
        /// <param name="w">Width</param>
		public PanelUnary(IObjectOperation operation, int w)
		{
			Width = w;
			this.operation = operation;
			ICategoryObject o = operation as ICategoryObject;
			label = o.Object as IObjectLabel;
			PictureBox p = new PictureBox();
			p.Image = NamedComponent.GetImage(label);
			int y = 10;
			int x = 10;
			p.Left = x;
			p.Top = y;
			Controls.Add(p);
			y += p.Height + 10;
			Label lab = new Label();
			lab.Text = label.RootName;//NamedComponent.GetText(label) + "";
			lab.Left = x;
			lab.Top = y;
			Controls.Add(lab);
			y += lab.Height + 10;
			cb.Top = y;
			cb.Left = x;
			Controls.Add(cb);
			y += cb.Height + 10;
			Height = y;
		}

        /// <summary>
        /// Fills comboboxes
        /// </summary>
        /// <param name="list">List of indexes</param>
		public void FillComboBoxes(ArrayList list)
		{
			cb.Items.Clear();
			cb.Text = "";
			foreach (int i in list)
			{
				cb.Items.Add(i);
			}
		}

        /// <summary>
        /// Fills number
        /// </summary>
        /// <param name="n">Maximal nunber</param>
		public void FillNumber(int n)
		{
			for (int i = 0; i < n; i++)
			{
				cb.Items.Add(i);
			}
		}

        /// <summary>
        /// Fills tabe
        /// </summary>
        /// <param name="table">The table</param>
		public void FillTable(Hashtable table)
		{
			if (cb.SelectedIndex < 0)
			{
				return;
			}
			int i = (int)cb.SelectedItem;
			if (table.ContainsKey(i))
			{
				throw new Exception("Item already exists");
			}
			table[i] = operation;
		}

        /// <summary>
        /// Fills names of unaries
        /// </summary>
        /// <param name="table">Table of unaries</param>
		public void FillUnaryNames(Hashtable table)
		{
			if (cb.SelectedIndex < 0)
			{
				return;
			}
			int i = (int)cb.SelectedItem;
			if (table.ContainsKey(i))
			{
				throw new Exception("Item already exists");
			}
			ICategoryObject ob = operation as ICategoryObject;
			IObjectLabel l = ob.Object as IObjectLabel;
			table[i] = l.Name;
		}

        /// <summary>
        /// Sets comboboxes by table
        /// </summary>
        /// <param name="table">The table</param>
		public void SetComboBoxes(Hashtable table)
		{
			string name = label.RootName;//NamedComponent.GetText(label) + "";
			if (!table.ContainsValue(name))
			{
				return;
			}
			int n = 0;
			foreach (int i in table.Keys)
			{
				if (table[i].Equals(name))
				{
					n = i;
					break;
				}
			}
			for (int i = 0; i < cb.Items.Count; i++)
			{
				if (n == (int)cb.Items[i])
				{
					cb.SelectedIndex = i;
					return;
				}
			}
		}

        /// <summary>
        /// Name of panel
        /// </summary>
		new public string Name
		{
			get
			{
				return label.RootName;//NamedComponent.GetText(label) + "";
			}
		}

	}

}
