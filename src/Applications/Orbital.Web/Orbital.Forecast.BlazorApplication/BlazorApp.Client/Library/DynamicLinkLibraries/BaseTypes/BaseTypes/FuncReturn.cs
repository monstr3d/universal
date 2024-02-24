using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseTypes
{
    /// <summary>
    /// Rerurn of function
    /// </summary>
    public class FuncReturn
    {
        #region Fields

        Type type;

        object inputType;

        object returnType;

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="inputType">Input type</param>
        /// <param name="returnType">Return type</param>
        public FuncReturn(Type type, object inputType,  object returnType)
        {
            this.type = type;
            this.inputType = inputType;
            this.returnType = returnType;
        }

        #endregion

        #region Public Members

        /// <summary>
        /// Type
        /// </summary>
        public Type Type
        {
            get { return type; }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object InputType
        {
            get { return inputType; }
        }

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
        {
            get { return returnType; }
        }

        #endregion
    }
}
