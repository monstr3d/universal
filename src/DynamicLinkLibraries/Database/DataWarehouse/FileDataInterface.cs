using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Xml;
using System.IO;

using DataWarehouse.Interfaces;


namespace DataWarehouse
{

/*
    /// <summary>
    /// File system database interface
    /// </summary>
    public class FileDataInterface : IDatabaseInterface, IDatabaseCoordinator
    {

        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        static public FileDataInterface Singleton = new FileDataInterface();

        /// <summary>
        /// Directory
        /// </summary>
        private string directory;


        private IDatabaseInterface data;

        private string ext;

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directory">Directory</param>
        public FileDataInterface(string directory)
        {
            this.directory = directory;
            data = this;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="directory">Directory</param>
        /// <param name="ext">Extension</param>
        public FileDataInterface(string directory, string ext)
            : this(directory)
        {
            this.ext = ext;
        }

        private FileDataInterface()
        {
        }

        #endregion

        
        #region IDatabaseInterface Members
/*
        void IDatabaseInterface.Login(string login, string password, object key)
        {
        }

        XmlDocument IDatabaseInterface.GetTree(string login, string password, object key, string[] ext)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\"?><Root><BinaryRoot></BinaryRoot></Root>");
            createXmlNode(directory, doc, doc.DocumentElement, ext);
            return doc;
        }

        string IDatabaseInterface.GetTreeString(string login, string password, object key, string[] ext)
        {
            XmlDocument doc = data.GetTree(login, password, key, ext);
            return doc.OuterXml;
        }

        byte[] IDatabaseInterface.GetData(string login, string password, object key, string id, ref string ext)
        {
            ext = Path.GetExtension(id);
            Stream stream = File.OpenRead(id);
            byte[] b = new byte[stream.Length];
            stream.Read(b, 0, b.Length);
            stream.Close();
            return b;
        }

        string IDatabaseInterface.AddData(string login, string password, object key, string parentId, string name, string description, byte[] data, string ext)
        {
            string s = addPathSeparator(parentId) + name + "." + ext;
            write(data, s);
            return s;
        }

        void IDatabaseInterface.UpdateData(string login, string password, object key, string id, byte[] data)
        {
            write(data, id);
        }

        string IDatabaseInterface.AddDirectory(string login, string password, object key, string parentId, string name, string description, string ext)
        {
            string s = addPathSeparator(parentId) + name;
            Directory.CreateDirectory(s);
            return s;
        }

        void IDatabaseInterface.UpdateData(string login, string password, object key, string Id, string name, string description)
        {
            string s = addPathSeparator(Id) + name;
            File.Replace(Id, s, Id + ".bak");
            File.Delete(Id);
        }

        void IDatabaseInterface.UpdateDirectory(string login, string password, object key, string id, string name, string description)
        {
            int n = id.LastIndexOf(Path.DirectorySeparatorChar);
            string s = id.Substring(0, n + 1) + name;
            Directory.CreateDirectory(s);
            Directory.Move(id, s);
            Directory.Delete(id);
        }

        void IDatabaseInterface.RemoveData(string login, string password, object key, string id)
        {
            File.Delete(id);
        }

        void IDatabaseInterface.RemoveDirectory(string login, string password, object key, string id)
        {
            Directory.Delete(id);
        }

        Hashtable IDatabaseInterface.GetItems(string login, string password, object key, string ext)
        {
            Hashtable t = new Hashtable();
            addDir(directory, ext, t);
            return t;
        }*//*
        #endregion
 
        #region IDatabaseCoordinator Members

        /// <summary>
        /// Access to database interface
        /// IDatabaseCoordinator method
        /// </summary>
        /// <param name="name">Name of database</param>
        /// <returns>The interface</returns>
        public IDatabaseInterface this[string name]
        {
            get
            {
                string dir = name + "";
                if (dir.Contains("."))
                {
                    int n = dir.LastIndexOf(Path.DirectorySeparatorChar);
                    dir = dir.Substring(0, n);
                    if (Directory.Exists(dir))
                    {
                        n = name.LastIndexOf('.');
                        string ext = name.Substring(n);
                        return new FileDataInterface(dir, ext.ToLower());
                    }
                }
                if (Directory.Exists(name))
                {
                    return new FileDataInterface(name);
                }
                return null;
            }
        }

        /// <summary>
        /// IDatabaseCoordinator Create method
        /// </summary>
        /// <param name="name">Name of database</param>
        /// <returns>True in success and false otherwise</returns>
        public bool Create(string name)
        {
            return false;
        }


        #endregion

        #region Specific Members

        static void write(byte[] b, string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            Stream stream = File.OpenWrite(filename);
            stream.Write(b, 0, b.Length);
            stream.Close();
        }

        static string addPathSeparator(string path)
        {
            string s = path + "";
            if (s[s.Length - 1] != Path.DirectorySeparatorChar)
            {
                s += Path.DirectorySeparatorChar;
            }
            return s;

        }

        static void addDir(string path, string ext, IDictionary<object, object> table)
        {
            string[] files = Directory.GetFiles(path, "*." + ext);
            foreach (string file in files)
            {
                table[file] = new object[] { file };
            }
            string[] dir = Directory.GetDirectories(path);
            foreach (string d in dir)
            {
                addDir(d, ext, table);
            }
        }

        void createXmlNode(string dir, XmlDocument doc, XmlElement parent, string[] ext)
        {
            XmlElement e = doc.CreateElement("BinaryNode");
            parent.AppendChild(e);
            e.SetAttribute("BinaryNodeId", dir);
            int n = dir.LastIndexOf(Path.DirectorySeparatorChar);
            string name = dir.Substring(n + 1);
            e.SetAttribute("BinaryNodeName", name);
            XmlElement d = doc.CreateElement("Description");
            e.AppendChild(d);
            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                string ex = Path.GetExtension(file);
                if (this.ext != null)
                {
                    if (ex.ToLower().Equals(this.ext.ToLower()))
                    {
                        XmlElement ef = doc.CreateElement("Binary");
                        e.AppendChild(ef);
                        ef.SetAttribute("BinaryId", file);
                        ef.SetAttribute("BinaryName", Path.GetFileNameWithoutExtension(file));
                        ef.SetAttribute("Ext", ex);
                        XmlElement df = doc.CreateElement("Description");
                        ef.AppendChild(df);
                        continue;
                    }
                }
                foreach (string et in ext)
                {
                    if (et.ToLower().Equals(ex.ToLower()))
                    {
                        XmlElement ef = doc.CreateElement("Binary");
                        e.AppendChild(ef);
                        ef.SetAttribute("BinaryId", file);
                        ef.SetAttribute("BinaryName", Path.GetFileNameWithoutExtension(file));
                        ef.SetAttribute("Ext", et);
                        XmlElement df = doc.CreateElement("Description");
                        ef.AppendChild(df);
                        break;
                    }
                }
            }
            string[] dirs = Directory.GetDirectories(dir);
            foreach (string di in dirs)
            {
                createXmlNode(di, doc, e, ext);
            }
        }

        #endregion


        #region IDatabaseInterface Members

        void IDatabaseInterface.Login(string login, string password, object key)
        {
        }

        IDirectory[] IDatabaseInterface.GetRoots(string login, string password, object key, string[] ext)
        {
            return new IDirectory[]
            {
                new FileDirectory(null, directory, ext[0])
            };
        }

        void IDatabaseInterface.Refresh(string login, string password, object key, string[] ext)
        {
        }

        /// <summary>
        /// Gets data
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="id">Id</param>
        /// <param name="extension">Extension</param>
        /// <returns>Data</returns>
        public byte[] GetData(string login, string password, object key,
            string id, ref  string extension)
        {
            ext = Path.GetExtension(id);
            Stream stream = File.OpenRead(id);
            byte[] b = new byte[stream.Length];
            stream.Read(b, 0, b.Length);
            stream.Close();
            return b;
        }

        /// <summary>
        /// Gets items
        /// </summary>
        /// <param name="login">Login</param>
        /// <param name="password">Password</param>
        /// <param name="key">Key</param>
        /// <param name="extension">Extension</param>
        /// <returns>Items dictionary</returns>
        public IDictionary<object, object> GetItems(string login, string password, object key, string extension)
        {
            IDictionary<object, object> dictionatry = new Dictionary<object, object>();
            addDir(directory, ext, dictionatry);
            return dictionatry;
        }

 
        #endregion


        #region FileDirectory class

        class FileDirectory : IDirectory
        {
            #region Fields

            string path;
            string ext;

            List<IDirectory> dirs = new List<IDirectory>();

            internal List<ILeaf> leafs = new List<ILeaf>();

            FileDirectory parent;

            #endregion

            #region Ctor

            internal FileDirectory(FileDirectory parent, string path, string ext)
            {
                this.parent = parent;
                if (parent != null)
                {
                    parent.dirs.Add(this);
                }
                this.path = path;
                this.ext = ext;
                string[] dirs = Directory.GetDirectories(path);
                foreach (string d in dirs)
                {
                    new FileDirectory(this, d, ext);
                }
                this.dirs.Sort(NodeComparer.Singleton);
                string[] files = Directory.GetFiles(path);
                foreach (string f in files)
                {
                    new FileLeaf(this, f, ext);
                }
                leafs.Sort(NodeComparer.Singleton);
            }


            #endregion

            #region IDirectory Members

            IDirectory IDirectory.Add(string name, string description, string ext)
            {
                throw new NotImplementedException();
            }

            ILeaf IDirectory.Add(string name, string description, byte[] data, string ext)
            {
                throw new NotImplementedException();
            }

            #endregion

            #region INode Members

            object INode.Id
            {
                get { return path; }
            }

            string INode.Name
            {
                get
                {
                    return path;
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            string INode.Description
            {
                get
                {
                    return "";
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            string INode.Extension
            {
                get { return ext; }
            }

            void INode.Remove()
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IEnumerable<IDirectory> Members

            IEnumerator<IDirectory> IEnumerable<IDirectory>.GetEnumerator()
            {
                return dirs.GetEnumerator();
            }

            #endregion

            #region IEnumerable Members

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }

            #endregion

            #region IEnumerable<ILeaf> Members

            IEnumerator<ILeaf> IEnumerable<ILeaf>.GetEnumerator()
            {
                return leafs.GetEnumerator();
            }

            #endregion
        }

        #endregion

        #region FileLeaf class

        class FileLeaf : ILeaf
        {
            #region Fields
            string path;
            string ext;
            FileDirectory parent;
            #endregion

            #region Ctor
            internal FileLeaf(FileDirectory parent, string path, string ext)
            {
                this.parent = parent;
                this.path = path;
                this.ext = ext;
                parent.leafs.Add(this);
            }

            #endregion

            #region ILeaf Members

            byte[] ILeaf.Data
            {
                get
                {
                    Stream stream = File.OpenRead(path);
                    byte[] b = new byte[stream.Length];
                    stream.Read(b, 0, b.Length);
                    stream.Close();
                    return b;
                }
                set
                {
                    if (File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    Stream stream = File.OpenWrite(path);
                    stream.Write(value, 0, value.Length);
                    stream.Close();
                }
            }

            #endregion

            #region INode Members

            object INode.Id
            {
                get { return path; }
            }

            string INode.Name
            {
                get
                {
                    return Path.GetFileNameWithoutExtension(path);
                }
                set
                {
                    string p = Path.GetDirectoryName(path);
                    string np = p + value + ext;
                    File.Move(path, np);
                    File.Delete(path);
                    path = np;
                }
            }

            string INode.Description
            {
                get
                {
                    return path;
                }
                set
                {
                }
            }

            string INode.Extension
            {
                get { return ext; }
            }

            void INode.Remove()
            {
                parent.leafs.Remove(this);
                File.Delete(path);
            }

            #endregion
        }

        #endregion

    }*/
}
