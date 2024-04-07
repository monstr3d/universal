using DataPerformer.UI;
using DataPerformer.UI.Interfaces;
using DataPerformer.UI.Labels;
using System;

namespace DataPerformer.WebGenerator
{
    internal class Generator : IDataConsumerCodeGenerator
    {

        public Generator() 
        {
            this.Add();
        }


        void IDataConsumerCodeGenerator.Generate(GraphLabel label)
        {
            throw new NotImplementedException();
        }
    }
}
