﻿using System.Collections.Generic;
using System.Resources;
using System.Drawing;


using Diagram.UI;
using Diagram.UI.Interfaces;

using CommonService;

using ResourceService;

using BasicEngineering.UI.Factory;
using BasicEngineering.UI.Factory.Advanced.Forms;
using DataPerformer.Portable.DifferentialEquationProcessors;
using ErrorHandler;

namespace Aviation.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtension
    {

        public static FormMain CreateAviationForm(string filename, ByteHolder holder,
          ButtonWrapper[] addButtons, IUIFactory[] factories, Motion6D.Portable.Interfaces.IPositionObjectFactory factory,
          Dictionary<string, object>[] addReasurces, bool throwsDoubleInit, string caption, Icon icon, IExceptionHandler logWriter, TestCategory.Interfaces.ITestInterface testInterface)
        {
            return CreateAviationForm(null, filename, holder, addButtons, factories, factory, addReasurces, 
                throwsDoubleInit, caption, icon, logWriter, testInterface);
        }
  

        public static FormMain CreateAviationForm(string filename, ButtonWrapper[] addButtons,
            IUIFactory[] factories, Motion6D.Portable.Interfaces.IPositionObjectFactory factory, 
            Dictionary<string, object>[] addResources, IExceptionHandler logWriter, 
            TestCategory.Interfaces.ITestInterface testInterface)
        {
            return CreateAviationForm(filename, addButtons, factories, factory, addResources, Properties.Resources.Aviation, "Aviation + Control Systems", logWriter, testInterface);
        }
 
        public static FormMain CreateAviationForm(string filename, ButtonWrapper[] addButtons,
            IUIFactory[] factories, Motion6D.Portable.Interfaces.IPositionObjectFactory factory, 
            Dictionary<string, object>[] addResources, Icon icon, string caption, IExceptionHandler logWriter,
            TestCategory.Interfaces.ITestInterface testInterface)
        {
            return CreateAviationForm(filename, null, addButtons, factories, factory, addResources, true, caption, icon, 
                logWriter, testInterface);
        }

        public static FormMain CreateAviationFormFull(LightDictionary<string, ButtonWrapper[]> buttons, IApplicationInitializer[] init,
            Dictionary<string, object>[] dictionary,
            DataWarehouse.Interfaces.IDatabaseCoordinator database, string filename, ByteHolder holder, IUIFactory[] factories, Motion6D.Portable.Interfaces.IPositionObjectFactory factory,
         bool throwsDoubleInit, string caption, Icon icon, IExceptionHandler logWriter, 
         TestCategory.Interfaces.ITestInterface testInterface)
        {
            List<IUIFactory> l = new List<IUIFactory>();
            l.AddRange(factories);
            Motion6D.Portable.Interfaces.IPositionObjectFactory pf = factory;
            if (pf == null)
            {
                pf = Motion6D.Portable.PositionObjectFactory.BaseFactory;
            }
            if (pf != null)
            {
                l.Add(new Motion6D.UI.Factory.VisibleFactory(pf));
            }
          FormMain form =
                Motion6D.UI.Avanced.Initialization.MotionApplicationCreator.CreateForm(database, holder,
               OrdinaryDifferentialEquations.Runge4Solver.Singleton,
           RungeProcessor.Processor, init, l.ToArray(), throwsDoubleInit, buttons,
            icon,
            null,
            filename,
            dictionary,
            caption,
            ".cfa", "Aviation configuration files |*.cfa;*.cont", logWriter, testInterface);
            return form;
        }


        public static FormMain CreateAviationForm(DataWarehouse.Interfaces.IDatabaseCoordinator database, string filename, ByteHolder holder,
            ButtonWrapper[] addButtons, IUIFactory[] factories, Motion6D.Portable.Interfaces.IPositionObjectFactory factory,
            Dictionary<string, object>[] addReasurces, bool throwsDoubleInit, string caption, Icon icon, 
            IExceptionHandler logWriter,
            TestCategory.Interfaces.ITestInterface testInterface)
        {
            string[] tabs = new string[] { "General", "Statistics", "6D Motion", "Events", "Arrows" };
            ButtonWrapper[][] but = new ButtonWrapper[tabs.Length][];
            int i = 0;
            List<ButtonWrapper> gen = new List<ButtonWrapper>();
            gen.AddRange(DataPerformer.UI.Factory.StaticFactory.GeneralObjectsButtons);
            gen.AddRange(addButtons);
            but[i] = gen.ToArray();
            ++i;
            List<ButtonWrapper> stat = new List<ButtonWrapper>();
            stat.AddRange(EngineeringUIFactory.StatisticalObjectsButtons);
            but[i] = stat.ToArray();
            ++i;
            List<ButtonWrapper> geom = new List<ButtonWrapper>();
            geom.AddRange(Motion6D.UI.Factory.MotionFactory.ObjectButtons);
            if (factory != null)
            {
                ButtonWrapper[] bw = Motion6D.UI.Factory.VisibleFactory.GetVisualObjectButtons(factory);
                geom.AddRange(bw);
            }
            but[i] = geom.ToArray();
            ++i;
            List<ButtonWrapper> events = new List<ButtonWrapper>();
            events.AddRange(Event.UI.Factory.UIFactory.ObjectButtons);
            but[i] = events.ToArray();
            ++i;
            List<ButtonWrapper> arr = new List<ButtonWrapper>();
            arr.AddRange(EngineeringUIFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.MotionFactory.ArrowButtons);
            arr.AddRange(Motion6D.UI.Factory.VisibleFactory.VisualArrowButtons);
            but[i] = arr.ToArray();
            LightDictionary<string, ButtonWrapper[]> buttons = new LightDictionary<string, ButtonWrapper[]>();
            buttons.Add(tabs, but);
            IApplicationInitializer[] init = new IApplicationInitializer[]
            {

            };
            Dictionary<string, object> dm = new Dictionary<string, object>();
 
            Dictionary<string, object>[] d = 
                
                Localizator.CreateResources(new Dictionary<string,object>[][]
                {
                Localizator.CreateResources(new string[]{"rus"}, new ResourceManager[]
            {
                ResourceControl_Ru.ResourceManager
            }),
            Motion6D.UI.Utils.ControlUtilites.Resources,
            addReasurces,
                }
          
            );
            IUIFactory[] facts = factories;
            if (factory != null)
            {
                List<IUIFactory> ff = new List<IUIFactory>(factories);
                ff.Add(new Motion6D.UI.Factory.VisibleFactory(factory));
                facts = ff.ToArray();
            }
            
            FormMain form =
                Motion6D.UI.Avanced.Initialization.MotionApplicationCreator.CreateForm(database, holder,
               OrdinaryDifferentialEquations.Runge4Solver.Singleton,
            DataPerformer.Portable.DifferentialEquationProcessors.RungeProcessor.Processor, 
            init, facts, throwsDoubleInit, buttons,
            icon,
            null,
            filename, d,
           caption,
            ".cfa", "Aviation configuration files |*.cfa;*.cont", logWriter, testInterface);
            return form;
        }

  


 

        static StaticExtension()
        {
        }

  }
}
