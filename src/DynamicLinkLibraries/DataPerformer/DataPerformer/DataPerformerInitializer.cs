﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces;
using FormulaEditor.CSharp;

namespace DataPerformer
{
    /// <summary>
    /// Initializer of data performer
    /// </summary>
    public class DataPerformerInitializer : IApplicationInitializer
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly IApplicationInitializer Initializer = 
            new DataPerformerInitializer();

        #endregion

        #region Ctor

        private DataPerformerInitializer()
        {

        }

        static  DataPerformerInitializer()
        {
            CSharpTreeCollectionProxyFactory.CodeCreator = CSharpCodeCreator.CodeCreator;
        }

        #endregion

        #region IApplicationInitializer Members

        void IApplicationInitializer.InitializeApplication()
        {
     
        }

        #endregion
    }
}
