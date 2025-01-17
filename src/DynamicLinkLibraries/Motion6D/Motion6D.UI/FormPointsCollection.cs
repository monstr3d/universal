using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Diagram.UI.Labels;
using Diagram.UI.Utils;
using Diagram.UI.Interfaces;

using Motion6D.Interfaces;

using Motion6D.UI.UserControls;
using ErrorHandler;


namespace Motion6D.UI
{
    /// <summary>
    /// Editor of properties of collection of points
    /// </summary>
    public partial class FormPointsCollection : Form, IUpdatableForm
    {
        private IObjectLabel label;

        PositionCollectionData collection;

        IPositionCollectionMeasureChooser chooser;

        private FormPointsCollection()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="label">Label of object</param>
        public FormPointsCollection(IObjectLabel label)
        {
            InitializeComponent();
            this.label = label;
            collection = label.Object as PositionCollectionData;
            Text = label.Name;
            fill();
            
        }



        #region IUpdatableForm Members

        void IUpdatableForm.UpdateFormUI()
        {
            Text = label.Name;
        }

        #endregion


        private void fill()
        {
            string[] names = PositionFactory.Factory.Names;
            comboBoxFactory.FillCombo(names);
            comboBoxFactory.SelectCombo(collection.FactoryName);
            selectFactory(collection.Factory);
            chooser.Meausements = collection.Measures;
        }

        void selectFactory(IPositionFactory factory)
        {
            if (chooser != null)
            {
                if (chooser is UserControl)
                {
                    UserControl uc = chooser as UserControl;
                    panelContainer.Controls.Remove(uc);
                }
                else
                {
                    Control c = chooser as Control;
                    panelContainer.Controls.Remove(c);
                }
            }
            chooser = SimpleChooser.Chooser[factory];
            if (chooser is UserControl)
            {
                UserControl uc = chooser as UserControl;
                panelContainer.Controls.Add(uc);
                uc.LoadControlResources();
            }
            else
            {
                Control c = chooser as Control;
                panelContainer.Controls.Add(c);
                c.LoadControlResources();
            }
            chooser.Consumer = collection;
        }

        void acceptFactory()
        {
            string s = comboBoxFactory.SelectedItem + "";
            if (s.Length == 0)
            {
                return;
            }
            IPositionFactory old = collection.Factory;
            IPositionFactory factory = PositionFactory.Factory[s];
            if (old == factory)
            {
                return;
            }
            collection.Factory = factory;
            selectFactory(factory);
        }

        void accept()
        {
            List<string> mea = chooser.Meausements;
            collection.Measures = mea;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                accept();
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                WindowsExtensions.ControlExtensions.ShowMessageBoxModal(ex.Message);
            }
        }

        private void comboBoxFactory_SelectedIndexChanged(object sender, EventArgs e)
        {
            acceptFactory();
        }
    }
}