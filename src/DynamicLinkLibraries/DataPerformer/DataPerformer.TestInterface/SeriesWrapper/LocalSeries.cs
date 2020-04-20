﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace DataPerformer.TestInterface.SeriesWrapper
{
    [Serializable()]
    class LocalSeries : ISerializable
    {
        #region Fields

        DataPerformer.Basic.Series series;
       
        #endregion

        #region Ctor

        internal LocalSeries(DataPerformer.Basic.Series series)
        {
            this.series = series;
        }

        private LocalSeries(SerializationInfo info, StreamingContext context)
        {
            byte[] b = info.GetValue("Series", typeof(byte[])) as byte[];
            series = new DataPerformer.Basic.Series();
            series.FromBlob(b);
        }

        #endregion

        #region ISerializable Members

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Series", series.ToBlob(), typeof(byte[]));
        }

        #endregion

        #region Members

        internal bool Compare(DataPerformer.Basic.Series series)
        {
           return this.series.Compare(series);
        }

        #endregion
    }
}
