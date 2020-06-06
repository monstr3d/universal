using System;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


using Diagram.UI;

using BaseTypes.Interfaces;


using FormulaEditor.Interfaces;


namespace DataPerformer
{
    /// <summary>
    /// Series
    /// </summary>
	[Serializable()]
	public class Series : SeriesBase, IComments
	{
		
		#region Fields
   
		#endregion

		#region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
		public Series()
		{
			initialize();
			initFunc();

		}

		/// <summary>
		/// Deserialization constructor
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		protected Series(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                comments = (byte[])info.GetValue("Comments", typeof(byte[]));
            }
            catch (Exception ex)
            {
                ex.ShowError(-1); ;
            }
            try
            {
                x = info.GetValue("X", typeof(string)) as string;
                y = info.GetValue("Y", typeof(string)) as string;
            }
            catch (Exception exc)
            {
                exc.ShowError(100); ;
            }
            Post();
        }

        private Series(bool b)
        {

        }


		#endregion

		#region ISerializable Members

		/// <summary>
		/// ISerializable interface implementation
		/// </summary>
		/// <param name="info">Serialization info</param>
		/// <param name="context">Streaming context</param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
            base.GetObjectData(info, context);
            info.AddValue("X", X, typeof(string));
            info.AddValue("Y", Y, typeof(string));
        }

		#endregion

		#region Specific Members


		/// <summary>
		/// Imports series collecion from document
		/// </summary>
		/// <param name="doc">The document</param>
		/// <returns>Collection of series</returns>
		public static Series[] ImportSeriesCollection(XmlDocument doc)
		{
			XmlNodeList l = doc.DocumentElement.GetElementsByTagName("Series");
			List<Series> ls = new List<Series>();
			foreach (XmlElement e in l)
			{
				Series s = new Series();
				s.Load(e);
				ls.Add(s);
			}
			return ls.ToArray();
		}

		/// <summary>
		/// Gets or sets comments
		/// </summary>
		public ArrayList Comments
		{
			get
			{
				return PureDesktopPeer.Deserialize(comments) as ArrayList;
			}
			set
			{
                comments = PureDesktopPeer.Serialize(value);
			}
		}



		/// <summary>
		/// Creates correspond xml
		/// </summary>
        /// <param name="n">Point number</param>
        /// <param name="doc">document to create element</param>
        /// <returns>The created element</returns>
		public XmlElement CreateXmlPoint(int n, XmlDocument doc)
		{
			XmlElement el = doc.CreateElement("CommonPlotPoint");
			XmlAttribute nx = doc.CreateAttribute("NX");
			nx.Value = X;
			el.Attributes.Append(nx);
			XmlAttribute ny = doc.CreateAttribute("NY");
			ny.Value = Y;
			el.Attributes.Append(ny);
			double[] p = points[n] as double[];
			XmlAttribute x = doc.CreateAttribute("X");
			x.Value = p[0] + "";
			el.Attributes.Append(x);
			XmlAttribute y = doc.CreateAttribute("Y");
			y.Value = p[1] + "";
			el.Attributes.Append(y);
			return el;
		}




        /// <summary>
        /// Access to value of function and its derivation
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Value - derivation vector</returns>
		new public double[] this[double x]
		{
			get
			{
				if (this[0, 0] > x)
				{
					parameter[0] = this[0, 1];
					parameter[1] = 0;
					return parameter;
				}
				if (this[Count - 1, 0] < x)
				{
					parameter[0] = this[Count - 1, 1];
					parameter[1] = 0;
					return parameter;
				}
				if (step != 0)
				{
					int i = (int)(Math.Floor((x - this[0, 0]) / step));
					if (i == Count - 1)
					{
						--i;
					}
					double x1 = this[i, 0];
					double x2 = this[i + 1, 0];
					double y1 = this[i, 1];
					double y2 = this[i + 1, 1];
					parameter[1] = (y2 - y1) / (x2 - x1);
					parameter[0] = y1 + parameter[1] * (x - x1);
					return parameter;
				}
				for (int i = 1; i < Count; i++)
				{
					double x2 = this[i, 0];
					if (x2 > x)
					{
						double x1 = this[i - 1, 0];
						double y1 = this[i - 1, 1];
						double y2 = this[i, 1];
						parameter[1] = (y2 - y1) / (x2 - x1);
						parameter[0] = y1 + parameter[1] * (x - x1);
						break;
					}
				}
				return parameter;
			}
		}



        /// <summary>
        /// Name of X - coordinate
        /// </summary>
		new public string X
		{
			get
			{
				return x;
			}
			set
			{
				x = value;
			}
		}

        /// <summary>
        /// Name of Y - coordinate
        /// </summary>
		new public string Y
		{
			get
			{
				return y;
			}
			set
			{
				y = value;
			}
		}

        /// <summary>
        /// Initialization
        /// </summary>
        new protected void initialize()
        {
            base.initialize();
        }

 

		#endregion

     }

}
