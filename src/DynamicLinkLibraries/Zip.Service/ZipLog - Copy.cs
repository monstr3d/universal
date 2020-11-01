using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Event.Basic;

using Event.Interfaces;

using ZipUtils;

namespace Zip.Service
{
    /// <summary>
    /// Zip log
    /// </summary>
    public class ZipLog : MemoryLog, ISaveLog
    {

        /// <summary>
        /// New log
        /// </summary>
        public override IEventLog NewLog
        {
            get
            {
                return new ZipLog();
            }
        }

        byte[] ISaveLog.Bytes
        {
            get
            {
                byte[] b = list.LogListToBytes();
                b = b.CreateDefaultZipBuffer("Zip.zip", (DateTime.Now + "").Replace("/", "_").Replace(":", "_"));
                return b;
            }
            set
            {
                list = value.LogListFromBytes();
            }
        }

        string ISaveLog.Extension
        {
            get
            {
                return "zip";
            }
        }
    }
}
