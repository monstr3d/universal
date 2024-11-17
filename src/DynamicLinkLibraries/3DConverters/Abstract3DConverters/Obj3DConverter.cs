
using Collada;

namespace Abstract3DConverters
{
    public class Obj3DConverter: ITextReaderMeshCreator
    {
        List<AbstractMesh> models = new();

        

        public Obj3DConverter()
        {

        }


        public List<AbstractMesh> Create(string filename)
        {
            models = new();
            using (var reader = new StreamReader(filename))
            {

                Create(reader, Path.GetDirectoryName(filename));

            }
            return models;
        }

        void Create(TextReader reader, string name = null)
        {
            string currName = null;
            List<float[]> vertices = new();
            List<float[]> normals = new();
            List<float[]> textures = new();
            List<int[][]> triangles = new();
            string material = null;

            while (true)
            {
                var line = reader.ReadLine();
                if (line == null)
                {
                    //     models[name] = 
                    break;
                }
                var objs = "# object ";
                if (line.Contains(objs))
                {
                    var lt = line.Substring(objs.Length).Trim();
                    if (name == null)
                    {
                        if (currName == null)
                        {
                            currName = lt;
                            continue;
                        }
                        else
                        {
                            var mod = new AbstractMesh(currName,  material, vertices, normals, textures, triangles);
                            models.Add(mod);
                            Create(reader, lt);
                            continue;
                        }
                    }
                    else
                    {
                        var model = new AbstractMesh(name,  material, vertices, normals, textures, triangles);
                        models.Add(model);
                        //models[currName] = modelVisual3D;
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
                if (line.Contains("usemtl "))
                {
                    material = line.Substring("usemtl ".Length).Trim();
                }
                if (line.IndexOf("f ") == 0)
                {
                    var s = line.Substring("f ".Length).Trim();
                    var ss = s.Split(" ".ToCharArray());
                    var ind = new int[ss.Length][];
                    for (int j = 0; j < ss.Length; j++)
                    {
                        var sss = ss[j].Split("/".ToCharArray());
                        var k = new int[sss.Length];
                        for (int m = 0; m < sss.Length; m++)
                        {
                            k[m] = int.Parse(sss[m]);
                        }
                        ind[j] = k;
                    }
                    triangles.Add(ind);
                    continue;
                }
            }
        }

        string ITextReaderMeshCreator.Extension => ".obj";

        List<AbstractMesh> ITextReaderMeshCreator.Create(TextReader reader)
        {
            models.Clear();
            Create(reader, null);
            return models;
        }
    }
}