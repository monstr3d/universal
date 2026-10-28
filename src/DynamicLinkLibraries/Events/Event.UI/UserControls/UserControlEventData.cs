using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using Diagram.UI;

using Event.Basic.Data.Events;
using Event.Interfaces;

namespace Event.UI.UserControls
{
    /// <summary>
    /// User control for event + data
    /// </summary>
    public partial class UserControlEventData : UserControl
    {
        #region Fields

        ForcedEventData forced;

        UserControlEventDataFull parent;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal List<Tuple<string, object>> Types
        {  get; set; } = new List<Tuple<string, object>>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlEventData()
        {
            InitializeComponent();
            parent = this.FindParent<UserControlEventDataFull>();
        }

        #endregion

        #region Internal Membres

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ForcedEventData Forced
        {
            set
            {
                forced = value;
                userControlTypeList.Types = GetTypes();
                userControlTypeList.OnChange += (List<Tuple<string, object>> types) =>
                    {
                        Types = userControlTypeList.Types;
                        parent.UpdateAll();
                    };
                ForcedChange();
                forced.OnChangeTypes += ForcedChange;
                propertyGridValues.PropertyValueChanged += (object s, PropertyValueChangedEventArgs e) =>
                    { forced.Force(); };
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal object[] Initial
        {
            get;
            set;
        } = new object[0];



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal object[] Data
        {
            get;
            set;
        } = new object[0];


        #endregion

        #region Event handlers


        private void ForcedChange()
        {
            var kb = StaticExtensionEventInterfaces.Keyboard;
            var i = 0;
            var ini = new List<object>();
            var d = new List<object>();
            var l = new List<Tuple<string, object>>();
            foreach (var t in forced.Types)
            {
                var k = t.Item1;
                if (!k.StartsWith(kb))
                {
                    l.Add(t);
                    ini.Add(forced.Initial[i]);
                    d.Add(forced.Data[i]);
                }
                ++i;
            }
            Initial = ini.ToArray();
            Data = d.ToArray();
            propertyGridInitial.SetArrayEditor(l, Initial);
            propertyGridValues.SetArrayEditor(l, Data);
        }

        #endregion

        #region Private

        List<Tuple<string, object>> GetTypes()
        {

            var kb = StaticExtensionEventInterfaces.Keyboard;
            var l = new List<Tuple<string, object>>();
            foreach (var t in forced.Types)
            {
                var k = t.Item1;
                if (!k.StartsWith(kb))
                {
                    l.Add(t);
                }
            }
            return l;
        }

        #endregion

    }
}
