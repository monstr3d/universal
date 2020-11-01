using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;

using Event.Basic.Events;
using Event.Basic.Data.Events;
using Event.Interfaces;

using Diagram.UI.Interfaces;

using Event.UI.UserControls;

namespace Event.UI.Labels
{
    /// <summary>
    /// Label of remoting event
    /// </summary>
    [Serializable()]
    public class ImportedEventReaderLabel : UserControlBaseLabel, IRealTimeStartStop, IRealtimeUpdate
    {
        #region Fields

        UserControlImportedReader uc;

        ImportedEventReader reader;

        Form form = null;


        IRealTimeStartStop ss = null;

        object ownproperties = 1;

        IRealtimeUpdate realtimeUpdate = null;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="kind">Kind</param>
        /// <param name="icon">Icon</param>
        public ImportedEventReaderLabel(Type type, string kind, Image icon)
            : base(type, kind, icon)
        {
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected ImportedEventReaderLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region IRealTimeStartStop Members


        void IRealTimeStartStop.Start()
        {
            if (ss != null)
            {
                ss.Start();
            }
        }

        void IRealTimeStartStop.Stop()
        {
            if (ss != null)
            {
                ss.Stop();
            }
        }

        event Action IRealTimeStartStop.OnStart
        {
            add
            {

            }

            remove
            {

            }
        }

        event Action IRealTimeStartStop.OnStop
        {
            add
            {

            }

            remove
            {

            }
        }

        #endregion

        #region IRealtimeUpdate Members


        Action IRealtimeUpdate.Update
        {
            get
            {
                if (realtimeUpdate == null)
                {
                    return null;
                }
                return realtimeUpdate.Update;
            }
        }


        event Action IRealtimeUpdate.OnUpdate
        {
            add
            {

            }

            remove
            {

            }
        }

        #endregion

        #region Overriden

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get
            {
                uc = new UserControlImportedReader();
                return uc;
            }
        }

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("OwnProperties", ownproperties, typeof(object));
        }

        /// <summary>
        /// Base load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                ownproperties = info.GetValue("OwnProperties", typeof(object));
            }
            catch
            {

            }
        }

        /// <summary>
        /// Object
        /// </summary>
        public override ICategoryObject Object
        {
            get
            {
                return reader;
            }
            set
            {
                reader = value.GetObject<ImportedEventReader>();
                uc.Reader = reader;
                realtimeUpdate = this.FindChildObject<IRealtimeUpdate>();
                ss = this.FindChildObject<IRealTimeStartStop>();
            }
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                return form;
            }
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {
            PanelDesktop d = StaticExtensionDiagramUI.CurrentDeskop as PanelDesktop;
            form = d.Tools.Factory.CreateForm(this) as Form;
        }

        #endregion

        #region Own Members

        public object OwnProperties
        {
            get { return ownproperties; }
            set { ownproperties = value; }
        }

        #endregion
    }
}