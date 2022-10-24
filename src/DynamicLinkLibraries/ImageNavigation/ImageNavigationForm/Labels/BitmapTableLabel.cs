using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Windows.Forms;

using CategoryTheory;


using Diagram.UI.Labels;
using ImageNavigation.UserControls;
using ImageNavigationForm.Properties;

namespace ImageNavigation.Labels
{
    [Serializable()]
    public class BitmapTableLabel : UserControlBaseLabel, IPostSetArrow
    {

        #region Fields

        BitmapColorTable table;

        UserControlBitmapTable uc;

        bool begin = true;

        #endregion


        #region Ctor

        public BitmapTableLabel()
            : base(typeof(BitmapColorTable), "", Resources.BitmapColorSelection.ToBitmap())
        {
        }


        protected BitmapTableLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion


        protected override UserControl Control
        {
            get 
            {
                uc = new UserControlBitmapTable();
                return uc;
            }
        }

        public override ICategoryObject Object
        {
            get
            {
                return table;
            }
            set
            {
                table = value.GetObject<BitmapColorTable>();
                uc.Table = table;
            }
        }

        #region IPostSetArrow Members

        void IPostSetArrow.PostSetArrow()
        {
            if (!begin)
            {
                return;
            }
            begin = false;
            uc.Post();
        }

        #endregion
    }
}
