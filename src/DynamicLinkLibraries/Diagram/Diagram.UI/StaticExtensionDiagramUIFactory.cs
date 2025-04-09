using System;
using System.Collections.Generic;
using System.Linq;
using CategoryTheory;

using Diagram.UI.Factory;
using Diagram.UI.Interfaces;
using ErrorHandler;
using NamedTree;

namespace Diagram.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionDiagramUIFactory
    {

       #region Fields

        /// <summary>
        /// Default label factoty
        /// </summary>
        static private IDefaultLabelFactory labelFactory;

        private static List<IUIFactory> list = new List<IUIFactory>();

        static public IUIFactory uiFactory;

    
        #endregion

        #region Public Members

        /// <summary>
        /// Default label factoty
        /// </summary>
        static public IDefaultLabelFactory Factory
        {
            get
            {
                return labelFactory;
            }
            set
            {
                labelFactory = value;
            }
        }

        /// <summary>
        /// UI Factory
        /// </summary>
        static public IUIFactory UIFactory
        { 
            get
            {
                return uiFactory;
            }
            set
            {
                if (value != null)
                {
                    if (uiFactory != null)
                    {
                        throw new OwnException("UI factory already exists"); 
                    }
                    uiFactory = value;
                    if (list.Count > 0)
                    {
                        if (uiFactory is AssemblyFactory)
                        {
                            AssemblyFactory ass = uiFactory as AssemblyFactory;
                            foreach (IUIFactory f in list)
                            {
                                ass.Add(f);
                            }
                        }
                        list.Clear();
                    }
               }
            }
        }

        /// <summary>
        /// Adds a factory to the main factory
        /// </summary>
        /// <param name="factory">The factory to add</param>
        static public void Add(this IUIFactory factory)
        {
            if (UIFactory is AssemblyFactory f)
            {
                var fact = list.ToArray();
                list.Clear();
                f.Add(factory);
                return;
            }
            list.Add(factory);
        }

        /// <summary>
        /// Performs start stop action
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="type">Action type</param>
        /// <param name="actionType">True in start and false in stop</param>
        static public void Action(this IDesktop desktop, object type, ActionType actionType)
        {
            IEnumerable<object> comp = desktop.AllComponents;
            foreach (object o in comp)
            {
                if (o is IStartStop)
                {
                    IStartStop ss = o as IStartStop;
                    ss.Action(type, actionType);
                }
            }
        }

        /// <summary>
        /// Gets additional feature
        /// </summary>
        /// <typeparam name="T">Feature type</typeparam>
        /// <param name="factory">User interface factory</param>
        /// <param name="obj">Obj</param>
        /// <returns>Feature</returns>
        static public object GetAdditionalFeature<T>(this IUIFactory factory, IAssociatedObject obj)
        {
            IUIFactory f = factory;
            IUIFactory p = factory.Parent;
            if (p != null)
            {
                f = p;
            }
           if (obj == null)
            {
                return null;
            }
            if (obj is T)
            {
                return f.GetAdditionalFeature<T>((T)obj);
            }
            if (obj is IChildren<IAssociatedObject> tt) // If object has children
            {
                IAssociatedObject[] ao = tt.Children.ToArray();
                foreach (IAssociatedObject aa in ao) // Searches additional feature among children
                {
                    object ob = GetAdditionalFeature<T>(f, aa);
                    if (ob != null)
                    {
                        return ob;
                    }
                }
            }
            return null;
        }

        #endregion

    }
}
