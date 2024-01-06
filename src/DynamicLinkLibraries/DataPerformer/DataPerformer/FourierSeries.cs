using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;
using System.Runtime.Serialization;

using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Labels;
using DataPerformer.Interfaces;
using DataPerformer.Portable.Measurements;
using DataPerformer.Portable;

namespace DataPerformer
{
    /// <summary>
    /// Vector formula data transformer
    /// </summary>
    [Serializable()]
    public class FourierSeries : DataConsumer, IMeasurements, ISerializable,
        IPostSetArrow, IAssociatedObject
    {
        /// <summary>
        /// Output measurements
        /// </summary>
        private IMeasurement[] output = new IMeasurement[2];

        /// <summary>
        /// Results of calculation
        /// </summary>
        private double[,] result = new double[2, 2];

        /// <summary>
        /// Arguments
        /// </summary>
        private string argument;

        /// <summary>
        /// Input measurements
        /// </summary>
        private IMeasurement input;

        /// <summary>
        /// List of series
        /// </summary>
        private ArrayList seriesList = new ArrayList();

        /// <summary>
        /// Series
        /// </summary>
        private Series[] series = new Series[2];

        /// <summary>
        /// Names of unary
        /// </summary>
        private Hashtable seriesTable = new Hashtable();


        /// <summary>
        /// Constructor
        /// </summary>
        public FourierSeries()
            : base(65)
        {
            argument = "";
            for (int i = 0; i < 2; i++)
            {
                seriesTable[i] = "";
            }
            Double a = 0;
            output[0] = new MeasurementDerivation(a, new Func<object>(getRe), new Measurement(getReDerivation, ""), "Real");
            output[1] = new MeasurementDerivation(a, new Func<object>(getIm), new Measurement(getImDerivation, ""), "Image");
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public FourierSeries(SerializationInfo info, StreamingContext context)
            :
            base(65)
        {
            try
            {
                argument = (string)info.GetValue("Argument", typeof(string));
                seriesTable = info.GetValue("SeriesTable", typeof(Hashtable)) as Hashtable;
            }
            catch (Exception ex)
            {
                ex.ShowError(10);
                seriesTable = new Hashtable();
                seriesTable[0] = "";
                seriesTable[1] = "";
            }
            if (seriesTable == null)
            {
            }
            Double a = 0;
            output[0] = new MeasurementDerivation(a, new Func<object>(getRe), new Measurement(getReDerivation, ""), "Real");
            output[1] = new MeasurementDerivation(a, new Func<object>(getIm), new Measurement(getImDerivation, ""), "Image");
        }

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        new public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Argument", argument);
            info.AddValue("SeriesTable", seriesTable);
        }

        /*new public XmlElement CreateXml(XmlDocument doc)
        {
			
            XmlElement el = doc.CreateElement("FourierSeries");
            return el;
        }*/

   
        /*	public Hashtable SeriesTable
            {
                get
                {
                    return seriesTable;
                }
            }

            /// <summary>
            /// Table of series names
            /// </summary>
            /*	public Hashtable SeriesNames
                {
                    get
                    {
                        return seriesNames;
                    }
                }*/

        /*	public void AddSeries(Series series)
            {
                if (seriesList.Count == 2)
                {
                    throw new Exception("Too many series");
                }
                seriesList.Add(series);
            }


            /// <summary>
            /// Removes series
            /// </summary>
            /// <param name="series">Series to remove</param>
            public void RemoveSeries(Series series)
            {
                seriesList.Remove(series);
            }*/


        /// <summary>
        /// The count of measurements
        /// </summary>
        int IMeasurements.Count
        {
            get
            {
                return 2;
            }
        }

        /// <summary>
        /// Access to n - th measurement
        /// </summary>
        IMeasurement IMeasurements.this[int n]
        {
            get
            {
                return output[n];
            }
        }

        /// <summary>
        /// Updates measurements data
        /// </summary>
        public void UpdateMeasurements()
        {
            if (IsUpdated)
            {
                return;
            }
            try
            {
                UpdateChildrenData();
                result[0, 0] = 0;
                result[1, 0] = 0;
                double x = (double)input.Parameter();
                IDerivation der = input as IDerivation;
                double d = der.Derivation.ToDouble();
                for (int i = 0; i < series[0].Count; i++)
                {
                    double om = series[0][i, 0];
                    d *= om;
                    double a = x * om;
                    double s = Math.Sin(a);
                    double c = Math.Cos(a);
                    double re = series[0][i, 1] * c + series[1][i, 1] * s;
                    double im = -series[0][i, 1] * s + series[1][i, 1] * c;
                    result[0, 0] += re;
                    result[1, 0] += im;
                    result[0, 1] += d * im;
                    result[1, 1] -= d * re;
                }
                isUpdated = true;
            }
            catch (Exception e)
            {
                e.ShowError(10);
                this.Throw(e);
            }
        }

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
        {
            acceptArgument();
            AcceptSeries();
        }

        /// <summary>
        /// The name of measurements source
        /// </summary>
        public string SourceName
        {
            get
            {
                INamedComponent comp = Object as INamedComponent;
                return comp.Name;
            }
        }

        /// <summary>
        /// Argument
        /// </summary>
        public string Argument
        {
            get
            {
                return argument;
            }
            set
            {
                argument = value;
                acceptArgument();
            }
        }

        /// <summary>
        /// Dynamical parametrer
        /// </summary>
        public DynamicalParameter Parameter
        {
            set
            {
                if (value.Variables.Length != 1)
                {
                    throw new Exception("Fourier transform should have one parameter");
                }
                input = value['x'];
                argument = input.Name;
            }
        }

        /*public IUnary GetUnary(int i)
        {
            return seriesList[i] as IUnary;
        }*/

        /// <summary>
        /// Count of unaries
        /// </summary>
        public int UnaryCount
        {
            get
            {
                return seriesList.Count;
            }
        }

        /// <summary>
        /// Accepts series
        /// </summary>
        public void AcceptSeries()
        {
            if (seriesTable.Count != 2)
            {
                return;
            }
            for (int i = 0; i < 2; i++)
            {
                string sn = seriesTable[i] as string;
                foreach (Series s in seriesList)
                {
                    //INamedComponent nc = s.Object as INamedComponent;
                    if (sn.Equals(this.GetRelativeName(s)))//nc.Name))
                    {
                        series[i] = s;
                        continue;
                    }
                }
            }
        }


        /// <summary>
        /// Accepts arguments
        /// </summary>
        private void acceptArgument()
        {
            foreach (IMeasurements measurements in measurementsData)
            {
                /*IAssociatedObject cont = measurements as IAssociatedObject;
                INamedComponent c = cont.Object as INamedComponent;*/
                /*			string name = DataConsumer.GetName(this, measurements);//c.Name;
                            for (int i = 0; i < measurements.Count; i++)
                            {
                                IMeasure measure = measurements[i];
                                string p = name + "." + measure.Name;
                                if (argument.Substring(4).Equals(p))
                                {
                                    input = measure;
                                    break;
                                }
                            }
                        }
                        if (argument.Equals("Time"))
                        {
                            input = DataConsumer.TimeMeasure;
                        }
                    }*/
            }
        }







        /// <summary>
        /// Gets function value
        /// </summary>
        /// <returns>The value</returns>
        private object getRe()
        {
            return result[0, 0];
        }

        /// <summary>
        /// Gets function value
        /// </summary>
        /// <returns>The value</returns>
        private object getIm()
        {
            return result[1, 0];
        }

        /// <summary>
        /// Gets function derivation
        /// </summary>
        /// <returns>The derivation</returns>
        private object getReDerivation()
        {
            return result[0, 1];
        }

        /// <summary>
        /// Gets function derivation
        /// </summary>
        /// <returns>The derivation</returns>
        private object getImDerivation()
        {
            return result[1, 1];
        }

    }
}