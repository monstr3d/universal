using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Interfaces;

using SerializationInterface;

using DataPerformer.Interfaces;

using Event.Interfaces;

namespace DynamicAtmosphere.Web.Wrapper
{
    /// <summary>
    /// Atmosphere
    /// </summary>
    [Serializable()]
    public class Atmosphere : CategoryObject, ISerializable, IAlias, IStarted, IMeasurements,
        IPropertiesEditor, ISeparatedAssemblyEditedObject, IChildrenObject, IEventHandler
    {

        #region Fields

        /// <summary>
        /// External independent calculation
        /// </summary>
        Web.Atmosphere atmosphere = new Web.Atmosphere();

        private readonly string[] Names = new string[] { "F10_7", "Ap", "F10_7A" };

        Dictionary<string, double> aliases = new Dictionary<string, double>();

        event Action<IAlias, string> onChange = (IAlias alias, string name) => { };

        private IAlias child = null;

        private IMeasurement[] measurements;

        IAssociatedObject[] children = null;

        ISeparatedPropertyEditor editor;

        byte[] bytes;


        /// <summary>
        /// Add event 
        /// </summary>
        event Action<IEvent> onAddEvent = (IEvent e) => { };

        /// <summary>
        /// Remove event
        /// </summary>
        event Action<IEvent> onRemoveEvent = (IEvent e) => { };
  

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor of an independent object
        /// </summary>
        public Atmosphere()
        {
            CreateMeasurements(); // Creates external measurements
        }

        /// <summary>
        /// Constructor with child
        /// </summary>
        /// <param name="childType">Type of child</param>
        public Atmosphere(string childType)
            : this()
        {
            Fill();
            Type t = Type.GetType(childType); // Type of a child object
            child = t.GetConstructor(new Type[0]).Invoke(new object[0]) as IAlias; // Child object
            if (child is ISeparatedAssemblyEditedObject)
            {
                (child as ISeparatedAssemblyEditedObject).FirstLoad();
            }
            SetAlias(child);
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected Atmosphere(SerializationInfo info, StreamingContext context)
            : this()
        {
            (this as IPropertiesEditor).Properties =
                info.GetValue("Properties", typeof(object));
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Properties", (this as IPropertiesEditor).Properties, typeof(object));
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return Names; }
        }

        object IAlias.this[string name]
        {
            get
            {
                return aliases[name];
            }
            set
            {
                throw new Exception("Set Atmosphere alias is prohibited");
            }
        }

        object IAlias.GetType(string name)
        {
            return (double)0;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IStarted Members

        void IStarted.Start(double time)
        {
            Refresh();
        }

        #endregion

        #region IMeasurements Members

        int IMeasurements.Count
        {
            get { return 3; }
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

        #region IPropertiesEditor Members

        object IPropertiesEditor.Editor
        {
            get { return this.GetEditor(); }
        }

        object IPropertiesEditor.Properties
        {
            get
            {
                byte[] b = null;
                if (child != null)
                {
                    b = child.Serialize();
                }
                return new object[] { bytes, b };
            }
            set
            {
                object[] o = value as object[];
                bytes = o[0] as byte[];
                object ob = o[1];
                if (ob != null)
                {
                    byte[] b = ob as byte[];
                    child = b.Deserialize<IAlias>();
                    SetAlias(child);
                }
            }
        }

        #endregion

        #region ISeparatedAssemblyEditedObject Members

        byte[] ISeparatedAssemblyEditedObject.AssemblyBytes
        {
            get
            {
                return bytes;
            }
            set
            {
                bytes = value;
            }
        }

        ISeparatedPropertyEditor ISeparatedAssemblyEditedObject.Editor
        {
            get
            {
                return editor;
            }
            set
            {
                editor = value;
            }
        }

        void ISeparatedAssemblyEditedObject.FirstLoad()
        {
            this.LoadAssembly();
        }

        #endregion

        #region IChildrenObject Members

        IAssociatedObject[] IChildrenObject.Children
        {
            get { return children; }
        }

   
        #endregion

        #region IEvent Members

        void IEventHandler.Add(IEvent ev)
        {
            ev.Event += Event;
            onAddEvent(ev);
        }

        void IEventHandler.Remove(IEvent ev)
        {
            ev.Event -= Event;
            onAddEvent(ev);
        }

        IEnumerable<IEvent> IEventHandler.Events
        {
            get
            {
                return null;
            }
        }

        event Action<IEvent> IEventHandler.OnAdd
        {
            add { onAddEvent += value; }
            remove { onAddEvent -= value; }
        }

        event Action<IEvent> IEventHandler.OnRemove
        {
            add { onRemoveEvent += value; }
            remove { onRemoveEvent -= value; }
        }

        #endregion
  
        #region Private Members

        void SetAlias(IAlias alias)
        {
           // Children
            children = new IAssociatedObject[] { alias as IAssociatedObject };
            if (alias is IAliasConsumer)
            {
                // Adaption of an object
                IAliasConsumer aliasConsumer = alias as IAliasConsumer;
                aliasConsumer.Add(this); // Child object consumes information
            }
        }

        void Fill()
        {
            aliases["F10_7"] = atmosphere.F107;
            aliases["Ap"] = atmosphere.Ap;
            aliases["F10_7A"] = atmosphere.F107A;
            if (child == null)
            {
                return;
            }
            List<string> nam = child.AliasNames.ToList<string>();
            foreach (string s in aliases.Keys)
            {
                if (nam.Contains(s))
                {
                    double a = aliases[s];
                    object t = child.GetType(s);
                    if (t.Equals((double)0))
                    {
                        child[s] = a;
                        continue;
                    }
                    if (t.Equals((int)0))
                    {
                        child[s] = (int)a;
                    }
                }
            }
            onChange(this, null);

        }


        void Refresh()
        {
            atmosphere.Refresh();
            Fill();
        }

        void CreateMeasurements()
        {
            atmosphere.OnException += (Exception exception) => { exception.ShowError(10); };
            List<IMeasurement> mm = new List<IMeasurement>();
            foreach (string name in Names)
            {
               mm.Add(new Measure(aliases, name)); 
            }
            measurements = mm.ToArray();
        }

        void Event()
        {
            onChange(this, null);
        }

        #endregion

        #region Measure Class

        class Measure : IMeasurement
        {
            Func<object> func;

            string name;

            internal Measure(Dictionary<string, double> d, string name)
            {
                this.name = name;
                func = () => { return d[name]; };
            }

            #region IMeasure Members

            Func<object> IMeasurement.Parameter
            {
                get { return func; }
            }

            string IMeasurement.Name
            {
                get { return name; }
            }

            object IMeasurement.Type
            {
                get { return (double)0; }
            }

            #endregion
        }


        #endregion

     }
}
