using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows.Forms;

using Diagram.UI;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Event.Portable.Objects.BufferedData;

using DataPerformer.UI.Objects;

using WindowsExtensions;

namespace DataPerformer.UI.BufferedData.UserControls
{
    /// <summary>
    /// User control of buffer reader cadr
    /// </summary>
    public partial class UserControlBufferReadWriteCadr : UserControl
    {

        #region Fields

        internal BufferReadWrite buffer;

        AutoResetEvent ev = new AutoResetEvent(false);

        DisassemblyWrapper wrapper;

        IndicatorWrapper indicatorWrapper = new IndicatorWrapper();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlBufferReadWriteCadr()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal void ShowIndicators()
        {
            UserControlBufferReadWrite uc = this.FindParent<UserControlBufferReadWrite>();
            buffer = uc.buffer;
            Labels.BufferReadWriteLabel l = this.FindParent<Labels.BufferReadWriteLabel>();
            Dictionary<string, IMeasurement> mm = buffer.Measurements;
            indicatorWrapper.Show(buffer, mm.Values, l.sizes);
        }

        #endregion

        #region Private Members

        bool Next()
        {
            ev.Set(); 
            return true;
        }

        void FillTypes()
        {
            UserControlBufferReadWrite uc = this.FindParent<UserControlBufferReadWrite>();
            uc.buffer.WriteTypes();
        }

        bool Stop(object obj)
        {
            ev.WaitOne();
            ShowList();
            ev.WaitOne();
            ShowList();
            return false;
        }

        void Run()
        {
            buffer.Perform(Stop);
        }

        void ShowList()
        {
            this.InvokeIfNeeded(() => 
            {
                indicatorWrapper.UpdateIndicators();
                listView.Set(wrapper.Dictionary);
            });
        }

        void Set(bool b)
        {
            toolStripButtonForward.Enabled = b;
            toolStripButtonPlusType.Enabled = !b;
        }

        #endregion

        #region Event handlers

        private void toolStripButtonPlusType_Click(object sender, EventArgs e)
        {
            UserControlBufferReadWrite uc = this.FindParent<UserControlBufferReadWrite>();
            buffer = uc.buffer;
            FillTypes();
            Set(true);
            Dictionary<string, IMeasurement> mm = buffer.Measurements;
            wrapper = new DisassemblyWrapper(mm.Keys, buffer,
                StaticExtensionDataPerformerUI.Disassembly);
            backgroundWorkerRun.RunWorkerAsync();
        }

        private void toolStripButtonForward_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void backgroundWorkerRun_DoWork(object sender, DoWorkEventArgs e)
        {
            UserControlBufferReadWrite uc = this.FindParent<UserControlBufferReadWrite>();
            buffer = uc.buffer;
            buffer.Perform(Stop);
            this.InvokeIfNeeded(() => { Set(false); });
        }

        #endregion

    }
}
