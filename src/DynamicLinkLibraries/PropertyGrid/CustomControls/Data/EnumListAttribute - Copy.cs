using System;

namespace CustomControls.Data
{
	public class EnumListAttribute : ListAttribute
	{
		#region Data Members

		private readonly Type _enumType;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="enumType">List of items for display in the GridComboBox</param>
		public EnumListAttribute( Type enumType )
		{
			if ( enumType.BaseType == typeof( Enum ) )
				this._enumType = enumType;
			else
				throw new ArgumentException( "Argument must be of type Enum" );
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set for EnumType
		/// </summary>
		public Type EnumType
		{
			get { return ( _enumType ); }
		}

		#endregion
	}
}