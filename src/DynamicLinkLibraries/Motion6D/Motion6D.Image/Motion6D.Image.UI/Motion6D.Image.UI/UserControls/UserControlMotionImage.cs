using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BitmapConsumer;
using Diagram.UI;

namespace Motion6D.Image.UI.UserControls
{
    public partial class UserControlMotionImage : UserControl
    {
        #region Fields

        MotionImageFigure figure;

        #endregion

        public UserControlMotionImage()
        {
            InitializeComponent();
        }


        internal MotionImageFigure Figure
        {
            set
            {
                figure = value;

            }
        }

        void SetList()
        {
            List<string> l = (figure as IBitmapConsumer).GetProviders().ToList();
            for (int i = 0; i < userControlComboboxList.Count; i++)
            {
                userControlComboboxList.Boxes[i].Items.Clear();
            }
            userControlComboboxList.Fill(l);
        }

        internal void Post()
        {
            string[] texts = figure.TextureKeys.ToArray();
            userControlComboboxList.Count = texts.Length;
            userControlComboboxList.Texts = texts;
            List<string> l = (figure as IBitmapConsumer).GetProviders().ToList();
            userControlComboboxList.Fill(l);
            userControlComboboxList.Dictionary = figure.TextureDictionary;
            userControlComboboxList.OnSelect += ()
                =>
            { figure.TextureDictionary = userControlComboboxList.Dictionary; };
            (figure as IBitmapConsumer).AddRemove += 
                (IBitmapProvider p, bool b) => { SetList(); };
        }

        void Open()
        {
            try
            {
          try
            {
                if (openFileDialogFigure.ShowDialog(this) != DialogResult.OK)
                {
                    return;
                }
                figure.Load(openFileDialogFigure.FileName);
            }
            catch (Exception ex)
            {
                ex.ShowError(1);
            }
 
            }
            catch (Exception e)
            {
                e.ShowError(10);
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            Open();
        }
    }
}
