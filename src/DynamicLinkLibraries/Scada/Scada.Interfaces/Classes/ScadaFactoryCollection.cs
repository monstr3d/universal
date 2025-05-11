using System;
using System.Collections.Generic;
using System.Reflection;

namespace Scada.Interfaces.Classes
{
    /// <summary>
    /// Collection of factories
    /// </summary>
    public class ScadaFactoryCollection : IScadaFactory
    {
        #region Fields 

        List<IScadaFactory> factories = new();

        List<Type> types = new();

        #endregion

        #region IScadaInterface

        IScadaInterface IScadaFactory.this[object id, bool unique] => Get(id, unique);

        #endregion

        IScadaInterface Get(object id, bool isunique = true)
        {
            foreach (var factory in factories)
            {
                var scada = factory[id, isunique];
                if (scada != null)
                {
                    return scada;
                }
            }
            return null;
        }

        public void Add(IScadaFactory factory)
        {
            factories.Add(factory);
        }

        public void Add(Assembly assembly)
        {
            var atypes = assembly.GetTypes();
            foreach (var type in atypes)
            {
                if (types.Contains(type))
                {
                    continue;
                }
                types.Add(type);
                var tt = new List<Type>(type.GetInterfaces());
                if (tt.Contains(typeof(IScadaFactory)))
                {
                    var c = type.GetConstructor([]);
                    if (c != null)
                    {
                        var factory = c.Invoke(null) as IScadaFactory;
                        Add(factory);
                    }
                }
            }
        }

    }
}
