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
        Dictionary<string, Material> dict = new();


        public MtlWrapper()
        {

        }

        public  Dictionary<string, Material> Create(string filename, string directory)
        {
            dict.Clear();
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

        public string Name { get; private set; }

        public Color Ambient { get; private set; }

        public Color Diffuse { get; private set; }

        public Color Specular { get; private set; }


        public float Ns { get; private set; }
        public float Ni { get; private set; }
        public float d { get; private set; }
        public float illum { get; private set; }

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
            MaterialGroup mat = new MaterialGroup();
            var children = mat.Children;
            material = mat;
            var diffuse = new DiffuseMaterial(Diffuse, Kd, d);
            //diffuse.Texture = Kd;
            children.Add(diffuse);
            var emissive = new EmissiveMaterial(Ambient, Ka);
             children.Add(emissive);
            var specular = new SpecularMaterial(Specular, Ns);
            children.Add(specular);

        }

        private MtlWrapper(string str, string directory, StreamReader reader, Dictionary<string, Material> materials)
        {
            Name = str;
            string newName = "";

            List<string> list = new List<string>();
            do
            {
                var line = reader.ReadLine();
                if (line.Length > 0)
                {
                    list.Add(line);
                }
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
            materials[Name] = Material;

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
                    case "Ka":
                        Ambient = new Color(value);
                        break;
                    case "Kd":
                        Diffuse = new Color(value);
                        break;
                    case "Ks":
                        Specular = new Color(value);
                        break;
                    case "map_Ka":
                        Ka = new Image(value, directory);
                        break;
                    case "map_Kd":
                        Kd = new Image(value, directory);
                        break;
                    case "Ns":
                        Ns = ToFloat(value);
                        break;
                    case "Ni":
                        Ni = ToFloat(value);
                        break;
                    case "d":
                        d = ToFloat(value);
                        break;
                    case "illum":
                        illum = ToFloat(value);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}