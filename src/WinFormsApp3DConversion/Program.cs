using System.Reflection;
using Aspose.ThreeD;

namespace WinFormsApp3DConversion
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
           //  var files = Directory.GetFiles(dir, "*.obj"); 
            
            TrialException.SuppressTrialException = true;

            @"c:\AUsers\1MySoft\CSharp\03D\XAML\".Process("*.obj");
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}