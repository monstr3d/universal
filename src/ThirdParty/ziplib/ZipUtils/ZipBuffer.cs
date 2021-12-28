using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZipUtils
{
    /// <summary>
    /// Zip buffer
    /// </summary>
    public class ZipBuffer : IDictionary<string, string>, IDisposable
    {
        /// <summary>
        /// Buffer of Zip
        /// </summary>
        #region Fields
        
        string directory;

        string fileName;

        Dictionary<string, byte[]> buffer;

        Dictionary<string, string> d = new Dictionary<string, string>();

        ICollection<KeyValuePair<string, string>> coll;

        IEnumerable<KeyValuePair<string, string>> en;

        System.Collections.IEnumerable enu;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">File name</param>
        public ZipBuffer(string fileName) : this(fileName, StaticExtensionZipUtils.UnZipDirectory)
        {

        }


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="fileName">File name</param>
        /// <param name="directory">Directory</param>
        public ZipBuffer(string fileName, string directory)
        {
            coll = d;
            en = d;
            enu = d;
            this.fileName = fileName;
            this.directory = directory;
            directory.ClearDirectory();
            fileName.UnZip(directory);
            using (var zf = System.IO.Compression.ZipFile.OpenRead(fileName))
            {
                foreach (var ze in zf.Entries)
                {
                    string zn = ze.Name;
                    d[zn] = directory + zn.Replace('/', System.IO.Path.DirectorySeparatorChar);
                }
            }
         }

        #endregion

        #region Public Members

        /// <summary>
        /// File name
        /// </summary>
        public string FileName
        {
            get
            {
                return fileName;
            }
        }
 
        /// <summary>
        /// Saves it to directory
        /// </summary>
        /// <param name="fileName"></param>
        public void Save(string fileName)
        {
            directory.CreateZipFromDirectory(fileName);
        }

        #endregion

        #region IDisposable Members

        void IDisposable.Dispose()
        {
            directory.ClearDirectory();
        }

        #endregion

        #region IDictionary<string,string> Members

        void IDictionary<string, string>.Add(string key, string value)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, string>.ContainsKey(string key)
        {
            return d.ContainsKey(key);
        }

        ICollection<string> IDictionary<string, string>.Keys
        {
            get { return d.Keys; }
        }

        bool IDictionary<string, string>.Remove(string key)
        {
            throw new NotImplementedException();
        }

        bool IDictionary<string, string>.TryGetValue(string key, out string value)
        {
            return d.TryGetValue(key, out value);
        }

        ICollection<string> IDictionary<string, string>.Values
        {
            get { return d.Values; }
        }

        string IDictionary<string, string>.this[string key]
        {
            get
            {
                return d[key];
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        #region ICollection<KeyValuePair<string,string>> Members

        void ICollection<KeyValuePair<string, string>>.Add(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        void ICollection<KeyValuePair<string, string>>.Clear()
        {
            throw new NotImplementedException();
        }

        bool ICollection<KeyValuePair<string, string>>.Contains(KeyValuePair<string, string> item)
        {
            return coll.Contains(item);
        }

        void ICollection<KeyValuePair<string, string>>.CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
           coll.CopyTo(array, arrayIndex);
        }

        int ICollection<KeyValuePair<string, string>>.Count
        {
            get { return coll.Count; }
        }

        bool ICollection<KeyValuePair<string, string>>.IsReadOnly
        {
            get { return true; }
        }

        bool ICollection<KeyValuePair<string, string>>.Remove(KeyValuePair<string, string> item)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IEnumerable<KeyValuePair<string,string>> Members

        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            return en.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return enu.GetEnumerator();
        }

        #endregion
    }
}
