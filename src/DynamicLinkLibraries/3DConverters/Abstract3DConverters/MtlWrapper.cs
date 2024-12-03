using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Collada;

namespace Abstract3DConverters
{
    public class MtlWrapper : IMaterialDictionary
    {
        Dictionary<string, Material> dict;


        public MtlWrapper()
        {
            dict = new Dictionary<string, Material>();
        }

        public Dictionary<string, object> Create( Dictionary<string, Material> keyValuePairs, IMaterialCreator creator)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();
            foreach ( var pair in keyValuePairs )
            {
                Material mat = pair.Value;
                var v = creator.Create(mat);
                d[pair.Key] = v;
            }
            return d;
        }

        public  Dictionary<string, Material> Create(string filename, string directory)
        {
            using (var reader = new StreamReader(Path.Combine(directory, filename)))
            {
                new MtlWrapper(filename, directory, reader, dict);

            }
            return dict;

        }

        public Dictionary<string, Material> Create(string filename)
        {
            dict.Clear();
            using (var reader = new StreamReader(filename))
            {
                do
                {
                    var line = reader.ReadLine();
                    if (line.Contains("newmtl"))
                    {
                        var ss = line.Split(" ".ToCharArray());
                        var name = ss[ss.Length - 1];
                        new MtlWrapper(name, Path.GetDirectoryName(filename), reader, dict);
                    }
                }
                while (!reader.EndOfStream);
            }
            return dict;
        }


        public Image Ka { get; private set; }
        public Image Kd { get; private set; }
        public Image Ks { get; private set; }

        public string Name { get; private set; }

        public Color Ambient { get; private set; }

        public Color Diffuse { get; private set; }

        public Color Specular { get; private set; }


        public float Ns { get; private set; }
        public float Ni { get; private set; }
        public float d { get; private set; }
        public int illum { get; private set; }

 
        private Material material;
        public Material Material
        {
            get
            {
                Create();
                return material;
            }
        }

        Dictionary<string, Material> IMaterialDictionary.Materials => dict;

        void Create()
        {
            if (material != null)
            {
                return;
            }
            if (Diffuse == null)
            {
                return;
            }
            MaterialGroup mat = new MaterialGroup();
            var children = mat.Children;
            material = mat;
            if (Diffuse != null)
            {
                var diffuse = new DiffuseMaterial(Diffuse, null, Kd, d);
                //diffuse.Texture = Kd;
                children.Add(diffuse);
            }
            if (Ambient != null)
            {
                var emissive = new EmissiveMaterial(Ambient, Ka);
                children.Add(emissive);
            }
            if (Specular != null)
            {
                var specular = new SpecularMaterial(Specular, Ns);
                children.Add(specular);
            }
        }

        bool first = false;

        private MtlWrapper(string str, string directory, StreamReader reader, Dictionary<string, Material> materials)
        {
            Name = str;
            string newName = "";

            List<string> list = new List<string>();
            do
            {
                var line = reader.ReadLine();
                if (line.Length ==  0)
                {
                    continue;
                }
                list.Add(line);
                if (line.Contains("newmtl"))
                {
                    var ss = line.Split(" ".ToCharArray());
                    newName = ss[ss.Length - 1];
                    break;
                }
                if (reader.EndOfStream)
                {
                    break;
                }
            }
            while (!reader.EndOfStream);
            
            Finalize(list, directory);
            Create();
            var mat = Material;
            if (mat != null)
            {
                materials[Name] = Material;
            }

            if (!reader.EndOfStream)
            {
                new MtlWrapper(newName, directory, reader, materials);
            }

        }

        private  float ToFloat(string str)
        {
            return float.Parse(
                str.Replace(".",
                System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
        }


        void Finalize(List<string> list, string directory)
        {
            foreach (var s in list)
            {
                if (s.Length == 0)
                {
                    continue;
                }
                var t = s.Trim();
                int n = t.IndexOf(" ");
                var name = t.Substring(0, n);
                var value = t.Substring(n);
                switch (name)
                {
                    /// The ambient color of the material is declared using Ka. Color definitions are in RGB where each channel's 
                    /// value is between 0 and 1.

                    case "Ka":
                        Ambient = new Color(value);
                        break;
                    case "Kd":
                      //  Similarly, the diffuse color is declared using Kd.
                        Diffuse = new Color(value);
                        break;
                    case "Ks":
               //         The specular color is declared using Ks, and weighted using the specular exponent Ns.
                        Specular = new Color(value);
                        break;
                       // the ambient texture map
                    case "map_Ka":
                        Ka = new Image(value, directory);
                        break;
                    // the diffuse texture map 
                    case "map_Kd":
                        Kd = new Image(value, directory);
                        break;

                    //# specular color texture map
                    case "map_Ks":
                        Ks = new Image(value, directory);
                        break;
                    case "Ns":
                /// Specular exponent ranges between 0 and 1000                        Ns 10.000            
                        Ns = ToFloat(value);
                        break;
                    case "Ni":
                        // # optical density                    Values can range from 0.001 to 10
                        Ni = ToFloat(value);
                        break;
                    case "d":
// some implementations use 'd'        d 0.9 # others use 'Tr' (inverted: Tr = 1 - d) Tr 0.1
                        d = ToFloat(value);
                        break;
                    case "Tr":
                        d = 1 - ToFloat(value);
                        break;
            //            illumination model
                    case "illum":
                        illum = int.Parse(value);
                        break;
                    default:
                        break;
                        
                }
            }
        }
    }
}