using CategoryTheory;
using DataPerformer.Base.Filters;
using DataPerformer.Portable.Basic;
using DataPerformer.UI.UserControls;
using Diagram.UI.Labels;
using FormulaEditor.UI;
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
    public class FilterLabel : UserControlBaseLabel
    { 
        UserControlFilter uc = new UserControlFilter();
        protected override UserControl Control =>  uc;

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
        public FilterLabel()
            : base(typeof(FilterWrapper), "Filter", ResourceFilters.Average)
        {
            Width = uc.Width;
            Height = uc.Height;
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        private FilterLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
    
        }

        #endregion

    }
}
