namespace CustomControls.Rule
{
	/// <summary>
	/// Validate the input data meets a minimum length and doesn't exceed a maximum
	/// </summary>
	public class LengthRuleAttribute : RuleBaseAttribute
	{
		#region Data Members

		private readonly int _minLength;
		private readonly int _maxLength;

		#endregion

		#region Constructor

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="minLength"></param>
		/// <param name="maxLength"></param>
		public LengthRuleAttribute( int minLength, int maxLength )
		{
			this._minLength = minLength;
			this._maxLength = maxLength;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set for MinLength
		/// </summary>
		public int MinLength
		{
			get { return ( _minLength ); }
		}

		/// <summary>
		/// Get/Set for MaxLength
		/// </summary>
		public int MaxLength
		{
			get { return ( _maxLength ); }
		}

		#endregion

		#region Methods - Public

		/// <summary>
		/// Validate the input data
		/// </summary>
		/// <param name="dataObject"></param>
		/// <returns></returns>
		public override bool IsValid( object dataObject )
		{
			this.ErrorMessage = string.Empty;

			if ( dataObject is string )
			{
				string data = (string)dataObject;
				if ( ( _minLength <= data.Length ) && ( data.Length <= _maxLength ) )
				{
					return ( true );
				}
			}

			this.ErrorMessage = string.Format(
				"The value you entered: {0} is not between {1} and {2}.",
				dataObject, _minLength, _maxLength );

			return ( false );
		}

		#endregion
	}
}

