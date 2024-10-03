using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Configuration.Assemblies;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;

namespace DataPerformer.UI
{
	/// <summary>
	/// Panel for reflection of arrow
	/// </summary>
	public class ArrowPanel : System.Windows.Forms.Panel
	{
		private readonly string[] texts = new string[]{"Source", "Target"};
		private IObjectLabel[] objects;
		private int y = 0;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="source">Arrow source</param>
        /// <param name="target">Arrow target</param>
		public ArrowPanel(IObjectLabel source, IObjectLabel target)
		{
			objects = new IObjectLabel[2];
			objects[0] = source;
			objects[1] = target;
			initialize();
		}
		
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theLabel">The arrow label</param>
		public ArrowPanel(IArrowLabel theLabel)
		{
			PictureBox box = new PictureBox();
			box.Left = 5;
			box.Top = y + 5;
			Image im = theLabel.GetImage();
			box.Width = im.Width;
			box.Height = im.Height;
			box.Image = im;
			Controls.Add(box);
			Label label = new Label();
			label.Top = box.Top;
			label.Left = box.Left + box.Width + 5;
			label.Text = theLabel.RootName;//NamedComponent.GetText(theLabel);
			Controls.Add(label);
			objects = new IObjectLabel[2];
			objects[0] = theLabel.Source;
			objects[1] = theLabel.Target;
			y = box.Top + box.Height;
			Name = theLabel.RootName;//NamedComponent.GetText(theLabel) + "";
			initialize();

		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theLabel">The arrow label</param>
        /// <param name="source">Arrow source</param>
        /// <param name="target">Arrow target</param>
        public ArrowPanel(IArrowLabel theLabel, IObjectLabel source, IObjectLabel target)
		{
			PictureBox box = new PictureBox();
			box.Left = 5;
			box.Top = y + 5;
			box.Width = 50;
			box.Height = 50;
			box.Image = theLabel.GetImage();
			Controls.Add(box);
			Label label = new Label();
			label.Top = box.Top;
			label.Left = box.Left + box.Width + 5;
			label.Text = theLabel.RootName;//NamedComponent.GetText(theLabel);
			Controls.Add(label);
			objects = new IObjectLabel[2];
			objects[0] = source;
			objects[1] = target;
			y = box.Top + box.Height;
			Name = label.Text + "";
			initialize();

		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="theObject">Base object</param>
        /// <param name="source">Arrow source</param>
        /// <param name="target">Arrow target</param>
        public ArrowPanel(IObjectLabel theObject, IObjectLabel source, IObjectLabel target)
		{
		
			PictureBox box = new PictureBox();
			box.Left = 5;
			box.Top = y + 5;
			Image im = theObject.GetImage();
			box.Width = im.Width;
			box.Height = im.Height;
			box.Image = im;
			Controls.Add(box);
			Label label = new Label();
			label.Top = box.Top;
			label.Left = box.Left + box.Width + 5;
			label.Text = theObject.RootName;//NamedComponent.GetText(theObject);
			Controls.Add(label);
			objects = new IObjectLabel[2];
			objects[0] = source;
			objects[1] = target;
			y = box.Top + box.Height;
			initialize();

		}

		/// <summary>
		/// Initialization
		/// </summary>
		private void initialize()
		{
			Width = 300;
			Height = 100;
			for (int i = 0; i < 2; i++)
			{
				Label label = new Label();
				label.Top = y + 5;
				label.Left = 5;
				label.Text = texts[i];
				int yy = label.Top + label.Height;
				Controls.Add(label);
				PictureBox box = new PictureBox();
				Image im = objects[i].GetImage();
				box.Width = im.Width;
				box.Height = im.Height;
				box.Left = 5;
				box.Top = yy + 5;
				box.Image = im;
				Controls.Add(box);
				Label labelObj = new Label();
				labelObj.Top = box.Top;
				labelObj.Left = box.Left + box.Width + 5;
				string text = objects[i].RootName;//NamedComponent.GetText(objects[i]) + "";
				labelObj.Text = text;
				Controls.Add(labelObj);
				y = 5 + box.Top + box.Height;
			}
			Height = y;
		}
	}



}
