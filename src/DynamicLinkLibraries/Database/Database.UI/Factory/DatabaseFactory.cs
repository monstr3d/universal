using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Forms;

using System.Drawing;


using CategoryTheory;

using Diagram.UI;
using Diagram.UI.Labels;
using Diagram.UI.Factory;
using Diagram.UI.Interfaces.Labels;
using Diagram.UI.Interfaces;

using Database.UI.Labels;
using Database.UI.Forms;


using BasicEngineering.UI.Factory;


namespace Database.UI.Factory
{
    public class DatabaseFactory : EmptyUIFactory
    {

        #region Fields

 
        public static readonly ButtonWrapper[] ObjectButtons = 
        {
                 new ButtonWrapper(typeof(DataSetService.StatementWrapper),
                    "", "ODBC Table", ResourceImage.Query, 
                    DatabaseFactory.Object, true, false),
                 new ButtonWrapper(typeof(DataTableSelection.DataSetSelection),
                    "", "Table selection", ResourceImage.DataTableSelection.ToBitmap(), 
                    DatabaseFactory.Object, true, false),
                 new ButtonWrapper(typeof(DataTableSelection.DataSetIterator),
                    "", "Data set iterator", ResourceImage.DataTableIterator.ToBitmap(), 
                    DatabaseFactory.Object, true, false),
                 new ButtonWrapper(typeof(DataTableSelection.DataTableSeries),
                    "", "Data table series", ResourceImage.SeriesData.ToBitmap(), 
                    DatabaseFactory.Object, true, false),
                 new ButtonWrapper(typeof(DataSetService.SavedDataProvider),
                    "", "Saved data set", ResourceImage.DataSave.ToBitmap(), 
                    DatabaseFactory.Object, true, false)
               /*  new ButtonWrapper(typeof(DataSetWeb.StatementWrapperWeb),
                    "", "Web service data", ResourceImage.DataWeb.ToBitmap(), 
                    DatabaseFactory.Object, true, false),*/
         };

        public static readonly Dictionary<Type, Image> TypeImage =
            ButtonWrapper.CreateImageDictionary(ObjectButtons);

        public static readonly ButtonWrapper[] ArrowButtons = 
        {
                 new ButtonWrapper(typeof(DataSetService.DataSetArrow),
                    "", "Link between table provider and table consumer", 
                    ResourceImage.DataTableSelectionLink.ToBitmap(), 
                    DatabaseFactory.Object, true, true),
        };


        /// <summary>
        /// Singleton
        /// </summary>
        public static DatabaseFactory Object = new DatabaseFactory();



        #endregion

        #region Ctor

        private DatabaseFactory()
        {
            Dictionary<Type, Image> d = DataPerformer.UI.Labels.NamedlSeriesLabel.ImageDictionary;
            Dictionary<Type, Image> dic = ButtonWrapper.CreateImageDictionary(ObjectButtons);
            foreach (Type type in dic.Keys)
            {
                if (!d.ContainsKey(type))
                {
                    d[type] = dic[type];
                }
            }
            Dictionary<Type, Icon> ico = DataPerformer.UI.Labels.NamedlSeriesLabel.IconDictionary;
            ico[typeof(DataTableSelection.DataTableSeries)] = ResourceImage.SeriesData;
            QueryLabel.Factory = this;
        }

        #endregion

        #region IUIFactory Members

        public override object CreateForm(INamedComponent comp)
        {
            if (comp is IObjectLabel)
            {
                IObjectLabel lab = comp as IObjectLabel;
                // The object of component
                ICategoryObject obj = lab.Object;
   /*             if (obj is DataSetService.StatementWrapper)
                {
                    return new FormStatementWrapper(lab);
                }
                if (obj is DataSetService.SavedDataProvider)
                {
                    return new FormSavedData(lab);
                }*/
            }
            return null;
        }


        public override IObjectLabelUI CreateObjectLabel(IPaletteButton button)
        {
            return CreateObjectLabel(button.ReflectionType, button.Kind, button.ButtonImage as System.Drawing.Image);
        }

        /// <summary>
        /// Creates object label from object
        /// </summary>
        /// <param name="obj">The object</param>
        /// <returns>The label</returns>
        public override IObjectLabelUI CreateLabel(ICategoryObject obj)
        {
            Type t = obj.GetType();
            return CreateObjectLabel(t, "", null);
        }

  
        #endregion

        #region Private Members

        private IObjectLabelUI CreateObjectLabel(Type t, string kind, System.Drawing.Image image)
        {
            if (t == null)
            {
                return null;
            }
            if (t.GetInterface(typeof(DataPerformer.Interfaces.INamedCoordinates).FullName) != null)
            {
                return DataPerformer.UI.Labels.NamedlSeriesLabel.Create(t);
            }
            {
                //return UserControlLabel.CreateLabel(new Labels.SeriesTableLabel(), image, false);
            }

            if (t.Equals(typeof(DataSetService.StatementWrapper)))
            {
                return (new QueryLabel()).CreateLabelUI(image, false);
            }
            if (t.Equals(typeof(DataSetService.SavedDataProvider)))
            {
                return (new SavedDataLabel()).CreateLabelUI(image, false);
            }
            if (t.Equals(typeof(DataSetService.ExternalDataSetProvider)))
            {
                return (new SavedDataLabel()).CreateLabelUI(image, false);
             }
            return null;
        }


        #endregion

        
    }
}
