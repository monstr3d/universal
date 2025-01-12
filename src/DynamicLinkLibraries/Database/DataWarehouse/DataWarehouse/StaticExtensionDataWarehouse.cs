using System;

using DataWarehouse.Interfaces;

namespace DataWarehouse
{
    /// <summary>
    /// Static extension for data warehouse
    /// </summary>
    public static class StaticExtensionDataWarehouse
    {
        #region Fields
      
        /// <summary>
        /// Saves node
        /// </summary>
        static ISaveNode save;

        /// <summary>
        /// Remove node action
        /// </summary>
        static private event Action<INode> removeNode = (INode node) => { };
        
        /// <summary>
        /// Add node action
        /// </summary>
        static private event Action<IDirectory, INode> addNode = (IDirectory directory, INode node) => { };

        /// <summary>
        /// Change node
        /// </summary>
        static private Action<INode> changeNode = (INode node) => { };

        /// <summary>
        /// Exception event
        /// </summary>
        static Action<Exception> onError = (Exception exception) => { };

        /// <summary>
        /// Message event
        /// </summary>
        static Action<string> onMessage = (string message) => { };


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        static StaticExtensionDataWarehouse()
        {
            save = 
                AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<ISaveNode>();
        }

        #endregion

        #region Public Members

 

        /// <summary>
        /// Message event
        /// </summary>
        public static event Action<string> OnMessage
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
        public static event Action<Exception> OnError
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
        static public void AddNode(this IDirectory directory, INode node)
        { 
            addNode(directory, node);
        }

        /// <summary>
        /// Removes node
        /// </summary>
        /// <param name="node">Node to remove</param>
        public static void Remove(this INode node)
        {
            node.RemoveItself();
            removeNode(node);
        }

        /// <summary>
        /// Change node
        /// </summary>
        /// <param name="node">Node to change</param>
        public static void Change(this INode node)
        {
            changeNode(node);
        }

        /// <summary>
        /// Add node event
        /// </summary>
        static public event Action<IDirectory, INode> OnAddNode
        {
            add { addNode += value; }
            remove { addNode -= value; }
        }

        /// <summary>
        /// Remove node event
        /// </summary>
        static public event Action<INode> OnRemoveNode
        {
            add { removeNode += value; }
            remove { removeNode -= value; }
        }

        /// <summary>
        /// Change node event
        /// </summary>
        static public event Action<INode> OnChangeNode
        {
            add { changeNode += value; }
            remove { changeNode -= value; }
        }

        /// <summary>
        /// Finder of database
        /// </summary>
        static public IDatabaseCoordinator Coordinator
        { get; set; }

        /// <summary>
        /// Saves node
        /// </summary>
        /// <param name="node">Node to save</param>
        public static void Save(this INode node)
        {
            save.Save(node);
        }

        /// <summary>
        /// Shows error message
        /// </summary>
        /// <param name="message">Message</param>
        public static void ShowError(this string message)
        {
            onMessage(message);
        }

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        public static void ShowError(this Exception exception)
        {
            onError(exception);
        }

        /// <summary>
        /// Sets coordinator from application base directory
        /// </summary>
        public static void SetAppBaseCoordinator()
        {
            var c = AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IDatabaseCoordinator>();
            if (c != null)
            {
                Coordinator = c;
            }
        }

        #endregion
    }
}
