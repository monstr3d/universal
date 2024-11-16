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

        Dictionary<string, AbstractMesh> models = new();

        public ObjToXamlConverter()
        {

        }

    
        public Dictionary<string, AbstractMesh> Create(string filename)
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
            List<float[]> vertices = new();
            List<float[]> normals = new();
            List<float[]> textures = new();

            ModelVisual3D modelVisual3D = new ModelVisual3D();
            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    models[name] = modelVisual3D;
                    break;
                }
                var objs = "# object ";
                if (line.Contains(objs))
                {
                    var lt = line.Substring(objs.Length).Trim();
                    if (currName == null)
                    {
                        currName = lt;
                        if (name != null)
                        {
                            models[name] = modelVisual3D;
                            Create(reader, currName);
                        }

                    }
                    else
                    {
                        models[currName] = modelVisual3D;
                        Create(reader, lt);

                    }
                }
                if (currName == null)
                {
                    continue;
                }
                if (line.IndexOf("v ") == 0)
                {
                    var f = line.Substring("v ".Length).Trim().ToRealArray<float>();
                    vertices.Add(f);
                    continue;
                }
                if (line.IndexOf("vn ") == 0)
                {
                    var f = line.Substring("vn ".Length).Trim().ToRealArray<float>();
                    normals.Add(f);
                    continue;
                }
                if (line.IndexOf("vt ") == 0)
                {
                    var f = line.Substring("vt ".Length).Trim().ToRealArray<float>();
                    textures.Add(f);
                    continue;
                }
                int i = 0;
            }
        }

    }
}
