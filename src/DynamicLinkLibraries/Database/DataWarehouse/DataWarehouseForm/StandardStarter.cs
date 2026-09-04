using BaseTypes.Interfaces;
using DataWarehouse.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

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

        Task IBlob.SetBytesAsync(byte[] bytes, CancellationToken cancellationToken)
        {
            return Task.FromResult(Ask);
        }

        void Ask(byte[] bytes, CancellationToken cancellationToken)
        {
            if (!start.ContainsKey(ext))
            {
                return;
            }
            string cmd = start[ext];
            string fn = directory + "0." + ext;
            using Stream stream = File.OpenWrite(fn);
            stream.Write(bytes, 0, bytes.Length);
            stream.Close();
            Process.Start(cmd, fn);

        }

        #endregion
    }
}
