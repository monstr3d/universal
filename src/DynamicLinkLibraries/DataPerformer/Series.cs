using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System.Xml;


using Diagram.UI;

using BaseTypes.Interfaces;


using FormulaEditor.Interfaces;

using DataPerformer.Portable.Measurements;

namespace DataPerformer
{
    /// <summary>
    /// Series
    /// </summary>
	[Serializable()]
	public class Series : SeriesBase,
        IUnary, IObjectOperation, IPowered, IOperationAcceptor, IComments, IOneVariableFunction
	{
		
		#region Fields
        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly Series Singleton = new Series(false);

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
            initFunc();
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

		#region IObjectOperation Members

		object IObjectOperation.this[object[] x]
		{
			get
			{
				double a = (double) x[0];
				return GetValue(a);
			}
		}

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
		{
			get
			{
				return a;
			}
		}

        object[] IObjectOperation.InputTypes
        {
            get { return new object[] { (double)0 }; }
        }


        /// <summary>
        /// The "is powered" sign
        /// </summary>
        bool IPowered.IsPowered
		{
			get
			{
				return true;
			}
		}

		#endregion

        #region IOneVariableFunction Members

        object IOneVariableFunction.VariableType
        {
            get { return a; }
        }

        #endregion

		#region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
		{
			if (type.Equals(a))
			{
				return this;
			}
			return null;
		}

		#endregion

		#region IUnary Members

		/// <summary>
		/// Gets value of function
		/// </summary>
		/// <param name="x">Argument</param>
		/// <returns></returns>
		public double GetValue(double x)
		{
			return this[x][0];
		}

		/// <summary>
		/// Gets derivation of function
		/// </summary>
		/// <param name="x">Argument</param>
		/// <returns></returns>
		public double GetDerivation(double x)
		{
			return this[x][1];
		}

		#endregion

        #region Specific Members


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


		private object parX()
		{
			InitialzeMeasurements();
			return meaX;
		}

		private object parY()
		{
			InitialzeMeasurements();
			return meaY;
		}



		/// <summary>
		/// Checks whether series has equal step
		/// </summary>
		private void checkEqualStep()
		{
			if (points.Count < 2)
			{
				return;
			}
			double s =  0;
			double t = 0;
			for (int i = 0; i < points.Count; i++)
			{
				double[] p = points[i] as double[];
				if (i == 1)
				{
					s = p[0] - t;
				}
				if (i > 1)
				{
					if (Math.Abs(s - (p[0] - t)) > (eps * Math.Abs(s)))
					{
						return;
					}
				}
				t = p[0];
			}
			step = s;
		}


        private void initFunc()
        {
            Func<object> par = func;
            function = new Measurement(Singleton, par, "Function");
        }

        private object func()
        {
            return this;
        }



		#endregion

     }

}
