using System;
using System.Collections.Generic;
using System.Linq;
using CategoryTheory;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using NamedTree;

namespace Diagram.UI
{
    public class Performer
    {

        public IEnumerable<T> Get<T>(IEnumerable<object> objects) where T : class
        {
            return from o in objects where o is T select o as T;
        }

        public IEnumerable<T> Get<T>(IComponentCollection desktop) where T : class
        {
            return Get<T>(desktop.Desktop);
        }


        public IEnumerable<T> GetEnumerable<T>(IEnumerable<object> collection, bool find = false) where T : class
        {
            foreach (object o in collection)
            {
                if (o is T t)
                {
                    yield return t;
                }
                if (o is IObjectLabel l)
                {
                    object obj = l.Object;
                    var enu = GetEnumerable<T>(new object[] { obj }, find);
                    foreach (T tc in enu)
                    {
                        yield return tc;
                    }
                }
                if (o is IArrowLabel al)
                {
                    object obj = al.Arrow;
                    var enu = GetEnumerable<T>(new object[] { obj }, find);
                    foreach (T tc in enu)
                    {
                        yield return tc;
                    }
                }
                if (o is IAssociatedObject)
                {
                    var enu = GetEnumerable<T>(new object[] { o }, find);
                    foreach (T tc in enu)
                    {
                        yield return tc;
                    }
                }
            }

        }

        /// Transforms collection
        /// </summary>
        /// <typeparam name="T">Output type</typeparam>
        /// <typeparam name="S">Inupt type</typeparam>
        /// <param name="collection">Input collection</param>
        /// <returns>Output collection</returns>
        public  IEnumerable<T> ForEach<T, S>(IEnumerable<S> collection)
            where T : class where S : class
        {
            foreach (S s in collection)
            {
                if (s is T t)
                {
                    yield return t;
                }
                if (s is IObjectLabel l)
                {
                    object obj = l.Object;
                    if (obj is T to)
                    {
                        yield return to;
                    }
                }
                if (s is IArrowLabel al)
                {
                    object a = al.Arrow;
                    if (a is T ta)
                    {
                        yield return ta;
                    }
                }
                if (s is IAssociatedObject ao)
                {
                    T tc = ao.Find<T>();
                    if (tc != null)
                    {
                        yield return tc;
                    }
                }
            }
        }


        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        public  void ForEach<T>(IEnumerable<object> collection, Action<T> action, bool find = false)
            where T : class
        {
            foreach (object o in collection)
            {
                if (o is T t)
                {
                    Execute(t, action, find);
                    continue;
                }
                if (o is IObjectLabel)
                {
                    IObjectLabel l = o as IObjectLabel;
                    object obj = l.Object;
                    Execute(obj, action, find);
                }
                if (o is IArrowLabel)
                {
                    IArrowLabel l = o as IArrowLabel;
                    object obj = l.Arrow;
                    Execute(obj, action, find);
                }
                if (o is IAssociatedObject)
                {
                    Execute(o, action, find);
                }
            }
        }

        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        /// <param name="find">The "find" sign</param>
        public  void ForEach<T>(IComponentCollection collection, Action<T> action, bool find = false) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            ForEach(c, action, find);
        }

        /// <summary>
        /// Performs action for each collection objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="collection">The collection</param>
        /// <param name="action">The action</param>
        public  void ForAll<T>(IComponentCollection collection,
            Action<T> action, bool find = true) where T : class
        {
            IEnumerable<object> en = collection.AllComponents;
            foreach (var a in en)
            {
                if (a is T t)
                {
                    Execute(t, action, find);
                }
                if (a is IObjectLabel)
                {
                    var o = (a as IObjectLabel).Object;
                    if (o is T tt)
                    {
                      Execute(tt, action, find);
                    }
                    if (o is IObjectContainer)
                    {
                        (o as IObjectContainer).Desktop.ForAll(action, find);
                    }
                }
            }
        }

        /// <summary>
        /// Gets all objects of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>Objects</returns>
        public  IEnumerable<T> GetObjectsAndArrows<T>(IComponentCollection collection) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                T t = GetLabelObject<T>(o);
                if (t != null)
                {
                    yield return t;
                }
                if (o is IChildren<IAssociatedObject> ttt)
                {
                    IEnumerable<T> en = ttt.GetChildren<T>();
                    foreach (T tt in en)
                    {
                        yield return tt;
                    }
                }
            }
        }


        /// <summary>
        /// Performs action for each desktop objects
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">Base object</param>
        /// <param name="action">The action</param>
        /// <param name="find">The "find" sign</param>
        public void ForEach<T>(ICategoryObject obj, Action<T> action, bool find = false) where T : class
        {
            IDesktop desktop = GetRootDesktop(obj);
            desktop.ForEach(action, find);
        }




  
        /// <summary>
        /// Gets root desktop
        /// </summary>
        /// <param name="obj">Object</param>
        /// <returns>Root desktop</returns>
        public  IDesktop GetRootDesktop(ICategoryObject obj)
        {
            object o = obj.Object;
            if (o == null)
            {
                return null;
            }
            INamedComponent nc = o as INamedComponent;
            nc = nc.Root;
            return nc.Desktop;
        }

        /// <summary>
        /// Executes action
        /// </summary>
        /// <typeparam name="T">Type of variable</typeparam>
        /// <param name="obj">object</param>
        /// <param name="action">Action</param>
        /// <param name="find">Find sign</param>
        private  void Execute<T>(object obj, Action<T> action, bool find) where T : class
        {
            if (obj == null)
            {
                return;
            }
            if (obj is T t)
            {
                action(t);
                return;
            }
            if (find)
            {
                if (obj is IAssociatedObject ao)
                {
                    T ta = ao.Find<T>();
                    if (ta != null)
                    {
                        action(ta);
                    }
                }
            }
        }

        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="o">Object</param>
        /// <returns>The object</returns>
        public T GetLabelObject<T>(object o) where T : class
        {
            if (o == null)
            {
                return null;
            }
            T t = null;
            if (o is T)
            {
                t = o as T;
            }
            else if (o is IAssociatedObject)
            {
                t = (o as IAssociatedObject).GetObject<T>();
            }
            else if (o is IObjectLabel)
            {
                IObjectLabel ol = o as IObjectLabel;
                t = ol.Object.GetLabelObject<T>();
            }
            else if (o is IArrowLabel)
            {
                IArrowLabel al = o as IArrowLabel;
                t = al.Arrow.GetLabelObject<T>();
            }
            return t;
        }

        /// <summary>
        /// Gets object
        /// </summary>
        /// <param name="collection">Collection</param>
        /// <param name="name">Name</param>
        /// <returns>The object</returns>
        public object GetObject(IComponentCollection collection, string name)
        {
            IEnumerable<object> c = collection.AllComponents;
            foreach (object o in c)
            {
                string n = GetName(o, collection);
                if (n != null)
                {
                    if (n.Equals(name))
                    {
                        return o;
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Gets mame of object
        /// </summary>
        /// <param name="o">The object</param>
        /// <param name="collection">The collection</param>
        /// <returns>The name</returns>
        public  string GetName(object o, IComponentCollection collection)
        {
            INamedComponent nc = null;
            if (o is INamedComponent)
            {
                nc = o as INamedComponent;
            }
            else if (o is IAssociatedObject)
            {
                IAssociatedObject ao = o as IAssociatedObject;
                object ob = ao.Object;
                if (ob is INamedComponent)
                {
                    nc = ob as INamedComponent;
                }
            }
            if (nc == null)
            {
                return null;
            }
            IDesktop d = collection.Desktop;
            if (d == null)
            {
                return null;
            }
            return nc.GetName(d);
        }




        /// <summary>
        /// Gets object
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">Collection</param>
        /// <param name="name">Name</param>
        /// <returns>The object</returns>
        public  T GetCollectionObject<T>(IComponentCollection collection, string name) where T : class
        {
            return GetLabelObject<T>(GetObject(collection, name));
        }

        /// <summary>
        /// Gets children objects
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="childrenObject"></param>
        /// <returns>children</returns>
        public  IEnumerable<T> GetChildren<T>(IChildren<IAssociatedObject> childrenObject) where T : class
        {
            IAssociatedObject[] children = childrenObject.Children.ToArray();
            foreach (object o in children)
            {
                if (o is T)
                {
                    yield return o as T;
                }
                if (o is IChildren<IAssociatedObject> tt)
                {
                    IEnumerable<T> en = tt.GetChildren<T>();
                    foreach (T t in en)
                    {
                        yield return t;
                    }
                }
            }
        }

        /// <summary>
        /// Gets object from collection
        /// </summary>
        /// <typeparam name="T">Object type</typeparam>
        /// <param name="collection">Collection of objects</param>
        /// <param name="name">Full name</param>
        /// <returns>Object if exist and false otherwise</returns>
        public  T GetObject<T>(IComponentCollection collection, string name) where T : class
        {
            return collection.GetObject(name).GetLabelObject<T>();
        }


        /// <summary>
        /// Gets all names of collection
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="collection">The collection</param>
        /// <returns>List of names</returns>
        public IEnumerable<string> GetAllNames<T>(IComponentCollection collection) where T : class
        {
            IEnumerable<object> c = collection.AllComponents;
            string n = null;
            foreach (object o in c)
            {
                n = GetName(o, collection);
                if (n == null)
                {
                    continue;
                }
                T t = GetLabelObject<T>(o);
                if (t != null)
                {
                    yield return n;
                }
            }
        }

    }
}