namespace Abstract3DConverters.Materials
{
    public abstract class Material : ICloneable
    {
        public Color Color { get; set; }

        public string Name { get; protected set; } = null;


        public object Clone()
        {
            return CloneIfself();
        }

        protected abstract object CloneIfself();

        public abstract bool HasImage { get;  }
        public Material SetImage(Image image)
        {
            var name = Name + "-";
            if (image == null)
            {
                name += Path.GetRandomFileName();
            }
            else
            {
                name += image.Name;
            }
            if (this is MaterialGroup group)
            {
                var mat = new MaterialGroup(name);
                foreach (var child in group.Children)
                {
                    var m = child.Clone() as Material;
                    if (m is DiffuseMaterial diffuse)
                    {
                        if (diffuse.Image != null)
                        {
                            throw new Exception();
                        }
                        diffuse.Image = image;
                    }
                    mat.Children.Add(m);
                }
                return mat;
            }
            return null;


        }
    }
}
