using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;


namespace BitmapConsumer
{

	/// <summary>
	/// Provider of image
	/// </summary>
	public interface IBitmapProvider
	{
		/// <summary>
		/// Bitmap
		/// </summary>
		Bitmap Bitmap
		{
			get;
		}
	}

}