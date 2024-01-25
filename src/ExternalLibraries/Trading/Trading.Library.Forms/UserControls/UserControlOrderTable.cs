
using Diagram.Interfaces;
using System;
using System.Data;
using System.Windows.Forms;
using Trading.Library.Enums;
using Trading.Library.Forms.Interfaces;
using Trading.Library.Objects;
using WindowsExtensions;

namespace Trading.Library.Forms.UserControls
{
    public partial class UserControlOrderTable : UserControl, IOrderHolder
    {
        Order order;
        public UserControlOrderTable()
        {
            InitializeComponent();
        }

        Order IOrderHolder.Order
        {
            get => order;
            set
            {
                if (value == null) { return; }
                if (order != null) { throw new Exception("Order exists"); }
                order = value;
                running = value;
                Set();
                Disposed += UserControlOrderTable_Disposed;
            }
        }

        private void UserControlOrderTable_Disposed(object sender, EventArgs e)
        {
            running.Running -= Running;
            order.OrderChanged -= Order_OrderChanged;
        }

        IRunning running;

        void Set()
        {
            running.Running += Running;
            order.OrderChanged += Order_OrderChanged;
        }


        private void Order_OrderChanged(Order arg, PositionDirection direction)
        {
            this.InvokeIfNeeded(OrderChanged, arg, direction);
        }

        void OrderChanged(Order arg, PositionDirection direction)
        {
            if (direction != PositionDirection.Closed) return;
            var enter = DateTime.FromOADate(order.EnterDate).ToString();
            var exit = DateTime.FromOADate(order.ExitDate).ToString();
            dataGridView.Rows.Add(enter, exit,
                order.EnterPrice.ToString(), order.ExitPrice.ToString(),
                order.ClosedIncome.ToString(), 
                order.ClosedPositionType == PositionType.Long);
        }

        private void Running(IRunning run, bool arg)
        {
            if (arg)
            {
                var a = () => dataGridView.Rows.Clear();
                this.InvokeIfNeeded(a);
            }
        }
    }
}
