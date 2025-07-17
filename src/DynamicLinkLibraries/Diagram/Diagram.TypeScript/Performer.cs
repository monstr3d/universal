using System;
namespace Diagram.TypeScript
{
    public class Performer 
    {
        public void AddObjectConstructor(List<string> l)
        {
            l.Add("\tconstructor(desktop: IDesktop, name: string)");
            l.Add("\t{");
            l.Add("\t\tsuper(desktop, name);");
        }

        public string ClassString(string preffix, string extends = null)
        {
            var s = "class " + preffix;
            if (extends != null)
            {
                s += " extends " + extends;
            }
            return s;
        }
    }
}
