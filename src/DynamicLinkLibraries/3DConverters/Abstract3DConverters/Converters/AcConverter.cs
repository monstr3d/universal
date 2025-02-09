
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters.Converters
{
    
    [Converter(".ac")]
    public class AcConverter : LinesConverter
    {
        #region Fields


   
        Service s = new();


        List<string> materials = new();

        Dictionary<string, int> dm = new();


        #endregion

        #region Ctor

        public AcConverter() : base()
        {
            materialCreator = new ExeptionalMaterialCreator();
        }

        #endregion

        #region Interface implementation
  

        protected override object Combine(IEnumerable<object> meshes)
        {
             lines.AddRange(materials);
            return base.Combine(meshes);
        }

        protected override object Create(AbstractMesh mesh)
        {
            if (mesh is AbstractMeshPolygon meshPolygon)
            {
                return Get(meshPolygon);
            }
            return null;
        }

        protected override void SetMaterial(object mesh, object material)
        {
            throw new NotImplementedException();
        }

        protected override void SetTransformation(object mesh, float[] transformation)
        {
            throw new NotImplementedException();
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
                foreach (var im in polygon.Children)
                {
                    var lt = converter.Create(im) as List<string>;
                    l.AddRange(lt);
                }
               return l;
            }
            l.Add("OBJECT poly");
            l.Add("name " + s.Wrap(n));
            l.Add(n);
            var mat = polygon.Material;
            if (mat != null)
            {
                var im = s.GetImage(mat);
                if (im != null)
                {
                    l.Add("texture " + s.Wrap(im.Name));
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
                l.Add(s.StrinValue(v));
            }
            l.Add("numsurf " + polygon.Polygons.Count);
            foreach (var poly in polygon.Polygons)
            {
                var mt = poly.Material;
                var i = dm[mt.Name];
                l.Add("mat " + i);
  /*              var points = poly.Indexes;
                l.Add("refs " + points.Count);
                foreach (var point in points)
                {
                    var s = "" + point.Vertex + " " + point.Data[0] + " " + point.Data[1];
                    l.Add(s);
                }*/
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
                var st =  s.Shrink(GetMaterial(item.Value));
                mat.Add(st);
            }

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
