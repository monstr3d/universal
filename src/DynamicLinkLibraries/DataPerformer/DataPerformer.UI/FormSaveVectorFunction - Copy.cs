using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

using DataPerformer;
using DataPerformer.Interfaces;

namespace DataPerformer.UI
{
	/// <summary>
	/// Summary description for FormSaveVectorFunction.
	/// </summary>
	public class FormSaveVectorFunction : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MainMenu mainMenu1Form;
		private System.Windows.Forms.MenuItem menuItemFile;
		private System.Windows.Forms.MenuItem menuItemSave;
		private System.Windows.Forms.SaveFileDialog saveFileDialogArray;
		private DoubleArrayFunction function;

		private FormSaveVectorFunction()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="o">Input</param>
        public FormSaveVectorFunction(object[] o)
            : this()
		{
            this.LoadResources();
            //IMeasure m = o[2] as IMeasure;
            Text = o[0] + "";
            function = o[1] as DoubleArrayFunction;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu1Form = new System.Windows.Forms.MainMenu();
			this.menuItemFile = new System.Windows.Forms.MenuItem();
			this.menuItemSave = new System.Windows.Forms.MenuItem();
			this.saveFileDialogArray = new System.Windows.Forms.SaveFileDialog();
			// 
			// mainMenu1Form
			// 
			this.mainMenu1Form.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						  this.menuItemFile});
			// 
			// menuItemFile
			// 
			this.menuItemFile.Index = 0;
			this.menuItemFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																						 this.menuItemSave});
			this.menuItemFile.Text = "File";
			// 
			// menuItemSave
			// 
			this.menuItemSave.Index = 0;
			this.menuItemSave.Text = "Save as";
			this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
			// 
			// FormSaveVectorFunction
			// 
			this.ClientSize = new System.Drawing.Size(648, 389);
			this.Menu = this.mainMenu1Form;
			this.Name = "FormSaveVectorFunction";
			this.Text = "FormSaveVectorFunction";

		}
		#endregion

		private void menuItemSave_Click(object sender, System.EventArgs e)
		{
			if (saveFileDialogArray.ShowDialog(this) != DialogResult.OK)
			{
				return;
			}
			if (File.Exists(saveFileDialogArray.FileName))
			{
				File.Delete(saveFileDialogArray.FileName);
			}
			Stream stream = File.OpenWrite(saveFileDialogArray.FileName);
			BinaryFormatter f = new BinaryFormatter();
			f.Serialize(stream, function);
			stream.Close();
		}
	}
}
