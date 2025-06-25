using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

using DataWarehouse.Interfaces;

namespace DataWarehouse
{
    /// <summary>
    /// Standard starter
    /// </summary>
    public class StandardStarter : IBlob
    {
        //public static readonly StandardStarter Object = new StandardStarter(); 

        string ext = null;
        Dictionary<string, string> start = new Dictionary<string, string>();
        private string directory;

        private string[,] strStart = {
												{"doc", "WINWORD"}, 
												{"docx", "WINWORD"}, 
												{"htm", "IExplore"}, 
												{"html", "IExplore"}, 
												{"xml", "IExplore"},
												{"xsl", "IExplore"},
												{"avi", "mplayer2.exe"},
												{"bmp", "mspaint"}
											};

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directory">The directory</param>
        public StandardStarter(string directory)
        {
            this.directory = directory;
            for (int i = 0; i < strStart.GetLength(0); i++)
            {
                start[strStart[i, 0]] = strStart[i, 1];
            }
        }

        #region IBlob Members

        byte[] IBlob.Bytes
        {
            get
            {
                return null;
            }
            set
            {
                if (!start.ContainsKey(ext))
                {
                    return;
                }
                string cmd = start[ext];
                string fn = directory + "0." + ext;
                Stream stream = File.OpenWrite(fn);
                stream.Write(value, 0, value.Length);
                stream.Close();
                Process.Start(cmd, fn);
            }
        }

        string IBlob.Extension
        {
            get
            {
                return ext;
            }
            set
            {
                ext = value.ToLower().Trim();
            }
        }

        #endregion
    }
}
