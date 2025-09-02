using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;


using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Formula;


using FormulaEditor.Interfaces;
using FormulaEditor;

using Regression.Portable;

namespace DataPerformer
{
    /// <summary>
    /// Formula iterator for filter
    /// </summary>
    [Serializable()]
    public class FormulaFilterIterator : Formula.Regression.FormulaFilterIterator, ISerializable
    {
        #region Fields

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public FormulaFilterIterator()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private FormulaFilterIterator(SerializationInfo info, StreamingContext context)
        {
            variables = info.GetValue("Variables", typeof(Dictionary<string, string>)) as Dictionary<string, string>;
            constants = info.GetValue("Constants", typeof(Dictionary<string, object>)) as Dictionary<string, object>;
            formula = info.GetValue("Formula", typeof(string)) as string;
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Variables", variables, typeof(Dictionary<string, string>));
            info.AddValue("Constants", constants, typeof(Dictionary<string, object>));
            info.AddValue("Formula", formula, typeof(string));
        }

        #endregion

    }
}
