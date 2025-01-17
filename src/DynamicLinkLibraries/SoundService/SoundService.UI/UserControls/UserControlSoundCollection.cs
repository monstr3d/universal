using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Diagram.UI;
using Diagram.UI.UserControls;
using Diagram.UI.Utils;
using ErrorHandler;

namespace SoundService.UI.UserControls
{
    public partial class UserControlSoundCollection : UserControl
    {

        #region Fields

        SoundCollection sounds;

        private event Action accept = () => { };

        #endregion

        #region Ctor

        public UserControlSoundCollection()
        {
            InitializeComponent();

        }

        #endregion

        #region Own Members

        internal event Action OnAccept
        {
            add { accept += value; }
            remove { accept -= value; }
        }

        internal SoundCollection SoundCollection
        {
            set
            {
                sounds = value;
                numericUpDown.Value = sounds.Sounds.Count;
            }
        }

        internal void Post()
        {
            FillCombo();
            numericUpDown.ValueChanged += numericUpDown_ValueChanged;
        }

        private void FillCombo()
        {
            int n = (int)numericUpDown.Value;
            UserControlComboboxList[] ll = new UserControlComboboxList[]
                {
                    userControlComboboxListFile, userControlComboboxListMea
                };
            List<string> em = new List<string>();
            for (int i = 0; i < n; i++)
            {
                em.Add("");
            }
            string[] arr = em.ToArray();
            foreach (UserControlComboboxList l in ll)
            {
                l.Count = n;
                l.Texts = arr;
           }
            string[] files = System.IO.Directory.GetFiles(StaticExtensionSoundService.SoundDirectory);

            List<string> filesn = new List<string>();
            foreach (string f in files)
            {
                filesn.Add(System.IO.Path.GetFileName(f));
            }
            userControlComboboxListFile.Fill(filesn);
            userControlComboboxListMea.Fill(sounds.Sources);
            int j = 0;
            Dictionary<string, string> d = sounds.Sounds;
            foreach (string key in d.Keys)
            {
                userControlComboboxListMea.Boxes[j].SelectCombo(key);
                userControlComboboxListFile.Boxes[j].SelectCombo(d[key]);
                ++j;
                if (j == n)
                {
                    break;
                }
            }
        }

        void Accept()
        {
            try
            {
                accept();
                Dictionary<string, string> d = sounds.Sounds;
                d.Clear();
                int n = (int)numericUpDown.Value;
                for (int i = 0; i < n; i++)
                {
                    d[userControlComboboxListMea.Boxes[i].SelectedItem + ""] =
                        userControlComboboxListFile.Boxes[i].SelectedItem + "";
                }
            }
            catch (Exception e)
            {
                e.ShowError(1);
            }
        }

        #endregion

        #region Event Handlers

        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            FillCombo();
        }



        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Accept();
        }


        #endregion

    }
}
