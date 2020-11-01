using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CategoryTheory;
using Diagram.UI.Interfaces;

using ZipUtils;

namespace Diagram.UI.Zip
{
    /// <summary>
    /// Drag drop zip
    /// </summary>
    public class ZipDragDrop : IDragDrop
    {


        #region Fields

        ICategoryObjectConverter converter;
        public static IDragDrop Singleton = new ZipDragDrop();

        Dictionary<string, byte[]> dictionary = new Dictionary<string, byte[]>();

        PanelDesktop desktop;


        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        private ZipDragDrop()
        {
        }

        #endregion

        #region IDragDrop Members

        void IDragDrop.Set(ICategoryObjectConverter converter, PanelDesktop desktop)
        {
            this.converter = converter;
            this.desktop = desktop;
            desktop.AllowDrop = true;
            desktop.DragEnter += DragEnter;
            desktop.DragDrop += DragDrop;
        }

        IDragDrop IDragDrop.New
        {
            get { return new ZipDragDrop(); }
        }

        #endregion


        bool Detect(DragEventArgs e)
        {
            dictionary.Clear();
            IDataObject data = e.Data;
            if (data.GetDataPresent("FileNameW"))
            {
                object da = data.GetData("FileNameW");
                if (da is string[])
                {
                    string[] str = da as string[];
                    if (str.Length == 1)
                    {
                        string file = str[0];
                        if (Path.GetExtension(file).ToLower().Equals(".zip"))
                        {
                            IDictionary<string, byte[]> d = file.UnZipDictionary();
                            foreach (string key in d.Keys)
                            {
                                if (Path.GetExtension(key).ToLower().Equals(desktop.Extension))
                                {
                                    dictionary[key] = d[key];
                                }
                            }
                        }

                    }
                }
            }
            return dictionary.Count > 0;
        }

        private void DragEnter(object sender, DragEventArgs e)
        {
            if (Detect(e))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }


        private void DragDrop(object sender, DragEventArgs e)
        {
            if (Detect(e))
            {
                if (dictionary.Count == 1)
                {
                    foreach (byte[] b in dictionary.Values)
                    {
                        desktop.Load(b);
                    }
                    return;
                }
                dictionary.Values.Start();
            }
        }
    }
}