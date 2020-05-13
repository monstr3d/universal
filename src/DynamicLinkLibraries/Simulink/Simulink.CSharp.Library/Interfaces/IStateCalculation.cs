using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Simulink.CSharp.Library.Interfaces
{
    /// <summary>
    /// State calulation
    /// </summary>
    public interface IStateCalculation
    {
        /// <summary>
        /// Updates itself
        /// </summary>
        void Update();

        /// <summary>
        /// Resets itself
        /// </summary>
        void Reset();

        /// <summary>
        /// State
        /// </summary>
        double[] State
        {
            get;
        }

        /// <summary>
        /// Derivation
        /// </summary>
        double[] Derivation
        {
            get;
        }

        /// <summary>
        /// Input delegates
        /// </summary>
        Dictionary<string, SetValue> Input
        {
            get;
        }


        /// <summary>
        /// Output delegates
        /// </summary>
        Dictionary<string, GetValue> Output
        {
            get;
        }

        /// <summary>
        /// Constansts
        /// </summary>
        Dictionary<string, SetValue> Constants
        {
            get;
        }

        /// <summary>
        /// Time variable
        /// </summary>
        double Time
        {
            get;
            set;
        }

    }

    /// <summary>
    /// Sets value
    /// </summary>
    /// <param name="o">The value</param>
    public delegate void SetValue(object o);

    /// <summary>
    /// Gets valuye
    /// </summary>
    /// <returns>The value</returns>
    public delegate object GetValue();
}
