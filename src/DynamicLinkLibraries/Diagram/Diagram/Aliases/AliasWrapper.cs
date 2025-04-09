using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Diagram.UI.Interfaces;
using CategoryTheory;
using NamedTree;
using ErrorHandler;

namespace Diagram.UI.Aliases
{
    /// <summary>
    /// Wrappers of alias
    /// </summary>
    public class AliasWrapper : IAlias
    {
        #region Fields

        Dictionary<string, IAlias> aliases = new Dictionary<string, IAlias>();
        
        List<string> names = new List<string>();

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

        #endregion

        #region Ctor

        private AliasWrapper()
        {
        }

        #endregion

        #region IAlias Members

        IList<string> IAlias.AliasNames
        {
            get { return names; }
        }

        object IAlias.this[string name]
        {
            get
            {
                return aliases[name][name];
            }
            set
            {
                aliases[name][name] = value;
            }
        }

        object IAlias.GetType(string name)
        {
            return aliases[name].GetType(name);
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Gets alias from associated object
        /// </summary>
        /// <param name="obj">Associated object</param>
        /// <returns>Alias</returns>
        public static IAlias GetAlias(IAssociatedObject obj)
        {
            return GetAlias(null, obj);
        }

        #endregion

        #region Private Members

        private void Add(IAlias alias)
        {
            IList<string> n = alias.AliasNames;
            foreach (string name in names)
            {
                if (n.Contains(name))
                {
                    throw new OwnException("Alias name already exists");
                }
            }
            names.AddRange(n);
            foreach (string name in n)
            {
                aliases[name] = alias;
            }
        }

        private static IAlias GetAlias(IAlias alias, IAssociatedObject obj)
        {
            IAlias res = null;
            if (obj is IAlias)
            {
                res = obj as IAlias;
            }
            res = Create(alias, res);
            if (!(obj is IChildren<IAssociatedObject>))
            {
                return res;
            }
            var co = obj as IChildren<IAssociatedObject>;
            IAssociatedObject[] children = co.Children.ToArray();
            foreach (IAssociatedObject ao in children)
            {
                res = GetAlias(res, ao);
            }
            return res;
        }

        private static IAlias Create(IAlias master, IAlias slave)
        {
            if (master == null)
            {
                return slave;
            }
            if (slave == null)
            {
                return master;
            }
            if (master is AliasWrapper)
            {
                AliasWrapper aw = master as AliasWrapper;
                aw.Add(slave);
                return aw;
            }
            AliasWrapper wrapper = new AliasWrapper();
            wrapper.Add(master);
            wrapper.Add(slave);
            return wrapper;
        }

        #endregion
    
    }
}
