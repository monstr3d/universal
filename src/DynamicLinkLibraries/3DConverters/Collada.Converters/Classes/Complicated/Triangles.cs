using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Abstract3DConverters;
using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Points;
using Collada.Converters.Classes.Elementary;
using NamedTree;


namespace Collada.Converters.Classes.Complicated
{
    [Tag("triangles")]
    internal partial class Triangles : XmlHolder, IMesh
    {


        public Abstract3DConverters.Materials.Effect Effect { get; private set; }

        public Dictionary<string, OffSet> Inputs { get; private set; } = new();

        public List<int[][]> Indexes { get; private set; }

        public List<int[]> Index { get; private set; }

        public float[] Vertices { get; private set; }


        protected List<float[]> ProtectedVertices { get; set; } = new List<float[]>();

        protected List<float[]> ProtectedTextures { get; set; } = new List<float[]>();

        protected List<float[]> ProtectedNormals { get; set; } = new List<float[]>();



        protected List<Polygon> Polygons
        {
            get;
            private set;
        } = new List<Polygon>();

        public float[] Normals { get; private set; }

      

        public Material Material { get; private set; }

  
        public int[] Idx { get; private set; }

    //    public List<int[]> Indexes { get; private set; }

 
        public int[] P { get; private set; }

        public static IClear Clear => StaticExtensionCollada.GetClear<Triangles>();

        public Tuple<List<float[]>, List<float[]>, List<float[]>, List<int[]>> Tuple { get; private set; }

        float[] IGeometry.TransformationMatrix => throw new NotImplementedException();

 
        private Triangles(XmlElement element, IMeshCreator meshCreator) : base(element, meshCreator)
        {
            Create(element);
            return;
            var p = element.Get<P>();
            if (p != null)
            {
                Idx = p.Value;
            }
         //   // Index = element.ToIntArray();
     /*       Material = element.GetMaterial();
   /        if (Indexes == null)
            {
                Indexes = element.ToInt3Array();
            }*/
            var d = element.GetAllChildren<Input>().ToArray();
            foreach (var inp in d)
            {
                KeyValuePair<string, OffSet> sem = inp.Semantic;
                if (sem.Key != null)
                {
                    Inputs[sem.Key] = sem.Value;
                }
            }
            List<float[]> vertices = null;
            
        }

        event Action<IMesh> INode<IMesh>.OnAdd
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        event Action<IMesh> INode<IMesh>.OnRemove
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        void Create(XmlElement element)
        {
            try
            {
                var p = element.Get<P>();
                var vc = element.Get<VCount>();
                var arr = p.Value;
                var c = element.GetAttribute("material");
                if (meshCreator.Effects.ContainsKey(c))
                {
                    Effect = meshCreator.Effects[c];
                }
                float[] textures = null;
                var children = element.GetAllChildren<Input>().ToArray();
                int count = 0;
                int[] offs = new int[] { -1, -1, -1 };
                foreach (var item in children)
                {
                    var t = item.Semantic.Key;
                    if (t == "VERTEX")
                    {
                        var ofs = item.Semantic.Value;
                        offs[0] = ofs.Offset;
                        var tt = ofs.Value as Vertices;
                        Vertices = tt.Array;
                        ProtectedVertices = s.ToRealArray(Vertices, 3);
                        ++count;
                        continue;
                    }
                    if (t == "NORMAL")
                    {
                        var ofs = item.Semantic.Value;
                        offs[2] = ofs.Offset;
                        var tt = ofs.Value as Source;
                        Normals = tt.Array;
                        ProtectedNormals = s.ToRealArray(Normals, 3);
                        ++count;
                        continue;
                    }
                    if (t == "TEXCOORD")
                    {
                        var ofs = item.Semantic.Value;
                        offs[1] = ofs.Offset;
                        var v = ofs.Value;
                        if (v is float[] vt)
                        {
                            textures = vt;
                        }
                        if (v is Source tt)
                        {
                            textures = tt.Array;
                        }
                        ProtectedTextures = s.ToRealArray(textures, 2);
                        ++count;
                        continue;
                    }
                }
                var nn = 0;
                if (textures == null)
                {
                    return;
                }
                var txt = s.ToRealArray<float>(textures, 2);
                List<float[]> norms = null;
                if (offs[2] >= 0)
                {
                    norms = s.ToRealArray(Normals, 3);
                }
                var k = 0;
                var pp = p.Value;
                int tn = 0;
                for (var j = 0; ;)
                {
                    var points = new List<PointTexture>();
                    for (var i = 0; i < 3; i++)
                    {
                        var idx = arr[tn + offs[0]];
                        var idt = arr[tn + offs[1]];

                        PointTexture point = null;
                        if (offs[2] >= 0)
                        {
                            point = s.CreatePointTexture(this, idx, idt, arr[tn + offs[2]]);
                        }
                        else
                        {
                            point = s.CreatePointTexture(this, idx, idt);

                        }
                        if (point == null)
                        {
                            throw new Exception("Triangles");
                        }

                        tn += count;
                        points.Add(point);
                    }
                    var polygon = new Polygon(this, points.ToArray(), Effect);
                    if (Polygons == null)
                    {
                        Polygons = new();
                    }
                    Polygons.Add(polygon);
                    if (tn + offs[0] >= arr.Length)
                    {
                        break;
                    }

                }
            }
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("Triangles");
            }
        }


        object Get()
        {
            return this;
        }

        public static object Get(XmlElement element, IMeshCreator meshCreator)
        {
            var a = new Triangles(element,  meshCreator);
            return a.Get();
        }

        void IMesh.CalculateAbsolute()
        {
            throw new NotImplementedException();
        }

        void INode<IMesh>.Remove(INode<IMesh> node)
        {
            throw new NotImplementedException();
        }
    }
}
