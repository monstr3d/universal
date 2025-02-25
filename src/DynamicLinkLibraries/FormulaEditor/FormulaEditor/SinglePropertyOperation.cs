using System;
using System.Reflection;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;


namespace FormulaEditor
{

    /// <summary>
    /// Operation associated with single property
    /// </summary>
	public class SinglePropertyOperation : IObjectOperation, IOperationAcceptor
	{
		private PropertyAcceptor propertyAcceptor;
		private string propertyName;
		private PropertyInfo propertyInfo;

        static private readonly object[] types = new object[] { new object() };


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="propertyAcceptor">Acceptor of property</param>
        /// <param name="propertyName">Name of property</param>
		public SinglePropertyOperation(PropertyAcceptor propertyAcceptor, string propertyName)
		{
			this.propertyAcceptor = propertyAcceptor;
			this.propertyName = propertyName;
            TypeInfo ti = IntrospectionExtensions.GetTypeInfo(propertyAcceptor.ObjectType);
            propertyInfo = ti.GetDeclaredProperty(propertyName);
			if (propertyInfo == null)
			{
				throw new Exception("SinglePropertyOperatio");
			}
		}

		#region IObjectOperation Members

        /// <summary>
        /// Types of input parameters
        /// </summary>
        object[] BaseTypes.Interfaces.IObjectOperation.InputTypes
        {
			get
			{
				return types;
			}
		}

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
		{
			get
			{
				return propertyInfo.GetValue(propertyAcceptor.Object, null);
			}
		}


        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
		{
			get
			{
				return new object[]{propertyAcceptor.Object, propertyName};
			}
		}


		#endregion

		#region IOperationAcceptor Members

        /// <summary>
        /// Accepts operation
        /// </summary>
        /// <param name="type">Argument type</param>
        /// <returns>The operation</returns>
        public IObjectOperation Accept(object type)
		{
			return this;
		}

		#endregion
	}
}
