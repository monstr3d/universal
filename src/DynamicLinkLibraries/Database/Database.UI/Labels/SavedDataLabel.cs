using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Drawing;
using System.Windows.Forms;


using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI;

using DataSetService;

using Web.Interfaces;

using Database.UI.Forms;

namespace Database.UI.Labels
{
    [Serializable()]
    public class SavedDataLabel : QueryLabel
    {
        #region Fields

       #endregion

        #region Ctor

        public SavedDataLabel()
        {
        }

        protected SavedDataLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion

        #region Overriden Members


        /// <summary>
        /// Object
        /// </summary>
        public override CategoryTheory.ICategoryObject Object
        {
            get
            {
                return base.Object;
            }
            set
            {
                if (!(value is SavedDataProvider))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                provider = value as SavedDataProvider;
                value.Object = this;
            }
        }

        public override string Type
        {
            get
            {
                return provider.GetType().FullName;
            }
        }

        /// <summary>
        /// Creates Form
        /// </summary>
        public override void CreateForm()
        {
            Icon icon = this.GetBaseIcon();
            // Searching of additional control
            object o = factory.GetAdditionalFeature<IUrlConsumer>(provider as IAssociatedObject);
            if (o is Control) // Additional control
            {
                form = new FormExternalData(this.GetRootLabel(), o as Control);
                if (icon != null)
                {
                    form.Icon = icon;
                }
                return;
            }
            form = new FormSavedData(this.GetRootLabel(), checkBoxShowData.Checked,
                 ShowNumber, ShowTable);

        }

        public override object Image
        {
            get
            {
                return null;
            }
        }

        #endregion


    }
}
