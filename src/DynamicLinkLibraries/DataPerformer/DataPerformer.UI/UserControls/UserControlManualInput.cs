using System;
using System.Collections.Generic;
using System.Windows.Forms;

using DataPerformer.Portable.Objects;

using Diagram.UI;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// User control of manual input
    /// </summary>
    public partial class UserControlManualInput : UserControl
    {
        #region Fields

        ManualInput input;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlManualInput()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Membres

        internal ManualInput Input
        {
            set
            {
                input = value;
                userControlTypeList.Types = value.Types;
                userControlTypeList.OnChange += (List<Tuple<string, object>> types) =>
                { value.Types = types; };
                InputChange();
                input.OnChangeTypes += InputChange;
               // propertyGridValues.PropertyValueChanged += (object s, PropertyValueChangedEventArgs e) =>
               // { input.Force(); };
            }
        }

        #endregion

        #region Event handlers


        private void InputChange()
        {
            propertyGridInitial.SetArrayEditor(input.Types, input.Initial);
            propertyGridValues.SetArrayEditor(input.Types, input.Data);
        }

        #endregion


    }
}
