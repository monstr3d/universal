using System;
using System.Collections;
using System.Drawing;

using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

using DataPerformer;
using DataPerformer.UI;
using DataPerformer.UI.Forms;
using DataPerformer.Helpers;

namespace BasicEngineering.UI.Factory
{
    /// <summary>
    /// Minimal factory
    /// </summary>
    public class MinimalFactory : EmptyUIFactory
    {
        #region Fields

        internal static readonly MinimalFactory Object = new MinimalFactory();

        private IToolsDiagram tools;


        /// <summary>
        /// Button of library
        /// </summary>
        protected PaletteButton libraryButton;


        #endregion

        #region Ctor

        private MinimalFactory()
        {
        }

        #endregion

        #region IUIFactory Members

        /// <summary>
        /// Object creation
        /// </summary>
        /// <param name="button">Corresponding button</param>
        /// <returns>The object</returns>
        public override ICategoryObject CreateObject(IPaletteButton button)
        {
            var type = button.ReflectionType;
            var kind = button.Kind;
            if (type.Equals(typeof(DataConsumer)))
            {
                return new DataConsumer(0);
            }
            if (type.Equals(typeof(DataPerformer.Base.Filters.FilterWrapper)))
            {
                return new DataPerformer.Base.Filters.FilterWrapper(0);
            }
            return null;
        }


        /// <summary>
        /// Creates property editor from of desktop component
        /// </summary>
        /// <param name="comp">The component</param>
        /// <returns>The property editor</returns>
        public override object CreateForm(INamedComponent comp)
        {
            // Checks whether component is an arrow
            if (comp is IArrowLabel)
            {
                IArrowLabel lab = comp as IArrowLabel;
                ICategoryArrow arrow = lab.Arrow;
                /*!!! FOR ARTICLE SAMPLE if (arrow is Motion6D.MechanicalAggregateLink)
                {
                    return new Motion6D.UI.FormAggregateLink(lab);
                }*/
            }
            // The component is an object
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                Form form = ToolsDiagram.CreateEditorForm(obj);
                if (form != null)
                {
                    return form;
                }

                // Creation of iterator property editor
                if (obj is Regression.IteratorGLM)
                {
                    return new FormIterateGLM(lab);
                }
                // Creation of VectorFormulaConsumer property editor
                if (obj is VectorFormulaConsumer)
                {
                    return new FormVectorConsumer(lab);
                }
                if (obj.GetType().Equals(typeof(Series)))
                {
                    object[] array = [ (int)0, Color.Red, new ICollection[0], true ];
                    return new FormSeries(lab, array);
                }
                if (obj is Table3D)
                {
                    return new FormTable3D(lab);
                }
                if (obj is DataPerformerCollectionStateTransformer)
                {
                    return new FormDataPerformerCollectionStateTransformer(lab);
                }
                if (obj is MatrixAssembly)
                {
                    return new FormMatrixAssembly(lab);
                }
                if (obj is VectorAssembly)
                {
                    return new FormVectorAssembly(lab);
                }
                if (obj is ArrayDisassembly)
                {
                    return new FormArrayDisassembly(lab);
                }
                if (obj is ArrayTransformer)
                {
                    return new FormArrayTransformer(lab);
                }
                if (obj is ObjectTransformer)
                {
                    return new FormObjectTransformer(lab);
                }
                if (obj is Chart.Objects.DrawSeries)
                {
                    return new FormPointCollection(lab);
                }
                if (obj is KalmanFilter)
                {
                    return new FormKalmanFilter(lab);
                }
                if (obj is FunctionAccumulator)
                {
                    return new FormFuncAccumulator(lab);
                }
                if (obj is Regression.CombinedSelection)
                {
                    return new FormCombinedSelection(lab);
                }
                if (obj is FormulaFilterIterator)
                {
                    return new FormIteratorFilter(lab);
                }
                if (obj is DifferentialEquationSolver)
                {
                    return new FormDiffEquation(lab);
                }
                if (obj is Recursive)
                {
                    return new FormRecursive(lab);
                }
                if (obj is Regression.Portable.XmlSelectionCollection)
                {
                    return new FormXmlSelection(lab);
                }
                if (obj is Regression.AliasRegression)
                {
                    return new FormAliasRegression(lab);
                }
            }
            return null;
        }


        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            return CreateObjectLabel(button.ReflectionType, button.Kind, button.ButtonImage as Image);
        }

 
        public override IToolsDiagram Tools
        {
            set { tools = value; }
        }

 
        public override void CheckOrder(IDesktop desktop)
        {
            Control desk = desktop as Control;
            foreach (Control c in desk.Controls)
            {
                if (!(c is ArrowLabel))
                {
                    continue;
                }
                ArrowLabel l = c as ArrowLabel;
                ICategoryArrow a = l.Arrow;
                if (!(a is DataLink))
                {
                    continue;
                }
                if (l.Source.Root.Ord < l.Target.Root.Ord)
                {
                    a.Throw(new Exception(DataLink.SetProviderBefore));
                }
            }
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override  IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            if (obj is IProperties)
            {
                IProperties p = obj as IProperties;
                object pr = p.Properties;
                if (pr != null)
                {
                    if (pr is IObjectLabelUI)
                    {
                        return pr as IObjectLabelUI;
                    }
                }
            }
            Type t = obj.GetType();
            if (t.Equals(typeof(ObjectsCollection)))
            {
                ObjectsCollection coll = obj as ObjectsCollection;
                if (coll.Type.Equals(typeof(Regression.AliasRegression)))
                {
                    return (new DataPerformer.UI.Labels.FisherLabel()).CreateLabelUI(null, false);
                }
            }
            return CreateObjectLabel(t, "", null);
        }

        public override IArrowLabelUI CreateLabel(ICategoryArrow arr)
        {
            return null;
        }



        #endregion

        #region Members

        /// <summary>
        /// Button of library
        /// </summary>
        internal PaletteButton LibraryButton
        {
            set
            {
                libraryButton = value;
            }
        }

        private IObjectLabelUI CreateObjectLabel(Type t, string kind, Image image)
        {
            if (t == null)
            {
                return null;
            }
            if (t.GetInterface(typeof(DataPerformer.Interfaces.INamedCoordinates).FullName) != null)
            {
                return DataPerformer.UI.Labels.NamedlSeriesLabel.Create(t);
            }
            if (t.Equals(typeof(DataPerformer.Base.Filters.FilterWrapper)))
            {
                return typeof(DataPerformer.UI.Labels.FilterLabel).CreateLabelUI(true);
            }
            if (t.Equals(typeof(DataConsumer)))
            {
                return typeof(DataPerformer.UI.Labels.GraphLabel).CreateLabelUI(false);
            }
            if (t.Equals(typeof(Series)))
            {
                return (new DataPerformer.UI.Labels.SeriesLabel()).CreateLabelUI(image, false);
            }
            if (t.Equals(typeof(SeriesVectorData)))
            {
                //return UserControlLabel.CreateLabel(new DataPerformer.UI.Labels.SeriesVectorLabel(), image, false);
            }
            if (t.Equals(typeof(Chart.Objects.DrawSeries)))
            {
                return (new DataPerformer.UI.Labels.DrawSeriesLabel()).CreateLabelUI(image, false);
            }
            if (t.Equals(typeof(Table2D)))
            {
                return (new DataPerformer.UI.Labels.Table2DLabel()).CreateLabelUI(image, false);
            }
            if (t.Equals(typeof(DataPerformer.Advanced.DynamicFunction)))
            {
                return typeof(DataPerformer.UI.Labels.DelayAccumulatorLabel).CreateLabelUI(true);
            }
            if (t.Equals(typeof(FunctionAccumulator)))
            {
                return typeof(DataPerformer.UI.Labels.FuncAccumulatorLabel).CreateLabelUI(true);
            }
            if (t.Equals(typeof(DataPerformer.Advanced.Accumulators.AccumulatorSeriesArgument)))
            {
                return typeof(DataPerformer.UI.Labels.AccumulatorSeriesArgumentLabel).CreateLabelUI(true);
            }
            if (t.Equals(typeof(ObjectsCollection)))
            {
                if (kind.Equals("Regression.AliasRegression,AliasRegression"))
                {
                    return (new DataPerformer.UI.Labels.FisherLabel()).CreateLabelUI(image, false);
                }
            }
            if (t.Equals(typeof(Regression.IteratorGLM)))
            {
                return (new DataPerformer.UI.Labels.IteratorGLMLabel()).CreateLabelUI(image, true);
            }
            if (t.Equals(typeof(DataPerformer.EventRelated.TimeSeriesMedian)))
            {
                return (new DataPerformer.UI.Labels.TimeSeriesMedianLabel()).CreateLabelUI(image, true);
            }
            if (t.Equals(typeof(DataPerformer.EventRelated.BufferedData.BufferReadWrite)))
            {
                return (new DataPerformer.UI.BufferedData.Labels.BufferReadWriteLabel()).CreateLabelUI(image, true);
            }
            if (t.Equals(typeof(DataPerformer.Objects.ManualInput)))
            {
                return (new DataPerformer.UI.Labels.ManualInputLabel()).CreateLabelUI(image, true);
            }

            return null;
        }

        #endregion

    }
}
