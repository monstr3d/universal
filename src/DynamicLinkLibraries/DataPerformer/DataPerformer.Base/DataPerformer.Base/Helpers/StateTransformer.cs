using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using CategoryTheory;

using BaseTypes;

using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Helpers;

using DataPerformer.Interfaces;
using DataPerformer.Portable.DifferentialEquationProcessors;
using ErrorHandler;

namespace DataPerformer.Helpers
{
    /// <summary>
    /// Transformer of differential equatuins
    /// </summary>
    public class StateTransformer : AbstractDoubleTransformer, IMeasurement, ITimeMeasurementProvider
    {
        #region Fields

 
        IDifferentialEquationProcessor processor;


        ITimeMeasurementProvider provider;


    
   
        double time;


        double step;

        #endregion

        #region Ctor

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="collection">Colletion of objects</param>
        /// <param name="processor">Differential equation proessor</param>
        /// <param name="provider">Provider of time</param>
        protected StateTransformer(IObjectCollection collection, IDifferentialEquationProcessor processor, 
            ITimeMeasurementProvider provider) : base(collection)
        {
            this.processor = processor;
            this.provider = provider;
        }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="collection">Colletion of objects</param>
        /// <param name="processor">Differential equation proessor</param>
        public StateTransformer(IObjectCollection collection,
            IDifferentialEquationProcessor processor)
            : this(collection, processor, null)
        {
            provider = this;
            processor.TimeProvider = provider;
        }


        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="collection">Colletion of objects</param>
        public StateTransformer(IObjectCollection collection)
            : this(collection, new InternalRungeProcessor())
        {
        }



        #endregion


        #region IMeasurement Members

        Func<object> IMeasurement.Parameter
        {
            get { return GetTime; }
        }

        string IMeasurement.Name
        {
            get { return "Time"; }
        }

        object IMeasurement.Type
        {
            get { return a; }
        }

        #endregion

        #region ITimeMeasurementProvider Members

        IMeasurement ITimeMeasurementProvider.TimeMeasurement
        {
            get { return this; }
        }

        double ITimeMeasurementProvider.Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }

        double ITimeMeasurementProvider.Step
        {
            get
            {
                return step;
            }
            set
            {
                step = value;
            }
        }

        #endregion


        #region Members

        /// <summary>
        /// Prepares itself
        /// </summary>
        protected override void Prepare()
        {
            if (processor == null)
            {
                processor = new InternalRungeProcessor();
            }
            base.Prepare();
            processor.Set(collection);
        }

        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        public override void Calculate(object[] input, object[] output)
        {
           ITimeMeasurementProvider old = processor.TimeProvider;
            try
            {
                using (new DataPerformer.Portable.TimeProviderBackup(collection, provider, DifferentialEquationProcessor.Processor, 0, null))
                {
                    using (new ComponentCollectionBackup(collection))
                    {
                        processor.TimeProvider = provider;

                        // Input
                        double[] inp = input[0] as double[];

                        // Sets state vector
                        collection.SetStateVector(inp);
                        double start = provider.Time;
                        double step = provider.Step;
                        runtime.StartAll(start);
                        runtime.UpdateAll();

                        // Solution of differential equations
                        processor.Step(start, start + step);
                        provider.Time = start + step;
                        collection.GetStateVector(outbuffer);

                        // Sets final vector
                        output[0] = outbuffer;
                    }
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
            }
            processor.TimeProvider = old;
        }


        #endregion

        object GetTime()
        {
            return time;
        }

        #region Internal Runge Processor

        class InternalRungeProcessor : Portable.DifferentialEquationProcessors.RungeProcessor
        {
            #region Fields

 
            #endregion

            internal InternalRungeProcessor()
            {
            }

        }

        #endregion


     }
}
