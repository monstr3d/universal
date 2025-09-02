using System;
using System.Collections.Generic;
using DataPerformer.Interfaces;
using ErrorHandler;
using NamedTree;

namespace Regression.Portable
{
    /// <summary>
    /// Selection of array collections
    /// </summary>
    public class ArraySelectionCollection : IStructuredSelectionCollection, IMeasurements
    {
        #region Fields

        private ArraySelection[] selections;

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        protected ArraySelectionCollection()
        {
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region IStructuredSelectionCollection Members

        int IStructuredSelectionCollection.Count
        {
            get
            {
                return selections.Length;
            }
        }

        IStructuredSelection IStructuredSelectionCollection.this[int i]
        {
            get
            {
                return selections[i];
            }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get
            {
                return selections.Length;
            }
        }



        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                return selections[n];
            }
        }

        /// <summary>
        /// Updates measurements
        /// </summary>
        public void UpdateMeasurements()
        {
        }

        /// <summary>
        /// Name of source
        /// </summary>
        public string SourceName
        {
            get
            {
                return "";
            }
        }

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        public bool IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => selections;

        #endregion

        #region Specific Members

        /// <summary>
        /// Sets names to data
        /// </summary>
        /// <param name="names">Array of names</param>
        /// <param name="data">Array of data arrays</param>
        protected void Set(string[] names, double[][] data)
        {
            if (names.Length != data.Length)
            {
                throw new OwnException("Names length does not coincides with data length");
            }
            selections = new ArraySelection[names.Length];
            for (int i = 0; i < selections.Length; i++)
            {
                selections[i] = new ArraySelection(names[i], data[i]);
            }
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion
    }
}
