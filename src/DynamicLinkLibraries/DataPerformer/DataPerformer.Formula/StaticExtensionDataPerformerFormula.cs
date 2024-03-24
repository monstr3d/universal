using CategoryTheory;

using BaseTypes.Interfaces;


using Diagram.UI.Interfaces;
using Diagram.UI;
using AssemblyService.Attributes;


using FormulaEditor;
using FormulaEditor.Interfaces;

using DataPerformer.Formula.Interfaces;
using DataPerformer.Interfaces;
using System.Collections.Generic;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerFormula
    {
        #region Fields

        static readonly DataPerformerFormula dataPerformerFormula = new(null);

        #endregion


        #region Public Members

        /// <summary>
        /// Creates proxy factory
        /// </summary>
        /// <param name="treeCollection">Collection of trees</param>
        /// <returns>The proxy factory</returns>
        static public ITreeCollectionProxyFactory CreatorFactory(ITreeCollection treeCollection)
        {
            CreatorOfCrerator creatorOfCrerator = StaticExtensionFormulaEditor.CreatorFactory;
            return (creatorOfCrerator == null) ? null : creatorOfCrerator[treeCollection];
        }

        /// <summary>
        /// Converts a tree to AliasName
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>AliasName</returns>
        static public IAliasName ToAliasName(ObjectFormulaTree tree)
        {
            return dataPerformerFormula.ToAliasName(tree);
        }

        /// <summary>
        /// Converts a tree to Measurement
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>Measurement</returns>
        static public IMeasurement ToMeasurement(ObjectFormulaTree tree)
        {
            return dataPerformerFormula.ToMeasurement(tree);
        }

        /// <summary>
        /// Sets measure time variable
        /// </summary>
        /// <param name="measurement">The measure</param>
        /// <param name="variable">The time variable</param>
        static public void Set(this IMeasurement measurement, ITimeVariable variable)
        {
            dataPerformerFormula.Set(measurement, variable);
        }

        /// <summary>
        /// Gets time measurement from variable
        /// </summary>
        /// <param name="variable">The variable</param>
        /// <returns>The time measure</returns>
        static public IMeasurement GetTimeMeasurement(this ITimeVariable variable)
        {
            return dataPerformerFormula.GetTimeMeasurement(variable);
        }

        /// <summary>
        /// Creates variable measurement
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="measurement">The measurement</param>
        /// <param name="detector">The detector</param>
        /// <returns>The variable</returns>
        static public VariableMeasurement Create(this string symbol, IMeasurement measurement, IVariableDetector detector)
        {
            return dataPerformerFormula.Create(symbol, measurement, detector);
        }


        /// <summary>
        /// Creates variable measurement
        /// </summary>
        /// <param name="symbol">The symbol</param>
        /// <param name="measurement">The measurement</param>
        /// <param name="detector">The detector</param>
        /// <returns>The variable</returns>
        static public VariableMeasurement Create(this char symbol, IMeasurement measure, IVariableDetector detector)
        {
            return dataPerformerFormula.Create(symbol + "", measure, detector);
        }


        /// <summary>
        /// Detector of operations
        /// </summary>
        static public List<IOperationDetector> OperationDetectors
        {
            get { return DataPerformerFormula.operationDetectors; }
        }

        /// <summary>
        /// Detector of operations
        /// </summary>
        static public List<IBinaryDetector> BinaryDetectors
        {
            get { return DataPerformerFormula.binary; }
        }

        /// <summary>
        /// Adds detector
        /// </summary>
        /// <param name="detector">Detector for adding</param>
        static public void Add(this IOperationDetector detector)
        {
            DataPerformerFormula.operationDetectors.Add(detector);
        }

        /// <summary>
        /// Adds detector
        /// </summary>
        /// <param name="detector">Detector for adding</param>
        static public void Add(this IBinaryDetector detector)
        {
            DataPerformerFormula.binary.Add(detector);
        }

        /// <summary>
        /// Checks invalid compilation of the collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>The invalid component</returns>
        public static IAssociatedObject InvalidCompilation(this IComponentCollection collection)
        {
            return dataPerformerFormula.InvalidCompilation(collection);
        }

        /// <summary>
        /// Inits itself
        /// </summary>
        static public void Init()
        {

        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionDataPerformerFormula()
        {
            new CSCodeCreator();
            (new DataPerformerSeparator()).Add();
        }

        class DataPerformerSeparator : IOperationSeparator
        {
            string[] IOperationSeparator.this[IObjectOperation operation]
            {
                get
                {
                    if (operation is AliasNameVariable)
                    {
                        return [" = aliasName", ".Value;"];
                    }
                    if (operation is IMeasurementHolder)
                    {
                        return [" = measurement", ".Parameter();"];
                    }
                    return null;
                }
            }
        }

        #endregion

    }
}
