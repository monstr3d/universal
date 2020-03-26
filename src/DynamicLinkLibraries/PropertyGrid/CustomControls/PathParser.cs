using System;
using System.Collections.Generic;

namespace CustomControls
{
	public class PathParser
	{
		#region Methods - Public 

		/// <summary>
		/// Take a fully qualified path to a field/property/method and break it into the various segments
		/// </summary>
		/// <param name="path">Fully qualified path to a field/property/method - static or class instance</param>
		/// <returns>Array of the segments</returns>
		public static List<string> GetPathParts( string path )
		{
			List<string> parts = new List<string>();
			int length = path.Length;
			int startIndex = 0;
			int index;

			for ( index = 0; index < length; index++ )
			{
				if ( path[index] == '[' )
				{
					char ch;
					while ( ( ch = path[index] ) != ']' )
					{
						if ( ++index >= length )
						{
							ch = '\0';
							break;
						}
					}

					// Malformed string
					if ( ch != ']' )
						throw new FormatException( "The path to the data is malformed" );
				}
				else if ( path[index] == '.' )
				{
					parts.Add( path.Substring( startIndex, ( index - startIndex ) ) );
					startIndex = index + 1;
				}
			}

			// If we aren't at the end of the string - add the remaining information
			if ( startIndex != ( index - 1 ) )
			{
				parts.Add( path.Substring( startIndex, ( index - startIndex ) ) );
			}

			return ( parts );
		}


		/// <summary>
		/// Break a segment of a fully qualified path to a field/property, looking for array subscripting.
		/// </summary>
		/// <param name="variable">Segment of a fully qualified path to a field/property</param>
		/// <returns>A Property object containing the name of the field/property and the index if it exists</returns>
		public static Property BreakVariable( string variable )
		{
			Property property;
			string[] parts;

			parts = variable.Split( new char[] { '[', ']' } );

			// No index subscript
			if ( parts.Length == 1 )
				property = new Property( parts[0] );
			else if ( parts.Length == 3 )
			{
				int index;

				// This is not an enumeration
				if ( parts[1].IndexOf( '.' ) == -1 )
				{
					// Is it a number
					if ( int.TryParse( parts[1], out index ) )
						property = new Property( parts[0], index );
					else
					{
						// Pass it through - probably a string
						property = new Property( parts[0], parts[1] );
					}
				}
				else
				{
					// Enumeration
					index = GetEnumValue( parts[1] );
					property = new Property( parts[0], index );
				}
			}
			else
			{
				throw new FormatException( "Invalid format: " + variable );
			}

			return ( property );
		}

		/// <summary>
		/// Get the Enumeration value from a string
		/// </summary>
		/// <param name="enumString">String representation of an Enumeration</param>
		/// <returns>The integer value of the enumeration</returns>
		public static int GetEnumValue( string enumString )
		{
			string[] parts;
			string dll;
			string value;
			string className;

			parts = enumString.Split( new char[] { '.', ',' } );

			if ( parts.Length < 3 )
			{
				throw new FormatException( "Invalid format: " + enumString );
			}

			dll = parts[parts.Length - 1];
			value = parts[parts.Length - 2];
			className = string.Join( ".", parts, 0, parts.Length - 2 );

			Type enumClass = ClassType.GetType( dll, className );
			return ( (int)Enum.Parse( enumClass, value ) );
		}

		#endregion
	}
}
