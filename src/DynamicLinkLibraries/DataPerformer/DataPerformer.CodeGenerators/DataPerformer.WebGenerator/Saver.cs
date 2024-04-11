using System.Collections.Generic;
using System.Data;

namespace DataPerformer.WebGenerator
{
    public class Saver
    {

        public Dictionary<string, string> Input { get; set; } = new();

        public Dictionary<string, string> Output { get; set; } = new();

        public string Classname { get; set; }

        public string Namespace { get; set; }

        public bool Blazor { get; set; }

        public bool MVC { get; set; }

        public bool DateTime { get; set; }


    }
}
