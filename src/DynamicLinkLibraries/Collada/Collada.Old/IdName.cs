using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Collada
{
    class IdName
    {
        #region Fields

        string id;

        string name;

        #endregion

        #region Ctor

        internal IdName(string id, string name)
        {
            this.id = id;
            this.name = name;
        }

        #endregion

        #region Overriden

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var idn = obj as IdName;
            return idn.name.Equals(name) & idn.id.Equals(id);
        }

        #endregion

        #region Own Members

        internal IdName Double()
        {
            if (name.Length != 0)
            {
                return null;
            }
            return new IdName(id, id);
        }

        

        #endregion
    }
}
