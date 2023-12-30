using CategoryTheory;
using DataPerformer.Base.Filters;
using DataPerformer.UI.UserControls;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataPerformer.UI.Labels
{
    [Serializable()]
    public class DonchianLabel :  UserControlBaseLabel
    {
        UserControlDonchian uc = new UserControlDonchian();
        protected override UserControl Control => uc;

        FilterWrapper filterWrapper;

        public override ICategoryObject Object
        {
            get => filterWrapper;
            set
            {
                if (!(value is FilterWrapper))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                filterWrapper = value as FilterWrapper;
                uc.Filter = filterWrapper;
            }
        }


        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DonchianLabel()
            : base(typeof(DataPerformer.Base.Filters.FilterWrapper), "Donchian", ResourceFilters.Donhcian)
        {

        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private DonchianLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion


    }
}
