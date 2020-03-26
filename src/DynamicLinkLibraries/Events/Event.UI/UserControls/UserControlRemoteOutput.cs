using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Event.Basic.Data.Events;

using Web.Interfaces;

namespace Event.UI.UserControls
{
    public partial class UserControlRemoteOutput : UserControl
    {
        #region Fields

        ImportedEventWriter writer;

        #endregion

        public UserControlRemoteOutput()
        {
            InitializeComponent();
        }

        #region Internal Members

        internal ImportedEventWriter Writer
        {
            get
            {
                return writer;
            }
            set
            {
                if (value == null)
                {
                    return;
                }
                writer = value;
                userControlWriter.Writer = value;
                object o = writer.EventWriter;
                if (o is Event.Data.Remote.Server)
                {
                    UserControlRemoteObject uc =
                        new UserControlRemoteObject();
                    uc.Dock = DockStyle.Fill;
                    panelPar.Controls.Add(uc);
                    Event.Data.Remote.Server server =
                        o as Event.Data.Remote.Server;
                    Action<Remote.RemoteType> act = (Remote.RemoteType type) =>
                        {
                            server.RemoteType = type;
                        };
                    Tuple<Action<Remote.RemoteType>,
                        Remote.RemoteType, IUrlConsumer, IUrlProvider> tuple =
                        new Tuple<Action<Remote.RemoteType>, Remote.RemoteType,
                        IUrlConsumer, IUrlProvider>
                        (act, server.RemoteType, server, server);
                    uc.Tuple = tuple;
                }
            }
        }

        #endregion

    }
}
