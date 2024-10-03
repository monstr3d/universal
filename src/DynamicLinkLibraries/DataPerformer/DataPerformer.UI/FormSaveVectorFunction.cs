using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace DataPerformer.UI
{
	/// <summary>
	/// Summary description for FormSaveVectorFunction.
	/// </summary>
	public class FormSaveVectorFunction : Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.MenuStrip mainMenu1Form;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.ToolStripMenuItem menuItemSave;
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
			this.mainMenu1Form = new System.Windows.Forms.MenuStrip();
			this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemSave = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialogArray = new System.Windows.Forms.SaveFileDialog();
			// 
			// mainMenu1Form
			// 
			this.mainMenu1Form.Items.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																						  this.menuItemFile});
			// 
			// menuItemFile
			// 
			this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripMenuItem[] {
																						 this.menuItemSave});
			this.menuItemFile.Text = "File";
			// 
			// menuItemSave
			// 
			this.menuItemSave.Text = "Save as";
			this.menuItemSave.Click += new System.EventHandler(this.menuItemSave_Click);
			// 
			// FormSaveVectorFunction
			// 
			this.ClientSize = new System.Drawing.Size(648, 389);
			this.MainMenuStrip = this.mainMenu1Form;
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
