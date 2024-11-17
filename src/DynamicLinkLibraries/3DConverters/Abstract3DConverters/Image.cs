namespace Abstract3DConverters
{
    public class Image
    {

        public string Name { get; private set; }

        public string Directory { get; private set; }
        public Image(string name, string directory)
        {
            Name = name;
            Directory = directory;

        }
    }
}
