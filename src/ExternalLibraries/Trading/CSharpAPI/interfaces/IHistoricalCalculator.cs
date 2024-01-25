using IBApi;
using IBApi.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBApi.interfaces
{
    public interface IHistoricalCalculator
    {
        double Calculate(HistoricalDataMessageDateTime message, Order order, Contract contract);
    }
}