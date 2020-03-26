using Motion6D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scada.Motion6D.Interfaces
{
    /// <summary>
    /// Provider of cameras
    /// </summary>
    public interface ICameraProvider
    {
        Dictionary<string, Camera> Cameras
        {
            get;
        }
    }
}
