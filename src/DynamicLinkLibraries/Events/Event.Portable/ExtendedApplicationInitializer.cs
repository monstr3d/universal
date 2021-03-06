﻿using System;
using System.Collections.Generic;

using Diagram.UI;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;
using DataPerformer.Portable.Interfaces;

namespace Event.Portable
{
    /// <summary>
    /// Extended application initializer
    /// </summary>
    public class ExtendedApplicationInitializer : ApplicationInitializerAssembly
    {
        private OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver;

        private DataPerformer.Interfaces.IDifferentialEquationProcessor diffProcessor;

        private IDataRuntimeFactory strategy;

        #region Ctor

        public ExtendedApplicationInitializer(OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
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
            IsInitialized = true;
            DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor.Processor = diffProcessor;
            OrdinaryDifferentialEquations.DifferentialEquationsPerformer.Default = ordSolver;
            strategy.SetBase();
            base.InitializeApplication();
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