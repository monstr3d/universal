using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using BaseTypes;

namespace Diagram.Data.WpfData
{
    /// <summary>
    /// Static extension
    /// </summary>
    public static class StaticExtensionWPF
    {
        #region Fields

        public const string Desktop = "Desktop";

        public const string Aliases = "Aliases";

        private static readonly System.Globalization.CultureInfo culture =
            System.Globalization.CultureInfo.InvariantCulture;

        static private readonly DateTime t0 =
            new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        static private TimeSpan timeSpan;

        #endregion

        #region Members


        /// <summary>
        /// Action with disable control
        /// </summary>
        /// <param name="control">The control</param>
        /// <param name="action">The action</param>
        public static void DisableAction(this FrameworkElement control, Action action)
        {
            using (new Classes.Disable(control))
            {
                action();
            }
        }



        /// <summary>
        /// Converts string to double
        /// </summary>
        /// <param name="str">String</param>
        /// <returns>Double</returns>
        public static double ToDouble(this string str)
        {
            return Double.Parse(str, culture);
        }

        /// <summary>
        /// Converts double to string
        /// </summary>
        /// <param name="x">Double</param>
        /// <returns>String</returns>
        public static string ToInvString(this double x)
        {
            return x.ToString(culture.NumberFormat);
        }

        /// <summary>
        /// Conerts date time to Java Script milliseconds
        /// </summary>
        /// <param name="dt">Date time</param>
        /// <returns>Milliseconds</returns>
        public static double ToJSMilliseconds(this DateTime dt)
        {
            TimeSpan ts = (dt - t0);
            return ts.TotalMilliseconds;
        }

        /// <summary>
        /// Converts time from seconds to JS milliseconds
        /// </summary>
        /// <param name="time">Time in seconds</param>
        /// <returns>JS Millisceonds</returns>
        public static double Time2JSMilliseconds(this double time)
        {
            return 0; // ((time / 86400) - timeSpan).ToJSMilliseconds();
        }

        /// <summary>
        /// Converts from JS milliseconds to seconds
        /// </summary>
        /// <param name="time">JS Millisceonds</param>
        /// <returns>Time in seconds</returns>
        public static double JSMilliseconds2Time(this long time)
        {
            return (t0 - timeSpan + TimeSpan.FromTicks(time * 10000)).DateTimeToDay() * 86400;
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
        /// <param name="action">Action</param>
        public static void RootRecursiveAction<T>(this DependencyObject obj, Action<T> action)
            where T : class
        {
            DependencyObject d = obj.GetRoot();
            d.RecursiveAction<T>(action);
        }

        /// <summary>
        /// Recursive action
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">Object</param>
        /// <param name="action">Action</param>
        public static void RecursiveAction<T>(this DependencyObject obj, Action<T> action) where T : class
        {
            if (obj is T)
            {
                action(obj as T);
            }
            if (obj is ContentControl)
            {
                object o = (obj as ContentControl).Content;
                if (o is DependencyObject)
                {
                    (o as DependencyObject).RecursiveAction<T>(action);
                }
            }
            if ((obj is Visual) | (obj is System.Windows.Media.Media3D.Visual3D))
            {
                int childrenCount = VisualTreeHelper.GetChildrenCount(obj);
                for (int i = 0; i < childrenCount; i++)
                {
                    var child = VisualTreeHelper.GetChild(obj, i);
                    if (child is DependencyObject)
                    {
                        (child as DependencyObject).RecursiveAction<T>(action);
                    }
                }
            }
            if (obj is FrameworkContentElement)
            {
                IEnumerable en = LogicalTreeHelper.GetChildren(obj);
                foreach (object o in en)
                {
                    if (o is DependencyObject)
                    {
                        (o as DependencyObject).RecursiveAction<T>(action);
                    }
                }
            }
        }

        /// <summary>
        /// Gets dictionary from control
        /// </summary>
        /// <param name="control">Control</param>
        /// <param name="dictionary">Dictionary</param>
        /// <returns>Dictionary</returns>
        public static void GetDictionary(this UIElement control, Dictionary<string, string> dictionary)
        {

            Action<FrameworkElement> act = (FrameworkElement e) =>
            {
                string[] kv = e.GetKeyValue();
                if (kv != null)
                {
                    dictionary[kv[0]] = kv[1];
                }
            };
            control.RecursiveAction<FrameworkElement>(act);
        }

        /// <summary>
        /// Gets dictionary from control
        /// </summary>
        /// <param name="control">Control</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, string> GetDictionary(this UIElement control)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            control.GetDictionary(dictionary);
            return dictionary;
        }

        /// <summary>
        /// Gets dictionary from controls
        /// </summary>
        /// <param name="controls">Controls</param>
        /// <returns>Dictionary</returns>
        public static Dictionary<string, string> GetDictionary(this IEnumerable<UIElement> controls)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (UIElement control in controls)
            {
                control.GetDictionary(dictionary);
            }
            return dictionary;
        }

        /// <summary>
        /// Gets key value from Framework element
        /// </summary>
        /// <param name="element">The element</param>
        /// <param name="allowEmpy">Allow empty value sign</param>
        /// <returns>The key value</returns>
        public static string[] GetKeyValue(this FrameworkElement element, bool allowEmpty = false)
        {
            string n = element.Name;
            Type t = element.GetType();
            if (n == null)
            {
                return null;
            }
            if (n.Length == 0)
            {
                return null;
            }
            if (t.Equals(typeof(TextBox)))
            {
                return new string[] { n, (element as TextBox).Text };
            }
            if (element is ComboBox)
            {
                ComboBox cb = element as ComboBox;
                object o = cb.SelectedItem;
                if (o == null)
                {
                    if (allowEmpty)
                    {
                        return new string[] { n, "" };
                    }
                }
                if (o is ComboBoxItem)
                {
                    ComboBoxItem cbi = o as ComboBoxItem;
                    string v = "";
                    object tag = cbi.Tag;
                    if (tag != null)
                    {
                        v = tag + "";
                    }
                    if (v.Length == 0)
                    {
                        v = cbi.Content + "";
                    }
                    if (v.Length > 0)
                    {
                        return new string[] { n, v };
                    }
                    if (allowEmpty)
                    {
                        return new string[] { n, v };
                    }
                }
                return new string[] { n, o + "" };
            }

            int childrenCount = VisualTreeHelper.GetChildrenCount(element);
            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(element, i);
                if (child is RadioButton)
                {
                    RadioButton rb = child as RadioButton;
                    if (rb.IsChecked != null)
                    {
                        if ((bool)rb.IsChecked)
                        {
                            return new string[] { n, rb.Tag + "" };
                        }
                    }
                }
            }


            return null;
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        static StaticExtensionWPF()
        {
          /*  DateTime dt = DateTime.FromOADate(0);
            DateTime utc = dt.ToUniversalTime();
            //!!!TEMP  timeSpan = dt - utc;*/
            timeSpan = new TimeSpan(0);
        }

        #endregion
    }

}