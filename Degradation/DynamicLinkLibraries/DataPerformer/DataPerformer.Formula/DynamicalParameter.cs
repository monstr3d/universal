using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

using FormulaEditor;
using DataPerformer.Interfaces;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Multidimensional dynamical parameter
    /// </summary>
    public class DynamicalParameter : DataPerformer.Portable.DynamicalParameter
    {

        #region Ctor

        /// <summary>
        ///Dafault constructor
        /// </summary>
        public DynamicalParameter()
        {
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Sets formula argument
        /// </summary>
        /// <param name="arg"></param>
        public void Set(ElementaryObjectArgument arg)
        {
            foreach (char c in labels)
            {
                arg[c] = this[c].Parameter();
            }
        }

        #endregion
    }
}
