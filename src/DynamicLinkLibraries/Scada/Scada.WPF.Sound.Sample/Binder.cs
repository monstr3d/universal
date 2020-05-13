using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using Diagram.UI;
using System.IO;



namespace Scada.WPF.Sound.Sample
{
    /*!!!TEMP
   class Binder : SerializationBinder, IDisposable
    {
       TextWriter writer = new StreamWriter(@"c:\\0\\1.txt");


        internal Binder()
        {
            this.Add();
        }


        public override Type BindToType(string assemblyName, string typeName)
        {
            writer.WriteLine(String.Format("{0}, {1}", typeName, assemblyName));
           Type t = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
            if (t == null)
            {
                throw new Exception();
            }
            return t;
        }

       ~Binder()
        {
            if (writer != null)
            {
              //  writer.Flush();
              //  writer.Dispose();
            }
            writer = null;

        }

        void IDisposable.Dispose()
        {
            if (writer != null)
            {
                writer.Flush();
           //     writer.Dispose();
            }
            writer = null;
        }
    }*/
}
