using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TestCategory.Interfaces;

namespace DataPerformer.TestInterface.Regression
{
    /// <summary>
    /// Base class of regression test
    /// </summary>
    public abstract class BaseRegressionTest : ITest, ISerializable
    {
        #region Fields

        /// <summary>
        /// Name of component on desktop
        /// </summary>
        protected string name;

        /// <summary>
        /// Number of iterations
        /// </summary>
        protected int number;

        /// <summary>
        /// Residual parameter
        /// </summary>
        protected  double value;

    
        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of component on desktop</param>
        /// <param name="number">Number of iterations</param>
        protected BaseRegressionTest(string name, int number)
        {
            this.name = name;
            this.number = number;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected BaseRegressionTest(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            number = info.GetInt32("Number");
            value = info.GetDouble("Value");
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
            info.AddValue("Value", value);
        }

        #endregion

        #region ITest Members

        /// <summary>
        /// Tests collection of components
        /// </summary>
        /// <param name="collection">Collection of components</param>
        /// <returns>Test result</returns>
        Tuple<bool, object> ITest.this[IComponentCollection collection]
        {
            get
            {
                var eps = Math.Abs(GetValue(collection) - value);
                if (Math.Abs(eps) != 0)  // If calculated value of residual parameter is not equal
                {
                    return new Tuple<bool, object>(false, "Different regression values. Object - " + name);  // Then method returns error message
                }
                return new Tuple<bool, object>(true, "Success. Object - " + name);        // Null means absence of error
            }
        }

        #endregion


        protected abstract double GetValue(IComponentCollection collection);


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

   
        #endregion




    }
}
