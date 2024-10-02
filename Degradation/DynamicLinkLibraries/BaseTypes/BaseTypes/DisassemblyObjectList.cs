using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes.Interfaces;

namespace BaseTypes
{
    /// <summary>
    /// List of disassembly objects
    /// </summary>
    public class DisassemblyObjectList : IDisassemblyObject
    {

        #region Fields

        List<IDisassemblyObject> list = new List<IDisassemblyObject>();

        #endregion

        #region IDisassemblyObject Members

        IDisassemblyObject IDisassemblyObject.this[object type]
        {
            get
            {
                foreach (IDisassemblyObject d in list)
                {
                    IDisassemblyObject dob = d[type];
                    if (dob != null)
                    {
                        return dob;
                    }
                }
                return null;
            }
        }

        List<Tuple<string, object>> IDisassemblyObject.Types
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        object[] IDisassemblyObject.Disassembly(object obj)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Specific Members

        /// <summary>
        /// Adds a disassembly object
        /// </summary>
        /// <param name="disassemblyObject">The disassembly object</param>
        public void Add(IDisassemblyObject disassemblyObject)
        {
            list.Add(disassemblyObject);
        }

        #endregion
    }
}
