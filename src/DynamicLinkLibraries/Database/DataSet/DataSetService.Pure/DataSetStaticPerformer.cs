
using System.Data;

namespace DataSetService.Pure
{
    /// <summary>
    /// Performer of static operations
    /// </summary>
    public static class DataSetStaticPerformer
    {
        /// <summary>
        /// Converts all columns to unspecified time
        /// </summary>
        /// <param name="dataSet">Data set for conversion</param>
        public static void ConvertToUnspecifiedTime(DataSet dataSet)
        {
            foreach (DataTable dt in dataSet.Tables)
            {
                foreach (DataColumn dc in dt.Columns)
                {
                    if (dc.DataType.Equals(typeof(DateTime)))
                    {
                        dc.DateTimeMode = DataSetDateTime.Unspecified;
                    }
                }
            }
        }
    }
}
