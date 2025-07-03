using System;
using System.Threading.Tasks;
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

        //
        protected event Action<object> OnAddDirectoryObject;
       
        Action<Issue> action = (issue) => { };
             
        ILeaf leaf;

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
            this.directory = directory;
            this.leaf = leaf;
            leaf.OnDeleteItself += Leaf_OnDeleteItself;
            leaf.OnChangeItself += Leaf_OnChangeItself;
            Tag = leaf;
        }

        #endregion

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
            return Get(o).Object as T;
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
            Tag = directory;
        }

        public async Task Expand(bool leaves, Action<Issue> action)
        {
            if (directory != null)
            {
                var t = directory.FillNode(this, false, leaves, action);
                await t;
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
            leaf.OnDeleteItself -= Leaf_OnDeleteItself;
            leaf.OnChangeItself -= Leaf_OnChangeItself;
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
            if (Fail(obj)) return;
            Change(Get<IDirectory>(obj));
        }

        private void Leaf_OnChangeItself(object obj)
        {
            if (Fail(obj)) return;
            Change(Get<ILeaf>(obj));
        }

    }
}
