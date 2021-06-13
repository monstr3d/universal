using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

using UnityEngine;

namespace Scripts
{

    [Serializable()]
    public class Saver : ISerializable
    {
        #region Fields

        public static Saver saver;

        public int level = 0;
 
        public Dictionary<int, Tuple<int, KeyCode[]>> dictionary;
        
        public Dictionary<int, KeyCode> dict;

        internal KeyCode unused = KeyCode.F11;


        Dictionary<string, int> d = new Dictionary<string, int>()
        {
            { "Pitch" , 3 },
            { "Roll" , 5 },
            { "Heading" , 4 },
            { "X" , 2 },
            { "Y" , 0 },
            { "Z" , 1}
         };

        List<string> l = new List<string>()
        {
            "X", "Y", "Z", "Roll", "Pitch", "Heading"
        };

        Dictionary<string, KeyCode[]> codes = new Dictionary<string, KeyCode[]>();

        static string path;
        public  Dictionary<int, KeyCode> Dict
        {
            get { return new Dictionary<int, KeyCode>(dict); }
            set { dict = value; }
        }

        #endregion

        #region Ctor

        static Saver()
        {
            path = Application.persistentDataPath + "/gamesave.save";
            if (File.Exists(path))
            {
                using (Stream stream = File.OpenRead(path))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    saver = bf.Deserialize(stream) as Saver;
                }
            }
            else
            {
                saver = new Saver();
            }
            Application.quitting += () =>
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
                using (Stream stream = File.OpenWrite(path))
                {
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(stream, saver);
                }
            };
        }


        public Saver()
        {
            Reset();
            foreach (var key in d.Keys)
            {
                if (key.Length == 0)
                {
                    continue;
                }
                codes[key] = dictionary[d[key]].Item2;
            }
            SetCodes();
        }

        private Saver(SerializationInfo info, StreamingContext context)
        {
            dictionary = info.GetValue("Dictionary", typeof(Dictionary<int, Tuple<int, KeyCode[]>>)) as
               Dictionary<int, Tuple<int, KeyCode[]>>;
            dict = info.GetValue("Dict", typeof(Dictionary<int, KeyCode>)) as
               Dictionary<int,  KeyCode>;
            unused = (KeyCode)info.GetValue("unused",  typeof(KeyCode));
            Unity.Standard.StaticExtensionUnity.UnusedKey = unused;
            level = info.GetInt32("Level");
            SetCodes();
        }

        #endregion

        public Dictionary<int, KeyCode> KeyValuePairs
        {
            get
            {
                var kk = new Dictionary<int, KeyCode>();
                for (int i = 0; i < l.Count; i++)
                {
                    string s = l[i];
                    var a = d[s];
                    var tt = dictionary[a].Item2;
                    var k = 2 * i;
                    for (int j = 0; j < 2; j++)
                    {
                        kk[k + j] = tt[j];
                    }
                }
                return kk;
            }
            set
            {
                for (int i = 0; i < l.Count; i++)
                {
                    string s = l[i];
                    var a = d[s];
                    var tt = dictionary[a].Item2;
                    var k = 2 * i;
                    for (int j = 0; j < 2; j++)
                    {
                        tt[j] = value[k + j];
                    }
                }
            }

        }

        internal void SetUnused()
        {
            List<KeyCode> l = new List<KeyCode>();
            l.AddRange(KeyValuePairs.Values);
            l.AddRange(dict.Values);
            if (l.Contains(unused))
            {
                var en = Enum.GetValues(typeof(KeyCode));
                foreach (KeyCode k in en)
                {
                    if (k == default(KeyCode))
                    {
                        continue;
                    }
                    if (!l.Contains(k))
                    {
                        unused = k;
                        Unity.Standard.StaticExtensionUnity.UnusedKey = unused;
                        return;
                    }
                }
            }
        }

        public void SetCodes()
        {
            foreach (var key in codes.Keys)
            {
                var cc = codes[key];
                var i = d[key];
                var tt = dictionary[i];
                var tcc = tt.Item2;
                for (int k = 0; k < 2; k++)
                {
                    tcc[k] = cc[k];
                }
            }
        }


        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Dictionary", dictionary,
                  typeof(Dictionary<int, Tuple<int, KeyCode[]>>));
            info.AddValue("Dict", dict, typeof(Dictionary<int, KeyCode>));
            info.AddValue("unused", unused, typeof(KeyCode));
            info.AddValue("Level", level);
        }


        internal void Reset()
        {
            dict =
            new Dictionary<int, KeyCode>() { { 12, KeyCode.Escape }, { 13, KeyCode.Return }, { 14, KeyCode.F1 } };

            dictionary = new
     Dictionary<int, Tuple<int, KeyCode[]>>()
        {
            {3, new Tuple<int, KeyCode[]>(3, new KeyCode[]{KeyCode.W, KeyCode.S } )},
            {5, new Tuple<int, KeyCode[]>(4, new KeyCode[]{KeyCode.Q, KeyCode.E } )},
            {4, new Tuple<int, KeyCode[]>(5, new KeyCode[]{KeyCode.D, KeyCode.A } )},
            {2, new Tuple<int, KeyCode[]>(0, new KeyCode[]{KeyCode.RightShift,
                KeyCode.RightControl} )},
            {0, new Tuple<int, KeyCode[]>(1, new KeyCode[]{KeyCode.RightArrow,
                KeyCode.LeftArrow} )},
           {1, new Tuple<int, KeyCode[]>(2, new KeyCode[]{KeyCode.UpArrow,
               KeyCode.DownArrow} ) }
                };
            unused = KeyCode.F11;
        }



    }
}
