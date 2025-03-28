using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Creators
{
    public abstract class AbstractMeshCreator : IMeshCreator
    {

        protected virtual string Directory
        {
            get;
            set;
        }

     
        protected Service s = new Service();
   
        protected IMeshCreator creator;

        protected object[] Objects
        {
            get;
            private set;
        }

        protected string Extension
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="filename">File name</param>
        /// <param name="directory">File name</param>
        protected AbstractMeshCreator(string filename, string directory, params object[] objects)
        {
            Objects = Cut(objects);
            Filename = filename;
            Directory = (directory == null) ?  filename.GetDirectory() : directory;
            creator = this;
            Extension = Path.GetExtension(Filename);
        }


        string IMeshCreator.Directory => Directory;


        public abstract void Load(byte[] bytes);


        IEnumerable<IMesh> IMeshCreator.Meshes => Meshes;

        Dictionary<string, Effect> IMeshCreator.Effects => Effects;

        string IMeshCreator.Filename => Filename;


        protected abstract IEnumerable<IMesh> Meshes { get;  }

   
        protected abstract void CreateAll();

        protected virtual Dictionary<string, Effect> Effects
        {
            get;
        } = new();

        protected virtual Dictionary<string, Image> Images
        {
            get;
        } = new();

        protected virtual Dictionary<string, Material> Materials
        {
            get;
        } = new();


        protected virtual string Filename
        {
            get;
            set;
        }

  
        protected virtual void Perform(IMesh mesh, Action<IMesh> action)
        {
            var children = mesh.Children;
            foreach (var child in children)
            {
                Perform(child, action);
            }
            action(mesh);
        }

        object[] Cut(object[] obj)
        {
            for (int j = obj.Length - 1; j >= 0; j--)
            {
                if (obj[j] != null)
                {
                    var o = new object[j + 1];
                    Array.Copy(obj, o, o.Length);
                    return o;
                }
            }
            return [];
        }

    }
}
