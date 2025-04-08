using System;
using System.Collections.Generic;

using CategoryTheory;

using Diagram.UI.Interfaces;

using NamedTree;

using Audio.Record.Interfaces;

namespace Audio.Record
{
    /// <summary>
    /// Command of audio
    /// </summary>
    public class AudioCommand : CategoryObject, IAddRemove, IDisposable
    {

        #region Fields

        event Action<object> addAction = (object obj) => {};

        event Action<object> removeAction = (object obj) => { };

        List<object> children = new List<object>();

        protected IAudioCommand command;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public AudioCommand()
        {
            command = StaticExtensionAudioRecord.AudioCommandFactory.GetDefault();
            Init();
        }

        /// <summary>
        /// Fiction constructor
        /// </summary>
        /// <param name="b">Fiction parameter</param>
        protected AudioCommand(bool b)
        {

        }

        #endregion

        #region IAddRemove Members

        Type IAddRemove.Type
        {
            get
            {
                return typeof(object);
            }
        }

        event Action<object> IChildren<object>.OnAdd
        {
            add
            {
                addAction += value;
            }

            remove
            {
                addAction -= value;
            }
        }

        event Action<object> IChildren<object>.OnRemove
        {
            add
            {
                removeAction += value;
            }

            remove
            {
                removeAction += value;
            }
        }

        void IChildren<object>.AddChild(object obj)
        {
            children.Add(obj);
        }

        void IChildren<object>.RemoveChild(object obj)
        {
            children.Remove(obj);
        }

        #endregion

        #region IAddRemove Members

        void IDisposable.Dispose()
        {
            command.Command -= Execute;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// The command
        /// </summary>
        public IAudioCommand Command
        {
            get
            {
                return command;
            }
        }

        IEnumerable<object> IChildren<object>.Children => children;

        #endregion

        #region Protected Members

        /// <summary>
        /// Initialize itself
        /// </summary>
        protected void Init()
        {
            command.Command += Execute;
        }

        #endregion

        #region Private Members

        /// <summary>
        /// Executes a command
        /// </summary>
        /// <param name="command">The command</param>
        void Execute(string command)
        {
            foreach (object o in children)
            {
                if (o is IAssociatedObject)
                {
                    IAssociatedObject ao = o as IAssociatedObject;
                    IExecuteCommand execute = ao.Find<IExecuteCommand>();
                    if (execute != null)
                    {
                        execute.Execute(command);
                    }
                }
            }
        }

        #endregion

        
    }

}