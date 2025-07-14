using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PostgreSQLConsoleApp
{
    internal class A
    {
        public string s { get; set; }
        public string[] ss { get; set; }

        public static void TestA()
        {

            var a = new A { s = "hh", ss = ["ll", "gg"] };
            string jsonString = JsonSerializer.Serialize(a);
        }
    }
}