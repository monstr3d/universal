﻿using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

namespace Abstract3DConverters
{
    public class Image : ICloneable
    {

        public string Name { get; private set; }

        public string Directory { get; private set; }

        public string FullPath { get; private set; }

        public Image(string name, string directory)
        {
            var n = Path.GetFileName(name);
            Directory = directory;
            Name = Find(n, Directory);
            FullPath = Directory + Name;
            var p = File.Exists(FullPath);
        }

        private string Find(string name, string directory)
        {
            var f = Path.Combine(directory, name);
            if (File.Exists(f))
            {
                return f.Substring(Directory.Length);
            }
            var dirs = System.IO.Directory.GetDirectories(directory);
            foreach (var d in dirs)
            {
                var s = Find(name, d);
                if (s != null)
                {
                    return s;
                }
            }
            return null;
        }

        public object Clone()
        {
            return new Image(Name, Directory);
        }
    }
}