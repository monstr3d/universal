using System.Reflection;
using System.Text;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    [Converter(".ac")]
    public class AcConverter : IMeshConverter, IStringRepresentation
    {
        #region Fields

        Service service = new();

        MaterialCreator materialCreator = new MaterialCreator();

        Service s = new();


        List<float[]> vertices;

        List<float[]> textures;

        List<float[]> normals;

        List<string> materials = new();

        Dictionary<string, int> dm = new();

        IMeshConverter converter;

        #endregion

        #region Ctor

        public AcConverter()
        {
            converter = this;
        }

        #endregion

        #region Interface implementation

        Assembly IMeshConverter.Assembly => typeof(AcConverter).Assembly;

        Dictionary<string, Material> IMeshConverter.Materials { set => Set(value); }

        IMaterialCreator IMeshConverter.MaterialCreator => materialCreator;

   //     Dictionary<string, Image> IMeshConverter.Images { set => Set(value); }

        string IMeshConverter.Directory => throw new NotImplementedException();

        void IMeshConverter.Add(object mesh, object child)
        {
            var m = mesh as List<string>;
            var c = child as List<string>;
            m.AddRange(c);
        }

        object IMeshConverter.Combine(IEnumerable<object> meshes)
        {
            var l = new List<string>();
            l.AddRange(materials);
            foreach (var mesh in meshes)
            {
                var lm = mesh as List<string>;
                l.AddRange(lm);
            }
            return l;
        }

        object IMeshConverter.Create(AbstractMesh mesh)
        {
            if (mesh is AbstractMeshPolygon meshPolygon)
            {
                return Get(meshPolygon);
            }
            return null;
        }

        void IMeshConverter.SetMaterial(object mesh, object material)
        {
            throw new NotImplementedException();
        }

        void IMeshConverter.SetTransformation(object mesh, float[] transformation)
        {
            throw new NotImplementedException();
        }


        string IStringRepresentation.ToString(object obj)
        {
            var l = obj as List<string>;
            var sb = new StringBuilder();
            foreach (var str in l)
            {
                sb.Append(str + '\n');
            }
            return sb.ToString();
        }



        #endregion

        #region Members

        List<string> Get(AbstractMeshPolygon polygon)
        {
            var l = new List<string>();
            var n = polygon.Name;
            if (n.Length == 0)
            {
                l.Add("OBJECT word");
                var kids = polygon.Children.Count;
                l.Add("kids " + kids);
               /* foreach (var im in polygon.Children)
                {
                    var lt = coverter.Create(im) as List<string>;
                    l.AddRange(lt);
                }*/
                return l;
            }
            l.Add("OBJECT poly");
            l.Add("name " + service.Wrap(n));
            l.Add(n);
            var mat = polygon.Material;
            if (mat != null)
            {
                var im = service.GetImage(mat);
                if (im != null)
                {
                    l.Add("texture " + service.Wrap(im.Name));
                }
            }
            if (polygon.Vertices == null)
            {
                l.Add("kids " + polygon.Children.Count);
                return l;
            }
            if (polygon.Vertices.Count == 0)
            {
                l.Add("kids " + polygon.Children.Count);
                return l;
            }
            l.Add("numvert " + polygon.Vertices.Count);
            foreach (var v in polygon.Vertices)
            {
                l.Add(service.StrinValue(v));
            }
            l.Add("numsurf " + polygon.Polygons.Count);
            foreach (var poly in polygon.Polygons)
            {
                var mt = poly.MaterialName;
                var i = dm[mt];
                l.Add("mat " + i);
                var points = poly.Points;
                l.Add("refs " + points.Count);
                foreach (var point in points)
                {
                    var s = "" + point.Item1 + " " + point.Item4[0] + " " + point.Item4[1];
                    l.Add(s);
                }
            }
            l.Add("kids " + polygon.Children.Count);
            return l;
        }

        void Set(Dictionary<string, Image> images)
        {

        }

  
        void Set(Dictionary<string, Material> materials)
        {
            var mat = this.materials;
            mat.Add("AC3Db");
            var i = 0;
            foreach (var item in materials)
            {
                dm[item.Key] = i;
                ++i;
                var s = service.Shrink(GetMaterial(item.Value));
                mat.Add(s);
            }

        }

        string GetMaterial(Material material)
        {
            var s = "MATERIAL " + service.Wrap(material.Name) + " ";
            float trans = 0;
            float shi = 0;
            string diff = " 0 0 0 ";
            string emis = " 0 0 0 ";
            string spec = " 0 0 0 ";

            if (material is MaterialGroup group)
            {
                foreach (var mat in group.Children)
                {
                   switch (mat)
                    {
                        case DiffuseMaterial diffuseMaterial:
                            trans = diffuseMaterial.Opacity - 1;
                            diff =  GetMaterial(diffuseMaterial);
                            break;
                        case SpecularMaterial specularMaterial:
                            shi = specularMaterial.SpecularPower;
                            spec = GetMaterial(specularMaterial);
                            break;
                  
                        case EmissiveMaterial emissiveMaterial:
                            emis  = GetMaterial(emissiveMaterial);
                            break;
                    }
                }
            }
            s += diff + " emis " + emis + " spec " + spec + " shi " + shi + " trans " + trans;
            return s;
        }

        string GetMaterial(DiffuseMaterial material)
        {

            var s = " rgb ";
            var col = material.Color;
            if (col != null)
            {
                s += col.StringValue();
            }
            else
            {
                s += " 0 0 0 ";
            }
            s += " amb ";
            var amb = material.AmbientColor;
            if (amb != null)
            {
                return s + amb.StringValue() + " ";
            }
            return  s + "0 0 0 ";
        }
        string GetMaterial(SpecularMaterial material)
        {
            return  material.Color.StringValue() + " ";
        }
        string GetMaterial(EmissiveMaterial material)
        {
            return material.Color.StringValue() + " ";
        }

        #endregion

        #region Materail Creator

        class MaterialCreator : IMaterialCreator
        {

            internal MaterialCreator()
            {

            }
            Assembly IMaterialCreator.Assembly => throw new NotImplementedException();

            void IMaterialCreator.Add(object group, object value)
            {
                throw new NotImplementedException();
            }

    
            object IMaterialCreator.Create(DiffuseMaterial material)
            {
                throw new NotImplementedException();
            }

            object IMaterialCreator.Create(SpecularMaterial material)
            {
                throw new NotImplementedException();
            }

            object IMaterialCreator.Create(EmissiveMaterial material)
            {
                throw new NotImplementedException();
            }

            object IMaterialCreator.Create(string key, Image image)
            {
                throw new NotImplementedException();
            }

            object IMaterialCreator.Create(Color color)
            {
                throw new NotImplementedException();
            }

            object IMaterialCreator.Create(string key, Material material)
            {
                throw new NotImplementedException();
            }

            object IMaterialCreator.Create(string key, MaterialGroup material)
            {
                throw new NotImplementedException();
            }

            void IMaterialCreator.Set(object material, object color)
            {
                throw new NotImplementedException();
            }

            void IMaterialCreator.Set(object material, Color color)
            {
                throw new NotImplementedException();
            }

            void IMaterialCreator.SetImage(object material, object image)
            {
                throw new NotImplementedException();
            }

            void IMaterialCreator.SetImage(object material, Image image)
            {
                throw new NotImplementedException();
            }


        }

        #endregion

    }
}
