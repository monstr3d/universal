using System;
using System.ComponentModel;
using CustomControls.Data;

namespace CustomControls.ComboBox
{
	public class EnumGridComboBox : GridComboBox
	{
		#region Overrides

		/// <summary>
		/// Get the object selected in the ComboBox
		/// </summary>
		/// <returns>Selected Object</returns>
		protected override object GetDataObjectSelected( ITypeDescriptorContext context )
		{
			return ( base.ListBox.SelectedItem );
		}

		/// <summary>
		/// Find the list of data items to populate the ComboBox
		/// </summary>
		/// <param name="context"></param>
		protected override void RetrieveDataList( ITypeDescriptorContext context )
		{
			// Find the Attribute that has the path to the Enumerations list
			foreach ( Attribute attribute in context.PropertyDescriptor.Attributes )
			{
				if ( attribute is EnumListAttribute )
				{
					base.ListAttribute = attribute as EnumListAttribute;
					break;
				}
			}

			// If we found the Attribute, find the Data List
			if ( base.ListAttribute != null )
			{
				// Save the DataList
				base.DataList = Enum.GetValues( ((EnumListAttribute)base.ListAttribute).EnumType ); 
			}
		}

		#endregion
	}
}