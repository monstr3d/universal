using System.ComponentModel.DataAnnotations;
using System.IO.Compression;
using Abstract3DConverters.Attributes;
using Abstract3DConverters.Interfaces;



namespace Abstract3DConverters
{
    /// <summary>
    /// Performer of transformation
    /// </summary>
    public class Performer
    {
        /// <summary>
        /// Service
        /// </summary>
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
        /// <param name="additional">Additional object</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="act">The action</param>
        /// <returns>Created object</returns>
        public T CreateAll<T>(string fileinput, byte[] bytes, object additional,  string outExt, string outComment, Action<T> act) where T : class
        {
            var creator = fileinput.ToMeshCreator(bytes, additional);
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
        /// <param name="additional">Additional object</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="act">The action</param>
        /// <returns>Created object</returns>
        public string CreateString(string fileinput, byte[] bytes, object additional, string outExt, string outComment, Action<object> act = null)
        {
            var creator = fileinput.ToMeshCreator(bytes, additional);
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
        public T Create<T>(IMesh mesh, IMeshConverter meshConverter) where T : class
        {
            try
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
            catch (Exception exception)
            {
                exception.HandleExceptionDouble("PERFORMER CREATE T");
            }
            return null;
        }

        /// <summary>
        /// Creates peers of meshes
        /// </summary>
        /// <typeparam name="T">The type of peer</typeparam>
        /// <param name="meshes">Input meshes</param>
        /// <param name="converter">The converter</param>
        /// <returns>Peers of meshes</returns>
        public IEnumerable<T> Create<T>(IEnumerable<IMesh> meshes, IMeshConverter converter) where T : class
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
        public T Combine<T>(IEnumerable<IMesh> meshes, IMeshConverter converter) where T : class
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
            var cd = converterDirectory;
            var exte = s.GetAttribute<ExtensionAttribute>(creator);
            if (exte != null)
            {
                if (converter is IImagePathFull full)
                {
                    full.ImagePathFull = exte.ImagePathFull;
                }
            }
            if (cd == null)
            {
                cd = creator.Directory;
            }
            converter.Directory = cd;
            if (cd != creator.Directory)
            {
                s.CopyImages(creator, creator.Directory, cd);
            }
            var materialCreator = converter.MaterialCreator;
            converter.Filename = creator.Filename;
            converter.Effects = creator.Effects;
            var res = Combine<T>(creator.Meshes, converter);
            action?.Invoke(res);
            return res;
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
        /// <param name="additional">Additional object</param>
        /// <param name="converter">Converter</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, byte[] bytes, object additional, IMeshConverter converter, 
            string converterDirectory, Stream outs, Action<object> act = null)
        {
            var creator = fileinput.ToMeshCreator(bytes, additional);
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
        /// <param name="additional">Additional object</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Stream of output</param>
        /// <param name="act">The action</param>
        public void CreateAndSave(string fileinput, byte[] bytes, object additional, string outExt, string outComment, 
             string converterDirectory, Stream outs, Dictionary<string, byte[]> add = null, Action<object> act = null)
        {
            var converter = outExt.ToMeshConvertor(outComment);
            CreateAndSave(fileinput, bytes, additional, converter, converterDirectory, outs, act);
            if (add == null)
            {
                return;
            }
            if (converter is IAdditionalInformation additionalObj)
            {
                var t = additionalObj.Information;
                foreach (var item in t)
                {
                    add.Add(item.Key, item.Value);
                }    
            }
        }

        /// <summary>
        /// Creates and saves zip
        /// </summary>
        /// <param name="fileinput">Input</param>
        /// <param name="filename">File name</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="additional">Additional object</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="outs">Output stream</param>
        /// <param name="act">Action</param>
        public void CreateAndSaveZip(string fileinput, string filename, byte[] bytes, object additional, string outExt, string outComment,
             string converterDirectory, Stream outs, Action<object> act = null)
        {
            using var stream = new MemoryStream();
            var d = new Dictionary<string, byte[]>();
            CreateAndSave(fileinput, bytes, additional, outExt, outComment, converterDirectory, stream, d, act);
            using var archive = new ZipArchive(outs, ZipArchiveMode.Create, true);
            var demoFile = archive.CreateEntry(filename);
            using (var entryStream = demoFile.Open())
            {
                entryStream.Write(stream.ToArray());
            }
            foreach (var item in d)
            {
                var file = archive.CreateEntry(item.Key);
                using (var entr = file.Open())
                {
                    entr.Write(item.Value);
                }
            }
        }

        /// <summary>
        /// Creates and saves zip
        /// </summary>
        /// <param name="fileinput">Input</param>
        /// <param name="filename">File name</param>
        /// <param name="bytes">Input bytes</param>
        /// <param name="additional">Additional object</param>
        /// <param name="outExt">Output extension</param>
        /// <param name="outComment">Output comment</param>
        /// <param name="converterDirectory">Converter directory</param>
        /// <param name="act">Action</param>
        /// <returns>Output bytes</returns>
        public byte[] CreateAndSaveZip(string fileinput, string filename, byte[] bytes, object additional, string outExt, string outComment,
         string converterDirectory,  Action<object> act = null)
        {
            using var outs = new MemoryStream();
            CreateAndSaveZip(fileinput, filename, bytes, additional, outExt, outComment, converterDirectory, outs, act);
            return outs.ToArray();
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
            CreateAndSave(fileinput, bytes, null, converter, converterDirectory, outs, act);
            if (converter is IAdditionalInformation add)
            {
                if (add.Information != null)
                {
                    foreach (var dd in add.Information)
                    {
                        using var addStream = File.OpenWrite(Path.Combine(converterDirectory, dd.Key));
                        addStream.Write(dd.Value);
                    }
                }
            }
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
        public string CreateAndSaveByUniqueName(string fileinput, string outExt, 
            string converterDirectory = null, Action<object> act = null)
        {
            var t = StaticExtensionAbstract3DConverters.FileTypes[outExt];
            var cd = converterDirectory;
            if (cd == null)
            {
                cd = Path.GetDirectoryName(fileinput);
            }
            var ext = t.Item1[0];
            var comment = t.Item2;
            var dir = Path.GetDirectoryName(fileinput);
            var fn = Path.GetFileNameWithoutExtension(fileinput);
            var file = fn + t.Item1[0];
            if (comment != null)
            {
                file = fn + '.' + comment + t.Item1[0];
            }
            var filename = Path.Combine(cd, file);
            if (s.FileExists(filename))
            {
                file = fn + Path.GetRandomFileName() + ext;
                filename = Path.Combine(cd, file);
            }
            CreateAndSave(fileinput, filename, comment, cd);
            return filename;
        }

        #endregion

    }
}