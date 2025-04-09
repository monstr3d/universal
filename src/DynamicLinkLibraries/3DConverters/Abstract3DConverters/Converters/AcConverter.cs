using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.MaterialCreators;
using Abstract3DConverters.Materials;
using ErrorHandler;
using NamedTree;

namespace Abstract3DConverters.Converters
{
   
    [Converter(".ac", false, true)]
    public class AcConverter : LinesMeshConverter
    {
        #region Fields

       List<string> materials = new();

        Dictionary<string, string> Images
        {
            get;
        } = new();

        List<Material> MaterialPP
        {
            get;

        } = new();

     //   Dictionary<string, int> dm = new();


        #endregion

        #region Ctor

        public AcConverter(params object[] obj) : base(new ExeptionalMaterialCreator())
        {

        }

        #endregion

        #region Overriden Members

        protected override List<string> Combine(IEnumerable<object> meshes)
        {
           // lines.AddRange(materials);
            var ms = meshes.ToList();
            var count = ms.Count;
            lines.Add("OBJECT world");
            lines.Add("kids " + count);
            base.Combine(ms);
            return lines;
        }

        protected virtual void Add(List<string> parent, List<string> child)
        {
            base.Add(parent, child);
        }


        protected override List<string> CreateLines(IMesh mesh)
        {
            try
            {
                var l = new List<string>();
                var children = mesh.Children;
                var kids = children.Count;
                if (kids > 0)
                {
                    l.Add("OBJECT group");
                    AddName(mesh, l);
                    l.Add("kids " + kids);
                    return l;
                    foreach (var im in children)
                    {
                        var lt = Converter.Create(im) as List<string>;
                        l.AddRange(lt);
                    }
                    return l;
                }
                if (s.IsEmpty(mesh.Vertices))
                {
                    return l;
                }
                var effect = mesh.Effect;
                if (effect == null)
                {

                }
                l.Add("OBJECT poly");
                AddName(mesh, l);
                if (effect != null)
                {
                    var image = effect.Image;
                    if (image != null)
                    {
                        if (Images.ContainsKey(image.Name))
                        {
                            var nm = Images[image.Name];
                            l.Add("texture " + nm);
                        }
                    }
                }
                l.Add("numvert " + mesh.AbsoluteVertices.Count);
                foreach (var point in mesh.AbsoluteVertices)
                {
                    l.Add(s.StringValue(point));
                }
                l.Add("numsurf " + mesh.Polygons.Count);
                foreach (var polygon in mesh.Polygons)
                {
                    //  var mate = polygon.Effect.Name;
                    //   var i = materials.IndexOf(mate);
                    //  i =  EffectsSP[polygon.Effect];
                    var i = GetMatInd(polygon.Effect);
                    if (i < 0)
                    {

                    }
                    l.Add("SURF 0x10");
                    if (i >= 0)
                    {
                        l.Add("mat " + i);
                    }
                    i = polygon.Points.Length;
                    l.Add("refs " + i);
                    foreach (var point in polygon.Points)
                    {
                        l.Add(point.VertexIndex + " " + s.StringValue(point.Texture));
                    }

                }
                l.Add("kids 0");
                return l;
            }
            catch (Exception ex)
            {
                ex.HandleExceptionDouble("AConverter.CreateLines");
            }
            return null;
        }

        internal Dictionary<string, int> MaterialsSP
        {
            get;
        } = new();

        internal Dictionary<Effect, int> EffectsSP
        {
            get;
        } = new();

        internal int GetMatInd(Effect effect)
        {
            if (effect == null)
            {
                return -1;
            }
            var n = MaterialPP.IndexOf(effect.Material);
            if (n < 0)
            {
                throw new ErrorHandler.OwnException("GetMatInd");
            }
            return n;
        }

        private void Set(Image image)
        {
            if (image == null)
            {
                return;
            }
            var name = image.Name;
            if (name == null)
            {
                return;
            }
            if (Images.ContainsKey(name))
            {
                return;
            }
            var sep = Path.DirectorySeparatorChar;
            var nm = name.Replace('/', sep);
            nm = nm.Replace('\\', sep);
            if (nm == name)
            {
                Images[name] = name;
                return;
            }
            nm = nm.Replace("" + Path.DirectorySeparatorChar, "_DirectorySeparatorChar_");
            var fd = image.FullPath;
            if (s.FileExists(fd))
            {
                var fo = Path.Combine(Converter.Directory, fd);
                if (!s.FileExists(fo))
                {
                    File.Copy(fd, fo);
                }
            }
            
        }

        protected override Dictionary<string, Effect> Effects
        {
            set
            {
                base.Effects = value;
                lines.Add("AC3Db");
                var i = 0;
                foreach (var item in value)
                {
                    var effect = item.Value;
                    Set(effect.Image);
                    EffectsSP[effect] = i;
                    MaterialsSP[item.Key] = i;
                    ++i;
                    materials.Add(item.Key);
                    var mt = item.Value.Material;
                    if (mt != null)
                    {
                        if (MaterialPP.Contains(mt))
                        {
                            continue;
                        }
                        MaterialPP.Add(mt);
                        var st = s.Shrink(GetMaterial(item.Key, item.Value.Material));
                        lines.Add(st);
                    }
                }
            }
        }

        #endregion

        #region Members

        private void AddName(IMesh mesh, List<string> list)
        {
            var n = mesh.Name;
            var nn = "name " + s.Wrap(n);
            list.Add(nn);
            list.Add("data " + n.Length);
            list.Add(n);
        }

        string GetMaterial(string name, Material material)
        {
            var st = "MATERIAL " + s.Wrap(name) + " ";
            float trans = 0;
            float shi = 0;
            string diff = " 0 0 0 ";
            string emis = " 0 0 0 ";
            string spec = " 0 0 0 ";
            if (material is IChildren<SimpleMaterial> group)
            {
                foreach (var mat in group.Children)
                {
                   switch (mat)
                    {
                        case DiffuseMaterial diffuseMaterial:
                            trans =  1f - diffuseMaterial.Opacity;
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
                st += diff + " emis " + emis + " spec " + spec + " shi " + shi + " trans " + trans;
            }
            else
            {
                throw new OwnException("MATERIAL AC");
            }
            return st;
        }

        string GetMaterial(DiffuseMaterial material)
        {

            var s = " rgb ";
            var col = material.Color;
            if (col != null)
            {
                s += col.StringRGBValue();
            }
            else
            {
                s += " 0 0 0 ";
            }
            s += " amb ";
            var amb = material.AmbientColor;
            if (amb != null)
            {
                return s + amb.StringRGBValue() + " ";
            }
            return  s + "0 0 0 ";
        }
        string GetMaterial(SpecularMaterial material)
        {
            if (material == null)
            {
                return "0 0 0 ";
            }
            if (material.Color == null)
            {
                return "0 0 0 ";
            }
            return material.Color.StringRGBValue() + " ";
        }
        string GetMaterial(EmissiveMaterial material)
        {
            if (material == null)
            {
                return "0 0 0 ";
            }
            if (material.Color == null)
            {
                return "0 0 0 ";
            }
            return material.Color.StringRGBValue() + " ";
        }
 
        #endregion

    }
}
