using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Helpers;

using DataPerformer.Interfaces;
using DataPerformer.Portable;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Transformer of state variable
    /// </summary>
    public class StateVariableTransformer : AbstractDoubleTransformer
    {
        #region Fields

        string measurements;

        IMeasurements mea;


        #endregion

        #region Ctor

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="collection">Collection of objects</param>
        public StateVariableTransformer(IObjectCollection collection)
            : base(collection)
        {
        }

        #endregion

        #region Overiden members


        /// <summary>
        /// Output variables
        /// </summary>
        public override string[] Output
        {
            get
            {
                if (mea == null)
                {
                    return null;
                }
                string[] s = new string[mea.Count];
                for (int i = 0; i < s.Length; i++)
                {
                    s[i] = mea[i].Name;
                }
                return s;
            }
        }


        /// <summary>
        /// Gets type of i - th output variable
        /// </summary>
        /// <param name="i">Variable index</param>
        /// <returns>The type</returns>
        public override object GetOutputType(int i)
        {
            if (mea == null)
            {
                return null;
            }
            return mea[i].Type;
        }



        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        public override void Calculate(object[] input, object[] output)
        {
            using (new ComponentCollectionBackup(collection))
            {
                double[] inp = input[0] as double[];
                collection.SetStateVector(inp);
                if (mea is IDataConsumer)
                {
                    IDataConsumer dc = mea as IDataConsumer;
                    dc.FullReset();
                    dc.UpdateChildrenData();
                }
                mea.UpdateMeasurements();
                for (int i = 0; i < mea.Count; i++)
                {
                    output[i] = mea[i].Parameter();
                }
            }
        }

        #endregion

        #region Members

        /// <summary>
        /// Measurements
        /// </summary>
        public string Measurements
        {
            get
            {
                return measurements;
            }
            set
            {
                measurements = value;
                SetMeasurement();
            }
        }

        #endregion

        #region Private Members

        void SetMeasurement()
        {
            mea = collection.GetCollectionObject<IMeasurements>(measurements);
        }

        #endregion
    }
}
