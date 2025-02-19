using Abstract3DConverters.Interfaces;
using Abstract3DConverters.Meshes;
using ErrorHandler;

namespace Abstract3DConverters
{
    /// <summary>
    /// Performer of transformation
    /// </summary>
    public class Performer
    {

        Service s = new ();

        /// <summary>
        /// Mesh creator
        /// </summary>
        public IMeshCreator MeshCreator
        {
            get;
            private set;
        }

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
            if (o == null)
            {
                return null;
            }
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
            return meshes.Where(e => e != null).Select(e => Create<T>(e, converter)).ToList();
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
        public T Create<T>(IMeshCreator creator, IMeshConverter converter, string converterDirectory, Action<T> action = null) where T : class
        {
            try
            {
                var cd = converterDirectory;
                if (cd == null)
                {
                    cd = creator.Directory;
                }
                converter.Directory = cd;
                if (cd != creator.Directory)
                {
                    s.CopyImages(creator, creator.Directory, cd);
                    if (creator is IAdditionalInformation add)
                    {
                        foreach (var dd in add.Information)
                        {
                            using var stream = File.OpenWrite(Path.Combine(cd, dd.Key));
                            stream.Write(dd.Value);
                        }
                    }
                }
                var materialCreator = converter.MaterialCreator;
                converter.Effects = creator.Effects;
                var res = Combine<T>(creator.Meshes, converter);
                action?.Invoke(res);
                return res;
            }
            catch (Exception ex)
            {
                ex.ShowError();
            }
            return null; 
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
            return Create<T>(creator, converter, creator.Directory, action);
        }

        #region Create & Save

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="converter">Converter</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, byte[] bytes, IMeshConverter converter, string converterDirectory, Stream outs, Action<object> act = null)
        {
            var creator = fileinput.ToMeshCreator(bytes);
            var res = Create<object>(creator, converter, converterDirectory, act);
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
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, byte[] bytes, string outExt, string outComment, 
             string converterDirectory, Stream outs, Action<object> act = null)
        {
            var converter = outExt.ToMeshConvertor(outComment);
            CreateAndSave(fileinput, bytes, converter, converterDirectory, outs, act);
        }

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, string outExt, string outComment, string converterDirectory,
            
            Stream outs, Action<object> act = null)
        {
            var converter = outExt.ToMeshConvertor(outComment);
            using var stream = File.OpenRead(fileinput);
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes);
            CreateAndSave(fileinput, bytes, converter, converterDirectory, outs, act);
        }

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="outExt">Output extension by name</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSaveByName(string fileinput, string outExt, string converterDirectory,  Stream outs, Action<object> act = null)
        {
            var t = StaticExtensionAbstract3DConverters.FileTypes[outExt];
            var comm = t.Item2;
            CreateAndSave(fileinput, t.Item1[0], comm, converterDirectory, outs, act);
        }

        /// <summary>
        /// Converts and saves
        /// </summary>
        /// <param name="fileinput">The name of input file</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, string outExt, string outComment = null, 
            string converterDirectory=null, Action<object> act = null)
        {
            using var stream = File.OpenWrite(outExt);
            CreateAndSave(fileinput, outExt, outComment, converterDirectory, stream, act);
        }

        /// <summary>
        /// Creates
        /// </summary>
        /// <param name="fileinput">The input</param>
        /// <param name="outExt">Output unique</param>
        /// <param name="converterDirectory">CrateDirectory</param>
        /// <param name="act">Action</param>
        public string CreateAndSaveByUniqueName(string fileinput, string outExt, string converterDirectory, Action<object> act = null)
        {
            var t = StaticExtensionAbstract3DConverters.FileTypes[outExt];
            var ext = t.Item1[0];
            var comment = t.Item2;
            var dir = Path.GetDirectoryName(fileinput);
            var fn = Path.GetFileNameWithoutExtension(fileinput);
            var file = fn + t.Item1[0];
            var filename = Path.Combine(converterDirectory, file);
            if (File.Exists(filename))
            {
                file = fn + Path.GetRandomFileName() + ext;
                filename = Path.Combine(dir, file);
            }
            CreateAndSave(fileinput, filename, comment, converterDirectory);
            return filename;
        }



        #endregion
    }
}