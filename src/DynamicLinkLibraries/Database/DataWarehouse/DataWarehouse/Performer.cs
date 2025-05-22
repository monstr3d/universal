using System;

using DataWarehouse.Interfaces;

namespace DataWarehouse
{
    /// <summary>
    /// Pefrormer of operations
    /// </summary>
    public class Performer
    {

        #region Ctor

        #endregion


        #region Fields

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



        /// <summary>
        /// Message event
        /// </summary>
        public  event Action<string> OnMessage
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
        public  event Action<Exception> OnError
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
        public  void Save(INode node)
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
