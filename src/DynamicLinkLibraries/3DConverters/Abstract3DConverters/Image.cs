namespace Abstract3DConverters
{
    /// <summary>
    /// Image
    /// </summary>
    public class Image : ICloneable, IEquatable<Image>
    {
        static public string DefaultPath { get; set; }

        Service s = new();

        public string Name { get; private set; }

        public string Directory { get; private set; }

        public string FullPath { get; private set; }

        public Image(string name, string directory, string delimiter = null)
        {
            var ch = StaticExtensionAbstract3DConverters.CheckFile;
            Find = (ch == CheckFile.Check) ? FindFile : FindEmpty;
            if (directory == null)
            {
                Name = name;
                FullPath = name;
                return;
            }
            var n = Path.GetFileName(name);
            Directory = directory;
            Name = Find(n, Directory, delimiter);
            if (Name == null)
            {
                Name = name;
                return;
            }
            Name = Name.Replace(Path.DirectorySeparatorChar, '/');
            if (Name.StartsWith("/"))
            {
                Name = Name.Substring(1);
            }
            FullPath = Path.Combine(Directory, Name);
            if (!s.FileExists(FullPath))
            {
                throw new Exception("Image exception");
            }
        }

        private Func<string, string, string, string> Find;

        private string FindEmpty(string name, string directory, string delimiter)
        {
            return  Path.Combine(directory, name);
        }

        private string FindFile(string name, string directory, string delimiter)
        {
            var f = Path.Combine(directory, name);
            if (File.Exists(f))
            {
                return f.Substring(Directory.Length);
            }
            if (delimiter != null)
            {
                if (f.Contains(delimiter))
                {
                    f = f.Replace(delimiter, " ");
                    if (File.Exists(f))
                    {
                        return f.Substring(Directory.Length);
                    }
                }
            }
            if (f.Contains("%"))
            {
                f = f.Replace("%20", " ");
                if (File.Exists(f))
                {
                    return f.Substring(Directory.Length);
                }
            }
            var dirs = System.IO.Directory.GetDirectories(directory);
            foreach (var d in dirs)
            {
                var s = Find(name, d, delimiter);
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

        bool IEquatable<Image>.Equals(Image? other)
        {
            if (other == null)
            {
                return false;
            }
            return Name == other.Name;
        }


    }
}
