using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Aliases;

using FormulaEditor;

using DataPerformer.Interfaces;

namespace EngineeringInitializer
{
    public class BasicEngineeringInitializer : ApplicationInitializerAssembly
    {
        private OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver;

        private IDifferentialEquationProcessor diffProcessor;


        #region Ctor

        public BasicEngineeringInitializer(OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
            IDifferentialEquationProcessor diffProcessor,
             IApplicationInitializer[] initializers, 
            bool throwsRepeatException) : base(initializers, throwsRepeatException)
        {
            this.ordSolver = ordSolver;
            this.diffProcessor = diffProcessor;
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
    // !!! DELETED INIT        FormulaEditor.Compiler.StaticExtensionFormulaEditorCompiler.Init();
            DataPerformer.DataPerformerInitializer.Initializer.InitializeApplication();
            PureDesktop.DesktopPostLoad += DataPerformer.Portable.DataDesktopPostLoad.Object.PostLoad;
            IsInitialized = true;
            DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor = diffProcessor;
            DataPerformer.StaticExtensionDataPerformerBase.SetLinkChecker();
            AliasTypeDetector.Detector = DataPerformer.DataAliasDetector.Singleton;
            OrdinaryDifferentialEquations.DifferentialEquationsPerformer.Default = ordSolver;
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
                            throw new OwnException("Infinity");
                        }
                        if (Double.IsNaN(a))
                        {
                            throw new OwnException("NaN");
                        }
                    }
                }
                else
                {
                    throw new OwnException("null");
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
