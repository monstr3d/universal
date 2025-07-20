using System;
using System.Collections.Generic;

using Diagram.UI.Interfaces;
using Diagram.UI;

using BaseTypes.Interfaces;

using DataPerformer.Formula.Interfaces;

using DataPerformer.Interfaces;

using FormulaEditor;
using FormulaEditor.Interfaces;

using NamedTree;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Wrapper of formula
    /// </summary>
    public class DataPerformerFormula
    {
        #region Fields

        static internal List<IOperationDetector> operationDetectors = new List<IOperationDetector>();

        static internal List<IBinaryDetector> binary = new List<IBinaryDetector>();

        ITreeCollection treeCollection;

        protected IDataConsumer DataConsumer
        {
            get;
            init;
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor 
        /// </summary>
        /// <param name="treeCollection">Collection of trees</param>
        public DataPerformerFormula(ITreeCollection treeCollection)
        {
            if (treeCollection == null)
            {
                return;
            }
            this.treeCollection = treeCollection;
            DataConsumer = treeCollection as IDataConsumer;
        }

        #endregion

        #region Public Membres

        /// <summary>
        /// Collection of trees
        /// </summary>
        ITreeCollection TreeCollection {  get => treeCollection; }

        /// <summary>
        /// Converts a tree to AliasName
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>AliasName</returns>
        public IAliasName ToAliasName(ObjectFormulaTree tree)
        {

            IObjectOperation op = tree.Operation;
            if (op is AliasNameVariable variable)
            {
                return variable.AliasName;
            }
            return null;
        }

        /// <summary>
        /// Converts a tree to Measurement
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>Measurement</returns>
        public IMeasurement ToMeasurement(ObjectFormulaTree tree)
        {
            IObjectOperation operation = tree.Operation;
            if (operation is IMeasurementHolder)
            {
                return new HolderMeasurement((IMeasurementHolder)operation, treeCollection);
            }
            return null;
        }

        /// <summary>
        /// Gets table
        /// </summary>
        /// <returns></returns>
        public List<int[]> Get()
        {
            var d = new Dictionary<int, int[]>();
            var tr = treeCollection.Trees;
            for (var i = 0; i < tr.Length; i++)
            {
                var k = FindIndex(tr[i], DataConsumer);
                if (k != null)
                {
                    d[i] = k;
                }
            }
            var l = new List<int[]>();
            foreach (var k in d)
            {
                var v = k.Value;
                l.Add([k.Key, v[0], v[1]]);
            }
            return l;
        }

        /// <summary>
        /// Index of measurement
        /// </summary>
        /// <param name="tree">Tree</param>
        /// <param name="measurements">all measurements</param>
        /// <returns>The index</returns>
        public int[] FindIndex(ObjectFormulaTree tree, IDataConsumer dataConsumer)
        {
            IObjectOperation operation = tree.Operation;
            if (operation is IMeasurementHolder mh)
            {
                var mm = mh.Measurement;
                for (int i = 0; i < dataConsumer.Count; i++)
                {
                    var mea = dataConsumer[i];
                    var n = mea.Count;
                    for (var j = 0; j < n; j++)
                    {
                        var m = mea[j];
                        if (m == mm)
                        {
                            return [i, j];
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Sets measure time variable
        /// </summary>
        /// <param name="measurement">The measure</param>
        /// <param name="variable">The time variable</param>
        public void Set(IMeasurement measurement, ITimeVariable variable)
        {
            VariableMeasurement v = variable.Variable;
            if (v == null)
            {
                return;
            }
            v.Measurement = measurement;
        }

        /// <summary>
        /// Gets time measurement from variable
        /// </summary>
        /// <param name="variable">The variable</param>
        /// <returns>The time measure</returns>
        public IMeasurement GetTimeMeasurement(ITimeVariable variable)
        {
            if (variable.Variable is VariableMeasurement v)
            {
                return v.Measurement;
            }
            return null;
        }

        /// <summary>
        /// Creates variable measurement
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="measurement">The measurement</param>
        /// <param name="detector">The detector</param>
        /// <returns>The variable</returns>
        public VariableMeasurement Create(string symbol, IMeasurement measurement, IVariableDetector detector, object obj)
        {
            if (!(measurement is IDistribution))
            {
                return new VariableMeasurement(symbol, measurement, detector, obj);
            }
            IDistribution distribution = measurement as IDistribution;
            return new VariableMeasurementDistribution(symbol, measurement, distribution, detector, obj);
        }


        /// <summary>
        /// Creates variable measurement
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="measurement">The measurement</param>
        /// <param name="detector">The detector</param>
        /// <returns>The variable</returns>
        public VariableMeasurement Create(char symbol, IMeasurement measurement, IVariableDetector detector, object obj)
        {
            return Create(symbol + "", measurement, detector, obj);
        }

        /// <summary>
        /// Checks invalid compilation of the collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>The invalid component</returns>
        public IAssociatedObject InvalidCompilation(IComponentCollection collection)
        {
            IAssociatedObject ao = null;
            collection.ForEach((ITreeCollection c) =>
            {
                if (ao == null)
                {
                    if (!c.IsValid | c.HasFiction())
                    {
                        if (c is IAssociatedObject)
                        {
                            ao = c as IAssociatedObject;
                        }
                    }
                }

            }
            );
            return ao;
        }


        #endregion


        #region Classes


        class HolderMeasurement : IMeasurement
        {
            IMeasurementHolder measurementHolder;

            ITreeCollection treeCollection;

            object type;

            string name;

            internal HolderMeasurement(IMeasurementHolder measurementHolder, ITreeCollection treeCollection)
            {
                this.measurementHolder = measurementHolder;
                var measurement = measurementHolder.Measurement;
                type = measurement.Type;
                name = measurement.Name;
                this.treeCollection = treeCollection;
            }

            Func<object> IMeasurement.Parameter => parameter;

            string IMeasurement.Name => name;

            object IMeasurement.Type => type;

            object parameter()
            {
                var measurement = measurementHolder.Measurement;
                var p = measurement.Parameter;
                return p();
            }

            public ITreeCollection TreeCollection { get => treeCollection; }

            public override string ToString()
            {
                return measurementHolder.ToString() +  base.ToString();
            }

        }


        #endregion




    }
}