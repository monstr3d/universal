using Scada.Interfaces;
using Scada.WPF.UI.ErrorHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Scada.WPF.UI.Wrappers;

namespace Scada.WPF.UI
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionScadaWpfUI
    {
        #region Fields

        static ScadaConsumerFactoryCollection factory = 
            new ScadaConsumerFactoryCollection();

        static IScadaInterface scada;

        static Dictionary<DependencyObject, IScadaConsumer> scadaConsumers = 
            new Dictionary<DependencyObject, IScadaConsumer>();

        static private Dictionary<Type, Func<object, object[]>> dActions = new Dictionary<Type, Func<object, object[]>>()
        {
           {typeof(System.Windows.Controls.TabControl),
            (object o) =>
            {
                System.Windows.Controls.TabControl tc = o as System.Windows.Controls.TabControl;
                List<object> l = new List<object>(); 
                foreach (object c in   tc.Items)
                {
                    l.Add(c);
                }
                return l.ToArray();
              }
            },
                     {typeof(System.Windows.Controls.TabItem),
            (object o) =>
            {
                System.Windows.Controls.TabItem ti = o as System.Windows.Controls.TabItem;
                object ob = ti.Content;
                List<object> l = new List<object>(); 
                 return l.ToArray();
              }
            }
        };

        #endregion

        #region Public Members

        /// <summary>
        /// Factory of scada consumer
        /// </summary>
        public static IScadaConsumerFactory ScadaConsumerFactory
        {
            get
            { return factory; }
        }

        /// <summary>
        /// Scada
        /// </summary>
        public static IScadaInterface Scada
        {
            get { return scada; }
            set { scada = value; }
        }

        /// <summary>
        /// Adds a factory
        /// </summary>
        /// <param name="factory">The factory</param>
        public static void Add(this IScadaConsumerFactory factory)
        {
            StaticExtensionScadaWpfUI.factory.Add(factory);
        }

        /// <summary>
        /// Gets root of objet
        /// </summary>
        /// <param name="element">The element</param>
        /// <returns>The root</returns>
        public static DependencyObject GetRoot(this DependencyObject element)
        {
            if (element is FrameworkElement)
            {
                DependencyObject dob = (element as FrameworkElement).Parent;
                if (!(dob is FrameworkElement))
                {
                    return element;
                }
                return GetRoot(dob);
            }
            return null;
        }


        /// <summary>
        /// Root Recursive action
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <param name="func">Action</param>
        public static void RootRecursiveAction<T>(this DependencyObject obj, Func<T, bool> func)
            where T : class
        {
            DependencyObject d = obj.GetRoot();
            d.RecursiveAction<T>(func);
        }

        /// <summary>
        /// Recursive action
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <param name="func">Function</param>
        public static void RecursiveAction<T>(this DependencyObject obj, Func<T, bool> func) where T : class
        {
            List<object> l = new List<object>();
            obj.RecursiveActionPrivate(func, l);
        }

        /// <summary>
        /// Sets scada interface to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="scada">The scada</param>
        public static void Set(this DependencyObject control, IScadaInterface scada)
        {
            control.SetPrivate(scada);
            scada.OnRefresh += () => { control.SetPrivate(scada); };
            scada.OnStart += () => { control.SetScadaEnabled(true); };
            scada.OnStop += () => { control.SetScadaEnabled(false); };
        }

        /// <summary>
        /// Sets "is enabled" sign to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="isEnabled">The is enabled sign</param>
        public static void SetScadaEnabled(this DependencyObject control, bool isEnabled)
        {
            control.RecursiveAction((DependencyObject c) =>
            {
                if (c is IScadaConsumer)
                {
                    (c as IScadaConsumer).IsEnabled = isEnabled;
                    return true;
                }
                return false;
            });
        }

        /// <summary>
        /// Creates Message box event handler
        /// </summary>
        /// <param name="window">Window</param>
        /// <param name="scada">SCADA</param>
        public static void CreateMessageBoxEventHandler(this Window window, IScadaInterface scada)
        {
            scada.ErrorHandler = new MessageBoxErrorHandler(window);
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Recursive action
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <param name="func">Function</param>
        public static void RecursiveActionPrivate<T>(this DependencyObject obj, Func<T, bool> func, List<object> l) where T : class
        {
            if (l.Contains(obj))
            {
                return;
            }
            l.Add(obj);
            if (obj is T)
            {
                if (func(obj as T))
                {
                    return;
                }
            }
            int childrenCount = 0;
            if ((obj is Visual) | (obj is System.Windows.Media.Media3D.Visual3D))
            {
                childrenCount = VisualTreeHelper.GetChildrenCount(obj);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(obj, i);
                    if (child is DependencyObject)
                    {
                        (child as DependencyObject).RecursiveActionPrivate(func, l);
                    }
                    else
                    {
                        child.ProcessOther(func, l);
                    }
                }
            }
            if (obj is System.Windows.Controls.ContentControl)
            {
                object o = (obj as System.Windows.Controls.ContentControl).Content;
                if (o is DependencyObject)
                {
                    (o as DependencyObject).RecursiveActionPrivate(func, l);
                }
            }
            obj.ProcessOther(func, l);
        }


        /// <summary>
        /// Sets scada interface to control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="scada">The scada</param>
        private static void SetPrivate(this DependencyObject control, IScadaInterface scada)
        {
            control.RecursiveAction((DependencyObject c) =>
            {
                if (scadaConsumers.ContainsKey(c))
                {
                    return true;
                }
                IScadaConsumer sc = ScadaConsumerFactory[scada, c];
                if (sc != null)
                {
                    sc.Scada = scada;
                    scadaConsumers[c] = sc;
                    return true;
                }
                if (c is IScadaConsumer)
                {
                    (c as IScadaConsumer).Scada = scada;
                    return true;
                }
                return false;
            });
        }


        static void ProcessOther<T>(this object o, Func<T, bool> func, List<object> l) where T : class
        {
            Type t = o.GetType();
            if (dActions.ContainsKey(t))
            {
                object[] ob = dActions[t](o);
                foreach (object obj in ob)
                {
                    if (obj is DependencyObject)
                    {
                        (obj as DependencyObject).RecursiveActionPrivate<T>(func, l);
                    }
                    else
                    {
                        obj.ProcessOther<T>(func, l);
                    }
                }
            }
            else
            {

            }
        }

        static StaticExtensionScadaWpfUI()
        {
            string s = Environment.GetEnvironmentVariable("SCADA_DESIGN");
            if (System.IO.File.Exists(s))
            {
                scada = new EmptyScadaInterface(s);
            }
        }

        #endregion

        #region Scada Consumer Factory


        #endregion

    }
}