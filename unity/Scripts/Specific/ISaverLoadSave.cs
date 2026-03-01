using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Scripts.Specific
{
    interface ISaverLoadSave
    {
        Dictionary<int, KeyCode> Dictionary
        {
            get;
            set;
        }
    }

}
