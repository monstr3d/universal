/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using System;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.Serialization.Formatters.Binary;
using IBApi.messages;

namespace IBSampleApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StaticExtensionIBSample.Init();
         // StaticExtensionIBApi.TestGAGR();
         // StaticExtensionIBApi.TestComprod2();
   //         SaveHistoty();
            Application.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IBSampleAppDialog());
        }

        static BinaryFormatter bf = new BinaryFormatter();

  

    

        static void SaveHistoty()
        {
            var hist = StaticExtensionIBSample.HistoryFromWorkDirectory;
            var tt = hist.Convert();
            var k = tt.Check();
            using (var stream = File.OpenWrite("All.history"))
            {
                bf.Serialize(stream, tt);
            }

            using (var stream = File.OpenRead("All.history"))
            {
                var t = bf.Deserialize(stream);
            }


        }
    }
}
