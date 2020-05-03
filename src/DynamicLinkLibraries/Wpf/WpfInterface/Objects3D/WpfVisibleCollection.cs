using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

using DataPerformer.Interfaces;

using Motion6D.Interfaces;
using Motion6D.Portable.Interfaces;
using WpfInterface.Interfaces;



namespace WpfInterface.Objects3D
{
    /// <summary>
    /// Visual collection
    /// </summary>
    public  class WpfVisibleCollection : IWpfVisible, IVisibleCollection, ICameraConsumer, IStopped
    {
        
        #region Fields

        List<Motion6D.SerializablePosition> positions = new List<Motion6D.SerializablePosition>();

        List<Motion6D.Portable.Camera> cameras = new List<Motion6D.Portable.Camera>();

        IPosition position;

        Visual3D visual = new ModelVisual3D();

        /// <summary>
        /// Textures
        /// </summary>
        protected Dictionary<string, byte[]> textures = new Dictionary<string, byte[]>();

        protected IVisibleCollection collection;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected WpfVisibleCollection()
        {
            collection = this;
        }

        #endregion

        #region IWpfVisible Members

        Visual3D IWpfVisible.GetVisual(Motion6D.Portable.Camera camera)
        {
            return GetVisualProtected(camera);
        }

        /// <summary>
        /// Textures
        /// </summary>
        public virtual Dictionary<string, byte[]> Textures
        {
            get
            {
                return textures;
            }
        }

        #endregion

        #region ICameraConsumer Members

        void ICameraConsumer.Add(Motion6D.Portable.Camera camera)
        {
            if (cameras.Contains(camera))
            {
                return;
            }
            cameras.Add(camera);
            foreach (object o in positions)
            {
                if (o is ICameraConsumer)
                {
                    ICameraConsumer cc = o as ICameraConsumer;
                    cc.Add(camera);
                }
            }
        }

        void ICameraConsumer.Remove(Motion6D.Portable.Camera camera)
        {
            if (!cameras.Contains(camera))
            {
                return;
            }
            foreach (object o in positions)
            {
                if (o is ICameraConsumer)
                {
                    ICameraConsumer cc = o as ICameraConsumer;
                    cc.Remove(camera);
                }
            }
        }

        #endregion

        #region IStopped Members

        void IStopped.Stop()
        {
            List<Motion6D.SerializablePosition> l = new List<Motion6D.SerializablePosition>();
            foreach (Motion6D.SerializablePosition position in l)
            {
                Remove(position);
            }
            Stop();
        }

        #endregion

        #region Specific Members

        #region Public Members

        #endregion

        #region Abstract Members

        /// <summary>
        /// Gets visual to camera
        /// </summary>
        /// <param name="camera">Camera</param>
        /// <returns>Visual</returns>
        protected virtual Visual3D GetVisualProtected(Motion6D.Portable.Camera camera)
        {
            return visual;
        }

        /// <summary>
        /// Stop
        /// </summary>
        protected virtual void Stop()
        {
        }

        #endregion

        #region Private Members

        public void Add(Motion6D.SerializablePosition position)
        {
            if (positions.Contains(position))
            {
                return;
            }
            positions.Add(position);
            foreach (Motion6D.Camera camera in cameras)
            {
                camera.DynamicalAdd(position);
            }
        }


        public void Remove(Motion6D.SerializablePosition position)
        {

            positions.Remove(position);
            IWpfVisible visible = position.Parameters as IWpfVisible;
            foreach (Motion6D.Camera camera in cameras)
            {
                camera.DynamicalRemove(position);
            }
        }

        #endregion

        #endregion

        #region IPositionObject Members

        IPosition IPositionObject.Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        #endregion

        #region IVisibleCollection Members

        int IVisibleCollection.Count
        {
            get { return positions.Count; }
        }

        IPosition IVisibleCollection.this[int number]
        {
            get { return positions[number]; }
        }

        void IVisibleCollection.Add(IPosition position)
        {
            Add(position as Motion6D.SerializablePosition);
        }

        void IVisibleCollection.Remove(IPosition position)
        {
            Remove(position as Motion6D.SerializablePosition);
        }


        #endregion


    }
}
