using System;
using System.Reflection;


using Diagram.UI;
using CategoryTheory;
using DataPerformer.Interfaces;
using Diagram.UI.Interfaces;
using DataPerformer.Portable.Attributes;

namespace DataPerformer.Portable
{
    /// <summary>
    /// Post load of data desktop
    /// </summary>
    public class DataDesktopPostLoad 
    {

        #region Fields

        static NamedTree.Performer performer = new NamedTree.Performer();

        /// <summary>
        /// Singleton
        /// </summary>
        public static DataDesktopPostLoad Object = new DataDesktopPostLoad();

        private static int completionLevel = 3;

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected DataDesktopPostLoad()
        {
        }

        #endregion

        #region IDesktopPostLoad Members

        /// <summary>
        /// Post load operation
        /// </summary>
        /// <param name="desktop">The desktop for post load</param>
        public virtual void PostLoad(IDesktop desktop)
        {
            object[] o = desktop.GetIntersectObjects(new Type[] { typeof(IDataConsumer), typeof(IMeasurements) });
            int i = 0;
            while (!Complete(o))
            {
                ++i;
                if (i >= completionLevel)
                {
                    break;
                }
            }
        }

        #endregion

        bool Complete(object[] objs)
        {
            bool b = true;
            foreach (object o in objs)
            {
                Type t = o.GetType();
                PropertyInfo pi = t.GetProperty("IsComplete");
                if (pi == null)
                {
                    continue;
                }
                bool bi = (bool)pi.GetValue(o, null);
                if (!bi)
                {
                    Complete(o);
                    b = false;
                }
            }
            return b;
        }

        void Complete(object o)
        {
            if (o is IDataConsumer)
            {
                IDataConsumer dc = o as IDataConsumer;
                for (int i = 0; i < dc.Count; i++)
                {
                    IMeasurements m = dc[i];
                    CompletePost(m);
                }
            }
            CompletePost(o);
            CompleteSource(o as ICategoryObject);
        }

        void CompleteSource(ICategoryObject obj)
        {
            ICategoryArrow[] arr = obj.GetTargetArrows<DataLink>();
            foreach (ICategoryArrow a in arr)
            {
                ICategoryObject o = a.Source;
                CompletePost(o);
                CompleteSource(o);
            }
        }

        static void CompletePost(object obj)
        {
            return;
            ShouldCompleteAttribute at = performer.GetAttribute<ShouldCompleteAttribute>(obj);
            if (at != null)
            {
                TypeInfo ti = at.ToTypeInfo();
                if (at != null)
                {
                    if (at.ShouldComplete)
                    {
                        MethodInfo mi = ti.GetMethod("Complete", new Type[0]);
                        if (mi != null)
                        {
                            mi.Invoke(obj, new object[0]);
                            return;
                        }
                    }
                }
            }
            /*if (obj is IPostSetArrow)
            {
                IPostSetArrow ps = obj as IPostSetArrow;
                ps.PostSetArrow();
            }*/
        }
    }
}