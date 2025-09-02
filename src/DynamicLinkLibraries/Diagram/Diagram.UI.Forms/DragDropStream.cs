using System;
using Common.UI;

using System.Windows.Forms;
using System.IO;
using System.Threading;
using Diagram.UI.Interfaces;

namespace Diagram.UI
{
    class DragDropStream
    {
        #region Fields
        string name;


        CancellationToken cancellationToken;

        internal

        PanelDesktop desktop;

        private Action<Stream> afterDrag = (Stream stream) => {};

        #endregion


        #region Ctor

        internal DragDropStream(string name, PanelDesktop desktop)
        {
            this.name = name;
            desktop.DragEnter += dragEnter;
            desktop.DragDrop += dragDrop;
            this.desktop = desktop;
        }

        #endregion


        #region Members

        internal event Action<Stream> AfterDrag
        {
            add { afterDrag += value; }
            remove { afterDrag -= value; }
        }

        private void dragEnter(object sender, DragEventArgs e)
        {
            string[] s = e.Data.GetFormats();
            if (s == null)
            {
                return;
            }
            if (s.Length != 1)
            {
                return;
            }
            if (s[0].Equals(name))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private async void dragDrop(object sender, DragEventArgs e)
        {
            string[] s = e.Data.GetFormats();
            if (s == null)
            {
                return;
            }
            if (s.Length != 1)
            {
                return;
            }
            if (s[0].Equals(name))
            {
                object o = e.Data.GetData(s[0]);
                IStreamCreator cr = o as IStreamCreator;
                var async = cr.DataAsync;
                if (async != null)
                {
                    ICancellation c = desktop;
                    var ct = c.CreateCancellationToken();
                    var t = desktop.LoadAsync(async,
                        SerializationInterface.StaticExtensionSerializationInterface.Binder, 
                        desktop.Extension, desktop.Extension, ct);
                    await t;
                    return;
                }
                Stream stream = cr.Stream;
                desktop.LoadFromStream(stream,
                    SerializationInterface.StaticExtensionSerializationInterface.Binder, desktop.Extension, desktop.Extension);
                afterDrag(stream);
            }
        }



        #endregion
    }
}
