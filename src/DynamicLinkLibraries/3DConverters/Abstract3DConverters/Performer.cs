using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Materials;
using Abstract3DConverters.Meshes;

namespace Abstract3DConverters
{
    /// <summary>
    /// Performer of transformation
    /// </summary>
    public class Performer
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Performer()
        {

        }

        /// <summary>
        /// Creates all operation
        /// </summary>
        /// <typeparam name="T">The type of output</typeparam>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="act">The action</param>
        /// <returns>Created object</returns>
        public T CreateAll<T>(string fileinput, byte[] bytes, string outExt, string outComment, Action<T> act) where T : class
        {
            var creator = fileinput.ToMeshCreator(bytes);
            var p = new Performer();
            var converter = outExt.ToMeshConvertor(outComment);
            var res = p.Create<T>(creator, converter, act);
            return res;
        }
        /// <summary>
        /// Creates string
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="act">The action</param>
        /// <returns>Created object</returns>
        public string CreateString(string fileinput, byte[] bytes, string outExt, string outComment, Action<object> act = null)
        {
            var creator = fileinput.ToMeshCreator(bytes);
            var p = new Performer();
            var converter = outExt.ToMeshConvertor(outComment);
            var res = p.Create<object>(creator, converter, act);
            var sr = converter as IStringRepresentation;
            var r = sr.ToString(res);
            return r;
        }

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="converter">Converter</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, byte[] bytes, IMeshConverter converter, Stream outs, Action<object> act = null)
        {
            var creator = fileinput.ToMeshCreator(bytes);
            var res = Create<object>(creator, converter, act);
            if (converter is ISaveToStream save)
            {
                save.Save(res, outs);
                return;
            }
            var sr = converter as IStringRepresentation;
            var r = sr.ToString(res);
            using var wr = new StreamWriter(outs);
            wr.Write(r);
        }

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, byte[] bytes, string outExt, string outComment, Stream outs, Action<object> act = null)
        {
            var converter = outExt.ToMeshConvertor(outComment);
            CreateAndSave(fileinput, bytes, converter, outs, act);
        }

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, string outExt, string outComment, Stream outs, Action<object> act = null)
        {
            var converter = outExt.ToMeshConvertor(outComment);
            using var stream = File.OpenRead(fileinput);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes);
            CreateAndSave(fileinput, bytes, converter, outs, act);
        }


        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, string outExt, string outComment = null, Action<object> act = null)
        {
            using var stream = File.OpenWrite(outExt);
            CreateAndSave(fileinput, outExt, outComment, stream, act);
        }

        /// <summary>
        /// Creates a peer of mesh
        /// </summary>
        /// <typeparam name="T">The type of peer</typeparam>
        /// <param name="mesh">The mesh</param>
        /// <param name="meshConverter">The converter</param>
        /// <returns>The peer of mesh</returns>
        public T Create<T>(AbstractMesh mesh, IMeshConverter meshConverter) where T : class
        {
            IMaterialCreator materialCreator = meshConverter.MaterialCreator;
            object o = meshConverter.Create(mesh);
            var trans = mesh.TransformationMatrix;
            meshConverter.SetTransformation(o, trans);
            object mt = mesh.Effect;
            if (mt == null)
            {
                mt = mesh.GetEffect(materialCreator);
            }
            if (mt != null)
            {
                meshConverter.SetEffect(o, mt);
            }
            foreach (var child in mesh.Children)
            {
                var ch = Create<T>(child, meshConverter);
                meshConverter.Add(o, ch);
            }
            return o as T;
        }

        /// <summary>
        /// Creates peers of meshes
        /// </summary>
        /// <typeparam name="T">The type of peer</typeparam>
        /// <param name="meshes">Input meshes</param>
        /// <param name="converter">The converter</param>
        /// <returns>Peers of meshes</returns>
        public IEnumerable<T> Create<T>(IEnumerable<AbstractMesh> meshes, IMeshConverter converter) where T : class
        {
            return meshes.Select(e => Create<T>(e, converter)).ToList();
        }

        /// <summary>
        /// Combines meshes
        /// </summary>
        /// <typeparam name="T">The type of peer</typeparam>
        /// <param name="meshes">Meshes</param>
        /// <param name="converter">Converter of meshes</param>
        /// <returns>The combination</returns>
        public T Combine<T>(IEnumerable<AbstractMesh> meshes, IMeshConverter converter) where T : class
        {
            var enu = Create<T>(meshes, converter);
            return converter.Combine(enu) as T;
        }

        /// <summary>
        /// Creates peer object
        /// </summary>
        /// <typeparam name="T">The type of result</typeparam>
        /// <param name="creator">The creator of meshes</param>
        /// <param name="converter">The </param>
        /// <param name="action"></param>
        /// <returns>The peer object</returns>
        public T Create<T>(IMeshCreator creator, IMeshConverter converter, Action<T> action = null) where T : class
        {
            converter.Directory = creator.Directory;
            var materialCreator = converter.MaterialCreator;
            converter.Images = creator.Images;
            converter.Materials = creator.Materials;
            converter.Effects = creator.Effects;
            var res = Combine<T>(creator.Meshes, converter);
            action?.Invoke(res);
            return res;
        }
    }
}