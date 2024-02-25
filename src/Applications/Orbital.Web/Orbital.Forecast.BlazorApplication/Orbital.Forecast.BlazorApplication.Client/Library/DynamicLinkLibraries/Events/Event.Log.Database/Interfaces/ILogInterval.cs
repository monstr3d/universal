using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Log.Database.Interfaces
{
    public interface ILogInterval 
    {
        /// <summary>
        /// Data
        /// </summary>
        ILogData Data
        {
            get;
        }

        /// <summary>
        /// Begin
        /// </summary>
        uint Begin
        {
            get;
            set;
        }

        /// <summary>
        /// End
        /// </summary>
        uint End
        {
            get;
            set;
        }

        /// <summary>
        /// Data Id
        /// </summary>
        object DataId
        {
            get;
        }

    }
}
