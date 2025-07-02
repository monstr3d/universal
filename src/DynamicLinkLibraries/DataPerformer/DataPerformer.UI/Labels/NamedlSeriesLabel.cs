using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Runtime.Serialization;

using CategoryTheory;

using Diagram.UI.Labels;
using Diagram.UI.Interfaces;


using DataPerformer.Interfaces;

using DataPerformer.UI.UserControls;
using DataPerformer.UI.Forms;

namespace DataPerformer.UI.Labels
{
    /// <summary>
    /// Label for named series
    /// </summary>
    [Serializable()]
    public class NamedlSeriesLabel : UserControlBaseLabel, IPostSet
    {
        #region Fields

        INamedCoordinates coord;

        UserControlNamedSeries uc;


        private static Dictionary<Type, Image> imageDictionatry = Factory.StaticFactory.ButtonImages;

        private static Dictionary<Type, Icon> iconDictionary;

        private object[] array = StaticExtensionDataPerformerUI.DefaultSeriesPaintingArray;

        FormNamedSeries form;

        #endregion

        #region Ctor

        /// <summary>
        /// Named series label
        /// </summary>
        /// <param name="type"></param>
        public NamedlSeriesLabel(Type type)
            : base(type, "", imageDictionatry[type])
        {
        }

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        protected NamedlSeriesLabel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        /// <summary>
        /// Static initializer
        /// </summary>
        static NamedlSeriesLabel()
        {
            iconDictionary = new Dictionary<Type, Icon>()
            {
                {typeof(DataPerformer.Series), ResourceImage.Series},
                {typeof(DataPerformer.SeriesIterator), ResourceImage.SeriesIterator},
                {typeof(DataPerformer.DoubleSeries), ResourceImage.DoubleSeries},
                {typeof(DataPerformer.SeriesVectorData), ResourceImage.SeriesVector}
            };
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
        }

        #endregion

        #region IPostSet Members

        void IPostSet.Post()
        {
           // uc.SetToolStrip(true);
            uc.Array = array;
            uc.Fill();
            uc.ShowAll();
        }

        #endregion

        #region Overriden Members


        /// <summary>
        /// Internal control
        /// </summary>
        protected override UserControl Control
        {
            get 
            {
                uc = new UserControlNamedSeries();
                return uc;
            }
        }


        /// <summary>
        /// Object
        /// </summary>
        protected override ICategoryObject Object
        {
            get
            {
                return coord as ICategoryObject;
            }
            set
            {
                if (!(value is INamedCoordinates))
                {
                    CategoryException.ThrowIllegalObjectException();
                }
                coord = value as INamedCoordinates;
                uc.SetToolStrip(true);
                uc.Array = array;
                uc.NamedCoordinates = coord;
             }
        }

        /// <summary>
        /// Associated form
        /// </summary>
        public override object Form
        {
            get
            {
                form = new Forms.FormNamedSeries(this, uc.NamedCoordinates, array);
                if (iconDictionary.ContainsKey(type))
                {
                    Icon icon = iconDictionary[type];
                    form.Icon = icon;
                }
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
            array = info.GetValue("Array", typeof(object[])) as object[];
        }


        #endregion

        #region Public Members

        /// <summary>
        /// Creates label
        /// </summary>
        /// <param name="type">Object type</param>
        /// <param name="changeSize">The change size sign</param>
        /// <returns>Created label</returns>
        public static UserControlLabel Create(Type type, bool changeSize)
        {
            NamedlSeriesLabel l = new NamedlSeriesLabel(type);
            return l.Create(changeSize);
        }

        /// <summary>
        /// Creates label
        /// </summary>
        /// <param name="type">Object type</param>
        /// <returns>Created label</returns>
        public static UserControlLabel Create(Type type)
        {
            return Create(type, false);
        }

        /// <summary>
        /// Dictionary of images
        /// </summary>
        public static Dictionary<Type, Image> ImageDictionary
        {
            set
            {
                imageDictionatry = value;
            }
            get
            {
                return imageDictionatry;
            }
        }

        /// <summary>
        /// Dictionary of icons
        /// </summary>
        public static Dictionary<Type, Icon> IconDictionary
        {
            get
            {
                return iconDictionary;
            }
        }

 

        #endregion

    }
}
