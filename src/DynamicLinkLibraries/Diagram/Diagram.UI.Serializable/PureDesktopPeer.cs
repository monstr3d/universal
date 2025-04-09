using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using System.Reflection;


using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Attributes;
using Diagram.UI.Interfaces;

using SerializationInterface;
using ErrorHandler;


namespace Diagram.UI
{
    /// <summary>
    /// Desktop for serialization
    /// </summary>
    [Serializable()]
    public class PureDesktopPeer : PureDesktop, ISerializable
    {
        #region Fields

 
        /// <summary>
        /// The need change flag
        /// </summary>
        private static bool needChange;

        /// <summary>
        /// Comments
        /// </summary>
        private List<object> comments = new List<object>();

        /// <summary>
        /// Comment bytes
        /// </summary>
        private byte[] commentBytes;

        /// <summary>
        /// Stream position
        /// </summary>
        private long streamPosition;

  

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public PureDesktopPeer()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected PureDesktopPeer(SerializationInfo info, StreamingContext context)
        {
            byte[] b = info.GetValue("Bytes", typeof(byte[])) as byte[];
            MemoryStream ms = new MemoryStream(b);
            Load(ms, true);
        }


        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            MemoryStream ms = new MemoryStream();
            Save(ms);
            info.AddValue("Bytes", ms.GetBuffer(), typeof(byte[]));
        }

        #endregion

        #region IDesktop Members

        /// <summary>
        /// Copies objects and arrows
        /// </summary>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        /// <param name="associated">Copy associated objects sign</param>
        protected override void Copy(IEnumerable<IObjectLabel> objects, IEnumerable<IArrowLabel> arrows, bool associated)
        {
            foreach (IObjectLabel l in objects)
            {
                string type = l.Type;
                string st = l.Object.GetType() + "";
                if (!type.Equals(st))
                {
                    //type = st;
                }
                PureObjectLabelPeer lp = new PureObjectLabelPeer(l.Name, l.Kind, type, l.X, l.Y);
                Type t = l.GetType();
                object[] o = t.GetCustomAttributes(typeof(SerializableLabelAttribute), true);
                if (o != null)
                {
                    if (o.Length > 0)
                    {
                        IObjectLabelHolder lh = lp;
                        lh.Label = l;
                    }
                }
                IObjectLabel lab = lp;
                lab.Object = l.Object;
                lab.Desktop = this;
                this.objects.Add(lab);
                if (associated)
                {
                    lab.Object.Object = lab;
                }
                table[l.Name] = lab;
            }
            //PureObjectLabel.Wrappers = false;
            foreach (IArrowLabel l in arrows)
            {
                PureArrowLabelPeer lp = new PureArrowLabelPeer(l.Name, l.Kind, l.Type, l.X, l.Y);
                Type t = l.GetType();
                object[] o = t.GetCustomAttributes(typeof(SerializableLabelAttribute), true);
                if (o != null)
                {
                    if (o.Length > 0)
                    {
                        IArrowLabelHolder lh = lp;
                        lh.Label = l;
                    }
                }
                IArrowLabel lab = new PureArrowLabelPeer(l.Name, l.Kind, l.Type, l.X, l.Y);
                lab.Arrow = l.Arrow;
                if (associated)
                {
                    lab.Arrow.Object = lab;
                }
                lab.Desktop = this;
                this.arrows.Add(lab);
                // components.Add(lab);
                table[l.Name] = lab;
                List<IObjectLabel> objs = objects.ToList<IObjectLabel>();
                List<IObjectLabel> tobjs = this.Objects.ToList<IObjectLabel>();
                lab.Source = PureDesktop.Find(objs, tobjs, l.Source, l.Desktop);
                lab.Target = PureDesktop.Find(objs, tobjs, l.Target, l.Desktop);
            }
            if (!associated)
            {
                return;
            }
            this.SetParents();
            PureObjectLabel.SetLabels(objects);
            PureArrowLabel.SetLabels(arrows);
        }

  

        /// <summary>
        /// Level of desktop
        /// </summary>
        public override int Level
        {
            get
            {
                if (ParentDesktop == null)
                {
                    return 0;
                }
                return ParentDesktop.Level + 1;
            }
        }



        /// <summary>
        /// Root desktop
        /// </summary>
        public override IDesktop Root
        {
            get
            {
                IDesktop d = ParentDesktop;
                if (d == null)
                {
                    return this;
                }
                return d.Root;
            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Clears all content
        /// </summary>
        public override void ClearAll()
        {
            base.ClearAll();
            comments.Clear();
            commentBytes = null;
        }

        /// <summary>
        /// All components
        /// </summary>
        public override IEnumerable<object> AllComponents
        {
            get
            {
                return this.GetAllObjects();
            }
        }


        #endregion

        #region Public Members

        /// <summary>
        /// The need change sign
        /// </summary>
        static public bool NeedChange
        {
            get
            {
                return needChange;
            }
            set
            {
                needChange = value;
            }
        }

        /// <summary>
        /// Saves all aliases of desktop to stream
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="stream">The stream</param>
        static public void SaveAllAliases(IDesktop desktop, Stream stream)
        {
            Dictionary<string, object> d = desktop.GetAllAliases();
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, d);
        }

        /// <summary>
        /// Content
        /// </summary>
        public byte[] Content
        {
            get
            {
                MemoryStream ms = new MemoryStream();
                Save(ms);
                return ms.GetBuffer();
            }
        }

        /// <summary>
        /// Comments
        /// </summary>
        public List<object> Comments
        {
            get
            {
                if (commentBytes != null)
                {
                    MemoryStream ms = new MemoryStream(commentBytes);
                    BinaryFormatter bf = new BinaryFormatter();
                    comments = bf.Deserialize(ms) as List<object>;
                    commentBytes = null;
                }
                return comments;
            }
        }
 
        /// <summary>
        /// Checks desktop
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="binders">The serialization binders</param>
        /// <returns>List of exceptions or null if right</returns>
        public static List<Exception> Check(IDesktop desktop, SerializationBinder[] binders)
        {
            exceptions = new List<Exception>();
            bool b = false;
            try
            {
                IEnumerable<IObjectLabel> objects = desktop.Objects;
                IEnumerable<IArrowLabel> arrows = desktop.Arrows;
                PureDesktopPeer d = new PureDesktopPeer();
                d.Copy(objects, arrows, true);
                d.SetParents();
                Stream stream = new MemoryStream();
                d.Save(stream);
                PureDesktopPeer dnew = new PureDesktopPeer();
                b = dnew.Load(stream);
                dnew.Dispose();
            }
            catch (Exception e)
            {
                e.HandleException(10);
                if (exceptions != null)
                {
                    exceptions.Add(e);
                }
            }
            List<Exception> res = b ? null : exceptions;
            exceptions = null;
            desktop.SetParents();
            return res;
        }

        /// <summary>
        /// Checks loading from stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>List of exceptions</returns>
        public static List<Exception> Check(Stream stream)
        {
            bool b = false;
            SerializationBinder binder = SerializationInterface.StaticExtensionSerializationInterface.Binder;
            exceptions = new List<Exception>();
            try
            {
                PureDesktopPeer d = new PureDesktopPeer();
                d.Load(stream, binder, true);
                d.SetParents();
                Stream s = new MemoryStream();
                d.Save(s);
                d.Dispose();
                PureDesktopPeer dnew = new PureDesktopPeer();
                b = dnew.Load(s, binder, true);
                dnew.Dispose();
            }
            catch (Exception e)
            {
                e.HandleException(10);
                if (exceptions != null)
                {
                    exceptions.Add(e);
                }
            }
            List<Exception> res = b ? null : exceptions;
            if (res != null)
            {
                if (res.Count == 0)
                {
                    res = null;
                }
            }
            exceptions = null;
            return res;
        }

        /// <summary>
        /// Transforms
        /// </summary>
        /// <param name="instream">Input stream</param>
        /// <param name="outstream">Output strem</param>
        public void Transform(Stream instream, Stream outstream)
        {
            Load(instream);
            this.SetParents();
           Save(outstream);
        }

        /// <summary>
        /// Checks loading from bytes
        /// </summary>
        /// <param name="bytes">The bytes</param>
        /// <returns>Result of cheking</returns>
        public static List<Exception> Check(byte[] bytes)
        {
            MemoryStream stream = new MemoryStream(bytes);
            return Check(stream);
        }

        /// <summary>
        /// Saves itself
        /// </summary>
        /// <param name="stream">Stream to save</param>
        public void Save(Stream stream)
        {
            PreSave();
            BinaryFormatter bformatter = new BinaryFormatter();
            ArrayList objs = new ArrayList();
            ArrayList arrs = new ArrayList();
            objects.ForEach((o) => { objs.Add(o); });
            arrows.ForEach((a) => { arrs.Add(a); });
            bformatter.Serialize(stream, objs);
            bformatter.Serialize(stream, arrs);
            if (commentBytes != null)
            {
                bformatter.Serialize(stream, commentBytes);
                return;
            }
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream str = new MemoryStream();
            bf.Serialize(str, comments);
            bformatter.Serialize(stream, str.GetBuffer());
        }

        /// <summary>
        /// Refreshs itself
        /// </summary>
        public void Refresh()
        {
            MemoryStream stream = new MemoryStream();
            Save(stream);
            objects.Clear();
            arrows.Clear();
            stream.Position = 0;
            Load(stream);
        }

 
        /// <summary>
        /// Loading from stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <param name="binder">Serialization binder</param>
        /// <param name="post">The "post" sign</param>
        /// <returns>True in success and false otherwise</returns>
        public bool Load(Stream stream, SerializationBinder binder, bool post)
        {
            if (!loadBinder(stream, binder, post))
            {
                return false;
            }
            LoadComments(stream);
            return true;
        }

        /// <summary>
        /// Loads from bytes
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <param name="binder">Serialization binder</param>
        /// <returns>True in success and false otherwise</returns>
        public bool Load(byte[] buffer, SerializationBinder binder)
        {
            return Load(buffer, binder, true);
        }

        /// <summary>
        /// Loading from stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>True in success and false otherwise</returns>
        public bool Load(Stream stream)
        {
            return Load(stream, StaticExtensionSerializationInterface.Binder, true);
        }
 
        /// <summary>
        /// Loads from bytes
        /// </summary>
        /// <param name="buffer">Buffer</param>
        /// <returns>True in success and false otherwise</returns>
        public bool Load(byte[] buffer)
        {
            return Load(buffer, true);
        }

        /// <summary>
        /// Adds arrow with existing source and target
        /// </summary>
        /// <param name="arrow">Arrow</param>
        /// <param name="source">Source</param>
        /// <param name="target">Target</param>
        /// <param name="name">Arrow name</param>
        /// <param name="kind">Arrow kind</param>
        /// <returns>Added arrow</returns>
        public IArrowLabel AddArrowWithExistingLabels(ICategoryArrow arrow, 
            IObjectLabel source, IObjectLabel target, string name, string kind)
        {
            source.Object.Object = source;
            target.Object.Object = target;
            IArrowLabel arrowLabel = new PureArrowLabelPeer(name, kind, arrow.GetType().FullName, 0, 0);
            arrowLabel.Desktop = this;
            arrowLabel.Arrow = arrow;
            arrow.Object = arrowLabel;
            arrowLabel.Source = source;
            arrowLabel.Target = target;
            arrowLabel.Arrow = arrow;
            arrow.Source = source.Object;
            arrow.Target = target.Object;
            arrows.Add(arrowLabel);
            return arrowLabel;
        }
 
  
        /// <summary>
        /// Gets full list of desktop components
        /// </summary>
        /// <param name="desktop">The desktop</param>
        /// <param name="list">The list</param>
        static public void GetFullList(IDesktop desktop, List<INamedComponent> list)
        {
            IEnumerable<object> l = desktop.AllComponents;
            foreach (INamedComponent c in l)
            {
                list.Add(c);
                IAssociatedObject ao = c as IAssociatedObject;
                if (ao.Object is IObjectContainer)
                {
                    IObjectContainer cont = ao.Object as IObjectContainer;
                    IDesktop d = cont.Desktop;
                    GetFullList(d, list);
                }
            }
        }

        /// <summary>
        /// Gets full list of desktop components
        /// </summary>
        /// <param name="desktop">Desktop</param>
        /// <param name="objects">Objects</param>
        /// <param name="arrows">Arrows</param>
        static public void GetFullList(IDesktop desktop, out List<IObjectLabel> objects, out List<IArrowLabel> arrows)
        {
            objects = new List<IObjectLabel>();
            arrows = new List<IArrowLabel>();
            List<INamedComponent> list = new List<INamedComponent>();
            foreach (INamedComponent c in list)
            {
                if (c is IObjectLabel)
                {
                    IObjectLabel l = c as IObjectLabel;
                    objects.Add(l);
                }
                if (c is IArrowLabel)
                {
                    IArrowLabel l = c as IArrowLabel;
                    arrows.Add(l);
                }
            }
        }

        /// <summary>
        /// Gets type that implements interface
        /// </summary>
        /// <param name="interfaceName">Name of interface</param>
        /// <param name="assemblyBuffer">Bytes of assembly</param>
        /// <returns>Type that implements interface</returns>
        public static Type GetInterface(string interfaceName, byte[] assemblyBuffer)
        {
            Assembly ass = Assembly.Load(assemblyBuffer);
            Type[] types = ass.GetTypes();
            foreach (Type t in types)
            {
                object o = t.GetInterface(interfaceName);
                if (o != null)
                {
                    return t;
                }
            }
            return null;
        }

        /// <summary>
        /// Serializes object
        /// </summary>
        /// <param name="o">Object to serialize</param>
        /// <returns></returns>
        static public byte[] Serialize(object o)
        {
            if (o == null)
            {
                return null;
            }
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream stream = new MemoryStream();
            bf.Serialize(stream, o);
            return stream.GetBuffer();
        }

        /// <summary>
        /// Deserializes buffer
        /// </summary>
        /// <param name="buffer">The buffer</param>
        /// <returns>Dezerialized object</returns>
        static public object Deserialize(byte[] buffer)
        {
            if (buffer == null)
            {
                return null;
            }
            if (buffer.Length == 0)
            {
                return null;
            }
            BinaryFormatter bf = new BinaryFormatter();
            bf.Binder = StaticExtensionSerializationInterface.Binder;
            using (MemoryStream stream = new MemoryStream(buffer))
            {
                return bf.Deserialize(stream);
            }
        }

        /// <summary>
        /// Saves propreties
        /// </summary>
        /// <param name="properties">Properties</param>
        /// <param name="bytes">Bytes</param>
        /// <param name="info">Serialization info</param>
        public static void SaveProperties(object properties, byte[] bytes, SerializationInfo info)
        {
            if (properties != null)
            {
                info.Serialize<object>("Properties", properties);
                return;
            }
            byte[] b = bytes;
            if (b == null)
            {
                b = new byte[0];
            }
            info.AddValue("Properties", b, typeof(byte[]));
        }

        /// <summary>
        /// Loads bytes
        /// </summary>
        /// <param name="name">name</param>
        /// <param name="info">info</param>
        /// <returns>The bytes</returns>
        public static byte[] LoadBytes(string name, SerializationInfo info)
        {
            return info.GetValue(name, typeof(byte[])) as byte[];
        }

        /// <summary>
        /// Loads bytes properties
        /// </summary>
        /// <param name="info">Info</param>
        /// <returns>Propreties</returns>
        public static byte[] LoadProperties(SerializationInfo info)
        {
            return LoadBytes("Properties", info);
        }

        /// <summary>
        /// Loads label bytes
        /// </summary>
        /// <param name="info">Info</param>
        /// <returns>Butes</returns>
        public static byte[] LoadLabel(SerializationInfo info)
        {
            return LoadBytes("Label", info);
        }

        /// <summary>
        /// Saves label
        /// </summary>
        /// <param name="label">Label to save</param>
        /// <param name="bytes">Bytes of label</param>
        /// <param name="info">Info</param>
        public static void SaveLabel(object label, byte[] bytes, SerializationInfo info)
        {
            if (label != null)
            {
                info.Serialize<object>("Label", label);
                return;
            }
            byte[] b = bytes;
            if (b == null)
            {
                b = new byte[0];
            }
            info.AddValue("Label", b, typeof(byte[]));
        }

        /// <summary>
        /// Gets object from bytes
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="obj">The object</param>
        /// <param name="bytes">Bytes</param>
        /// <returns>The object</returns>
        public static T GetObject<T>(ref T obj, byte[] bytes) where T : class
        {
            if (obj != null)
            {
                return obj;
            }
            if (bytes == null)
            {
                return null;
            }
            if (bytes.Length == 0)
            {
                return null;
            }
            try
            {
                obj = StaticExtensionSerializationInterface.Deserialize<T>(bytes);
                if (obj != null)
                {
                    return obj;
                }
            }
            catch (Exception ee)
            {
                ee.HandleException(10);
            }
            MemoryStream ms = new MemoryStream(bytes);
            BinaryFormatter bf = new BinaryFormatter();
            SerializationBinder binder = StaticExtensionSerializationInterface.Binder;
            if (binder == null)
            {
                try
                {
                    obj = bf.Deserialize(ms) as T;
                }
                catch (Exception ex)
                {
                    ex.HandleException(10);
                    return null;
                }
            }
            else
            {
                try
                {
                    bf.Binder = binder;
                    obj = bf.Deserialize(ms) as T;
                }
                catch (Exception exc)
                {
                    exc.HandleException(10);
                    return null;
                }
            }
            return obj;
        }

        /// <summary>
        /// Gets properties
        /// </summary>
        /// <param name="properties">Properties</param>
        /// <param name="bytes">Bytes</param>
        /// <returns>Properties</returns>
        public static object GetProperties(object properties, byte[] bytes)
        {
            if (properties != null)
            {
                return properties;
            }
            if (bytes == null)
            {
                return null;
            }
            if (bytes.Length == 0)
            {
                return null;
            }
            try
            {
                object obj = StaticExtensionSerializationInterface.Deserialize<object>(bytes);
                if (obj != null)
                {
                    return obj;
                }
            }
            catch (Exception ex)
            {
                /*// !!!!
                using (var stream = File.OpenWrite("bytes.bin"))
                {
                    stream.Write(bytes);
                }
                ex.HandleException();//*/
            }
            return null;
        }

        /// <summary>
        /// Checks whether object can be setialized
        /// </summary>
        /// <param name="o">Object to check</param>
        public static void CheckSerialization(object o)
        {
            MemoryStream ms = new MemoryStream();
            BinaryFormatter bf = new BinaryFormatter();
            try
            {
                bf.Serialize(ms, o);
            }
            catch (Exception e)
            {
                e.HandleException(10);
                throw e;
            }
        }

        /// <summary>
        /// Path of component desktops
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>Desktop path</returns>
        static public List<IDesktop> GetPath(INamedComponent component)
        {
            List<IDesktop> l = new List<IDesktop>();
            IDesktop d = component.Desktop;
            while (true)
            {
                if (d == null)
                {
                    break;
                }
                l.Add(d);
                d = d.ParentDesktop;
            }
            return l;
        }

 
        /// <summary>
        /// Position of stream
        /// </summary>
        public long StreamPosition
        {
            get
            {
                return streamPosition;
            }
        }

    
        #endregion

        #region Internal Members

        internal bool Load(byte[] buffer, SerializationBinder binder, bool post)
        {
            MemoryStream stream = new MemoryStream(buffer);
            return Load(stream, binder, post);
        }

        internal bool Load(Stream stream, bool post)
        {
            return Load(stream, StaticExtensionSerializationInterface.Binder, post);
        }

        internal bool Load(byte[] buffer, bool post)
        {
            return Load(buffer, StaticExtensionSerializationInterface.Binder, post);
        }

        internal bool loadBinder(Stream stream, SerializationBinder binder, bool post)
        {
            if (binder == null)
            {
                if (load(stream, null, post))
                {
                    PostLoadPrivate();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            ObjectContainerBase.Binder = binder;
            if (load(stream, binder, post))
            {
                PostLoadPrivate();
                return true;
            }
            return false;
        }
   
        private bool load(Stream stream, SerializationBinder binder, bool post)
        {
            stream.Position = 0;
            BinaryFormatter bformatter = new BinaryFormatter();
            if (binder != null)
            {
                bformatter.Binder = binder;
            }
            try
            {
                objects = new List<IObjectLabel>();
                arrows = new List<IArrowLabel>();
                ArrayList objs = bformatter.Deserialize(stream) as ArrayList;
                ArrayList arrs = bformatter.Deserialize(stream) as ArrayList;
                if (objs != null)
                {
                    objects = new List<IObjectLabel>();
                    foreach (IObjectLabel l in objs)
                    {
                        objects.Add(l);
                    }
                }
                if (arrs != null)
                {
                    arrows = new List<IArrowLabel>();
                    foreach (IArrowLabel l in arrs)
                    {
                        arrows.Add(l);
                    }
                }
                foreach (object o in objects)
                {
                    if (o is INamedComponent)
                    {
                        INamedComponent nc = o as INamedComponent;
                        nc.Desktop = this;
                        string n = nc.Name;
                        if (!table.ContainsKey(n))
                        {
                            table[n] = nc;
                        }
                    }
                    if (o is IObjectLabel l)
                    {
                       object os = l.Object;
                        if (os is IAssociatedObject)
                        {
                            IAssociatedObject ass = os as IAssociatedObject;
                            ass.Object = l;
                            PostSetObject(ass);
                        }
                        if (os is IObjectContainer oc)
                        {
                            bool lb = oc.Load();
                            if (!lb)
                            {
                                return false;
                            }
                        }
                    }
                } 
                foreach (object o in arrows)
                {
                    if (o is INamedComponent)
                    {
                        if (o is IArrowLabel)
                        {
                            IArrowLabel l = o as IArrowLabel;
                            object os = l.Arrow;
                            if (os is IAssociatedObject ass)
                            {
                                ass.Object = l;
                                PostSetObject(ass);
                            }
                        }
                        INamedComponent nc = o as INamedComponent;
                        string n = nc.Name;
                        if (!table.ContainsKey(n))
                        {
                            table[n] = nc;
                        }
                        nc.Desktop = this;
                    }
                }
                if (post)
                {
                   bool b = PostLoad();
                   if (!b)
                   {
                       return false;
                   }
                   return PostDeserialize();
                }
                return true;
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                if (exceptions != null)
                {
                    exceptions.Add(ex);
                }
            }
            return false;
        }


        private void PostLoadPrivate()
        {
            this.ForEach((IPostLoad post) => { post.Post(); });
        }

        /// <summary>
        /// Loads Comments from stream
        /// </summary>
        /// <param name="stream">The stream</param>
        private void LoadComments(Stream stream)
        {
            streamPosition = stream.Position;
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                commentBytes = bf.Deserialize(stream) as byte[];
                if (commentBytes != null)
                {
                    streamPosition = stream.Position;
                }
            }
            catch (Exception ex)
            {
                ex.HandleException(10);
                stream.Position = streamPosition;
            }
        }

        #endregion

    }
}
