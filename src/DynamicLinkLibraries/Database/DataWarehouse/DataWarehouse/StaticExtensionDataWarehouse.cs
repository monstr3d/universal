using System;

using DataWarehouse.Interfaces;

namespace DataWarehouse
{
    /// <summary>
    /// Static extension for data warehouse
    /// </summary>
    public static class StaticExtensionDataWarehouse
    {

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        static StaticExtensionDataWarehouse()
        {
          Performer = new Performer();
          Performer.Saver = 
                AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<ISaveNode>();
        }

        #endregion


        #region Fields

        static public Performer Performer { get; private set; }

        #endregion


        #region Public Members



        /// <summary>
        /// Message event
        /// </summary>
        public static event Action<string> OnMessage
        {
            add
            {
                Performer.OnMessage += value;   
            }
            remove
            {
                Performer.OnMessage -= value;
            }
        }

        /// <summary>
        /// Exception event
        /// </summary>
        public static event Action<Exception> OnError
        {
            add
            {
                Performer.OnError += value;
             }
            remove
            {
                Performer.OnError -= value;
            }
        }

        /// <summary>
        /// Adds node to a directory
        /// </summary>
        /// <param name="directory">Parent directory</param>
        /// <param name="node">The node</param>
        static public void AddNode(this IDirectory directory, INode node)
        { 
            Performer.AddNode(directory, node);
        }

        /// <summary>
        /// Removes node
        /// </summary>
        /// <param name="node">Node to remove</param>
        public static void Remove(this INode node)
        {
          Performer.Remove(node);
        }

        /// <summary>
        /// Change node
        /// </summary>
        /// <param name="node">Node to change</param>
        public static void Change(this INode node)
        {
           Performer.Change(node);
        }

        /// <summary>
        /// Add node event
        /// </summary>
        static public event Action<IDirectory, INode> OnAddNode
        {
            add { Performer.OnAddNode += value; }
            remove { Performer.OnAddNode -= value; }
        }

        /// <summary>
        /// Remove node event
        /// </summary>
        static public event Action<INode> OnRemoveNode
        {
            add { Performer.OnRemoveNode += value; }
            remove { Performer.OnRemoveNode -= value; }
        }

        /// <summary>
        /// Change node event
        /// </summary>
        static public event Action<INode> OnChangeNode
        {
            add { Performer.OnChangeNode += value; }
            remove { Performer.OnChangeNode -= value; }
        }

        /// <summary>
        /// Finder of database
        /// </summary>
        static public IDatabaseCoordinator Coordinator
        { get => Performer.Coordinator; set => Performer.Coordinator = value; }

        /// <summary>
        /// Saves node
        /// </summary>
        /// <param name="node">Node to save</param>
        public static void Save(this INode node)
        {
           Performer.Save(node);
        }

        /// <summary>
        /// Shows error message
        /// </summary>
        /// <param name="message">Message</param>
        public static void ShowError(this string message)
        {
           Performer.ShowError(message);
        }

        /// <summary>
        /// Shows error
        /// </summary>
        /// <param name="exception">Exception</param>
        public static void ShowError(this Exception exception)
        {
           Performer.ShowError(exception);
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
