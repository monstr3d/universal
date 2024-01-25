using IBApi;
using IBSampleApp.Wrappers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IBSampleApp.ui
{
    public partial class FormAdditionalOptions : Form
    {

        #region Fields

        private IBSampleAppDialog parent;

        private readonly Dictionary<HistoryWriteState, string> dHistory =
            new Dictionary<HistoryWriteState, string>()
            {
            { HistoryWriteState.Active, "Written"},
            { HistoryWriteState.Stopping, "Stopping"},
            { HistoryWriteState.Stopped, "Write History"}
                };

        #endregion

        internal FormAdditionalOptions(IBSampleAppDialog parent)
        {
            InitializeComponent();
            this.parent = parent;
            StaticExtensionIBApi.HistoryWriteStateEvent += Indicate;
        }

        private void toolStripMenuWtriteHistory_Click(object sender, EventArgs e)
        {
            parent.WriteHisory();
        }



        private void indicate()
        {
            toolStripMenuWtriteHistory.Text = dHistory[StaticExtensionIBApi.HistoryWriteState];
        }

        private void Indicate(HistoryWriteState state)
        {
            if (IsDisposed)
            {
                return;
            }
            this.InvokeIfNeeded(indicate);
        }

        private void gAGRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.ibClient.Add(new EWrapper[] { new BacktestingWrapper() });
            parent.HistData();
        }

        private void backtestingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.ibClient.Add(new EWrapper[]
            {
                new HistoryReatimeWrapper(Strategy1.Instance)
            }
            );
            DefaultOrderManager.Instance.Set();
            parent.HistData();

        }

        private void saveAllHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaticExtensionIBSample.SaveAllHistoryData();
        }
    }
}
