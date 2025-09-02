using System.Collections.Generic;

namespace Diagram.UI.Interfaces
{
    public interface IEnumerableCodeCreator<T> where T : class
    {
        Dictionary<string, List<string>> Create(string id, IEnumerable<T> values);
    }
}
