using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

using CategoryTheory;

namespace Internet.Meteo.Factory
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
                {"Российская метеослужба (текущие сутки)", typeof(Services.RussianService)}
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
                return c.Invoke(new object[0]) as ICategoryObject;
            }
        }

        #endregion
    }
}
