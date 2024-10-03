namespace CustomControls
{
	public struct Property
	{
		#region Data Members

		private readonly object _index;
		private readonly string _name;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		public Property( string name )
		{
			this._name = name;
			this._index = null;
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="name"></param>
		/// <param name="index"></param>
		public Property( string name, object index )
			: this( name )
		{
			this._index = index;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set for Index
		/// </summary>
		public object Index
		{
			get { return ( _index ); }
		}

		/// <summary>
		/// Get/Set for Name
		/// </summary>
		public string Name
		{
			get { return ( _name ); }
		}

		#endregion
	}
}
 