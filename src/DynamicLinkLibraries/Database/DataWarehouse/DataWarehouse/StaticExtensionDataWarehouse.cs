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
        /// Finder of database
        /// </summary>
        static IDatabaseCoordinator coordinator;

        /// <summary>
        /// Saves node
        /// </summary>
        static ISaveNode save;

        static private event Action<INode> removeNode = (INode node) => { };

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
        /// Remove Node event
        /// </summary>
        static public event Action<INode> RemoveNode
        {
            add { removeNode += value; }
            remove { removeNode -= value; }
        }

        /// <summary>
        /// Finder of database
        /// </summary>
        static public IDatabaseCoordinator Coordinator
        {
            get
            {
                return coordinator;
            }
            set
            {
                coordinator = value;
            }
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
            IDatabaseCoordinator c = null;
            c = AssemblyService.StaticExtensionAssemblyService.GetFirstInterfaceObjectFromBaseDirectory<IDatabaseCoordinator>();
            if (c != null)
            {
                coordinator = c;
            }
        }

        #endregion
    }
}
