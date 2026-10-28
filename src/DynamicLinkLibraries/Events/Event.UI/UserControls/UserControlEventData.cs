using Diagram.UI;
using Diagram.UI.PropertyEditors;
using Event.Basic.Data.Events;
using Event.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

 

        #endregion

        #region Event handlers


        private void ForcedChange()
        {
            var kb = StaticExtensionEventInterfaces.Keyboard;
            var types = forced.Types;
            var l = new List<int>();
            var i = 0;
            
            foreach (var t in types)
            {
                var k = t.Item1;
                if (!k.StartsWith(kb))
                {
                    l.Add(i);
               }
                ++i;
            }
            var d = l.ToArray();
            propertyGridInitial.SetArrayEditor(types,  forced.Initial, d);
            propertyGridValues.SetArrayEditor(types, forced.Data, d);
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
