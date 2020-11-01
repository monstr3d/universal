using System;

namespace CustomControls
{
	public delegate void ObjectCreatedEventHandler( object sender, ObjectCreatedEventArgs arg );

	public class ObjectCreatedEventArgs : EventArgs
	{
		#region Data Members

		private readonly object _dataValue;

		#endregion
		
		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="dataValue"></param>
		public ObjectCreatedEventArgs( object dataValue )
		{
			this._dataValue = dataValue;
		}
		
		#endregion
		
		#region Properties
		
		/// <summary>
		/// Get/Set for DataValue
		/// </summary>
		public object DataValue
		{
			get { return (_dataValue); }
		}

		#endregion
	}
}
