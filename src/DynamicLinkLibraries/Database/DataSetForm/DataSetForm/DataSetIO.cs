using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace DataSetService.Forms
{
    /// <summary>
    /// Performs I/O operations for data sets
    /// </summary>
    public static class DataSetIO
    {
        /// <summary>
        /// Loads data set
        /// </summary>
        /// <param name="filename">Filename</param>
        /// <returns>Data set</returns>
        public static DataSet Load(string filename)
        {
            DataSet dataSet = new DataSet();
            dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
            string ext = Path.GetExtension(filename);
            if (ext.ToLower().Contains("xml"))
            {
                dataSet.ReadXml(filename);
            }
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                Stream stream = File.OpenRead(filename);
                dataSet = bf.Deserialize(stream) as DataSet;
                stream.Close();
            }
            return dataSet;
        }

        /// <summary>
        /// Saves data set
        /// </summary>
        /// <param name="dataSet">Data set for saving</param>
        /// <param name="filename">File name</param>
        public static void Save(DataSet dataSet, string filename)
        {

            dataSet.Locale = System.Globalization.CultureInfo.InvariantCulture;
            DataSetService.DataSetStaticPerformer.ConvertToUnspecifiedTime(dataSet);
            string ext = Path.GetExtension(filename);
            if (ext.ToLower().Contains("xml"))
            {
                dataSet.WriteXml(filename, XmlWriteMode.WriteSchema);
                return;
            }
            BinaryFormatter bf = new BinaryFormatter();
            Stream stream = File.OpenWrite(filename);
            bf.Serialize(stream, dataSet);
            stream.Flush();
            stream.Close();
        }

        /// <summary>
        /// Loads Data set
        /// </summary>
        /// <param name="form">Parent form</param>
        /// <returns>Loaded data set</returns>
        public static DataSet LoadDataSet(this IWin32Window form)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = ResourceService.Resources.GetControlResource("Xml Files|*.xml|Data set files|*.ds",
                DataSetService.Forms.Utils.ControlUtilites.Resources);
            if (dialog.ShowDialog(form) != DialogResult.OK)
            {
                return null;
            }
            return Load(dialog.FileName);
        }

        /// <summary>
        /// Saves data set
        /// </summary>
        /// <param name="control">Parent form</param>
        /// <param name="dataSet">Data set for saving</param>
        public static void SaveDataSet(this Control control, DataSet dataSet)
        {
            IWin32Window form = control.FindForm();
            if (form == null)
            {
                return;
            }
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = ResourceService.Resources.GetControlResource("Xml Files|*.xml|Data set files|*.ds",
                DataSetService.Forms.Utils.ControlUtilites.Resources);
            if (dialog.ShowDialog(form) != DialogResult.OK)
            {
                return;
            }
            Save(dataSet, dialog.FileName);
        }
    }
}
