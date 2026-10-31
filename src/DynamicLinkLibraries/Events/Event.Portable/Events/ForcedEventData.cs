using System;
using System.Collections.Generic;
using BaseTypes;
using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using Diagram.UI.Interfaces;
using ErrorHandler;
using Event.Interfaces;
using NamedTree.Interfaces;

namespace Event.Portable.Events
{
    /// <summary>
    /// Forced event data
    /// </summary>
    public class ForcedEventData : CategoryObject,  IMeasurements,
        IEvent, INativeEvent, IAlias
    {
        #region Fields

        protected List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        List<string> ltypes = new List<string>();

        IMeasurement[] measurements = new IMeasurement[0];

        private object[] data = new object[0];

        protected Dictionary<string, object> ini = new Dictionary<string, object>();


        /// <summary>
        /// Data
        /// </summary>
        public object[] Data
        {
            get => data;
            set
            {
                data = value;
                ev();
            }
        }   

        /// <summary>
        /// Initial values
        /// </summary>
        public object[] Initial
        {
            get;
            set;
        }
            = new object[0];
        event Action ev = () => { };

        Action force = () => { };

        bool isEnabled = false;

        event Action changeTypes = () => { };

        event Action<bool> onEnable;


        event Action<IAlias, string> onChangeAlias = (IAlias a, string s) => { };

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public ForcedEventData()
        {

        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return measurements.Length; }
        }

        IMeasurement IMeasurements.this[int number]
        {
            get { return measurements[number]; }
        }

        void IMeasurements.UpdateMeasurements()
        {
        }

        bool IMeasurements.IsUpdated
        {
            get
            {
                return true;
            }
            set
            {
            }
        }

        #endregion

        #region IEvent Members

        event Action IEvent.Event
        {
            add
            {
                ev += value;
            }
            remove
            {
                ev -= value;
            }
        }

        bool IEvent.IsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                if (isEnabled == value)
                {
                    return;
                }
                isEnabled = value;
                onEnable?.Invoke(value);
                if (isEnabled)
                {
                    Array.Copy(Initial, Data, Initial.Length);
                }
            }
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return ltypes; }
        }

        object IAlias.this[string name]
        {
            get
            {
                int i = ltypes.IndexOf(name);
                return Data[i];
            }
            set
            {
                int i = ltypes.IndexOf(name);
                Data[i] = value;
                force();
                onChangeAlias(this, name);
            }
        }

        object IAlias.GetType(string name)
        {
            int i = ltypes.IndexOf(name);
            return types[i].Item2;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChangeAlias += value; }
            remove { onChangeAlias -= value; }
        }

        #endregion

        #region INativeEvent Members

        void INativeEvent.Force()
        {
            ev();
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Types
        /// </summary>
        public List<Tuple<string, object>> Types
        {
            get
            {
                return types;
            }
            set
            {
                ini.Clear();
                for (int i = 0; i < types.Count; i++) 
                {
                    if (i >= Initial.Length)
                    {
                        break;
                    }
                    ini[types[i].Item1] = Initial[i];
                }
                types = value;
                Set();
            }
        }

 
        IEnumerable<IMeasurement> IChildren<IMeasurement>.Children => measurements;

        /// <summary>
        /// Force
        /// </summary>
        public void Force()
        {
            ev();
        }

        /// <summary>
        /// The "change types" event
        /// </summary>
        public event Action OnChangeTypes
        {
            add { changeTypes += value; }
            remove { changeTypes -= value; }
        }

        /// <summary>
        /// The "enable" event
        /// </summary>
        public event Action<bool> OnEnable
        {
            add { onEnable += value; }
            remove { onEnable -= value; }
        }



        event Action<IMeasurement> IChildren<IMeasurement>.OnAdd
        {
            add
            {
            }

            remove
            {
            }
        }

        event Action<IMeasurement> IChildren<IMeasurement>.OnRemove
        {
            add
            {
            }

            remove
            {
            }
        }

        #endregion

        #region Private Members

        private void Set()
        {
            List<IMeasurement> l = new List<IMeasurement>();
            Data = new object[types.Count];
            Initial = new object[types.Count];
            List<string> ls = new List<string>();
            for (int i = 0; i < types.Count; i++)
            {
                var t = types[i];
                var name = t.Item1;
                var type = t.Item2;
                if (ls.Contains(name))
                {
                    throw new OwnException(name + " already exists");
                }
                ls.Add(name);
                int[] k = new int[] { i };
                Func<object> f = () =>
                {
                    return Data[k[0]];
                };
                IMeasurement m = new ReplacedParameterMeasurement(type, f, name, this);
                l.Add(m);
                var o = (ini.ContainsKey(name)) ? ini[name] : type.GetDefaultValue();
                Data[i] = o;
                Initial[i] = o;
            }
            measurements = l.ToArray();
            changeTypes();
        }

        void IChildren<IMeasurement>.AddChild(IMeasurement child)
        {
            throw new OwnException();

        }

        void IChildren<IMeasurement>.RemoveChild(IMeasurement child)
        {
        }

        #endregion

    }
}
