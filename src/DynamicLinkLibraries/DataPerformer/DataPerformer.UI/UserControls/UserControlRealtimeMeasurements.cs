using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

using CategoryTheory;

using Diagram.UI;

using DataPerformer.Interfaces;
using NamedTree;

namespace DataPerformer.UI.UserControls
{
    /// <summary>
    /// Editor of realtime measurements
    /// </summary>
    public partial class UserControlRealtimeMeasurements : UserControl
    {
        #region Fields

        IDataConsumer dataConsumer;

        Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>> dictionary;

        List<UserControlRealtimeMeaHeader> d =
          new  List<UserControlRealtimeMeaHeader>();

        int iniHeight;

        // internal Dictionary<IMeasurement, BaseTypes.Interfaces.IDisassemblyObject> disassemblyDictionary = 
        //    new Dictionary<IMeasurement, BaseTypes.Interfaces.IDisassemblyObject>();
        //Dictionary<IMeasurement, BaseTypes.Interfaces.IDisassemblyObject> disassemblyDictionary

        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public UserControlRealtimeMeasurements()
        {
            InitializeComponent();
            iniHeight = Height;
        }

        #endregion

        #region Internal Members

        internal List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> Output
        {
            get
            {
                List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>> l =
                    new List<Tuple<Tuple<string, IMeasurement, object[]>, Tuple<Color[], bool, double[]>>>();
                foreach (UserControlRealtimeMeaHeader u in d)
                {
                    l.AddRange(u.UserControlRealtimeMeasureContainer.Output);
                }
                return l;
            }
        }

        internal void Set(IDataConsumer dataConsumer, 
            Dictionary<string, Dictionary<string, Tuple<Color[], bool, double[]>>> dictionary)
        {
            this.dataConsumer = dataConsumer;
            this.dictionary = dictionary;
        }

   
        internal void FillMeasurements()
        {
            if (dictionary == null | dataConsumer == null)
            {
                return;
            }
            foreach (UserControl uc in d)
            {
                panelCenter.Controls.Remove(uc);
            }
            d.Clear();
            int n = dataConsumer.Count;
            int y = 0;
            List<string> l = new List<string>();
            for (int i = 0; i < n; i++)
            {
                try
                {
                    IMeasurements measurements = dataConsumer[i];
                    string name = (dataConsumer as IAssociatedObject).GetRelativeName(
                        measurements as IAssociatedObject);
                    l.Add(name);
                    UserControlRealtimeMeaHeader uc = new UserControlRealtimeMeaHeader();
                    Dictionary<string, Tuple<Color[], bool, double[]>> dd;
                    if (dictionary.ContainsKey(name))
                    {
                        dd = dictionary[name];
                    }
                    else
                    {
                        dd = new Dictionary<string, Tuple<Color[], bool, double[]>>();
                        dictionary[name] = dd;
                    }
                    uc.Set(dataConsumer, measurements, dd); ;
                    uc.Left = 1;
                    uc.Width = panelCenter.Width - 2;
                    uc.Top = y;
                    panelCenter.Controls.Add(uc);
                    d.Add(uc);
                    y += uc.Height + 1;
                }
                catch 
                {

                }
            }
            Height = iniHeight + y;
            List<string> ll = new List<string>(dictionary.Keys);
            foreach (string key in ll)
            {
                if (!l.Contains(key))
                {
                    dictionary.Remove(key);
                }
            }
        }

        #endregion

        #region Event Handlers

        private void panelCenter_Resize(object sender, EventArgs e)
        {
            foreach (Control control in panelCenter.Controls)
            {
                control.Width = panelCenter.Width - 2;
            }
        }

        #endregion

    }
}
