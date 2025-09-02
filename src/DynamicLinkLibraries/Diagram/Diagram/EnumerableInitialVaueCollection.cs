using System.Collections.Generic;
using System.Linq;

using BaseTypes.Interfaces;

namespace Diagram.UI;

public class EnumerableInitialVaueCollection<T> : IInitialValueCollection where T : class
{
    IEnumerable<T> values;

    NamedTree.Performer performer = new NamedTree.Performer();

    public EnumerableInitialVaueCollection(IEnumerable<T> values)
    {
        this.values = values;
    }


    IEnumerable<IInitialValue> IInitialValueCollection.Values => [];

    void IInitialValueCollection.Add(IInitialValue value)
    {
        
    }

    void IInitialValueCollection.Clear()
    {
       
    }

    void IInitialValueCollection.Set()
    {
        var l = performer.Convert<IInitialValue, T>(values);
        var p = from value in l select Get(value);
        p.ToArray();

    }

    IInitialValue Get(IInitialValue initialValue)
    { 
        initialValue.Set();
        return initialValue;
    }
}
