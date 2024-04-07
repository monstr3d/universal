using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.WebGenerator.UserControls
{
    public partial class UserControGeneratorSummary : UserControl
    {
        Saver saver;

        TextBox[] texts;

        CheckBox[] checkboxes;

        public UserControGeneratorSummary()
        {
            InitializeComponent();
            userControlEditListClassNamespase.Types =
                [typeof(TextBox), typeof(TextBox), typeof(CheckBox), typeof(CheckBox),
           typeof(CheckBox) ];
            texts = [userControlEditListClassNamespase[0] as TextBox, userControlEditListClassNamespase[1] as TextBox];
            var l = new List<CheckBox>();
            for (int i = 2; i < 5; i++)
            {
                l.Add(userControlEditListClassNamespase[i] as CheckBox);
            }
            checkboxes = l.ToArray();
        }


        internal Saver Saver
        {
            set { saver = value; Set(); }
        }

        void Set()
        {
            texts[0].Text = saver.Namespace;
            texts[1].Text = saver.Classname;
            checkboxes[0].Checked = saver.MVC;
            checkboxes[1].Checked = saver.Blazor;
            checkboxes[2].Checked = saver.DateTime;

        }

        internal void Get()
        {
            saver.Namespace = texts[0].Text;
            saver.Classname = texts[1].Text;
            saver.MVC = checkboxes[0].Checked;
            saver.Blazor = checkboxes[1].Checked;
            saver.DateTime = checkboxes[2].Checked;
        }


    }
}
