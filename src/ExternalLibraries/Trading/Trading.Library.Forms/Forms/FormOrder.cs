using DataPerformer.Portable;
using Diagram.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Trading.Library.Forms.Interfaces;
using Trading.Library.Forms.Labels;
using Trading.Library.Objects;

namespace Trading.Library.Forms.Forms
{
    public partial class FormOrder : Form, IUpdatableForm
    {
        IObjectLabel label;

        OrderLabel orderLabel { get; set; }

        Order order;

        public FormOrder(IObjectLabel label, Order order)
        {
            InitializeComponent();

            this.label = label;
            this.order = order;
            var c = this.FindChildren<IOrderHolder>();
            foreach (IOrderHolder holder in c)
            {
                holder.Order = order;
            }
            if (label is OrderLabel)
            {
                orderLabel = (OrderLabel)label;
            }
            else if (label is Control)
            {
                var control = (Control)label;
                orderLabel = control.FindChildObject<OrderLabel>();
            }
            if (orderLabel != null)
            {
                WindowState = (FormWindowState)orderLabel.StateOfWindow;
            }
            UpdateFormUI();
            Disposed += FormOrder_Disposed;
        }

        private void FormOrder_Disposed(object sender, EventArgs e)
        {
            if (orderLabel == null)
            {
                return;
            }
            int i = (int)WindowState;
            orderLabel.StateOfWindow = i;
        }

        public void UpdateFormUI()
        {
            Text = label.Name;
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            if (orderLabel != null)
            {
                this.SetNamedComponentHolder(orderLabel);
            }
            Action<IPostSet> act = (p) =>  p.Post();
            this.Execute(act);


        }
    }
}
