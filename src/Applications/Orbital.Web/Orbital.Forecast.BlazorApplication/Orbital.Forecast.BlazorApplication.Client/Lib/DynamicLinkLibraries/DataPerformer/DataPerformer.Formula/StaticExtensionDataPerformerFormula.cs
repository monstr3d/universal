﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;

using BaseTypes.Interfaces;

using FormulaEditor;
using FormulaEditor.Interfaces;

using DataPerformer.Formula.Interfaces;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;
using Diagram.UI;
using DataPerformer.Portable.Measurements;
using AssemblyService.Attributes;
using System.Runtime.InteropServices;

namespace DataPerformer.Formula
{
    /// <summary>
    /// Static extensions
    /// </summary>
    [InitAssembly]
    public static class StaticExtensionDataPerformerFormula
    {
        #region Fields

        static List<IOperationDetector> operationDetectors = new List<IOperationDetector>();

        static List<IBinaryDetector> binary = new List<IBinaryDetector>();


        #endregion

       
        class HolderMeasurement:  IMeasurement
        {
            IMeasurementHolder measurementHolder;

            object type;

            string name;

            internal HolderMeasurement(IMeasurementHolder measurementHolder)
            {
                this.measurementHolder = measurementHolder;
                var mea = measurementHolder.Measurement;
                type = mea.Type;
                name = mea.Name;
            }

            Func<object> IMeasurement.Parameter => parameter;

            string IMeasurement.Name => name;

            object IMeasurement.Type => type;

            object parameter()
            {
                var mea = measurementHolder.Measurement;
                var p = mea.Parameter;
                return p();
            }
        }
        
        #region Public Members

        /// <summary>
        /// Converts a tree to AliasName
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>AliasName</returns>
        static public IAliasName ToAliasName(ObjectFormulaTree tree)
        {

            IObjectOperation op = tree.Operation;
            if (op is AliasNameVariable)
            {
                return (op as AliasNameVariable).AliasName;
            }
            return null;
        }

        /// <summary>
        /// Converts a tree to Measurement
        /// </summary>
        /// <param name="tree"></param>
        /// <returns>Measurement</returns>
        static public IMeasurement ToMeasurement(ObjectFormulaTree tree)
        {
            IObjectOperation operation = tree.Operation;
            if (operation is IMeasurementHolder)
            {
                return new HolderMeasurement((IMeasurementHolder)operation);
                /*
                IMeasurementHolder holder = operation as IMeasurementHolder;
                IMeasurement measurement = holder.Measurement;
                var paramerer = () =>
                {
                    var p = measurement.Parameter;
                    var value = p();
                    return value;
                };
                return new Measurement(measurement.Type, paramerer, measurement.Name);)*/
            }
            return null;
        }

        /// <summary>
        /// Sets measure time variable
        /// </summary>
        /// <param name="measurement">The measure</param>
        /// <param name="variable">The time variable</param>
        static public void Set(this IMeasurement measurement, ITimeVariable variable)
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
        static public IMeasurement GetTimeMeasurement(this ITimeVariable variable)
        {
            VariableMeasurement v = variable.Variable;
            if (v == null)
            {
                return null;
            }
            return v.Measurement;
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
            if (!(measurement is IDistribution))
            {
                return new VariableMeasurement(symbol, measurement, detector);
            }
            IDistribution distribution = measurement as IDistribution;
            return new VariableMeasureDistribution(symbol, measurement, distribution, detector);
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
            return Create(symbol + "", measure, detector);
        }


        /// <summary>
        /// Detector of operations
        /// </summary>
        static public List<IOperationDetector> OperationDetectors
        {
            get { return operationDetectors; }
        }


        /// <summary>
        /// Detector of operations
        /// </summary>
        static public List<IBinaryDetector> BinaryDetectors
        {
            get { return binary; }
        }


        /// <summary>
        /// Adds detector
        /// </summary>
        /// <param name="detector">Detector for adding</param>
        static public void Add(this IOperationDetector detector)
        {
            operationDetectors.Add(detector);
        }


        /// <summary>
        /// Adds detector
        /// </summary>
        /// <param name="detector">Detector for adding</param>
        static public void Add(this IBinaryDetector detector)
        {
            binary.Add(detector);
        }

        /// <summary>
        /// Checks invalid compilation of the collection
        /// </summary>
        /// <param name="collection">The collection</param>
        /// <returns>The invalid component</returns>
        static public IAssociatedObject InvalidCompilation(this IComponentCollection collection)
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

        #endregion


        class DataPerformerSeparator : IOperationSeparator
        {
            string[] IOperationSeparator.this[IObjectOperation operation]
            {
                get
                {
                    if (operation is AliasNameVariable)
                    {
                        return [ " = aliasName", ".Value;" ];
                    }
                    if (operation is IMeasurementHolder)
                    {
                        return [ " = measurement", ".Parameter();" ];
                    }
                    return null;
                }
            }
        }


    }
}