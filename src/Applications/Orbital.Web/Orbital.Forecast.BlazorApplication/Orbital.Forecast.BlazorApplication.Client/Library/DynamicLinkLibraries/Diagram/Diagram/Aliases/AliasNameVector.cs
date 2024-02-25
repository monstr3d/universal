using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Diagram.UI.Interfaces;

namespace Diagram.UI.Aliases
{
    /// <summary>
    /// Vector version of alias name
    /// </summary>
    public class AliasNameVector : IAliasName
    {
        #region Fields

        /// <summary>
        /// Alias
        /// </summary>
        protected IAliasVector alias;

        /// <summary>
        /// Name
        /// </summary>
        protected string name;

        /// <summary>
        /// Number of component
        /// </summary>
        protected int number;

        #endregion

        #region Ctor

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="alias">alias</param>
        /// <param name="name">name</param>
        /// <param name="number">Number of component</param>
        public AliasNameVector(IAliasVector alias, string name, int number)
        {
            this.alias = alias;
            this.name = name;
            this.number = number;
        }

        #endregion

        #region IAliasName Members

        object IAliasName.Value
        {
            get
            {
                return alias[name, number];
            }
            set
            {
                alias[name, number] = value;
            }
        }

        IAliasBase IAliasName.Alias
        {
            get { return alias; }
        }

        string IAliasName.Name
        {
            get { return name + "[" + number + "]"; }
        }

        #endregion
    }
}
