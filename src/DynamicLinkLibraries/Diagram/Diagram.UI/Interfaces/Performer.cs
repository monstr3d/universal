using System.Collections.Generic;
using System.Reflection;

namespace Diagram.UI.Interfaces
{
    /// <summary>
    /// Performer
    /// </summary>
    public class Performer
    {
        public T Get<T>(IPaletteButton button, Assembly assembly) where T : class
        {
            return Get<T>(button, [assembly]);
        }

        public T Get<T>(IPaletteButton button, IEnumerable<Assembly> assembly) where T : class
        {
            {
                var type = button.ReflectionType;
                foreach (var assemblyType in assembly)
                {
                    if (type.Assembly == assemblyType)
                    {
                        var c = type.GetConstructor(new System.Type[0]);
                        if (c != null)
                        {
                            return c.Invoke(null) as T;
                        }
                        var kind = button.Kind;

                        if (kind.Length > 0) // Kind or additional parameter
                        {
                            // Searches constructor from string
                            ConstructorInfo ci = type.GetConstructor([typeof(string)]);
                            return ci.Invoke([kind]) as T;
                        }
                    }
                }
                return null;
            }
        }
    }
}