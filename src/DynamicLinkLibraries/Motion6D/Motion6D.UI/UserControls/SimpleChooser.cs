using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Utils;

using DataPerformer.Portable;
using DataPerformer.Interfaces;

using Motion6D;
using Motion6D.Interfaces;

namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// Simple chooser of position collections measurements
    /// </summary>
    public class SimpleChooser : UserControlCoordinates, IPositionCollectionMeasureChooser
    {
        #region Fields

        ComboBox[] boxes;

        static private IPositionCollectionMeasureChooser chooser =
            new SimpleChooser();

        #endregion


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SimpleChooser()
        {
            this.LoadControlResources();
            boxes = Boxes;
            Dock = DockStyle.Fill;
        }

        #endregion


        #region IPositionCollectionMeasureChooser Members

        List<string> IPositionCollectionMeasureChooser.Meausements
        {
            get
            {
                List<string> l = new List<string>();
                foreach (ComboBox box in boxes)
                {
                    string s = box.SelectedItem + "";
                    if (s.Length == 0)
                    {
                        throw new Exception("Variales shortage");
                    }
                    l.Add(s);
                }
                return l;
            }
            set
            {
                for (int i = 0; i < boxes.Length; i++)
                {
                    if (i >= value.Count)
                    {
                        break;
                    }
                    boxes[i].SelectCombo(value[i]);
                }
            }
        }

        IDataConsumer IPositionCollectionMeasureChooser.Consumer
        {
            get
            {
                return null;
            }
            set
            {
                Double a = 0;
                List<string> l = value.GetAllMeasurements(a);
                boxes.FillCombo(l);
              }
        }

        IPositionCollectionMeasureChooser IPositionCollectionMeasureChooser.this[IPositionFactory factory]
        {
            get
            {
                return new SimpleChooser();
            }
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Access to global chooser
        /// </summary>
        static public IPositionCollectionMeasureChooser Chooser
        {
            get
            {
                return chooser;
            }
            set
            {
                chooser = value;
            }
        }

        #endregion


    }
}
