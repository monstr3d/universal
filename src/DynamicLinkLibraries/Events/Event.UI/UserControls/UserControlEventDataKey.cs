using BaseTypes;
using BaseTypes.CodeCreator.Interfaces;
using Diagram.UI;
using Diagram.UI.UserControls;
using ErrorHandler;
using Event.Interfaces;
using Event.Portable.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Event.UI.UserControls
{
    public partial class UserControlEventDataKey : UserControl
    {
        #region Fields

        ITypeCreator typeCreator = new BaseTypes.CSharp.CSTypeCreator();

        UserControlEventDataFull parent;



        ForcedEventData forced;

        List <Tuple<string, string?, object>> types = new();

        event Action<List<Tuple<string, string?, object>>> onChange = (List<Tuple<string, string?, object>> types) => { };

        #endregion

        #region Ctor

        public UserControlEventDataKey()
        {
            InitializeComponent();
            columnUp.ValueType = typeof(KeyboardHMI.Key);
            columnUp.DataSource = Enum.GetValues<KeyboardHMI.Key>();
            columnDown.ValueType = typeof(KeyboardHMI.Key);
            columnDown.DataSource = Enum.GetValues<KeyboardHMI.Key>();
            columnType.ValueType = typeof(EnumType);
            columnType.DataSource = Enum.GetValues<EnumType>();
        }


        #endregion


        #region Public Members


        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ForcedEventData Forced
        {
            set
            {
                forced = value;
                Types = GetTypes();

 /*               userControlTypeList.Types = value.Types;
                userControlTypeList.OnChange += (List<Tuple<string, object>> types) =>
                { value.Types = types; };
                ForcedChange();
                forced.OnChangeTypes += ForcedChange;
                propertyGridValues.PropertyValueChanged += (object s, PropertyValueChangedEventArgs e) =>
                { forced.Force(); };*/
            }
        }


        /// <summary>
        /// Types
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<Tuple<string, string?, object>> Types
        {
            get
            {
                Get();
                return types;
            }
            set
            {
                types = value;
                Set();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object[] Data

        {
            get;
            set;
        } = new object[0];

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object[] Input
        {
            get;
            set;
        } = new object[0];


        /// <summary>
        /// On change event
        /// </summary>
        public event Action<List<Tuple<string, string?, object>>> OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region Private Membrers

        void Set()
        {
            foreach (Tuple<string, string?, object> t in types)
            {
                dataGridView.Rows.Add(new object[] { t.Item1, t.Item2, t.Item2.ToEnumType() });
            }
        }

        void Get()
        {
            try
            {
                if (parent == null)
                {
                    parent = this.FindParent<UserControlEventDataFull>();
                }
                if (parent == null)
                {
                    return;
                }
                List<Tuple<string, string?, object>> types = new List<Tuple<string, string?, object>>();
                var ini = new List<object>();
                var d = new List<object>();
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    object type = row.Cells[2].Value;
                    object val = row.Cells[0].Value;
                    object val1 = row.Cells[1].Value;
                    if ((type == null) | (val == null))
                    {
                        continue;
                    }
                    string s = null;
                    if (val1 != null)
                    {
                        s = val1.ToString();
                    }
                    var tt = ((EnumType)type).ToType();
                    ini.Add(typeCreator.GetDefaultValue(tt));
                    d.Add(typeCreator.GetDefaultValue(tt));
                    Tuple<string, string?, object> t = new Tuple<string, string?, object>(val + "", s,  tt);
                    types.Add(t);
                }
                this.types = types;
                Data = d.ToArray();
                Input = ini.ToArray();
                onChange(this.types);
                parent.UpdateAll();
            }
            catch (Exception exception)
            {
                exception.HandleException();
                return;
            }
        }

        List<Tuple<string, string?, object>> GetTypes()
        {

            var kb = StaticExtensionEventInterfaces.Keyboard;
            var l = new List<Tuple<string, string?, object>>();
            var ini = new List<object>();
            var d = new List<object>();
            foreach (var t in forced.Types)
            {
                var k = t.Item1;
                if (!k.StartsWith(kb))
                {
                    continue;

                }
                var ss = new string[] { null, null };
                var sss = k.Substring(kb.Length);
                var ssss = sss.Split('_');
                for (int i = 0; i < ssss.Length; i++)
                {
                    ss[i] = ssss[i];
                }
                var type = t.Item2;
                l.Add(new Tuple<string, string?, object>(ss[0], ss[1], type));
            }
            return l;
        }


        #endregion


        #region Event Handlers

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            Get();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            Get();
        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            Get();
        }

        #endregion
    }
}
