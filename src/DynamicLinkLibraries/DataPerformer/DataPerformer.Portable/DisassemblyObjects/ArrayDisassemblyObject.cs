using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BaseTypes;
using BaseTypes.Interfaces;

namespace DataPerformer.Portable.DisassemblyObjects
{
    /// <summary>
    /// Array disassembly
    /// </summary>
    public class ArrayDisassemblyObject : IDisassemblyObject
    {
        #region Fields

        ArrayReturnType type;

        List<Tuple<string, object>> types = new List<Tuple<string, object>>();

        public object elementType;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">The type</param>
        protected ArrayDisassemblyObject(ArrayReturnType type)
        {
            this.type = type;
            object o = type.ElementType;
            int[] dim = type.Dimension;
            for (int i = 0; i < dim[0]; i++)
            {
                types.Add(new Tuple<string, object>((i + 1) + "", o));
            }
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="elementType">Type of element</param>
        public ArrayDisassemblyObject(object elementType)
        {
            this.elementType = elementType;
        }

        #endregion

        #region IDisassemblyObject Members

        IDisassemblyObject IDisassemblyObject.this[object type]
        {
            get
            {
                if (type is ArrayReturnType)
                {
                    ArrayReturnType art = type as ArrayReturnType;
                    if ((elementType != null))
                    {
                        if (!elementType.Equals(art.ElementType))
                        {
                            return null;
                        }
                        return new ArrayDisassemblyObject(art);
                    }
                }
                return null;
            }
        }

        List<Tuple<string, object>> IDisassemblyObject.Types
        {
            get
            {
                return types;
            }
        }

        object[] IDisassemblyObject.Disassembly(object obj)
        {
            Array a = obj as Array;
            object[] o = new object[a.Length];
            Array.Copy(a, o, o.Length);
            return o;
        }

        #endregion
    }
}
