using System;
using System.Reflection;
using System.Windows.Forms;

using CustomControls.Rule;

namespace CustomControls
{
    /// <summary>
    /// Specific property grid
    /// </summary>
	public class PropertyGridControl : PropertyGrid
	{
		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		public PropertyGridControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods - Private

		/// <summary>
		/// 
		/// </summary>
		private void InitializeComponent()
		{
			this.SuspendLayout();
			// 
			// PropertyGridControl
			// 
			this.PropertyValueChanged += PropertyGridControl_PropertyValueChanged;
			this.ResumeLayout( false );

		}

		#endregion

		#region Event Handlers

		/// <summary>
		/// Event handler
		/// </summary>
		/// <param name="s">Sender</param>
		/// <param name="e">Event aguments</param>
		private static void PropertyGridControl_PropertyValueChanged( object s, PropertyValueChangedEventArgs e )
		{
			RuleBaseAttribute rule;
			Type classType;
			string propertyName;
			PropertyInfo propertyInfo;
			object[] attributes;

			classType = e.ChangedItem.PropertyDescriptor.ComponentType;
			propertyName = e.ChangedItem.PropertyDescriptor.Name;
			propertyInfo = classType.GetProperty( propertyName );
			attributes = propertyInfo.GetCustomAttributes( true );

			if ( ( attributes != null ) && ( attributes.Length > 0 ) )
			{
				foreach ( object attribute in attributes )
				{
					// Is this Attribute a RuleBaseAttribute
					rule = attribute as RuleBaseAttribute;
					if ( rule != null )
					{
						// Validate the data using the rule
						if ( rule.IsValid( e.ChangedItem.Value ) == false )
						{
							// Data was invalid - show the error
							MessageBox.Show( rule.ErrorMessage, "Data Entry Error",
								MessageBoxButtons.OK, MessageBoxIcon.Error );
						}
					}
				}
			}
		}

		#endregion
	}
}
