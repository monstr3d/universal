using IBApi;
using IBApi.interfaces;
using IBApi.messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAPI.proxy
{
    public class IncomeCalculator
    {
        IHistoricalCalculator calculator;

        public double Income
        { get; set; } = 0;


        public IncomeCalculator(IHistoricalCalculator calculator)
        {
            this.calculator = calculator;
        }

        public void Process(HistoricalDataMessageDateTime  message, Order order, Contract contract)
        {
            Income = calculator.Calculate(message, order, contract);
        }

    }
}
