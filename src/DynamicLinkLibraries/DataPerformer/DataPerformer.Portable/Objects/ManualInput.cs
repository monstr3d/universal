using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CategoryTheory;

using Diagram.UI.Interfaces;

using BaseTypes;

using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;

namespace DataPerformer.Portable.Objects
{
    /// <summary>
    /// Manual input
    /// </summary>
    public class ManualInput : CategoryObject, IMeasurements, IAlias
    {
        #region Fields

        protected List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        List<string> ltypes = new List<string>();

        IMeasurement[] measurements = new IMeasurement[0];

        /// <summary>
        /// Data
        /// </summary>
        protected object[] data = new object[0];

        protected object[] initial = new object[0];

   
        event Action changeTypes = () => { };

        event Action<IAlias, string> onChangeAlias = (IAlias a, string s) => { };

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
                return data[i];
            }
            set
            {
                int i = ltypes.IndexOf(name);
                data[i] = value;
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
                types = value;
                Set();
            }
        }

        /// <summary>
        /// Data
        /// </summary>
        public object[] Data
        {
            get
            {
                return data;
            }
            set
            {
                data = value;
            }
        }

        /// <summary>
        /// Initial data
        /// </summary>
        public object[] Initial
        {
            get
            {
                return initial;
            }
            set
            {
                initial = value;
            }
        }

        /// <summary>
        /// The "change types" event
        /// </summary>
        public event Action OnChangeTypes
        {
            add { changeTypes += value; }
            remove { changeTypes -= value; }
        }

        #endregion

        #region Private Members

        private void Set()
        {
            List<IMeasurement> l = new List<IMeasurement>();
            int i = 0;
            data = new object[types.Count];
            ltypes.Clear();
            List<string> ls = new List<string>();
            foreach (Tuple<string, object> t in types)
            {
                if (ls.Contains(t.Item1))
                {
                    throw new Exception(t.Item1 + " already exists");
                }
                ls.Add(t.Item1);
                int[] k = new int[] { i };
                Func<object> f = () => { return data[k[0]]; };
                ltypes.Add(t.Item1);
                IMeasurement m = new Measurement(t.Item2, f, t.Item1);
                data[i] = t.Item2.GetDefaultValue();
                l.Add(m);
                ++i;
            }
            measurements = l.ToArray();
            object[] ini = initial;
            initial = new object[data.Length];
            for (i = 0; i < initial.Length; i++)
            {
                object n = data[i];
                if (i < ini.Length)
                {
                    object p = ini[i];
                    if (p.GetType().Equals(n.GetType()))
                    {
                        initial[i] = p;
                        continue;
                    }
                }
                initial[i] = n;
            }
            changeTypes();
        }

        #endregion

    }
}
