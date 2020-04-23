using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;


using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

using FormulaEditor;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Interfaces;

namespace EngineeringInitializer
{
    public class BasicEngineeringInitializer : ApplicationInitializerAssembly
    {
        private OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver;

        private DataPerformer.Interfaces.IDifferentialEquationProcessor diffProcessor;

        private IDataRuntimeFactory strategy;

        #region Ctor

        public BasicEngineeringInitializer(OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
            DataPerformer.Interfaces.IDifferentialEquationProcessor diffProcessor,
            IDataRuntimeFactory strategy, IApplicationInitializer[] initializers, 
            bool throwsRepeatException) : base(initializers, throwsRepeatException)
        {
            this.ordSolver = ordSolver;
            this.diffProcessor = diffProcessor;
            this.strategy = strategy;
        }
        #endregion

        #region Overriden Members

        /// <summary>
        /// Initialises application
        /// </summary>
        public override void InitializeApplication()
        {
            if (IsInitialized)
            {
                return;
            }
            BaseTypes.StaticExtensionBaseTypesExtended.Binder.Add();
            FormulaEditor.Compiler.StaticExtensionFormulaEditorCompiler.Init();
            DataPerformer.DataPerformerInitializer.Initializer.InitializeApplication();
            PureDesktop.DesktopPostLoad += DataPerformer.DataDesktopPostLoad.Object.PostLoad;
            IsInitialized = true;
            DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor = diffProcessor;
            DataPerformer.StaticExtensionDataPerformerBase.SetLinkChecker();
            AliasTypeDetector.Detector = DataPerformer.DataAliasDetector.Singleton;
            OrdinaryDifferentialEquations.DifferentialEquationsPerformer.Default = ordSolver;
            DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory = strategy;
            base.InitializeApplication();
           /* !!! CHECK VALUE  StaticExtensionFormulaEditor.CheckValue = (object o) =>
            {
                if (o != null)
                {
                    if (o.GetType().Equals(typeof(double)))
                    {
                        double a = (double)o;
                        if (Double.IsInfinity(a))
                        {
                            throw new Exception("Infinity");
                        }
                        if (Double.IsNaN(a))
                        {
                            throw new Exception("NaN");
                        }
                    }
                }
                else
                {
                    throw new Exception("null");
                }
            }; //*/
        }


        #endregion

        #region Members

        /// <summary>
        /// The "is initialized" sign
        /// </summary>
        public static bool IsInitialized { get; private set; } = false;
        #endregion
    }
}
