using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataPerformer.Interfaces;
using Event.Portable.Interfaces;

namespace Event.Portable.Internal
{
    /// <summary>
    /// Replaced backup of measutements
    /// </summary>
    class ReplacedMeasurementsBackup : IDisposable
    {
        Dictionary<IReplacedMeasurementParameter, string> dict;

        Dictionary<string, object>[] output = new Dictionary<string, object>[1];

   
        IRealtime realtime;

        internal ReplacedMeasurementsBackup(Dictionary<IReplacedMeasurementParameter, string> dict, 
            IRealtime realtime)
        { 
            this.dict = dict;
            foreach (IReplacedMeasurementParameter m in dict.Keys)
            {
                string n = dict[m];
                m.Replace(
                    () =>
                    {
                        if (output.Length == 0)
                        {
                            return null;
                        }
                        if (output[0] == null)
                        {
                            return null;
                        }
                        if (!output[0].ContainsKey(n))
                        {
                            return null;
                        }
                        return output[0][n];
                    });
            }
            this.realtime = realtime;
        }

        internal Dictionary<string, object>[] Output
        {
            get
            {
                return output;
            }
        }

        void IDisposable.Dispose()
        {
            realtime.Stop();
            foreach (IReplacedMeasurementParameter r in dict.Keys)
            {
                r.Reset();
            }
        }
    }
}
