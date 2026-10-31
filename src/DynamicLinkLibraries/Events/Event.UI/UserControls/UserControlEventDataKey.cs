using BaseTypes;
using BaseTypes.CodeCreator.Interfaces;
using Diagram.UI;
using ErrorHandler;
using Event.Interfaces;
using Event.Portable.Events;
using KeyboardHMI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace Event.UI.UserControls
{
    public partial class UserControlEventDataKey : UserControl
    {
        #region Fields

        bool disposed = false;

        Control desktop;

        KeyboardEvent keyboardEvent;

        ITypeCreator typeCreator = new BaseTypes.CSharp.CSTypeCreator();

        ForcedEventData forced;

        List<Tuple<string, string?, object>> types = new();

        event Action<List<Tuple<string, string?, object>>> onChange = (List<Tuple<string, string?, object>> types) => { };

        #endregion

        #region Ctor

        public UserControlEventDataKey()
        {
            InitializeComponent();
            columnUp.ValueType = typeof(Key);
            columnUp.DataSource = Enum.GetValues<Key>();
            columnDown.ValueType = typeof(Key);
            columnDown.DataSource = Enum.GetValues<Key>();
            columnType.ValueType = typeof(EnumType);
            columnType.DataSource = Enum.GetValues<EnumType>();
            dataGridView.Columns.Clear();
            dataGridView.Rows.Clear();
            dataGridView.Columns.AddRange(new DataGridViewColumn[] { columnUp, columnDown, columnType });
            Disposed += UserControlEventDataKey_Disposed;
        }

        private void UserControlEventDataKey_Disposed(object sender, EventArgs e)
        {
            Disp();
        }

        private void Disp()
        {
            if (disposed) return;
            disposed = true;
            forced.OnEnable -= Start;
            //    dataGridView.CellEndEdit -= dataGridView_CellValueChanged;
            dataGridView.RowsAdded -= dataGridView_RowsAdded;
            dataGridView.RowsRemoved -= dataGridView_RowsRemoved;

        }


        #endregion


        #region Public Members

        DataGridViewRow GetRow(int i)
        {
            if (i < dataGridView.Rows.Count)
            {
                return dataGridView.Rows[i];
            }
            return new DataGridViewRow();
        }



        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ForcedEventData Forced1
        {
            set
            {
                forced = value;
                keyboardEvent = new KeyboardEvent(value);
                value.OnEnable += Start;
                var kb = StaticExtensionEventInterfaces.Keyboard;
                var types = value.Types;
                int j = 0;
                try
                {
                    for (var i = 0; i < types.Count; i++)
                    {
                        var item = types[i];
                        var name = item.Item1;
                        var type = item.Item2.ToEnumType();
                        if (!name.StartsWith(kb))
                        {
                            continue;
                        }
                        var row = GetRow(j);
                        ++j;
                        row.Tag = item;
                        var nn = name.Substring(kb.Length).Split("_");
                        var key = nn[0].ToKeyType();
                        row.Cells[0].Value = key;
                        if (nn.Length > 1)
                        {
                            key = nn[1].ToKeyType();
                            row.Cells[1].Value = key;
                        }
                        row.Cells[2].Value = type;
                        if (!dataGridView.Rows.Contains(row))
                        {
                            dataGridView.Rows.Add(row);
                        }
                    }
                }
                catch (Exception e)
                {
                    e.HandleException();
                }
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal ForcedEventData Forced
        {
            set
            {
                forced = value;
                keyboardEvent = new KeyboardEvent(value);
                value.OnEnable += Start;
                var kb = StaticExtensionEventInterfaces.Keyboard;
                var types = value.Types;
                var j = 0;
                try
                {
                    for (var i = 0; i < types.Count; i++)
                    {
                        var item = types[i];
                        var o = Get(item);
                        if (o != null) 
                        {
                            var row = dataGridView.Rows.Add(o);
       /*                     for (var k = 0; k < row.Cells.Count; k++)
                            {
                                row.Cells[k].Value = o[k];
                            }*/
                            ++j;
                        }
                    }
                }
                catch (Exception e)
                {
                    e.HandleException();
                }
            }
        }



        object[] Get(Tuple<string, object> value)
        {
            var kb = StaticExtensionEventInterfaces.Keyboard;
            var o = new object[3];
            var name = value.Item1;
            o[2] = value.Item2.ToEnumType();
            if (!name.StartsWith(kb))
            {
                return null;
            }
            var nn = name.Substring(kb.Length).Split("_");
            var key = StaticExtensionKeyBoard.ToKeyType(nn[0]);
            o[0] = key;
            if (nn.Length > 1)
            {
                key = StaticExtensionKeyBoard.ToKeyType(nn[1]);
                o[1] = key;
            }
            return o;
        }

        private void Start(bool b)
        {
            desktop = this.FindParent<PanelDesktop>();
            keyboardEvent.Prepare();
            keyboardEvent.Set(desktop, b);

        }

        private void DataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
      /*      var row = dataGridView.Rows[e.RowIndex];
            var tag = row.Tag;
            if (tag == null)
            {
                var val = row.Cells[2].Value;
                if (val == null)
                {
                    return;
                }
                var et = (EnumType)val;
                var type = et.ToType();
                val = row.Cells[0].Value;

                if (val == null)
                {
                    return;
                }
                var kt = (Key)val;
                var s = StaticExtensionEventInterfaces.Keyboard + kt.KeyToSrting();
                val = row.Cells[1].Value;
                if (val != null)
                {
                    kt = (Key)val;
                    s += "_" + kt.KeyToSrting();
                }
                var types = forced.Types;
                types.Add(new Tuple<string, object>(s, type));
                forced.Types = types;
                return;
            }*/
        }

        private void DataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
      /*      var row = dataGridView.Rows[e.RowIndex];
            var tag = row.Tag;
            if (tag == null)
            {
                var val = row.Cells[2].Value;
                if (val == null)
                {
                    return;
                }
                var et = (EnumType)val;
                var type = et.ToType();
                val = row.Cells[0].Value;

                if (val == null)
                {
                    return;
                }
                var kt = (Key)val;
                var s = StaticExtensionEventInterfaces.Keyboard + kt.KeyToSrting();
                val = row.Cells[1].Value;
                if (val != null)
                {
                    kt = (Key)val;
                    s += "_" + kt.KeyToSrting();
                }
                var types = forced.Types;
                types.Add(new Tuple<string, object>(s, type));
                forced.Types = types;
                return;
            }*/
        }

        private void DataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
         /*   var row = dataGridView.Rows[e.RowIndex];
            var tag = row.Tag;
            if (tag == null)
            {
                var val = row.Cells[2].Value;
                if (val == null)
                {
                    return;
                }
                var et = (EnumType)val;
                var type = et.ToType();
                val = row.Cells[0].Value;

                if (val == null)
                {
                    return;
                }
                var kt = (Key)val;
                var s = StaticExtensionEventInterfaces.Keyboard + kt.KeyToSrting();
                val = row.Cells[1].Value;
                if (val != null)
                {
                    kt = (Key)val;
                    s += "_" + kt.KeyToSrting();
                }
                var types = forced.Types;
                types.Add(new Tuple<string, object>(s, type));
                forced.Types = types;
                return;
            }*/
        }



        #endregion

        #region Private Membrers

        void Get()
        {
            try
            {
                var kb = StaticExtensionEventInterfaces.Keyboard;

                /*              var ini = new List<object>();
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
                              parent.UpdateAll();*/
            }
            catch (Exception exception)
            {
                exception.HandleException();
                return;
            }
        }



        #endregion


        #region Event Handlers

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
    /*        var row = dataGridView.Rows[e.RowIndex];
            var tag = row.Tag;
            if (tag == null)
            {
                var val = row.Cells[2].Value;
                if (val == null)
                {
                    return;
                }
                var et = (EnumType)val;
                var type = et.ToType();
                val = row.Cells[0].Value;

                if (val == null)
                {
                    return;
                }
                var kt = (Key)val;
                var s = StaticExtensionEventInterfaces.Keyboard + kt.KeyToSrting();
                val = row.Cells[1].Value;
                if (val != null)
                {
                    kt = (Key)val;
                    s += "_" + kt.KeyToSrting();
                }
                var types = forced.Types;
                types.Add(new Tuple<string, object>(s, type));
                forced.Types = types;
                return;
            }*/

        }


        Tuple<string, object> Get(DataGridViewRow row)
        {
            var val = row.Cells[2].Value;
            if (val == null)
            {
                return null;
            }
            var et = (EnumType)val;
            var type = et.ToType();
            val = row.Cells[0].Value;
            if (val == null)
            {
                return null;
            }
            var kt = (Key)val;
            var s = StaticExtensionEventInterfaces.Keyboard + kt.KeyToSrting();
            val = row.Cells[1].Value;
            if (val != null)
            {
                kt = (Key)val;
                s += "_" + kt.KeyToSrting();
            }
            return new Tuple<string, object>(s, type);

        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (Disposing)
            {
                return;
            }

        }

        private void dataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {

      /*      var row = dataGridView.Rows[e.RowIndex];
            var tag = row.Tag;
            if (tag == null)
            {
                return;
            }
            var item = tag as Tuple<string, object>;
            var types = forced.Types;
            types.Remove(item);
            forced.Types = types;*/

        }

        void Save()
        {
            var l = new List<Tuple<string, object>>();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var t = Get(row);
                if (t != null)
                {
                    l.Add(t);
                }
            }
            var lt = new List<Tuple<string, object>>();
            foreach (var t in forced.Types)
            {
                if (!t.Item1.StartsWith(StaticExtensionEventInterfaces.Keyboard))
                {
                    lt.Add(t);
                }
            }
            lt.AddRange(l);
            forced.Types = lt;
        }

        #endregion

        private void toolStripButtonSave_Click(object sender, EventArgs e)
        {
            Save();
        }
    }
}
