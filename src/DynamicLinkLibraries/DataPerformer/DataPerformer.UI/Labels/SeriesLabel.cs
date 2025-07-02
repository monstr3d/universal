using CategoryTheory;
using DataPerformer.UI.UserControls;
using Diagram.UI.Interfaces;
using Diagram.UI.Labels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Windows.Forms;


namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label of series
    /// </summary>
    [Serializable()]
    public class SeriesLabel : UserControlBaseLabel, IPostSet
    {
        
        #region Fields


        DataPerformer.Series series;

        UserControlSeries ucs;

        private object[] array = StaticExtensionDataPerformerUI.DefaultSeriesPaintingArray;

        /// <summary>
        /// Formula
        /// </summary>
        private string formula = "";

        Forms.FormSeries form;
        
        #endregion

        #region Ctor

        /// <summary>
        /// Default constructor
        /// </summary>
        public SeriesLabel()
            : base(typeof(DataPerformer.Series), "", ResourceImage.Series.ToBitmap())
        {

        }


        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected SeriesLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            try
            {
                formula = info.GetString("Formula");
            }
            catch (Exception)
            {
            }
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
            info.AddValue("Array", array, typeof(object[]));
            info.AddValue("Formula", formula);
        }

        #endregion

        #region IObjectLabel Members

        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return series;
            }
            set
            {
                if (!(value is Series))
                {
                    CategoryException.ThrowIllegalSourceException();
                }
                series = value as Series;
                value.Object = this;
                ucs.Series = series;
            }
        }

        #endregion

        #region IPostSet Members

        void IPostSet.Post()
        {
            ucs.ShowStrip(true, array);
            ucs.ShowInternal();
        }

        #endregion

        #region Overriden Members


        /// <summary>
        /// Post operation
        /// </summary>
        public override void Post()
        {
            try
            {
            }
            catch (Exception ex)
            {

            }
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                form = new Forms.FormSeries(this, array);
                return form;
            }
        }

        /// <summary>
        /// Load operation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected override void Load(SerializationInfo info, StreamingContext context)
        {
            base.Load(info, context);
            try
            {
                if (type == null)
                {
                    type = typeof(DataPerformer.Series);
                }
                array = info.GetValue("Array", typeof(object[])) as object[];
            }
            catch (Exception)
            {

            }
        }

        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get 
            {
                ucs = new UserControlSeries();
                return ucs;
            }
        }



        #endregion

        #region Specific Members

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        internal string Formula
        {
            get
            {
                if (formula.Length == 0)
                {
                    return ResourceFormula.ZeroFormula;
                }
                return formula;
            }
            set
            {
                this.formula = value;
            }
        }

        #endregion

    }
}
