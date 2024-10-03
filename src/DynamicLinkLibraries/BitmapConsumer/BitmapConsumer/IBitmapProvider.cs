using System.Drawing;

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