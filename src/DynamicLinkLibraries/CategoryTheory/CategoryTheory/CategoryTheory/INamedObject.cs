using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
	/// <summary>
	/// Named object
	/// </summary>
	public interface INamedObject
	{
		/// <summary>
		/// Object name
		/// </summary>
		string Name
		{
			get;
		}
	}
}
