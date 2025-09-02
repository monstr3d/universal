using CategoryTheory;
using ErrorHandler;
using Event.Interfaces;
using Event.Portable.Interfaces;
using NamedTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event.Portable
{
    public class EventWrapper
    {
        CategoryTheory.Performer Performer
        {
            get;
        } = new CategoryTheory.Performer();

        Diagram.UI.Performer p = new Diagram.UI.Performer();
        /// <summary>
        /// Runtime
        /// </summary>
        public IRealtime Runtime
        {
            get;
            set;
        }

       

        /// <summary>
        /// Set base runtime
        /// </summary>
        /// <param name="runtime">The runtime to set</param>
        public  void SetBase(IRealtime runtime)
        {
            if (runtime == null)
            {
                throw new OwnException("SetBase");
            }
            if (Runtime == null)
            {
                Runtime = runtime;
                return;
            }
            if (Performer.IsBase(Runtime, runtime))
            {
                Runtime = runtime;
            }
        }

        /// <summary>
        /// Finds event
        /// </summary>
        /// <param name="handler">Event handler</param>
        /// <param name="name">The name of event</param>
        /// <returns>The event</returns>
        public  IEvent FindEvent(IEventHandler handler, string name)
        {
            if (!(handler is IAssociatedObject))
            {
                return null;
            }
            IAssociatedObject ao = handler as IAssociatedObject;
            foreach (IEvent ev in handler.Children)
            {
                if (ev is IAssociatedObject evo)
                {
                    string  s  = p.GetRelativeName(ao, evo);
                    if (s == name)
                    {
                        return ev;
                    }
                }
            }
            return null;
        }




    }
}
