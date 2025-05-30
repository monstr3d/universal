﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;



using CommonService;
using Diagram.UI;
using Diagram.UI.Interfaces;

using DataWarehouse;
using DataWarehouse.Interfaces;

using Motion6D;
using Motion6D.UI.Factory;
using Motion6D.Interfaces;


using BasicEngineering.UI.Factory;
using BasicEngineering.UI.Factory.Interfaces;
using BasicEngineering.UI.Factory.Forms;
using Motion6D.Portable.Interfaces;
using ErrorHandler;

namespace Motion6D.UI.Initialization
{
    /// <summary>
    /// Creator for motion type applications
    /// </summary>
    public class MotionApplicationCreator
    {
        /// <summary>
        /// Creates application form
        /// </summary>
        /// <param name="coordinator">Database coordinator</param>
        /// <param name="holder">byte holder for editor of proprerties</param>
        /// <param name="ordSolver">Ordinary differential equations solver</param>
        /// <param name="diffProcessor">Ordinary differential equations processor</param>
        /// <param name="initializers">Array of initializers</param>
        /// <param name="factories">UI Factotries</param>
        /// <param name="throwsRepeatException">The "throw exception for repeat" sign</param>
        /// <param name="buttons">Palette buttons</param>
        /// <param name="icon">Form icon</param>
        /// <param name="positionFactory">Position factory</param>
        /// <param name="filename">File name</param>
        /// <param name="resources">Localization resourses</param>
        /// <param name="text">Caption text</param>
        /// <param name="ext">File extesion</param>
        /// <param name="fileFilter">Filter for file dialog</param>
        /// <param name="logWriter">Log writer</param>
        /// <param name="testInterface">Test Interface</param>
        /// <returns>The Application form</returns>
        public static FormMain CreateForm(IDatabaseCoordinator coordinator, ByteHolder holder,
            OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
     DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor diffProcessor,
     IApplicationInitializer[] initializers,
            IUIFactory[] factories,
     bool throwsRepeatException, LightDictionary<string, ButtonWrapper[]> buttons,
            Icon icon,
            IPositionObjectFactory positionFactory,
            string filename,
            Dictionary<string, object>[] resources,
            string text,
            string ext, 
            string fileFilter,  IExceptionHandler logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            Motion6D.PositionFactory.Factory = Motion6D.Drawing.Factory.ColoredPositionFactory.Object;
            Motion6D.UI.UserControls.SimpleChooser.Chooser = Motion6D.UI.UserControls.ColoredChooser.Object;
            List<IUIFactory> fact = null;
            if (factories == null)
            {
                fact = new List<IUIFactory>();
            }
            else
            {
                fact = new List<IUIFactory>(factories);
            }
            fact.Add(MotionFactory.Object);
            if (positionFactory != null)
            {
                VisibleFactory vf = new VisibleFactory(positionFactory);
                fact.Add(vf);
            }
            List<IApplicationInitializer> apps = new List<IApplicationInitializer>(initializers);
            apps.Add(Motion6D.ApplicationInitializer.Object);
            FormMain form = DefaultApplicationCreator.CreateForm(coordinator, holder, ordSolver, diffProcessor,
                 
                  apps.ToArray(),
              fact.ToArray(),
              throwsRepeatException,
                  buttons, icon, filename, resources, text, ext, fileFilter, logWriter, testInterface);
            Portable.StaticExtensionMotion6DPortable.Animation = form;
            return form;
        }

        /// <summary>
        /// Creates application form without 3D shapes
        /// </summary>
        /// <param name="coordinator">Database coordinator</param>
        /// <param name="holder">byte holder for editor of proprerties</param>
        /// <param name="ordSolver">Ordinary differential equations solver</param>
        /// <param name="diffProcessor">Ordinary differential equations processor</param>
        /// <param name="initializers">Array of initializers</param>
        /// <param name="factories">UI Factotries</param>
        /// <param name="throwsRepeatException">The "throw exception for repeat" sign</param>
        /// <param name="buttons">Palette buttons</param>
        /// <param name="icon">Form icon</param>
        /// <param name="filename">File name</param>
        /// <param name="resources">Localization resourses</param>
        /// <param name="text">Caption text</param>
        /// <param name="ext">File extesion</param>
        /// <param name="fileFilter">Filter of files</param>
        /// <param name="logWriter">Log writer</param>
        /// <param name="testInterface">Test interface</param>
        /// <returns>The Application form</returns>
       public static FormMain CreateForm(IDatabaseCoordinator coordinator, ByteHolder holder,
     OrdinaryDifferentialEquations.IDifferentialEquationSolver ordSolver,
DataPerformer.Portable.DifferentialEquationProcessors.DifferentialEquationProcessor diffProcessor,
IApplicationInitializer[] initializers,
     IUIFactory[] factories,
bool throwsRepeatException, LightDictionary<string, ButtonWrapper[]> buttons,
     Icon icon,
     string filename,
            Dictionary<string, object>[] resources,
     string text,
     string ext, 
            string fileFilter, 
            IExceptionHandler logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            return CreateForm(coordinator, holder,
                ordSolver,
                diffProcessor,
                initializers,
                factories,
                throwsRepeatException,
                buttons,
                icon,
                null,
                filename,
                resources,
                text,
                ext, 
                fileFilter,
                logWriter, testInterface);
        }

    }
}
