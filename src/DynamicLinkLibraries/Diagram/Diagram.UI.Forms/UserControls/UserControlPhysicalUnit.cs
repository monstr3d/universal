using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;


using BaseTypes.Attributes;
using BaseTypes.Interfaces;

namespace Diagram.UI.UserControls
{
    /// <summary>
    /// Editor of physical unit attribute
    /// </summary>
    public partial class UserControlPhysicalUnit : UserControl
    {
        #region Fields

        PhysicalUnitTypeAttribute attribute;

        IPhysicalUnitTypeAttribute physicalUnitObject;

        static private List<PropertyInfo> props = new List<PropertyInfo>();

        static internal readonly List<Dictionary<string, object>> StringUnitDictionary =
           new List<Dictionary<string, object>>
           {
                new Dictionary<string, object>()
                {
                    { "Radian", AngleType.Radian},
                    {  "Degree", AngleType.Degree},
                    {  "Circle", AngleType.Circle}
             },
             new Dictionary<string, object>()
             {

                    { "Meter", LengthType.Meter},
                    {"Centimeter", LengthType.Centimeter},
                   {"Kilometer", LengthType.Kilometer}
             },
             new Dictionary<string, object>()
             {
                { "Second", TimeType.Second},
                { "Day", TimeType.Day}
             },
             new Dictionary<string, object>()
             {
                 { "Kilogram", MassType.Kilogram},
                 { "Gram", MassType.Gram}
               }
            };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlPhysicalUnit()
        {
            InitializeComponent();
            List<ComboBox> boxes = userControlComboboxList.Boxes;
            for (int i = 0; i < boxes.Count; i++)
            {
                List<object> l = new List<object>();
                Tuple<PropertyInfo, List<object>> t =
                    new Tuple<PropertyInfo, List<object>>(props[i], l);
                ComboBox b = boxes[i];
                b.Tag = t;
                Dictionary<string, object> d = StringUnitDictionary[i];
                foreach (string s in d.Keys)
                {
                    b.Items.Add(s);
                    l.Add(d[s]);
                }
            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Phisical unit object
        /// </summary>
        public IPhysicalUnitTypeAttribute PhysicalUnitObject
        {
            get
            {
                return physicalUnitObject;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                physicalUnitObject = value;
                this.Attribute = value.PhysicalUnitTypeAttribute;
            }
        }

        /// <summary>
        /// Attribute
        /// </summary>
        public PhysicalUnitTypeAttribute Attribute
        {
            get
            {
                return attribute;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                attribute = value;
                SelectBoxes();
            }
        }


        #endregion

        #region Private

        void SelectBoxes()
        {
            List<ComboBox> l = userControlComboboxList.Boxes;
            foreach (ComboBox b in l)
            {
                Tuple<PropertyInfo, List<object>> t = b.Tag as
                    Tuple<PropertyInfo, List<object>>;
                object o = t.Item1.GetValue(attribute);
                List<object> list = t.Item2;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i].Equals(o))
                    {
                        b.SelectedIndex = i;
                        break;
                    }
                }
                b.SelectedIndexChanged += SelectCombo;
            }
        }


        static UserControlPhysicalUnit()
        {
            string[] types = new string[]
            {
            "AngleType", "LengthType", "TimeType",
            "MassType"
            };

            Type t = typeof(PhysicalUnitTypeAttribute);
            foreach (string ty in types)
            {
                props.Add(t.GetProperty(ty));
            }

        }
        #endregion

        #region Event Handlers

        void SelectCombo(object sender, EventArgs arg)
        {
            ComboBox b = sender as ComboBox;
            int i = b.SelectedIndex;
            if (i < 0)
            {
                return;
            }
            Tuple<PropertyInfo, List<object>> t = b.Tag as
                Tuple<PropertyInfo, List<object>>;
            object o = t.Item2[i];
            t.Item1.SetValue(attribute, o);
        }

        #endregion
    }
}
