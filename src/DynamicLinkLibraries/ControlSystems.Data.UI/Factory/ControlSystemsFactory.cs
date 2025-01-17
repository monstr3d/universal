using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;


using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI;
using Diagram.UI.Factory;

using DataPerformer.Portable;

using ControlSystems.UI.Interfaces;
using ErrorHandler;

namespace ControlSystems.Data.UI.Factory
{
    /// <summary>
    /// Factory of control systems
    /// </summary>
    public class ControlSystemsFactory : EmptyUIFactory
    {
        #region Fields

        /// <summary>
        /// Singleton
        /// </summary>
        public static ControlSystemsFactory Object = new ControlSystemsFactory();

        public static readonly ButtonWrapper[] ObjectButtons = new ButtonWrapper[]
        {
                                        new ButtonWrapper(typeof(ControlSystems.Data.RationalTransformControlSystemData),
                    "", "Transformation function", ResourceImage.ControlSystemTransform, ControlSystemsFactory.Object, true, false)

        };

        #endregion

        #region Ctor

        private ControlSystemsFactory()
        {
        }

        #endregion


        #region IUIFactory Members

        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IArrowLabel)
            {
                IArrowLabel lab = comp as IArrowLabel;
                ICategoryArrow arrow = lab.Arrow;
            }
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
                if (obj is ControlSystems.Data.RationalTransformControlSystemData)
                {
                    return CreateControlSystemForm(lab);
                }
            }
            return null;
        }

        #endregion

        static private Form CreateControlSystemForm(IObjectLabel l)
        {

            ControlSystems.Data.RationalTransformControlSystemData tr =
                l.Object as ControlSystems.Data.RationalTransformControlSystemData;
            ControlSystems.UI.Forms.FormTransformationFunction form =
                new ControlSystems.UI.Forms.FormTransformationFunction(l);
            form.ShowComboBox();
            try
            {
                form.Measurements = tr.InputMeasurements;
                form.SelectedItem = tr.Input;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
            }
            form.SelectMeasure += delegate(object ob)
            {
                if (ob == null)
                {
                    tr.Input = "";
                }
                tr.Input = ob + "";
            };
            try
            {
                form.Feedback = new Feedback(tr);
            }
            catch (Exception exc)
            {
                exc.ShowError(10);
            }
            return form;
        }

    }


    #region Helper Class

    class Feedback : IFeedback
    {
        #region Fields

        ControlSystems.Data.RationalTransformControlSystemData tr;


        #endregion

        #region Ctor

        internal Feedback(ControlSystems.Data.RationalTransformControlSystemData tr)
        {
            this.tr = tr;
        }

        #endregion

        #region IFeedback Members

        ICollection<string> IFeedback.Aliases
        {
            get 
            {
                List<string> ali = new List<string>();
                Double a = 0;
                tr.GetAllAliases(ali, a);
                return ali;
            }
        }

        string IFeedback.Alias
        {
            get
            {
                return tr.Alias;
            }
            set
            {
                tr.Alias = value;
            }
        }

        #endregion
    }

    #endregion
}

