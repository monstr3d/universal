using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Diagram.UI;
using Diagram.UI.Factory;


namespace DataPerformer.UI.Factory
{
    /// <summary>
    /// Static factory for data performer
    /// </summary>
    public static class StaticFactory
    {

     /// <summary>
     /// Buttons of general objects
     /// </summary>
        public static readonly ButtonWrapper[] GeneralObjectsButtons = new ButtonWrapper[]
        {
            DefaultFactory.DefaultObjectButtons[0],  DefaultFactory.DefaultObjectButtons[1],
            new ButtonWrapper(typeof(DataPerformer.ObjectTransformer), "",
                      "Object transformer", ResourceImage.Transform.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.VectorFormulaConsumer),
                       "Mv", "Vector performer", ResourceImage.FormulaEditor, null, true, false),
            new ButtonWrapper(typeof(DataPerformer.Recursive), "",
                "Recursive", ResourceImage.Recursive.ToBitmap(),  null, true, false),
           new ButtonWrapper(typeof(DataPerformer.DifferentialEquationSolver), "",
                "Differential equation system", ResourceImage.ODE.ToBitmap(),  null, true, false),
          new ButtonWrapper(typeof(DataPerformer.VectorAssembly), "",
                "Vector", ResourceImage.Vector, null, true, false),
             new ButtonWrapper(typeof(DataPerformer.MatrixAssembly), "",
                "Matrix", ResourceImage.Matrix, null, true, false),
                new ButtonWrapper(typeof(DataPerformer.ArrayDisassembly), "",
                "Components of array", ResourceImage.ArrayDisassembly.ToBitmap(),  null, true, false),
            new ButtonWrapper(typeof(DataPerformer.ArrayTransformer), "",
                "Array transformer", ResourceImage.VectorToArray,  null, true, false),
            new ButtonWrapper(typeof(DataPerformer.FunctionAccumulator), "",
                "Accumulator function", ResourceImage.Accumulator, null, true, false),
            new ButtonWrapper(typeof(DataPerformer.Advanced.Accumulators.AccumulatorSeriesArgument), "",
                "Accumulator with series argument", ResourceImage.AccumSeries.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.Advanced.DynamicFunction), "",
                "Delay accumulator function", ResourceImage.AccumulatorDelay, null, true, false),
            new ButtonWrapper(typeof(DataPerformer.DataConsumer), "",
                "Graph representation", ResourceImage.Graph.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.Series), "",
                "Series", ResourceImage.Series.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.Table2D), "",
                "2D Table", ResourceImage.Table2D.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.Table3D), "",
                "3D Table", ResourceImage.Table3D.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.RandomGenerator), "",
                "Random generator", ResourceImage.Random.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.DoubleSeries), "",
                "Series from two sources", ResourceImage.DoubleSeries.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(DataPerformer.SeriesVectorData), "",
                "Vector data", ResourceImage.SeriesVector.ToBitmap(), null, true, false),
            new ButtonWrapper(typeof(Chart.Objects.DrawSeries), "",
                "Point series", ResourceImage.PointSeries, null, true, false),
            new ButtonWrapper(typeof(DataPerformer.FormulaFilterIterator), "",
                "Formula filter", ResourceImage.FormulaFilter.ToBitmap(), null, true, false),
           new ButtonWrapper(typeof(DataPerformer.Helpers.KalmanFilter), "",
                "Kalman filter", ResourceImage.KalmanFilter.ToBitmap(), null, true, false),

            new ButtonWrapper(typeof(DataPerformer.Helpers.DataPerformerCollectionStateTransformer), "",
                "Collection object transformer", ResourceImage.Collection.ToBitmap(), null, true, false),
          new ButtonWrapper(typeof(DataPerformer.Objects.ManualInput), "",
                "Manual input", ResourceImage._383, null, true, false),
    new ButtonWrapper(typeof(EventRelated.TimeSeriesMedian), "",
                "Median", ResourceImage.Median, null, true, false),
       new ButtonWrapper(typeof(EventRelated.BufferedData.BufferReadWrite), "",
                "Buffer", ResourceImage.DataObjectIcon, null, true, false)

        };

        /// <summary>
        /// Dictionary of images
        /// </summary>
        static public readonly Dictionary<Type, Image> ButtonImages =
            ButtonWrapper.CreateImageDictionary(GeneralObjectsButtons);

     }
}
