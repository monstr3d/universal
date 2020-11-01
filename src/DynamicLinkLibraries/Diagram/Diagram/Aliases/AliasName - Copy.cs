using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI.Interfaces;

namespace Diagram.UI.Aliases
{
    /// <summary>
    /// Helper class that contains alias and name
    /// </summary>
    public class AliasName : IAliasName
    {

        #region Fields

        /// <summary>
        /// Alias
        /// </summary>
        private IAlias alias;

        /// <summary>
        /// Name
        /// </summary>
        private string name;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="alias">Alias</param>
        /// <param name="name">Name</param>
        public AliasName(IAlias alias, string name)
        {
            this.alias = alias;
            this.name = name;
        }

        #endregion

        #region IAliasName Members

        object IAliasName.Value
        {
            get
            {
                return alias[name];
            }
            set
            {
                alias[name] = value;
            }
        }

        IAliasBase IAliasName.Alias
        {
            get { return alias; }
        }

        string IAliasName.Name
        {
            get { return name; }
        }

        #endregion

        #region Members

        /// <summary>
        /// Sets value to alias
        /// </summary>
        /// <param name="o">The value to set</param>
        public void SetValue(object o)
        {
            alias[name] = o;
        }

        #endregion
    }
}
