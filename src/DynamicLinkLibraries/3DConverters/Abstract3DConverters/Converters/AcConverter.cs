
using Abstract3DConverters.Attributes;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    
    [Converter(".ac")]
    public class AcConverter : LinesConverter
    {
        #region Fields

        List<string> materials = new();

        Dictionary<string, int> dm = new();


        #endregion

        #region Ctor

        public AcConverter() : base()
        {
            materialCreator = new ExeptionalMaterialCreator();
        }

        #endregion

        #region Overriden Members

        protected override List<string> Combine(IEnumerable<object> meshes)
        {
            lines.AddRange(materials);
            var ms = meshes.ToList();
            var count = ms.Count;
            lines.Add("OBJECT world");
            lines.Add("kids " + count);
            lines = base.Combine(ms);
            return lines;
        }

        protected override List<string> Create(AbstractMesh mesh)
        {
            /*if (mesh is AbstractMeshPolygon meshPolygon)
            {
                return Get(meshPolygon);
            }
            return null;*/
            return Get(mesh);
        }

   
        protected override void Set(Dictionary<string, Image> images)
        {

        }


        protected override void Set(Dictionary<string, Material> materials)
        {
            base.Set(materials);
            var mat = this.materials;
            mat.Add("AC3Db");
            var i = 0;
            foreach (var item in materials)
            {
                dm[item.Key] = i;
                ++i;
                var st = s.Shrink(GetMaterial(item.Value));
                mat.Add(st);
            }

        }

        #endregion

        #region Members

        private void AddName(AbstractMesh mesh, List<string> list)
        {
            var n = mesh.Name;
            var nn = "name" + s.Wrap(n);
            lines.Add(nn);
            lines.Add("data " + n.Length);
            lines.Add(n);
        }

        List<string> Get(AbstractMesh mesh)
        {
            var l = new List<string>();
            var children = mesh.Children;
            var kids = children.Count;
            if (kids > 0)
            {
                l.Add("OBJECT group");
                AddName(mesh, l);
                foreach (var im in children)
                {
                    var lt = converter.Create(im) as List<string>;
                    l.AddRange(lt);
                }
                return l;

            }
                l.Add("OBJECT poly");
            AddName(mesh, l);
            var image = mesh.Effect.Image;
            l.Add("texture " + image.Name);
            l.Add("numvert " + mesh.Points.Count);
            foreach (var point in mesh.AbsolutePoints)
            {
                l.Add(s.StringValue(point.Vertex));
            }
            l.Add("numsurf " + mesh.AbsolutePolygons.Count);
            foreach (var polygon in mesh.AbsolutePolygons)
            {
                var mate = polygon.Effect.Name;
                var i = materials.IndexOf(mate);
                l.Add("mat" + i);
                i = polygon.Points.Length;
                l.Add("refs " + i);
                foreach (var point in polygon.Points)
                {
                    l.Add(point.Index + " " + s.StringValue(point.Texture));
                }
                
            }
            l.Add("kids 0");
            return l;

        }

        protected override void Add(List<string> parent, List<string> child)
        {

        }

        string GetMaterial(Material material)
        {
            var st = "MATERIAL " + s.Wrap(material.Name) + " ";
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
            st += diff + " emis " + emis + " spec " + spec + " shi " + shi + " trans " + trans;
            return st;
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


    }
}
