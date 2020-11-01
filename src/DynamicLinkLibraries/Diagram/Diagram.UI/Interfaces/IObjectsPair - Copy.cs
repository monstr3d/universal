using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Labels;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Pair of objects
    /// </summary>
    public interface IObjectsPair
    {
        /// <summary>
        /// The i - th object
        /// </summary>
        IObjectLabel this[int i]
        {
            get;
        }

        /// <summary>
        /// Checks whether object belongs to this pair
        /// </summary>
        /// <param name="label">The object label</param>
        /// <returns>True if belongs and false otherwise</returns>
        bool Belongs(IObjectLabel label);

        /// <summary>
        ///  Checks whether two objects belong to this pair
        /// </summary>
        /// <param name="l1">The label of first object</param>
        /// <param name="l2">The label of second object</param>
        /// <returns>True if belong and false otherwise</returns>
        bool Belongs(IObjectLabel l1, IObjectLabel l2);



        /// <summary>
        /// Checks whether arrow belongs to this pair
        /// </summary>
        /// <param name="l">The arrow label</param>
        /// <returns>True if belongs and false otherwise</returns>
        bool Belongs(IArrowLabel l);

        /// <summary>
        /// Adds arrow to this pair
        /// </summary>
        /// <param name="label">The label of arrow to add</param>
        void Add(IArrowLabelUI label);

        /// <summary>
        /// Removes label from pair
        /// </summary>
        /// <param name="label">The label to remove</param>
        void Remove(IArrowLabelUI label);

        /// <summary>
        /// Refreshs this pair
        /// </summary>
        void Refresh();

        /// <summary>
        /// Clears selection
        /// </summary>
        void ClearSelection();

        /// <summary>
        /// Updates arrows forms
        /// </summary>
        void UpdateForms();

        /// <summary>
        /// Removes itself
        /// </summary>
        void Remove();
    }
}
