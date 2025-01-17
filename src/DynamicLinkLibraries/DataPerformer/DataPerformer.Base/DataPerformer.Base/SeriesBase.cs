using System;
using System.Collections.Generic;
using System.Collections;
using System.Runtime.Serialization;
using System.Xml;


using BaseTypes;
using Diagram.UI;


using Localization.Helper;
using DataPerformer.Portable.Basic;
using ErrorHandler;

namespace DataPerformer
{
    /// <summary>
    /// Base class of all series
    /// </summary>
    public class SeriesBase : Portable.SeriesBase, ISerializable
    {

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public SeriesBase() : base()
        {

        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SeriesBase(SerializationInfo info, StreamingContext context) 
        {
            foreach (string vn in vNames)
            {
                vectorNames.Add(vn);
            }
            try
            {
                points = info.GetValue("Points", typeof(List<double[]>)) as List<double[]>;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                ArrayList p = info.GetValue("Points", typeof(ArrayList)) as ArrayList;
                for (int i = 0; i < p.Count; i++)
                {
                    double[] d = p[i] as double[];
                    points.Add(d);
                }
            }
            InitialzeMeasurements();
        }

        #endregion

        #region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Points", points);
            if (comments != null)
            {
                info.AddValue("Comments", comments);
            }
        }

        #endregion

        #region Specific Members

        #region Public Members

        /// <summary>
        /// Creates correspond xml
        /// </summary>
        /// <param name="doc">document to create element</param>
        /// <returns>The created element</returns>
        public XmlElement ExportToXml(XmlDocument doc)
        {
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Series/>");
            foreach (double[] p in points)
            {
                XmlElement ep = doc.CreateElement("PlotPoint");
                XmlAttribute ax = doc.CreateAttribute("PlotX");
                ax.Value = "" + p[0];
                ep.Attributes.Append(ax);
                XmlAttribute ay = doc.CreateAttribute("PlotY");
                ay.Value = "" + p[1];
                ep.Attributes.Append(ay);
                doc.DocumentElement.AppendChild(ep);
            }
            return doc.DocumentElement;
        }

        /// <summary>
        /// Export to xml
        /// </summary>
        public XmlDocument Xml
        {
            get
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><Series/>");
                CreateElements(doc, doc.DocumentElement);
                return doc;
            }
            set
            {
                points.Clear();
                XmlElement e = value.DocumentElement;
                Load(e);
            }
        }

        /// <summary>
        /// Exports array of series to single document
        /// </summary>
        /// <param name="seriesArray">Array of series</param>
        /// <returns></returns>
        public static XmlDocument Export(Series[] seriesArray)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?><SeriesCollection/>");
            foreach (SeriesBase s in seriesArray)
            {
                XmlElement e = doc.CreateElement("Series");
                doc.DocumentElement.AppendChild(e);
                s.CreateElements(doc, e);
            }
            return doc;
        }

        /// <summary>
        /// Loads from element
        /// </summary>
        /// <param name="e">The element</param>
        public void Load(XmlElement e)
        {
            foreach (XmlElement el in e.ChildNodes)
            {
                AddXY(el.Attributes["PlotX"].Value.Convert(), el.Attributes["PlotY"].Value.Convert());
            }
        }

        #endregion 

        #region Private Members

        /// <summary>
        /// Creates Elements
        /// </summary>
        /// <param name="doc">document</param>
        /// <param name="e">root element</param>
        void CreateElements(XmlDocument doc, XmlElement e)
        {
            foreach (double[] p in points)
            {
                XmlElement ep = doc.CreateElement("PlotPoint");
                XmlAttribute ax = doc.CreateAttribute("PlotX");
                ax.Value = p[0].Convert();
                ep.Attributes.Append(ax);
                XmlAttribute ay = doc.CreateAttribute("PlotY");
                ay.Value = p[1].Convert();
                ep.Attributes.Append(ay);
                e.AppendChild(ep);
            }
        }

        #endregion


        #endregion

        #region Protected Members


       #endregion

        #region Private Members



   
        #endregion

        #region Helper Classes

        #endregion
    }
}
