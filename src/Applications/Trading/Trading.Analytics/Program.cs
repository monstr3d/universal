using CategoryTheory;
using DataSetService;
using Diagram.UI;
using System.Diagnostics.Metrics;

namespace Trading.Analytics
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.

           AssemblyService.StaticExtensionAssemblyService.Init();

           FormulaEditor.StaticExtensionFormulaEditor.CheckValue = check;
           
           FormulaEditor.StaticExtensionFormulaEditor.OnCreateProxy += StaticExtensionFormulaEditor_OnCreateProxy;


            ApplicationConfiguration.Initialize();
            var form = StaticExtension.CreateForm("");
            Application.Run(form);
        }

        static int counter = 0;

        static bool first = true;

        static bool check(object o)
        {
            if (o != null)
            {
                first = false;
                return false;
            }
            if (!first)
            {
                ++counter;
            }
            return o == null;
        }


        private static void StaticExtensionFormulaEditor_OnCreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, object code)
        {
            if (collection is IAssociatedObject)
            {
                IAssociatedObject ao = collection as IAssociatedObject;
                string n = ao.GetName(StaticExtensionDiagramUI.CurrentDeskop);
                n = n.Replace('/', '_').Replace('.', '_');

                string dir = AppDomain.CurrentDomain.BaseDirectory;
                if (dir[dir.Length - 1] != Path.DirectorySeparatorChar)
                {
                    dir += Path.DirectorySeparatorChar;
                }
                string d = dir + "Code" + Path.DirectorySeparatorChar;
                if (!Directory.Exists(d))
                {
                    Directory.CreateDirectory(d);
                }
                using (TextWriter writer = new StreamWriter(d + n + ".cs"))
                {
                    writer.Write(code + "");
                }
                //*/
            }
        }
    }
}