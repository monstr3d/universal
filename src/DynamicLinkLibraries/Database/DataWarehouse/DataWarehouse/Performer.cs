using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

using DataWarehouse.Classes;
using DataWarehouse.Interfaces;
using DataWarehouse.Interfaces.Async;

using ErrorHandler;

using NamedTree;


namespace DataWarehouse
{
    /// <summary>
    /// Performer of operations
    /// </summary>
    public class Performer : NamedTree.Performer
    {

        #region Ctor

        public Performer()
        {

        }

    
        public Performer(CancellationToken cancellationToken) 
        {
            this.cancellationToken = cancellationToken; 
        }

        #endregion

        #region Fields

        CancellationToken cancellationToken;

  
        /// <summary>
        /// Type of error
        /// </summary>
        /// <param name="o">Error object</param>
        /// <returns>Type of error</returns>
        public ErrorType GetErrorType(object o)
        {
            var issue = o as Issue;
            return issue.ErrorType;
        }

        /// <summary>
        /// Saves node
        /// </summary>
        public ISaveNode Saver
        {
            get;
            set;
        }


        /// <summary>
        /// Remove node action
        /// </summary>
        private event Action<INode> removeNode;

        /// <summary>
        /// Add node action
        /// </summary>
        private event Action<IDirectory, INode> addNode;

        /// <summary>
        /// Change node
        /// </summary>
        private Action<INode> changeNode = (INode node) => { };

        /// <summary>
        /// Exception event
        /// </summary>
        Action<Exception> onError = (Exception exception) => { };

        /// <summary>
        /// Message event
        /// </summary>
        Action<string> onMessage = (string message) => { };


        #endregion

        #region Public Members

        #region Copy



        public async Task Copy(string connecrionString, string directory, string ext,
            string extout, List<Task> tasks, CancellationToken cancellationToken)
        {
            var c = new DatabaseCoordinatorCollection(false);
            c.LoadDirectory();
            IDatabaseCoordinator coord = c;
            var to = coord[connecrionString];
            if (to == null)
            {

            }
            if (to is IDatabaseInterfaceAsync async)
            {
                var rt = async.GetRoots([ext], cancellationToken);
                await rt;
                var dr = rt.Result[0] as IDirectory;
                var dir = new DirectoryInfo(directory);
                var t = Copy(dr, dir, tasks, ext, extout, cancellationToken);
                tasks.Add(t);
                await t;
            }
        }


        public async Task Copy(string connecrionString, 
            string directory, string ext, List<Task> tasks, CancellationToken cancellationToken)
        {
            var c = new DatabaseCoordinatorCollection(false);
            c.LoadDirectory();
            IDatabaseCoordinator coord = c;
            var to = coord[connecrionString];
            if (to is IDatabaseInterfaceAsync async)
            {

                var rt = async.GetRoots([ext], cancellationToken);
                await rt;
                var dr = rt.Result[0] as IDirectory;
                var dir = new DirectoryInfo(directory);
                var t = Copy(dr, dir, tasks, ext, cancellationToken);
                tasks.Add(t);
                await t;
            }
            else
            {
                Copy(to, directory, ext);
            }
        }

        void Copy(IDatabaseInterface dt, string directory, string ext)
        {
            var r = dt.GetRoots([ext]);
            var dir = new DirectoryInfo(directory);
            Copy(r[0], dir, ext);
        }

        void Copy(IDirectory dir, DirectoryInfo directoryInfo, string ext)
        {
            IChildren<ILeaf> leaves = dir;
            var children = leaves.Children;
            foreach (var item in children)
            {

                var name = item.Name;
                var descrpition = item.Description;
                var fn = Path.Combine(directoryInfo.FullName, name);
                using var writer = new StreamWriter(fn + ".txt");
                writer.WriteLine(descrpition);

                if (item is IData data)
                {
                    var bt = data.Data;
                    if (bt.Length == 0)
                    {

                    }
                    using var stream = File.OpenWrite(fn + ext);
                    stream.Write(bt);
                }
            }
            IChildren<IDirectory> dirs = dir;
            var dchildren = dirs.Children;
            foreach (var dr in dchildren)
            {
                var name = dr.Name;
                var descrpition = dr.Description;
                var fn = Path.Combine(directoryInfo.FullName, name);
                using var writer = new StreamWriter(fn + ".description");
                writer.WriteLine(descrpition);
                var di = directoryInfo.CreateSubdirectory(name);
                Copy(dr, di, ext);
            }
        }




        public async Task Copy(IDirectory dir, DirectoryInfo directoryInfo, List<Task> l, 
            string ext, string extOut, CancellationToken cancellationToken)
        {
            IDirectoryAsync async = dir as IDirectoryAsync;
            var dn = directoryInfo.FullName;
            var files = directoryInfo.GetFiles("*" + ext);
            foreach (var f in files)
            {
                var fd = Path.GetFileNameWithoutExtension(f.FullName);
                var name = fd;
                var r = Path.Combine(dn, fd);
                using var reader = new StreamReader(r + ".txt");
                var description = reader.ReadToEnd();
                using var stream = File.OpenRead(f.FullName);
                var len = stream.Length;
                var bt = new byte[len];
                if (len == 0)
                {
                    continue;
                }
                stream.Read(bt);
                var leaf = new Leaf(null, name, description, extOut, bt);
                var t = async.AddAsync(leaf, cancellationToken);
                l.Add(t);
                await t;
            }
            var directories = directoryInfo.GetDirectories();
            foreach (var d in directories)
            {
                var name = d.Name;
                using var reader = new StreamReader(d.FullName + ".description");
                var description = reader.ReadToEnd();
                var direct = new Classes.Directory(null, name, description, extOut, true);
                var td = async.AddAsync(direct, cancellationToken);
                l.Add(td);
                await td;
                var tc = Copy(td.Result as IDirectory, d, l, ext, extOut, cancellationToken);
                l.Add(tc);
                await tc;

            }
        }




        public async Task Copy(IDirectory dir, DirectoryInfo directoryInfo, List<Task> l, string ext, 
            CancellationToken cancellationToken)
        {
            if (dir is IDirectoryAsync async)
            {
                var t = async.LoadLeaves(cancellationToken);
                l.Add(t);
                await t;
                IChildren<ILeaf> leaves = dir;
                var children = leaves.Children;
                foreach (var item in children)
                {
                    var name = item.Name;
                    var descrpition = item.Description;
                    var fn = Path.Combine(directoryInfo.FullName, name);
                    using var writer = new StreamWriter(fn + ".txt");
                    writer.WriteLine(descrpition);
                    if (item is IDataAsync datasync)
                    {
                        var tad = datasync.GetDataAsync(cancellationToken);
                        l.Add(tad);
                        await tad;
                        var bt = tad.Result;
                        if (bt.Length == 0)
                        {

                        }
                        using var stream = File.OpenWrite(fn + ext);
                        stream.Write(bt);
                    }
                }
                var td = async.LoadChildren(cancellationToken);
                l.Add(td);
                await td;
                IChildren<IDirectory> dirs = dir;
                var dchildren = dirs.Children;
                foreach (var dr in dchildren)
                {
                    var name = dr.Name;
                    var descrpition = dr.Description;
                    var fn = Path.Combine(directoryInfo.FullName, name);
                    using var writer = new StreamWriter(fn + ".description");
                    writer.WriteLine(descrpition);
                    var di = directoryInfo.CreateSubdirectory(name);
                    var tcc = Copy(dr, di, l, ext, cancellationToken);
                }
            }
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        public void Copy(IDatabaseInterface from, IDatabaseInterface to)
        {
            var f = from.GetRoots();
            var t = to.GetRoots();
            if (f.Length != t.Length)
            {
                return;
            }
            for (var i = 0; i < f.Length; i++)
            {
                Copy(f[i], t[i]);
            }
        }

        /// <summary>
        /// Copy
        /// </summary>
        /// <param name="from">from</param>
        /// <param name="to">to</param>
        public void Copy(IDirectory from, IDirectory to)
        {
            if (to == null)
            {
                throw new OwnException();
            }
            to.Post();
            IChildren<IDirectory> children = from;
            foreach (var child in children.Children)
            {
                if (child.Name != null)
                {
                    var d = to.Add(child);
                    Copy(child, d);
                }
                else
                {

                }
            }
            IChildren<ILeaf> leaves = from;
            foreach (var leave in leaves.Children)
            {
                if (leave.Name != null)
                {
                    to.AddChild(leave);
                }
                else
                {

                }
            }

        }

        #endregion



        /// <summary>
        /// Message event
        /// </summary>
        public event Action<string> OnMessage
        {
            add
            {
                if (value != null)
                {
                    onMessage += value;
                }
            }
            remove
            {
                if (value != null)
                {
                    onMessage -= value;
                }
            }
        }

        /// <summary>
        /// Exception event
        /// </summary>
        public event Action<Exception> OnError
        {
            add
            {
                if (value != null)
                {
                    onError += value;
                }
            }
            remove
            {
                if (value != null)
                {
                    onError -= value;
                }
            }
        }

        /// <summary>
        /// Adds node to a directory
        /// </summary>
        /// <param name="directory">Parent directory</param>
        /// <param name="node">The node</param>
        public void AddNode(IDirectory directory, INode node)
        {
            addNode?.Invoke(directory, node);
        }

        /// <summary>
        /// Removes node
        /// </summary>
        /// <param name="node">Node to remove</param>
        public void Remove(INode node)
        {
            removeNode?.Invoke(node);
        }

        /// <summary>
        /// Change node
        /// </summary>
        /// <param name="node">Node to change</param>
        public void Change(INode node)
        {
            changeNode(node);
        }

        /// <summary>
        /// Add node event
        /// </summary>
        public event Action<IDirectory, INode> OnAddNode
        {
            add { addNode += value; }
            remove { addNode -= value; }
        }

        /// <summary>
        /// Remove node event
        /// </summary>
        public event Action<INode> OnRemoveNode
        {
            add { removeNode += value; }
            remove { removeNode -= value; }
        }

        /// <summary>
        /// Change node event
        /// </summary>
        public event Action<INode> OnChangeNode
        {
            add { changeNode += value; }
            remove { changeNode -= value; }
        }

        /// <summary>
        /// Finder of database
        /// </summary>
        public IDatabaseCoordinator Coordinator
        {
            get;
            set;
        }

        /// <summary>
        /// Saves node
        /// </summary>
        /// <param name="node">Node to save</param>
        public void Save(INode node)
        {
            Saver.Save(node);
        }

        /// <summary>
        /// Shows error message
        /// </summary>
        /// <param name="message">Message</param>
        public void ShowError(string message)
        {
            onMessage(message);
        }

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        public void ShowError(Exception exception)
        {
            onError(exception);
        }


        #endregion
    }
}
