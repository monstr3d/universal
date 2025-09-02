
using System.Collections.Generic;

namespace Diagram.UI.Interfaces
{
    public interface IDictionaryCodeCreator<T, S> where T : class where S : class
    {
        Dictionary<string, List<string>> Create(string id, Dictionary<T, S> dictionary);
    }
}
