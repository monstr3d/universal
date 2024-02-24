using System;
using System.Collections.Generic;
using System.Text;

namespace FormulaEditor
{
    internal class DateTimeLessCompatrator : DateTimeMoreComparator
    {
        private DateTimeLessCompatrator()
        {
        }
        public override object this[object[] x]
        {
            get 
            {
                DateTime dt0 = (DateTime)x[0];
                DateTime dt1 = (DateTime)x[1];
                return dt0 < dt1;
            }
        }
    }
}
