﻿
using Collada;

namespace Abstract3DConverters
{
    public class Obj3DConverter: AbstractMeshCreator, IMaterialDictionary
    {
        List<AbstractMesh> models = new();

        string directory;

        Dictionary<string, Material> materials; 

        public Obj3DConverter() : base(".obj")
        {

        }



        #region IAbstractMeshCreator Members

        protected override Tuple<object, List<AbstractMesh>> Create(string filename)
        {
            var dir = Path.GetDirectoryName(filename);
            using (var reader = new StreamReader(filename))
            {
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        break;
                    }

                    if (line.StartsWith("mtllib "))
                    {
                        var file = line.Substring("mtllib ".Length).Trim();
                        //       file = Path.Combine(directory, file);
                        var mtl = new MtlWrapper();
                        materials = mtl.Create(file, dir);
                        break;
                    }
                }
            }
            Tuple<List<float[]>, List<float[]>, List<float[]>> obj = null;
            using (var reader = new StreamReader(filename))
            {
                var vertices = new List<float[]>();
                var normals = new List<float[]>();
                var textures = new List<float[]>();
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        obj = new Tuple<List<float[]>, List<float[]>, List<float[]>>(vertices,textures,normals);
                        break;
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

                }
            }
            List<AbstractMesh> meshes = new();
            using (var reader = new StreamReader(filename))
            {
                List<int[][]> indexes = null; 
                string name = null;
                string mat = null;
                while (true)
                {
                    var line = reader.ReadLine();
                    if (line == null)
                    {
                        var mesh = new AbstractMesh(name, mat, new List<float[]>(), new List<float[]>(),
                                new List<float[]>(), indexes);
                        meshes.Add(mesh);
                        break;
                    }
                    if (line.StartsWith("g "))
                    {
                        if (mat != null)
                        {
                            var mesh = new AbstractMesh(name, mat, new List<float[]>(), new List<float[]>(), 
                                new List<float[]>(), indexes);
                            meshes.Add(mesh);
                        }
                        name = line.Substring("g ".Length);
                        mat = null;
                        indexes = new();
                        continue;
                    }
                    if (line.StartsWith("usemtl "))
                   {
                        mat = line.Substring("usemtl ".Length);
                        continue;
                    }
                    if (line.IndexOf("f ") == 0)
                    {
                        var s = line.Substring("f ".Length).Trim();
                        var ss = s.Split(" ".ToCharArray());
                        var ind = new int[ss.Length][];
                        for (int j = 0; j < ss.Length; j++)
                        {
                            var sss = ss[j].Split("/".ToCharArray());
                            var i = new int[sss.Length];
                            ind[j] = i;
                            //var k =  new int[sss.Length];
                            for (int m = 0; m < sss.Length; m++)
                            {
                                if (sss[m].Length == 0)
                                {
                                    i[m] = -1;
                                }
                                else
                                {
                                    i[m] = int.Parse(sss[m]) - 1;
                                }
                            }
                        }
                        indexes.Add(ind);
                        continue;
                    }

                }
            }
            return new Tuple<object, List<AbstractMesh>>(obj, meshes);

        }

        #endregion
/*

        public List<AbstractMesh> Create(string filename)
        {
            models = new();
            directory = Path.GetDirectoryName(filename);

            using (var reader = new StreamReader(filename))
            {

                Create(reader);

            }
            return models;
        }*/

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
                    var model = new AbstractMesh(name, material, vertices, normals, textures, triangles);
                    models.Add(model);
                    break;
                }
                if (line.Length == 0)
                {
                    continue;
                }
                if (line == null)
                {
                    //     models[name] = 
                    break;
                }
                if (line.StartsWith("mtllib "))
                {
                    var file = line.Substring("mtllib ".Length).Trim();
             //       file = Path.Combine(directory, file);
                    var mtl = new MtlWrapper();
                    materials = mtl.Create(file, directory);
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
                if (currName == null & name == null)
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

   
        Dictionary<string, Material> IMaterialDictionary.Materials => materials;

    }
}