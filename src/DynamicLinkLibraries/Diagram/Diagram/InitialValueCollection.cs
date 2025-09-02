using System.Collections.Generic;

using BaseTypes.Interfaces;

namespace Diagram.UI
{
    public class InitialValueCollection : IInitialValueCollection
    {
        List<IInitialValue> values = new List<IInitialValue>();

        IEnumerable<IInitialValue> IInitialValueCollection.Values => values;

       protected IInitialValueCollection initial;

        public InitialValueCollection()
        {
            initial = this;
        }

        void IInitialValueCollection.Add(IInitialValue value)
        {
            values.Add(value);
        }

        void IInitialValueCollection.Set()
        {
            foreach (IInitialValue value in values)
            {
                value.Set();
            }
        }

        void IInitialValueCollection.Clear()
        {
            values.Clear();
        }
    }
}
