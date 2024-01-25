using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Trading.Library.Serializable.Objects
{
    [Serializable]
    public class Order : Library.Objects.Order, ISerializable
    {
        public Order() { }

        private Order(SerializationInfo info, StreamingContext context)
        {
            buyPrice = info.GetString("BuyPrice");
            sellPrice = info.GetString("SellPrice");
            position = info.GetString("Position");
            try
            {
                date = info.GetString("Date");
            }
            catch { }
        }

        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Position", position);
            info.AddValue("BuyPrice", buyPrice);
            info.AddValue("SellPrice", sellPrice);
            info.AddValue("Date", date);
        }
    }
}
