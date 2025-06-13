using Microsoft.JSInterop;
using System;

namespace OnlineGameConverter.Server
{
    public class Note
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ExtendedNote
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string DateTime { get; set; }
    }

}

