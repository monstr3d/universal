using System;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;

using DataPerformer.UI.Interfaces;
using DataPerformer.UI.UserControls;

namespace DataPerformer.UI.Forms
{
    /// <summary>
    /// Editor of properties of Graph component
    /// </summary>
    public partial class FormGraph : Form, IUpdatableForm, IStartStop
    {

        #region Fields
   
        Labels.GraphLabel label;

        IObjectLabel l;

        UserControlGraph child;

        #endregion

        #region Ctor

        private FormGraph()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lab">Parent graph label</param>
        public FormGraph(Labels.GraphLabel lab)
            : this()
        {
            child = new UserControlGraph(false);
            this.label = lab;
            l = lab;
            UpdateFormUI();
            child.Dock = DockStyle.Fill;
            panelGraph.Controls.Add(child);
         }

        #endregion

        #region IUpdatableForm Members

        /// <summary>
        /// Updates form UI
        /// </summary>
        public void UpdateFormUI()
        {
            Text = l.RootName;
        }

        #endregion

        #region IStartStop Members

        void IStartStop.Action(object type, ActionType actionType)
        {
            IStartStop ss = label;
            ss.Action(type, actionType);
        }

        #endregion
 

        private void FormGraph_Load(object sender, EventArgs e)
        {
            DataConsumer dc = (label as IObjectLabel).Object as DataConsumer;
            child.ParentLabel = label;
            (child as IGraphLabel).Data = (label as IGraphLabel).Data;
            child.Set(dc, (label as IGraphLabel).Data);
            child.Post();
            
            /*    child.TimeUnit = lab.timeType;
                child.IsAbsuluteTime = absoluteTime;
                child.ChangeAbsoluteTime += (bool b) => { absoluteTime = b; };
                child.ChangeTimeUnit += (TimeType tt) => { timeType = tt; };*/
            //  return child;

        }

     
        private void FormGraph_FormClosing(object sender, FormClosingEventArgs e)
        {
            child.Parent.Controls.Remove(child);
            child.Dispose();

        }
    }
}