﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.Interfaces;


using CompilerBridge;
using ExtendedFormulaEditor;
using FormulaEditor;
using FormulaEditor.Compiler;


using TestCategory;
using Diagram.UI;
using System.Runtime.Serialization.Formatters.Binary;
using DataSetService;
using DataPerformer.Portable;
using Motion6D.Portable;
using TestCategory.Standard;

namespace TestExamplesMotion6DConsoleApp
{
    /// <summary>
    /// Static Extension
    /// </summary>
    internal static class StaticExtension
    {

        static StaticExtension()
        {
            StaticExtensionTestCategoryStandard.Init();
            StaticExtensionMotion6DPortable.Init(null);

          //  DataPerformer.Portable.Runtime.DataRuntimeFactory.Singleton.SetBase();
        }

        internal static  void Init()
        {

        }
      

    }

 }