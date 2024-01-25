using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    public class HistoryReatimeWrapper : DefaultEWrapper
    {
        #region Fields
        EWrapper write;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="write">Writer</param>
        public HistoryReatimeWrapper(EWrapper write)
        {
            this.write = write;
        }

        #endregion

        #region Overriden Members

        /**
           * @brief returns the requested historical data bars
           * @param reqId the request's identifier
           * @param bar the OHLC historical data Bar. The time zone of the bar is the time zone chosen on the TWS login screen. Smallest bar size is 1 second. 
           * @sa EClientSocket::reqHistoricalData
           */
        public override void historicalData(int reqId, Bar bar)
        {
            write.realtimeBar(reqId, bar.Time.Convert().Ticks, bar.Open, bar.High, bar.Low, bar.Close, bar.Volume,
                bar.WAP, bar.Count);
        }

        #endregion
    }
}
