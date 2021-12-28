using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI;


namespace BitmapConsumer
{
 	/// <summary>
	/// Consumer of image
	/// </summary>
	public interface IBitmapConsumer
	{
		/// <summary>
		/// Procesess image
		/// </summary>
		void Process();

		/// <summary>
		/// Providers
		/// </summary>
		IEnumerable<IBitmapProvider> Providers
		{
			get;
		}

        /// <summary>
        /// Adds a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void Add(IBitmapProvider provider);

        /// <summary>
        /// Removes a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void Remove(IBitmapProvider provider);

        /// <summary>
        /// Add remove event of provider. If "bool" is true then adding
        /// </summary>
        event Action<IBitmapProvider, bool> AddRemove;
	}
}
