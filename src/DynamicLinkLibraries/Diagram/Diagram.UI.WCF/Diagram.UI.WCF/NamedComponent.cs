using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;

/*!!!
namespace Diagram.UI.WCF
{
    [DataContract]
    public class NamedComponent
    {
        protected INamedComponent component;

        public NamedComponent(INamedComponent component)
        {
            this.component = component;
        }

        [DataMember]
        public string Name
        {
            get
            {
                return component.Name;
            }
        }

        [OperationContract]
        public T GetRemoteObject<T>() where T : class
        {
          object[] ob = component.GetObjects();
          foreach (object o in ob)
          {
              T t = o.Transform<T>();
              if (t != null)
              {
                  return t;
              }
          }
          return null;
        }
    }
}*/
