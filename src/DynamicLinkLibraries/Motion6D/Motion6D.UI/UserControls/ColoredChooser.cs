using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;


using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using DataPerformer.Portable;


using Motion6D.Drawing.Factory;
using Motion6D.Interfaces;


namespace Motion6D.UI.UserControls
{
    /// <summary>
    /// Colored chooser
    /// </summary>
    public class ColoredChooser : UserControlCoordColorSize,
         IPositionCollectionMeasureChooser, IBoxArray

    {

        private ComboBox[] newboxes; 

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ColoredChooser Object = new ColoredChooser();

        internal ColoredChooser()
        {
            newboxes = Boxes;
        }


        #region IPositionCollectionMeasureChooser Members

        List<string> IPositionCollectionMeasureChooser.Meausements
        {
            get
            {
                List<string> l = new List<string>();
                foreach (ComboBox box in newboxes)
                {
                    string s = box.SelectedItem + "";
                    if (s.Length == 0)
                    {
                        throw new ErrorHandler.OwnException("Undefined measure");
                    }
                    l.Add(s);
                }
                return l;
            }
            set
            {
                for (int i = 0; i < value.Count & i < newboxes.Length; i++)
                {
                    newboxes[i].SelectCombo(value[i]);
                }
            }
        }

        DataPerformer.Interfaces.IDataConsumer IPositionCollectionMeasureChooser.Consumer
        {
            get
            {
                return null;
            }
            set
            {
                Double a = 0;
                List<string> mea = value.GetAllMeasurements(a);
                foreach (ComboBox box in newboxes)
                {
                    box.FillCombo(mea);
                }
            }
        }

        IPositionCollectionMeasureChooser IPositionCollectionMeasureChooser.this[IPositionFactory factory]
        {
            get
            {
                if (factory is ColoredPositionFactory)
                {
                    return new ColoredChooser();
                }
                return new SimpleChooser();

            }
        }

        #endregion

        #region IBoxArray Members

        ComboBox[] IBoxArray.Boxes
        {
            get { return newboxes; }
        }

        #endregion


    }
}
