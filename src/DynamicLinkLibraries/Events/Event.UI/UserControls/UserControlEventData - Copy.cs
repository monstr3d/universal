using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Diagram.UI;

using Event.Basic.Data.Events;

namespace Event.UI.UserControls
{
    /// <summary>
    /// User control for event + data
    /// </summary>
    public partial class UserControlEventData : UserControl
    {
        #region Fields

        ForcedEventData forced;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlEventData()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Membres

        internal ForcedEventData Forced
        {
            set
            {
                forced = value;
                userControlTypeList.Types = value.Types;
                userControlTypeList.OnChange += (List<Tuple<string, object>> types)  =>
                    { value.Types = types; };
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
            propertyGridInitial.SetArrayEditor(forced.Types, forced.Initial);
            propertyGridValues.SetArrayEditor(forced.Types, forced.Data);
        }

        #endregion

    }
}
