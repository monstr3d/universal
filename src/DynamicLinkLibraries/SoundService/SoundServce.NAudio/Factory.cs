using SoundService;
using SoundService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundServce.NAudio
{
    internal class Factory : ISoundFactory
    {
        internal Factory()
        {
            this.Set();
        }
        
        ISoundPlayer ISoundFactory.SoundPlayer => throw new NotImplementedException();
    }
}
