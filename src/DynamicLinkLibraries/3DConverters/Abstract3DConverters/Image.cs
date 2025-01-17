namespace Abstract3DConverters
{
    public class Image : ICloneable
    {
        static public string DefaultPath { get; set; } 

        public string Name { get; private set; }

        public string Directory { get; private set; }

        public string FullPath { get; private set; }

        public Image(string name, string directory)
        {
            if (directory == null)
            {
                Name = name;
                FullPath = DefaultPath;
                return;
            }
            var n = Path.GetFileName(name);
            Directory = directory;
            Name = Find(n, Directory);
            if (Name == null)
            {
                return;
            }
            Name = Name.Replace(Path.DirectorySeparatorChar, '/');
            if (Name.StartsWith("/"))
            {
                Name = Name.Substring(1);
            }
            FullPath = Directory + "/" + Name;
            if (!File.Exists(FullPath))
            {
                throw new Exception();
            }
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
