using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI.Utils;
using Diagram.UI;
using Diagram.UI.Interfaces;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Labels;

using Event.Interfaces;
using Event.Basic.Data.Events;

// !!!REMOVED using Event.Remote;

using Web.Interfaces;

namespace Event.UI.UserControls
{
    
    /// <summary>
    /// Control for an imported reader
    /// </summary>
    public partial class UserControlImportedReader : UserControl
    {
        #region Fields

        // !!!REMOVED    Event.Data.Remote.Client client = null;

        ImportedEventReader reader;

       

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlImportedReader()
        {
            InitializeComponent();
        }

        #endregion

        #region Internal Members

        internal ImportedEventReader Reader
        {
            set
            {
                if (value == null)
                {
                    return;
                }
                reader = value;
                IEventReader child = value.EventReader;
         /*       // !!!REMOVED       if (child is Data.Remote.Client)
                {
                    Data.Remote.Client client = child as Event.Data.Remote.Client;
                    Action<RemoteType> act = (RemoteType type) =>
                    {
                        client.Type = type;
                        Event.Interfaces.IEvent ev = reader;
                        ev.IsEnabled = false;
                        ev.IsEnabled = true;
                        ev.IsEnabled = false;
                    };
                    Tuple<Action<RemoteType>, RemoteType, IUrlConsumer, IUrlProvider>
                        tuple =
                        new Tuple<Action<RemoteType>, RemoteType, IUrlConsumer, IUrlProvider>(
                            act, client.Type, client, client);
                    UserControlRemoteObject uc = new UserControlRemoteObject();
                    uc.Tuple = tuple;
                    uc.Dock = DockStyle.Fill;
                    panelCenter.Controls.Add(uc);
                    (client as IUrlConsumer).Change += SetClient;
                }
                string[] names = child.EventNames;
                if (child.EventNames.Length <= 1)
                {
                    panelTop.Visible = false;
                }
                else
                {
                    comboBoxEventName.FillCombo(names);
                    comboBoxEventName.SelectCombo(reader.EventName);
                    comboBoxEventName.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        object o = comboBoxEventName.SelectedItem;
                        if (o != null)
                        {
                            reader.EventName = o + "";
                        }
                    };
                }
                if ((child as ICategoryObject).SetControl(panelCenter))
                {
                    return;
                }
                Control c = Recursion(child);
                if (c != null)
                {
                    c.Dock = DockStyle.Fill;
                    panelCenter.Controls.Add(c);
                }*/
            }
        }

        Control Recursion(object child)
        {
            if (child is IPropertiesEditor)
            {
                IPropertiesEditor ed = child as
                     IPropertiesEditor;
                object o = ed.Editor;
                if (o is object[])
                {
                    object[] oo = o as object[];
                    foreach (object ob in oo)
                    {
                        if ((ob is Control) & !(ob is Form))
                        {
                            Control c = ob as Control;
                            //c.Dock = DockStyle.Fill;
                           //anelCenter.Controls.Add(c);
                            return c;
                        }
                    }
                }
            }
            if (child is IChildrenObject)
            {
               IChildrenObject chl =
                    child as IChildrenObject;
                IAssociatedObject[] ao = chl.Children;
                foreach (object aa in ao)
                {
                    Control cc = Recursion(aa);
                    if (cc != null)
                    {
                        return cc;
                    }
                }
            }
            return null;
        }

        void SetClient(string url)
        {
            IEvent ev = reader;
            ev.IsEnabled = true;
            ev.IsEnabled = false;
        }



        #endregion

    }
}
