using System;
using System.Windows.Forms;

using Diagram.UI.Interfaces;
using Diagram.UI.Utils;

using DataPerformer.Portable;

using Trading.Library.Forms.Interfaces;
using Trading.Library.Objects;

namespace Trading.Library.Forms.UserControls
{
    public partial class UserControlOrder : UserControl, IPostSet, IOrderHolder
    {
        Order order;

    
        public UserControlOrder()
        {
            InitializeComponent();
            Disposed += UserControlOrder_Disposed;
            
        }

        private void UserControlOrder_Disposed(object sender, EventArgs e)
        {
            order.OnChangeInput -= Order_OnChangeInput;
        }



        internal Order Order
        {
            get => order;
            set
            {
                if (value == null)
                {
                    return;
                }
                if (order != null)
                {
                    throw new Exception();
                }
                order = value;
                order.OnChangeInput += Order_OnChangeInput;
           }
        }

        Order IOrderHolder.Order
        {
            get => order;
            set
            {
                Order = value;
                (this as IPostSet).Post();
            }
        }

        void SetEventHandlers()
        {
            userControlComboboxListCond.Boxes[0].SelectedValueChanged += (o, e) =>
            {
                var obj = userControlComboboxListCond.Boxes[0].GetSelectedString();
                if (obj != null)
                {
                    order.Position = obj.ToString();
                }
            };
            userControlComboboxListCond.Boxes[1].SelectedIndexChanged += (o, e) =>
            {
                var obj = userControlComboboxListCond.Boxes[2].GetSelectedString();
                if (obj != null)
                {
                    order.SellPrice = obj.ToString();
                }
            };
            userControlComboboxListCond.Boxes[2].SelectedValueChanged += (o, e) =>
            {
                var obj = userControlComboboxListCond.Boxes[2].GetSelectedString();
                if (obj != null)
                {
                    order.BuyPrice = obj.ToString();
                }
            };
            userControlComboboxListCond.Boxes[3].SelectedValueChanged += (o, e) =>
            {
                var obj = userControlComboboxListCond.Boxes[3].GetSelectedString();
                if (obj != null)
                {
                    order.Date = obj.ToString();
                }
            };

        }

        void FillBoxes()
        {
            var  str = order.GetAllMeasurements((double)0);
            for (var i = 0; i < userControlComboboxListCond.Count; i++)
            {
                
                userControlComboboxListCond.Boxes[i].FillCombo(str);
            }
            SelectCombo();
        }

        void SelectCombo()
        {
            order.OnChangeInput -= Order_OnChangeInput;
            userControlComboboxListCond.Boxes[0].SelectCombo(order.Position);
            userControlComboboxListCond.Boxes[1].SelectCombo(order.SellPrice);
            userControlComboboxListCond.Boxes[2].SelectCombo(order.BuyPrice);
            userControlComboboxListCond.Boxes[3].SelectCombo(order.Date);
            order.OnChangeInput += Order_OnChangeInput;
        }

        void IPostSet.Post()
        {
            FillBoxes();
            SetEventHandlers();
        }

        private void Order_OnChangeInput()
        {
            FillBoxes();
        }
    }
}