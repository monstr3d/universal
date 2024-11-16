using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace Collada.Wpf
{
    public class ObjToXamlConverter
    {

        Dictionary<string, Material> materials;

        Dictionary<string, ModelVisual3D> models = new();

        public ObjToXamlConverter()
        {

        }

        private ObjToXamlConverter(Dictionary<string, Material> materials)
        {
            this.materials = materials;
        }

        

        public Dictionary<string, ModelVisual3D> Create(string filename)
        {
            StaticExtensionCollada.Directory = Path.GetDirectoryName(filename);
            var fn = filename.ConvertExtension(".mtl");
            if (File.Exists(fn))
            {
                var mtl = new MtlWrapper();
                materials = mtl.Create(fn);
            }
            else
            {
                materials = new Dictionary<string, Material>();
            }
            var dict = new Dictionary<string, ModelVisual3D>();
            models = new();
            using (var reader  = new StreamReader(filename))
            {
             
                Create(reader);

            }
            return null;
        }

        void Create(TextReader reader, string name = null)
        {
            string currName = name;
            
            ModelVisual3D modelVisual3D = new ModelVisual3D();
            while (true)
            {
                var line = reader.ReadLine();
                if (currName == null)
                {
                    var objs = "# object ";
                    if (line.Contains(objs))
                    {
                        currName = line.Substring(objs.Length).Trim();
                    }
                }
                else
                {
                    models[currName] = modelVisual3D;
                    
                }
            }
        }

    }
}
