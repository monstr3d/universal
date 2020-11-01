using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Diagram.UI.Interfaces;

using TestCategory;

using DataWarehouse;
using DataWarehouse.Interfaces;


namespace Aviation.Test
{
    class Program
    {
        private static DatabaseInterface data;

        static void Main(string[] args)
        {
            if (args == null)
            {
                return;
            }
            List<IApplicationInitializer> ini = new List<IApplicationInitializer>();
            ini.Add(Motion6D.ApplicationInitializer.Object);
            IApplicationInitializer bi =
                new EngineeringInitializer.BasicEngineeringInitializer(OrdinaryDifferentialEquations.Runge4Solver.Singleton,
                   DataPerformer.Portable.DifferentialEquationProcessors.RungeProcessor.Processor,
                    Motion6D.Runtime.DataRuntimeFactory.Object, ini.ToArray(),
                    true);
            bi.InitializeApplication();
            init();
            DataWarehouse.StaticExtensionDataWarehouse.SetAppBaseCoordinator();
            string conn = "";
            foreach (string s in args)
            {
                if (!s.Contains('/'))
                {
                    conn += s + " ";
                }
            }
            conn = conn.Substring(0, conn.Length - 1);
            CreateData(conn);
            foreach (string s in args)
            {
                if (s.Equals("/t"))
                {
                    test();
                }
                if (s.Equals("/c"))
                {
                    refresh();
                }
            }
        }


        static private void init()
        {
            // Motion6D.PositionObjectFactory.Factory = InterfaceOpenGL.OpenGLFactory.Object;

        }

        static void CreateData(string s)
        {
            if (data != null)
            {
                return;
            }
            try
            {
                IDatabaseInterface inter = DataWarehouse.StaticExtensionDataWarehouse.Coordinator[s];
                data = new DatabaseInterface(new User(null, null, null), inter);
            }
            catch (Exception)
            {
            }
        }


        static void test()
        {
            testData(data);
        }

        static void change()
        {
            Change(data);
        }



        static void testData(DatabaseInterface data)
        {
            string[] ss = new string[] { /*"826959ff-f086-4dfd-af8e-2ae0fabf056e", */"3c034003-b63c-4d4c-b96b-317cbc605f69" };


            System.IO.StreamWriter sr = new System.IO.StreamWriter("1.txt");
            TestPerformer performer = new TestPerformer(DataPerformer.TestInterface.DataPerformerTestEventHandler.Singleton,
               new SoundService.Test.TestInterface(new TextWriter[] { sr, Console.Out }));
            performer.Add(new StandardTextExceptionWriter(sr, true));
            performer.Add(new StandardTextExceptionWriter(Console.Out, true));
            performer.TestData(data, "cfa");
            System.Console.WriteLine("Test has been finished. Press any key to stop");
            System.Console.ReadKey();
        }

        static void Change(DatabaseInterface data)
        {
            TestPerformer performer = new TestPerformer(DataPerformer.TestInterface.DataPerformerTestEventHandler.Singleton,
              new SoundService.Test.TestInterface(new TextWriter[] { Console.Out }));
            performer.TestChange(data, "cfa", true);
            System.Console.WriteLine("Changing is completed. Press any key to stop");
            System.Console.ReadKey();
        }

        static void refresh()
        {
            Refresh(data);
        }

        static void Refresh(DatabaseInterface data)
        {
            TestPerformer.Refresh(data, "cfa");
            System.Console.WriteLine("Refreshing is completed. Press any key to stop");
            System.Console.ReadKey();

        }

    }
}
