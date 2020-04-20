﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.Serialization;

using TestCategory.Interfaces;

using Diagram.UI.Interfaces;
using Diagram.UI;

using Regression;


namespace DataPerformer.TestInterface.Regression
{
    /// <summary>
    /// Test of nonlinear regression
    /// </summary>
    [Serializable()]
    class RegressionTest : ITest, ISerializable
    {
        #region Fields

        /// <summary>
        /// Name of component on desktop
        /// </summary>
        string name;

        /// <summary>
        /// Number of iterations
        /// </summary>
        int number;

        /// <summary>
        /// Residual parameter
        /// </summary>
        double value;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of component on desktop</param>
        /// <param name="number">Number of iterations</param>
        internal RegressionTest(string name, int number)
        {
            this.name = name;
            this.number = number;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private RegressionTest(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            number = info.GetInt32("Number");
            value = info.GetDouble("Value");
        }


        #endregion

        #region ITest Members

        /// <summary>
        /// Tests collection of components
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <returns>Test result</returns>
        object ITest.this[IComponentCollection collection]
        {
            get 
            {
                if (GetValue(collection) != value)  // If calculated value of residual parameter is not equal
                                                        // is not equal to saved value of residual parameter 
                {
                    return "Different regression values. Object - " + name;  // Then method returns error message
                }
                return null;        // Null means absence of error
            }
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", name);
            info.AddValue("Number", number);
            info.AddValue("Value",value);
        }

        #endregion

        #region Members

        internal int Number
        {
            get
            {
                return number;
            }
        }

        internal string Name
        {
            get
            {
                return name;
            }
        }

        internal void Create(IComponentCollection collection)
        {
            value = GetValue(collection);
        }

        /// <summary>
        /// Calculates value of residual parameter
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        /// <returns>Residual parameter</returns>
        double GetValue(IComponentCollection collection)
        {
            AliasRegression reg = collection.GetObject<AliasRegression>(name); // Regression component
            for (int i = 0; i < number; i++)
            {
                reg.FullIterate();                  // Iteration cylce
            }
            return reg.SquareResidual;              // returns residual parameter
        }

        #endregion

    }
}
