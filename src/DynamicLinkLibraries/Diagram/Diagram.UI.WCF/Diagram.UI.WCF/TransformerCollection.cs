using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Diagram.UI.WCF.Interfaces;

namespace Diagram.UI.WCF
{
    /*!!!
    public class TransformerCollection : ITransformer
    {
        private ITransformer[] transformers;

        public TransformerCollection(ITransformer[] transformers)
        {
            this.transformers = transformers;
        }



        #region ITransformer Members

        object ITransformer.Transform(Type outType, object obj)
        {
            foreach (ITransformer tr in transformers)
            {
                object o = tr.Transform(outType, obj);
                if (o != null)
                {
                    return o;
                }
            }
            return null;
        }

        #endregion

        #region Members

        public void Add(ITransformer transformer)
        {
            List<ITransformer> l = new List<ITransformer>(transformers);
            l.Add(transformer);
            transformers = l.ToArray();
        }

        #endregion
    }
     */ 
}
