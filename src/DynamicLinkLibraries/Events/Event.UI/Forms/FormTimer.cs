using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Labels;

using Event.Interfaces;
using NamedTree.Interfaces;

namespace Event.UI.Forms
{
    public partial class FormTimer : Form, IUpdatableForm
    {
        ITimerEvent timer;
         
        public FormTimer()
        {
            InitializeComponent();
        }

        internal FormTimer(ITimerEvent timer) :
            this()
        {
            this.timer = timer;
            userControlTimer.Timer = timer;
        }

        void IUpdatableForm.UpdateFormUI()
        {
            IObjectLabel l = (timer as IAssociatedObject).Object as IObjectLabel;
            if (l != null)
            {
                Text = l.RootName;
            }
        }

    }
}
