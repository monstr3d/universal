using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using DataWarehouse.Classes;
using DataWarehouse.Interfaces;
using ErrorHandler;
using NamedTree;

using WindowsExtensions;

namespace DataWarehouse.Forms.Tree
{
    public class TreeNode : System.Windows.Forms.TreeNode
    {
        IDirectory directory;
        
        TreeView treeView;

        DataWarehouse.Performer performer = new();

        NamedTree.Performer p = new();

         #region Ctor

        public TreeNode(IDirectory directory, Action<Issue> action) : base(directory.Name, 0, 1)
        {
            if (directory == null)
            {
                throw new OwnException("Tree node deirectory");
            }
            Init(action);
            this.directory = directory;
            Set();
        }

        public TreeNode(IDirectory directory, bool leaves, Action<Issue> action) : base(directory.Name)
        {
  
            if (directory == null)
            {
                throw new OwnException("Tree node deirectory");
            }
            Init(action);
            this.directory = directory;
            Leaves = leaves;
            Set();
        }

        public TreeNode(ILeaf leaf, Action<Issue> action) : base(leaf.Name, 2, 2)
        {
            if (leaf == null)
            {
                throw new OwnException("Tree node leaf");
            }
            Init(action);
            this.leaf = leaf;
            Tag = leaf;
            Set();
        }

        #endregion



        bool LeavesOpened
        {
            get;
            set;
        } = false;

        bool DirecoriesOpened
        {
            get;
            set;
        } = false;


        //
        protected event Action<object> OnAddDirectoryObject;
       
        Action<Issue> action = (issue) => { };
             
        ILeaf leaf;

        void Act(object o)
        {
            if (o is Issue issue) action(issue);
        }

        Issue Get(object o)
        {
            return o as Issue;
        }

        T Get<T>(object o) where T : class
        {
            var t = Get(o).Object;
            if (t is T tt)
            {
                return tt;
            }
            return null;
        }

        T Get<T, S>(object o) where T : class where S: class
        {
            var up = Get(o).Object as UpdateData<S, T>;
            return up.Node;
        }


        bool Fail(object o)
        {
            var i = Get(o);
            if (i.ErrorType != ErrorType.None)
            {
                action(i);
                return true;
            }
            return false;
        }


        void Set()
        {
            if (directory == null)
            {
                leaf.OnDeleteItself += Leaf_OnDeleteItself;
                leaf.OnChangeItself += Leaf_OnChangeItself;
                Tag = leaf;
                return;
            }
            directory.OnDeleteItself += Directory_OnDeleteItself;
            directory.OnAddDirectory += Directory_OnAddDirectory;
            directory.OnAddLeaf += Directory_OnAddLeaf;
            directory.OnChangeItself += Directory_OnChangeItself;
            directory.OnGetDirectories += Directory_OnGetDirectories;
            directory.OnGetLeaves += Directory_OnGetLeaves;
            Tag = directory;
        }

        private void Directory_OnGetLeaves(object obj)
        {
            Execute(Directory_OnGetLeavesT, obj);
        }

   

        private void Directory_OnGetLeavesT(object obj)
        {
            if (Leaves) return;
            if (Fail(obj))
            {
               // return;
            }
           
            var p = performer.GetErrorType(obj);
            if (p == ErrorType.AlreadyExecuted)
            {
                return;
            }
            if (LeavesOpened)
            {
                return;
            }
            LeavesOpened = true;
            var l = directory as IChildren<ILeaf>;
            var leaves = l.Children;
            leaves = this.p.SotByName<ILeaf>(leaves);
            leaves = leaves.ToArray();
            foreach (var child in leaves)
            {
                var t = new TreeNode(child, action);
                t.Tag = child;
                Nodes.Add(t);
            }
        }

        private void Directory_OnGetDirectories(object obj)
        {
            Execute(Directory_OnGetDirectoriesT, obj);
        }



        private void Directory_OnGetDirectoriesT(object obj)
        {
            if (Fail(obj))
            {     
               // return;
            }
            var p = performer.GetErrorType(obj);
            if (p != ErrorType.None & p != ErrorType.AlreadyExecuted)
            {
                return;
            }
            var ld = new List<IDirectory>();
            foreach (TreeNode node in Nodes)
            {
                if (node.Tag is IDirectory d)
                {
                    ld.Add(d);
                }
            }
            DirecoriesOpened = true;
            var l = directory as IChildren<IDirectory>;
            var dirs = l.Children;
            dirs = this.p.SotByName<IDirectory>(dirs);
            foreach (var child in dirs)
            {
                if (ld.Contains(child))
                {
                    continue;
                }
                var t = new TreeNode(child, action);
                t.Leaves = Leaves;
                t.Tag = child;
                Nodes.Add(t);
            }
        }
  
        bool Leaves { get; set; } = true;

        void Init(Action<Issue> action)
        {
            if (action != null)
            {
                this.action = action;
            }
            
        }

        public void SetDisposed()
        {
            var t = this.TreeView;
            t.Disposed += T_Disposed;
        }

        void Execute<T>(Action<T> action, T t) where T : class
        {
            treeView.InvokeIfNeeded(action, t);
        }

        void Execute(Action action)
        {
            treeView.InvokeIfNeeded(action);
        }

        private void T_Disposed(object sender, EventArgs e)
        {
            if (directory != null)
            {
                directory.OnDeleteItself -= Directory_OnDeleteItself;
                directory.OnAddDirectory -= Directory_OnAddDirectory;
                directory.OnAddLeaf -= Directory_OnAddLeaf;
                directory.OnChangeItself -= Directory_OnChangeItself;
                directory.OnGetDirectories -= Directory_OnGetDirectories;
                directory.OnGetLeaves -= Directory_OnGetLeaves;
                return;
            }
            leaf.OnDeleteItself -= Leaf_OnDeleteItself;
            leaf.OnChangeItself -= Leaf_OnChangeItself;
        }

        private void Leaf_OnDeleteItself(object obj)
        {
            Execute(Leaf_OnDeleteItselfT, obj);
        }

        private void Leaf_OnDeleteItselfT(object obj)
        {
            if (Fail(obj)) return;
            Remove();
        }


        private void Directory_OnAddLeafT(object obj)
        {
            if (Fail(obj)) return;
            if (Leaves) return;
            var node = new TreeNode(Get<ILeaf>(obj), action);
            Nodes.Add(node);
        }
        private void Directory_OnAddLeaf(object obj)
        {
            Execute(Directory_OnAddLeafT, obj);
        }

        private void Directory_OnAddDirectory(object obj)
        {
            
            Execute(Directory_OnAddDirectoryT, obj);
        }

        private void Directory_OnAddDirectoryT(object obj)
        {
            if (Fail(obj)) return;
            var node = new TreeNode(Get<IDirectory>(obj), action);
            Nodes.Add(node);
        }

        private void Directory_OnDeleteItself(object obj)
        {
            if (Fail(obj)) return;
            Execute(Directory_OnDeleteItselfT);
        }

        private void Directory_OnDeleteItselfT()
        {
            directory.OnDeleteItself -= Directory_OnDeleteItself;
            directory.OnAddDirectory -= Directory_OnAddDirectory;
            directory.OnAddLeaf -= Directory_OnAddLeaf;
            Remove();
        }


        void Change(INamed named)
        {
            var name = named.Name;
            if (name == Text)
            {
                return;
            }
            Text = name;

        }
        private void Directory_OnChangeItself(object obj)
        {
            Execute(Directory_OnChangeItselfT, obj);
        }

        private void Leaf_OnChangeItself(object obj)
        {
            Execute(Leaf_OnChangeItselfT, obj);
        }

        private void Directory_OnChangeItselfT(object obj)
        {
            if (Fail(obj)) return;
            Change(directory as INamed);
          
        }

        private void Leaf_OnChangeItselfT(object obj)
        {
            if (Fail(obj)) return;
            Change(leaf as INamed);
        }


    }
}
