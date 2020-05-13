using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    public interface IUpdate
    {
        void Set(MonoBehaviorWrapper wrapper, MonoBehaviour mono);
        void Update();
    }
}
