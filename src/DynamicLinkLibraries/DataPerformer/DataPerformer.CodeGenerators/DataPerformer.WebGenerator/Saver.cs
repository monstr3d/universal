using System.Data;

namespace DataPerformer.WebGenerator
{
    public class Saver
    {

        public DataTable Input {  get; set; }

        public DataTable Output { get; set; }

        public string Classname { get; set; }

        public string Namespace { get; set; }

        public bool Blazor { get; set; }

        public bool MVC { get; set; }

        public bool DateTime { get; set; }


    }
}
