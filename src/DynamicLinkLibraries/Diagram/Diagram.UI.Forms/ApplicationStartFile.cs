using System;
using System.Collections.Generic;
using System.Diagnostics;
using Diagram.UI.Interfaces;
using ErrorHandler;


namespace Diagram.UI
{
    class ApplicationStartFile : IStartFile, IDisposable
    {
        #region Fields

        List<Process> l = new List<Process>();
       
        #endregion

        #region DCON

        ~ApplicationStartFile()
        {
            (this as IDisposable).Dispose();
        }

        #endregion

        #region IStartFile Members

        void IStartFile.Start(string fileName)
        {
            {
                Process process = new Process();

                try
                {
                    process.StartInfo.UseShellExecute = false;
                    string exe = System.Reflection.Assembly.GetEntryAssembly().Location;
                    // You can start any process, HelloWorld is a do-nothing example.
                    process.StartInfo.FileName = exe;
                    process.StartInfo.Arguments = "\"" + fileName + "\"";
                    process.StartInfo.CreateNoWindow = true;
                    process.Start();
                    // This code assumes the process you are starting will terminate itself.  
                    // Given that is is started without a window so you cannot terminate it  
                    // on the desktop, it must terminate itself or you can do it programmatically 
                    // from this application using the Kill method.
                    l.Add(process);
                }
                catch (Exception e)
                {
                    e.ShowError();
                }
            }
        }


        void IStartFile.Start(byte[] buffer)
        {

            try
            {

                string fn = AppDomain.CurrentDomain.BaseDirectory + Guid.NewGuid() + ".tmp";
                using (System.IO.Stream stream = System.IO.File.OpenWrite(fn))
                {
                    stream.Write(buffer, 0, buffer.Length);
                }
                (this as IStartFile).Start(fn);
            }
            catch (Exception e)
            {
                e.ShowError();
            }
        }


        void IStartFile.Stop()
        {
            foreach (Process process in l)
            {
                try
                {
                    process.Kill();
                }
                catch (Exception)
                {
                }
            }
            string[] files = 
                System.IO.Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.tmp");
            foreach (string file in files)
            {
                if (System.IO.File.Exists(file))
                {
                    try
                    {
                        System.IO.File.Delete(file);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            IStartFile st = this;
            st.Stop();
        }

        #endregion
    }
}
