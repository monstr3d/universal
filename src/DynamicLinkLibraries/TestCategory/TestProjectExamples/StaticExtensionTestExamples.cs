using System;
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

namespace TestProjectExamples
{
    /// <summary>
    /// Static Extension
    /// </summary>
    public static class StaticExtensionTestExamples
    {

        static StaticExtensionTestExamples()
        {
            StaticExtensionDiagramUI.ErrorHandler = new ErrorHandler();
 //           AssemblyService.StaticExtensionAssemblyService.Init();
            LoadFormulaResources();
            StaticExtensionComplerBridge.Init();
            StaticExtensionFormulaEditorCompiler.Init();
            var init = new IApplicationInitializer[0];
            IApplicationInitializer initializer =
                new EngineeringInitializer.BasicEngineeringInitializer(
                    OrdinaryDifferentialEquations.Runge4Solver.Singleton,
       DataPerformer.Portable.DifferentialEquationProcessors.RungeProcessor.Processor, init.ToArray(),
       true);
            initializer.InitializeApplication();
        }


        /// <summary>
        /// Test
        /// </summary>
        /// <param name="bytes">Bytes</param>
        /// <returns>Test result</returns>
        public static object Test(this byte[] bytes)
        {
            try
            {
                using (var stream = new MemoryStream(bytes))
                {
                    var o = stream.Test();
                    return o;
                }
            }
            catch (Exception exception)
            {
                exception.ShowError();
                return exception;
            }
        }



        private static void LoadFormulaResources()
        {
            /*      if (loaded)
                  {
                      return;
                  }*/
 
            


            MathFormula.Saver = StandardXmlFormulaSaver.Object;
            FormulaEditor.CSharp.CSharpTreeCollectionProxyFactory.CodeCreator =
                    FormulaEditor.CSharp.CSharpCodeCreator.CodeCreator;

            MathSymbolFactory.Sizes = new int[4];
            string[,] contents = new string[,]{
                { "s", "sin" },
                { "c", "cos" },
                { "l", "ln" },
                { "u", "lg" },
                { "e", "exp" },
                { "t", "tg" },
                { "q", "ctg"},
                { "a", "arctg" },
                { "b", "arcctg"},
                { "j", "sec" },
                { "k", "cosec" },
                { "f", "arcsin" },
                { "g", "arccos" },
                { "v", "arctg" },
                {"w", "time"},
                {"o", "OADate"},
                {"atan2", "atan2"},
                {"'", "d/dt"},

                { ".", "" + System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator },
                { "×", "×" },
                { "+", "+" },
                { "-", "-" },
                { "*", "\u2219" },

                                                      {"\u2260", "\u2260"},	//NE
                                                      {"\u2264", "\u2264"}, //LE
                                                      {"\u2265", "\u2265"}, //GE
                                                      {"\u2217", "OR"}, //Dis
                                                      {"\u2216", "AND"}, //Con
                                                      {"\u8835", "=>"}, //Implication
                    {"\u2270", "LIKE"},
                                                      {"¬", "¬"},
                                                      {"~", "~"},
                                                      {"=", "="},
                                                      {">", ">"},
                                                      {"<", "<"},
                                                      {"?", "?"},
                                                      {":", ":"},
                                                      {"&", "&"},
                                                      {"|", "|"},
                                                      {"\u2266", "<<"},
                                                      {"\u2267", ">>"},
                                                      {"^", "^"},
                { "(", "(" },
                { ")", ")" },
                { "1", "1" },
                { "2", "2" },
                { "3", "3" },
                { "4", "4" },
                { "5", "5" },
                { "6", "6" },
                { "7", "7" },
                { "8", "8" },
                { "9", "9" },
                { "0", "0" },
                {"\u2211", "\u2211"},
                {"\u03B4", "\u03B4"},
                {"\u0442", "\u0442"}
                };
            MathFormula.Resources = new Dictionary<string, string>();
            for (int i = 0; i < contents.GetLength(0); i++)
            {
                MathFormula.Resources[contents[i, 0]] = contents[i, 1];
            }
            ObjectFormulaTree.Creator = new FormulaArrayObjectCreator(ElementaryFunctionsCreator.Object);
            ElementaryFunctionOperation.InitDeri();
            ElementaryIntegerOperation.Prepare();
            
        }
    }

    internal class ErrorHandler : IErrorHandler
    {
        void IErrorHandler.ShowError(Exception exception, object obj)
        {
            if (exception.Message == "Member \'Comments\' was not found.")
            {
                return;
            }
            else
            {
                int i = 0;
            }
        }

        void IErrorHandler.ShowMessage(string message, object obj)
        {
           
        }
    }
}