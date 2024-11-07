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
            var dir = @"c:\0\03D\Models\";
            dir = @"c:\0\03D\UNZIP\MODELS\cadnav.com_modelF16\Models_G0404A728\";
            dir = @"c:\0\03D\NRW\UNZIP\business jet.c4d\Models_G0404A700\";
            dir = @"c:\0\03D\NRW\UNZIP\fighter\Models\";
            dir = @"c:\0\03D\NRW\UNZIP\cadnav.com_model_TORNADO\Models_G0404A626\";
            dir = @"c:\0\03D\";//\NRW\UNZIP\cadnav.com_model_TORNADO\Models_G0404A626\";
            dir = @"c:\0\03D\Models_G0404A279\";
            var files = Directory.GetFiles(dir, "*.obj");   
            TrialException.SuppressTrialException = true;
            foreach (var file in files)
            {
                var output = Path.GetFileNameWithoutExtension(file);
                output = Path.Combine(dir, output);
                output = output + ".dae";
                file.Convert(output);
            }
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}