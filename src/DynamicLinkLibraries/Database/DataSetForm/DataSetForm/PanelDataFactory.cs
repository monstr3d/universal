using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

using DataSetService;


namespace DataSetService.Forms
{
    internal class PanelDataFactory : AbstractDataSetDesktop
    {
        internal static readonly PanelDataFactory Object = new PanelDataFactory();

        private PanelDataFactory()
        {
        }
        public override IColumn Column
        {
            get 
            { 
                return new PanelColumn(); 
            }
        }

        public override ITable Table
        {
            get 
            { 
                return new PanelTable(); 
            }
        }

        public override ILink Link
        {
            get
            {
                return new PanelLink();
            }
        }



        public override IDataSetDesktop Desktop
        {
            get 
            { 
                return new PanelDataSet(); 
            }
        }
    }
}
