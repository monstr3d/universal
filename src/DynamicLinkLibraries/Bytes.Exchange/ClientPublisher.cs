using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bytes.Exchange
{
    /// <summary>
    /// Client wrapper
    /// </summary>
    public class ClientPublisher
    {
        #region Fields

        IEvent ob;

        static int num = 0;

        static readonly CodeDomProvider compiler = CodeDomProvider.CreateProvider("cs");

        ServiceHost host;

        EventInfo ev;

        Type type;

        const string s1 = "using System;\n" +
             "using System.Collections.Generic;\n" +
 "using System.Reflection;\n" +
 "using System.ServiceModel;\n" +
 "using System.Text;\n" +
 "using System.Threading.Tasks;\n" +

 "using Bytes.Exchange;\n" +

 "[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]\n" +
 "public class Publishing";
        const string s2 = " : IEvent\n" +
      "{\n" +
       "   #region Fields\n" +

         " string url;\n" +

          "static Action<byte[]> ev = (byte[] b) => { };\n" +

          "#endregion\n" +

      "#region Ctor\n" +

       "   public Publishing";

        string s3 = "()" +
            "{" +

            "}\n" +



           "#endregion\n" +


        "public void OnEvent(AlertData e)\n" +
           " {        ev(e.Data);     }\n" +

             "public static event Action<byte[]> Event     {\n" +
             "add { ev += value; }  remove { ev -= value; }     } }";


        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="binding"></param>
        /// <param name="url"></param>
        public ClientPublisher(System.ServiceModel.Channels.Binding binding, string url)
        {
            string code = s1 + num + s2 + num + s3;
            ++num;
            CompilerParameters compileParams = new CompilerParameters();
            compileParams.IncludeDebugInformation = true;
            compileParams.GenerateExecutable = false;
            compileParams.GenerateInMemory = true;
            List<string> la = new List<string>();
            Assembly[] assemb = AppDomain.CurrentDomain.GetAssemblies();
            foreach (Assembly ass in assemb)
            {
                try
                {
                    string l = ass.Location;
                    string fn = System.IO.Path.GetFileName(l);
                    if (!la.Contains(fn))
                    {
                        compileParams.ReferencedAssemblies.Add(l);
                    }
                }
                catch (Exception)
                {
                }
            }
            CompilerResults results =
                compiler.CompileAssemblyFromSource(compileParams, code);
            try
            {
                Assembly ass = results.CompiledAssembly;
                type = ass.GetTypes()[0];
                host = new ServiceHost(type);
                host.AddServiceEndpoint(typeof(IEvent), binding, url);
                host.Open();
                ev = type.GetEvent("Event");
            }
            catch (Exception exception)
            {

            }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Event
        /// </summary>
        public event Action<byte[]> Event
        {
            add { ev.AddEventHandler(null, value); }
            remove { ev.RemoveEventHandler(null, value); }
        }

        #endregion
    }
}