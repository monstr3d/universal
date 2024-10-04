using System.Collections.Generic;

using CategoryTheory;
using Diagram.UI;
using Event.Interfaces;


namespace DataPerformer.Portable.Runtime
{
    public class EventBlock : CategoryObject,  IEventBlock, IPostSetArrow
    {

        #region Fields

        protected string[] names = new string[0];

        List<IEvent> list = new List<IEvent>();

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public EventBlock()
        {
        }


        #endregion

        #region IEventBlock Members

        bool IEventBlock.this[IEvent ev]
        {
            get
            {
                return list.Contains(ev);
            }
        }

        string[] IEventBlock.Names
        {
            get
            {
                return names;
            }
            set
            {
                SetNames(value);
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            SetNames(names);
        }

        #endregion

        #region Private

        void SetNames(string[] names)
        {
            List<string> l = new List<string>();
            list.Clear();
            foreach (string name in names)
            {
                IEvent ev = this.GetRelativeObject<IEvent>(name);
                if (ev == null)
                {
                    continue;
                }
                list.Add(ev);
                l.Add(name);
            }
            this.names = names;
        }

        #endregion
    }
}
