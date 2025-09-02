using BaseTypes.Interfaces;
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

        private IAliasName aliasName;

        /// <summary>
        /// Name
        /// </summary>
        private string name;


        protected Performer performer = new Performer();

        protected static readonly object[] types = new object[0];


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
            aliasName = this;
            var rt = performer.GetRootName(alias);
            FullName = (rt == null) ? name : rt + "." + name;
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

        string IAliasName.FullName => FullName;


        object IAliasName.Type => alias.GetType(name);



        #endregion

        #region Members


        protected virtual string FullName
        {
            get;
            set;
        }


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
