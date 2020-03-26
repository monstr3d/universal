using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Reflection;


using CategoryTheory;

using BaseTypes;

using Diagram.UI.Interfaces;

using SerializationInterface;

using DataPerformer.Interfaces;
using DataPerformer.Portable;
using DataPerformer.Portable.Measurements;

using Simulink.Parser.Library.DiagramElements;

using Simulink.CSharp.Library.Interfaces;
using Simulink.CSharp.Library.CodeCreators;
using Simulink.CSharp.Proxy.DifferentialEquations;

namespace Simulink.CSharp.Proxy
{
    /// <summary>
    /// C# proxy of Simulink object
    /// </summary>
    [Serializable()]
    public class CSharpSimulinkProxy : CategoryObject, ISerializable,
         IChildrenObject, IDataConsumer,
        IMeasurements, IStarted, IAlias, ITimeMeasureConsumer, IPostSetArrow
    {

        #region Fields

        /// <summary>
        /// Change input event
        /// </summary>
        private event Action onChangeInput = () => { };
        
        /// <summary>
        /// Text
        /// </summary>
        protected List<string> text = new List<string>();

        /// <summary>
        /// Inputs
        /// </summary>
        protected Dictionary<string, Type> input;

        /// <summary>
        /// Outputs
        /// </summary>
        protected Dictionary<string, Type> output;

        /// <summary>
        /// Links
        /// </summary>
        protected Dictionary<string, string> links = new Dictionary<string, string>();

        /// <summary>
        /// Constants
        /// </summary>
        protected Dictionary<string, object> constants =
    new Dictionary<string, object>();


        Block[] blocks;

        IAssociatedObject[] ass = new IAssociatedObject[1];

        IMeasurement[] measures = new IMeasurement[0];

        IStateCalculation calculation;

        bool isUpated = false;

        List<IMeasurements> measurements = new List<IMeasurements>();


        Dictionary<IMeasurement, SetValue> linkdel = new Dictionary<IMeasurement, SetValue>();

        double[] state;

        List<string> lconst = new List<string>();

        IMeasurement timeMeasure = DataPerformer.Portable.StaticExtensionDataPerformerPortable.Factory.TimeProvider.TimeMeasurement;

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

        #endregion

        #region Ctor


        /// <summary>
        /// Default constructor
        /// </summary>
        public CSharpSimulinkProxy()
        {
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected CSharpSimulinkProxy(SerializationInfo info, StreamingContext context)
        {
            Text = info.Deserialize<List<string>>("Text");
            links = info.Deserialize<Dictionary<string, string>>("Links");
            try
            {
                constants = info.Deserialize<Dictionary<string, object>>("Constants");
            }
            catch (Exception)
            {
            }
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.Serialize<List<string>>("Text", text);
            info.Serialize<Dictionary<string, string>>("Links", links);
            info.Serialize<Dictionary<string, object>>("Constants", constants);
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return ass; }
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get
            {
                return lconst;
            }
        }

        object IAlias.this[string name]
        {
            get
            {
                return constants[name];
            }
            set
            {
                constants[name] = value;
                SetValue sv = calculation.Constants[name];
                sv(value);
            }
        }

        object IAlias.GetType(string name)
        {
            Double a = 0;
            return a;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IDataConsumer Members

        void IDataConsumer.Add(IMeasurements measurements)
        {
            this.measurements.Add(measurements);
        }

        void IDataConsumer.Remove(IMeasurements measurements)
        {
            this.measurements.Remove(measurements);
        }

        void IDataConsumer.UpdateChildrenData()
        {
            measurements.UpdateChildrenData();
        }

        int IDataConsumer.Count
        {
            get { return measurements.Count; }
        }

        IMeasurements IDataConsumer.this[int number]
        {
            get { return measurements[number]; }
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
            measurements.UpdateChildrenData();
            foreach (IMeasurement m in linkdel.Keys)
            {
                linkdel[m](m.Parameter());
            }
            calculation.Time = (double)timeMeasure.Parameter();
            calculation.Update();
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return isUpated;
            }
            set
            {
                isUpated = value;
            }
        }

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            calculation.Reset();
            calculation.Time = time;
            Array.Clear(state, 0, state.Length);
        }

        #endregion

        #region ITimeMeasureConsumer Members

        IMeasurement ITimeMeasureConsumer.Time
        {
            get
            {
                return timeMeasure;
            }
            set
            {
                timeMeasure = value;
            }
        }

        #endregion

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            SetLinks();
            SetConstants();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Text
        /// </summary>
        public List<string> Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                if (!LoadText())
                {
                    text = new List<string>();
                }
            }
        }

        /// <summary>
        /// Links
        /// </summary>
        public Dictionary<string, string> Links
        {
            get
            {
                return links;
            }
            set
            {
                links = value;
                SetLinks();
            }
        }

        /// <summary>
        /// Input
        /// </summary>
        public Dictionary<string, Type> Input
        {
            get
            {
                return input;
            }

        }

        #endregion

        #region Private Members

        bool LoadText()
        {
            try
            {
                calculation = CodeCreator.CreateInterface(text, out input, out output, out blocks);
                state = calculation.State;
                ass[0] = new StateSolver(calculation, this, blocks);
                CreateOutput();
                links.Clear();
                CreateConstants();
                return true;
            }
            catch (Exception)
            {
            }
            return false;
        }


        private void CreateOutput()
        {
            List<IMeasurement> l = new List<IMeasurement>();
            foreach (string name in output.Keys)
            {
                Type vt = output[name];
                object type = vt.GetObjectFromType();
                GetValue gv = calculation.Output[name];
                Func<object> f = new Func<object>(gv);
                Measurement m = new Measurement(type, f, name);
                l.Add(m);
            }
            measures = l.ToArray();
        }


        void SetLinks()
        {
            linkdel.Clear();
            foreach (string key in links.Keys)
            {
                IMeasurement m = this.FindMeasurement(key, false);
                SetValue sv = calculation.Input[links[key]];
                linkdel[m] = sv;
            }
        }

        void CreateConstants()
        {
            constants.Clear();
            foreach (string s in calculation.Constants.Keys)
            {
                Double a = 0;
                constants[s] = a;
            }
            lconst.AddRange(constants.Keys);
            lconst.Sort();
        }

        void SetConstants()
        {
            IAlias a = this;
            List<string> l = new List<string>(constants.Keys);
            foreach (string key in l)
            {
                a[key] = constants[key];
            }
        }

        #endregion

    }
}
