using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Reflection;

using CategoryTheory;

namespace Http.Meteo.Factory
{
    /// <summary>
    /// Factory of Meteo
    /// </summary>
    public class MeteoFactory : IObjectFactory
    {

        #region Fields

        Dictionary<string, Type> dic =
            new Dictionary<string, Type>()
            {
                {"Hydrometeorological Centre of Russia", typeof(Services.MeteoService)}
            };

        #endregion

        #region Ctor

        public MeteoFactory()
        {
        }

        #endregion

        #region IObjectFactory Members

        string[] IObjectFactory.Names
        {
            get
            {
                return dic.Keys.ToArray<string>();
            }
        }

        ICategoryObject IObjectFactory.this[string name]
        {
            get
            {
                Type t = dic[name];
                ConstructorInfo c = t.GetConstructor(new Type[0]);
                ICategoryObject co = c.Invoke(new object[0]) as ICategoryObject;
                return co;
            }
        }

        #endregion
    }
}
