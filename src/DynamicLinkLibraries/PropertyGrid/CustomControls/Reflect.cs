using System;
using System.Reflection;

namespace CustomControls
{
	/// <summary>
	/// Utility class to access class fields/properties/methods via System.Reflection
	/// </summary>
	public static class Reflect
	{
		/// <summary>
		/// Create an instance of a class
		/// </summary>
		/// <param name="type">The type of class to instantiate</param>
		/// <param name="args">Arguments for the constructor</param>
		/// <returns>A class of the given type</returns>
		public static object CreateInstance( Type type, params object[] args )
		{
			return type.InvokeMember(
				null,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.CreateInstance |
				BindingFlags.Instance,
				null,
				null,
				args );
		}


		/// <summary>
		/// Set a field/property of a class that has been instantiated
		/// </summary>
		/// <param name="classInstance">Class instantiation that contains the field/property to set the value</param>
		/// <param name="dataMemberName">The field/property name</param>
		/// <param name="value">The value to set in the field/property</param>
		public static void SetDataMember( object classInstance, string dataMemberName, object value )
		{
			object[] args = { value };

			classInstance.GetType().InvokeMember(
				dataMemberName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.SetField |
				BindingFlags.SetProperty |
				BindingFlags.Instance,
				null,
				classInstance,
				args );
		}


		/// <summary>
		/// Set a static field/property of a class
		/// </summary>
		/// <param name="type">The class type</param>
		/// <param name="dataMemberName">The field/property name</param>
		/// <param name="value">The value to set in the field/property</param>
		public static void SetStaticDataMember( Type type, string dataMemberName, object value )
		{
			object[] args = { value };

			type.InvokeMember(
				dataMemberName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.SetField |
				BindingFlags.SetProperty |
				BindingFlags.Static,
				null,
				null,
				args );
		}


		/// <summary>
		/// Get the value of a field/property from an instantiated class
		/// </summary>
		/// <param name="classInstance">Class instantiation from which to obtain the field/property value</param>
		/// <param name="dataMemberName">The field/property name</param>
		/// <returns>The value from the field/property</returns>
		public static object GetDataMember( object classInstance, string dataMemberName )
		{
			return classInstance.GetType().InvokeMember(
				dataMemberName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.GetField |
				BindingFlags.GetProperty |
				BindingFlags.Instance,
				null,
				classInstance,
				null );
		}


		/// <summary>
		/// Get the value from a static field/property from a class
		/// </summary>
		/// <param name="type">The class type</param>
		/// <param name="dataMemberName">The field/property name</param>
		/// <returns>The value from the field/property</returns>
		public static object GetStaticDataMember( Type type, string dataMemberName )
		{
			return type.InvokeMember(
				dataMemberName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.GetField |
				BindingFlags.GetProperty |
				BindingFlags.Static,
				null,
				null,
				null
				);
		}


		/// <summary>
		/// Call a method of a class instantiation
		/// </summary>
		/// <param name="classInstance">Class instantiation that contains the method to call</param>
		/// <param name="methodName">The name of the method</param>
		/// <param name="args">Arguments for the method</param>
		/// <returns>The value from the method call</returns>
		public static object CallMethod( object classInstance, string methodName, params object[] args )
		{
			return classInstance.GetType().InvokeMember(
				methodName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.InvokeMethod |
				BindingFlags.Instance,
				null,
				classInstance,
				args );
		}


		/// <summary>
		/// Call a static method of a class
		/// </summary>
		/// <param name="type">Class type that contains the method to call</param>
		/// <param name="memberName">The name of the method</param>
		/// <param name="args">Arguments for the method</param>
		/// <returns>The value from the method call</returns>
		public static object CallStaticMethod( Type type, string memberName, params object[] args )
		{
			return type.InvokeMember(
				memberName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.InvokeMethod |
				BindingFlags.Static,
				null,
				null,
				args );
		}


		/// <summary>
		/// Call a field/property/method of a class instantiation
		/// </summary>
		/// <param name="classInstance">Class instantiation that contains the field/property/method to call</param>
		/// <param name="methodName">The name of the field/property/method</param>
		/// <param name="args">Arguments for the field/property/method</param>
		/// <returns>The value from the field/property/method call</returns>
		public static object CallGeneric( object classInstance, string methodName, params object[] args )
		{
			return classInstance.GetType().InvokeMember(
				methodName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.GetField |
				BindingFlags.GetProperty |
				BindingFlags.InvokeMethod |
				BindingFlags.Instance,
				null,
				classInstance,
				args );
		}


		/// <summary>
		/// Call a static field/property/method of a class
		/// </summary>
		/// <param name="type">Class type that contains the field/property/method to call</param>
		/// <param name="memberName">The name of the field/property/method</param>
		/// <param name="args">Arguments for the field/property/method</param>
		/// <returns>The value from the field/property/method call</returns>
		public static object CallStaticGeneric( Type type, string memberName, params object[] args )
		{
			return type.InvokeMember(
				memberName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.GetField |
				BindingFlags.GetProperty |
				BindingFlags.InvokeMethod |
				BindingFlags.Static,
				null,
				null,
				args );
		}
	}
}