using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


using CategoryTheory;

using Diagram.UI.Interfaces;
using Diagram.UI;

using SerializationInterface;

using DataPerformer.Interfaces;
using DataPerformer;
using DataPerformer.Portable;

namespace DataPerformer.Mappinng
{
    /// <summary>
    /// Mapping transformer
    /// </summary>
    public abstract class MappingTransformer : CategoryObject, ISerializable, IDataConsumer, IMeasurements
    {
        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Desktop
        /// </summary>
        protected PureDesktopPeer desktop;

        /// <summary>
        /// Inptut dictionary
        /// </summary>
        protected Dictionary<string, string> input = new Dictionary<string, string>();

        /// <summary>
        /// Output dictionary
        /// </summary>
        protected Dictionary<string, string> output = new Dictionary<string, string>();

        /// <summary>
        /// Attached object
        /// </summary>
        protected object attachment;

        /// <summary>
        /// External measurements
        /// </summary>
        protected List<IMeasurements> external = new List<IMeasurements>();

        /// <summary>
        /// Internal measurements
        /// </summary>
        protected List<IMeasurements> inter = new List<IMeasurements>();

        /// <summary>
        /// Mapping
        /// </summary>
        private MappingMeasure[] measures = null;

        /// <summary>
        /// The "is updated" sign
        /// </summary>
        private bool isUpdated;

        /// <summary>
        /// Parent desktop
        /// </summary>
        protected IDesktop parent;

        private IMeasurement defaultVar = StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        protected MappingTransformer()
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected MappingTransformer(SerializationInfo info, StreamingContext context)
        {
            input = info.Deserialize<Dictionary<string, string>>("Input");
            output = info.Deserialize<Dictionary<string, string>>("Output");
            attachment = info.Deserialize<object>("Attachment");
            desktop = Load(attachment);
        }

        #endregion

        #region Public

        /// <summary>
        /// Internal data consumers
        /// </summary>
        public IDataConsumer[] InternalConsumers
        {
            get
            {
               return desktop.GetAll<IDataConsumer>();
            }
        }

        /// <summary>
        /// External data consumers
        /// </summary>
        public IDataConsumer[] ExternalConsumers
        {
            get
            {
                return parent.GetAll<IDataConsumer>();
            }
        }

        /// <summary>
        /// Internal measurements
        /// </summary>
        public IMeasurements[] InternalMeasurements
        {
            get
            {
                return desktop.GetAll<IMeasurements>();
            }
        }


        /// <summary>
        /// External data consumers
        /// </summary>
        public IMeasurements[] ExternalMeasurements
        {
            get
            {
                return parent.GetAll<IMeasurements>();
            }
        }

        /// <summary>
        /// Sets data to itself
        /// </summary>
        /// <param name="input">Input</param>
        /// <param name="output">Output</param>
        public void Set(Dictionary<string, string> input, Dictionary<string, string> output)
        {
        }



        #endregion

        #region Absract

        /// <summary>
        /// Loads destop
        /// </summary>
        /// <param name="attachment">Attached object</param>
        /// <returns>Loaded desktop</returns>
        protected abstract PureDesktopPeer Load(object attachment);


        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<Dictionary<string, string>>("Input", input);
            info.Serialize<Dictionary<string, string>>("Output", output);
            info.Serialize<object>("Attachment", attachment);
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            external.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            external.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            external.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return external.Count; }
        }

        IMeasurements IDataConsumer.this[int number]
        {
            get { return external[number]; }
        }

        void IDataConsumer.Reset()
        {
            this.FullReset();
        }

        event Action IDataConsumer.OnChangeInput
        {
            add { onChangeInput += value; }
            remove { onChangeInput -= value; }
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measures.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return measures[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
            external.UpdateMeasurements(false);
            inter.UpdateMeasurements(false);
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpdated;
            }
            set
            {
                isUpdated = value;
            }
        }

        #endregion

        #region Private


        void Post()
        {
        }

        #endregion
    }
}
