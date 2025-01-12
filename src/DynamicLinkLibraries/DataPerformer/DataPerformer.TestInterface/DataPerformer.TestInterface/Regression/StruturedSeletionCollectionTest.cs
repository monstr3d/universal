using DataPerformer.Interfaces;
using Diagram.UI;
using Diagram.UI.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using TestCategory.Interfaces;

namespace DataPerformer.TestInterface.Regression
{
    [Serializable]
    public class StruturedSeletionCollectionTest : ITest, ISerializable
    {
        #region Fields

        /// <summary>
        /// Name of component on desktop
        /// </summary>
        protected string name;



        /// <summary>
        /// Residual parameter
        /// </summary>
        protected double[][] value;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">Name of component on desktop</param>
        public StruturedSeletionCollectionTest(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected StruturedSeletionCollectionTest(SerializationInfo info, StreamingContext context)
        {
            name = info.GetString("Name");
            value = info.GetValue("Value", typeof(double[][])) as double[][];
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
            info.AddValue("Value", value, typeof(double[][]));
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
                var vt = GetValue(collection);
                var n = vt.Length;
                if (n != value.Length)
                {
                    return new Tuple<bool, object>(false, "Different selection values. Object - " + name); return new Tuple<bool, object>(false, "Different lengths. Object - " + name);
                }
                for (int i = 0; i < n; i++)
                {
                    var v = vt[i];
                    var m = v.Length;
                    var val = value[i];
                    if (m != val.Length)
                    {
                        return new Tuple<bool, object>(false, "Different selection values. Object - " + name); return new Tuple<bool, object>(false, "Different lengths. Object - " + name);
                    }
                    for (int j = 0; j < m; j++)
                    {
                        if (v[j] != val[j])
                        {
                            return new Tuple<bool, object>(false, "Different selection values. Object - " + name); return new Tuple<bool, object>(false, "Different lengths. Object - " + name);

                        }
                    }
                }
                return new Tuple<bool, object>(true, "Success. Object - " + name);        // Null means absence of error

            }
        }

        #endregion

        /// <summary>
        /// Calculates value of residual parameter
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        /// <returns>Residual parameter</returns>
        protected double[][] GetValue(IComponentCollection collection)
        {
            var selections = collection.GetObject<IStructuredSelectionCollection>(name);
            var n = selections.Count;
            double[][] value = new double[n][];
            for (int i = 0; i < n; i++)
            {
                var selection = selections[i];
                var m = selection.DataDimension;
                value[i] = new double[m];
                for (int j = 0; j < m; j++)
                {
                    value[i][j] = selection[j] ?? 0;
                }
            }
            return value;
        }
        public void Create(IComponentCollection collection)
        {
            value = GetValue(collection);
        }

    }
}
