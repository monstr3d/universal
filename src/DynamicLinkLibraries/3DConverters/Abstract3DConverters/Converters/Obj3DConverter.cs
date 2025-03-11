using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;

using ErrorHandler;

namespace Abstract3DConverters.Converters
{
    
    [Converter(".obj", true, true)]
    public class Obj3DConverter : LinesMeshConverter, IAdditionalInformation
    {
        #region Fields

        Dictionary<string, byte[]> dictionary = new();

        private int numvert = 1;

        private int numtext = 1;

        private int numnorm = 1;

        #endregion

        #region Ctor
        public Obj3DConverter() : base(null)
        {
            lines.Add("# 3ds Max  OBJ");
            lines.Add("# File Created: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
        }

        #endregion

        string mtlName;

        protected override string Filename
        {
            set
            {
                mtlName = Path.GetFileNameWithoutExtension(value) + ".mtl";
                base.Filename = value;
            }
        }
  
        protected override Dictionary<string, Effect> Effects
        {
            set => Set(value);
        }

        Dictionary<string, byte[]> IAdditionalInformation.Information => dictionary;

        void Set(Dictionary<string, Effect> effects)
        {
            try
            {
                base.Effects = effects;
                using var stream = new MemoryStream();
                using var writer = new StreamWriter(stream);
                writer.WriteLine("# 3ds Max  OBJ");
                writer.WriteLine("# File Created: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));
                writer.WriteLine("");
                foreach (var effect in effects)
                {
                    var l = Get(effect.Key, effect.Value);
                    foreach (var s in l)
                    {
                        writer.WriteLine(s);
                    }
                }
                writer.Flush();
                // stream.Flush();
                var bt = stream.ToArray();
                dictionary[mtlName] = bt;
                lines.Add("mtllib " + mtlName);
            }
            catch (Exception e)
            {
                e.HandleException();
            }
        }

        IEnumerable<string> Get(string name, Effect effect)
        {
            var mat = effect.Material;
            yield return "newmtl " + effect.Name;
            var materials = effect.Materials;
            var diff = materials.Item1;
            var emis = materials.Item2;
            var spec = materials.Item3;
            yield return "Ns " + spec.SpecularPower;
            yield return "Ni 0";
            yield return "d " + diff.Opacity;
            yield return "Tr " + (1-diff.Opacity);
            yield return "Tf 0";
            yield return "illum 0";
            yield return "Ka " + diff.AmbientColor.StringRGBValue();
            yield return "Kd " + diff.Color.StringRGBValue();
            yield return "Ks " + spec.Color.StringRGBValue();
            yield return "Ke " + emis.Color.StringRGBValue();
            yield return "map_Ka 0";
            var image = effect.Image;
            var pth =  (image == null) ? "0" : image.GetImageFile();
            yield return "map_Kd " + pth;
        }

        protected override List<string> CreateLines(IMesh mesh)
        {
            var l = new List<string>();
            if (!s.HasVertices(mesh))
            {
                return l;
            }
            l.Add("");
            l.Add("#");
            l.Add("# object " + mesh.Name);
            l.Add("#");
            l.Add("");
        //    var points = mesh.AbsolutePoints;
            var vertices = mesh.AbsoluteVertices;
            foreach (var v in vertices)
            {
                l.Add("v  " + s.StringValue(v));
            }
            l.Add("# " + vertices.Count + " vertices");
            l.Add("");
            var polygons = mesh.Polygons;
            foreach (var polygon in polygons)
            {
                polygon.GetVertices(vertices);
                var n = polygon.VertexNormal;
                l.Add("vn " + s.StringValue(n));
            }
            l.Add("# " + polygons.Count + " vertex normals");
            l.Add("");
            if (false)
            {
                foreach (var polygon in polygons)
                {
                    foreach (var point in polygon.Points)
                    {
                        var pt = point.Texture;
                        var str = "vt " + s.StringValue(pt);
                        if (pt.Length == 2)
                        {
                            str += " 0.0000";
                        }
                        l.Add(str);

                    }
                }
            }
            var txt = mesh.Textures;
            foreach (var t in txt)
            {
                var str = "vt " + s.StringValue(t);
                if (t.Length == 2)
                {
                    str += " 0.0000";
                }
                l.Add(str);
            }
            l.Add("# " + txt.Count + " texture coords");
            l.Add("");
            l.Add("g " + mesh.Name);
            l.Add("usemtl " + mesh.Effect.Name);
            l.Add("s 1");
            for (int i = 0; i < polygons.Count; i++)
            {
                var str = "f";
                var polygon = polygons[i];
                var tn = i + numnorm;
                for (int j = 0; j < polygon.Points.Length; j++)
                {
                    var p = polygon.Points[j];
                    str += " " + (p.VertexIndex + numvert) + "/" + +(p.TextureIndex + numtext) + "/" + tn;
                }
                l.Add(str);
            }
            l.Add("# 0 polygons - " + polygons.Count + " triangles");
            numvert += vertices.Count;
            numtext += txt.Count;
            numnorm += mesh.Polygons.Count;
            return l;
        }
    }
    
}
