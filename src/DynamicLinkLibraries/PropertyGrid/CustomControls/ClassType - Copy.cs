using System;

namespace CustomControls
{
    /// <summary>
    /// Utility for type detection
    /// </summary>
	public static class ClassType
	{
		/// <summary>
		/// Get the class type object
		/// </summary>
		/// <param name="assemblyQualifiedName">Assembly-qualified name of the Type containing DLL, class name, version, culture, public key</param>
		/// <returns>The type object of the class</returns>
		public static Type GetType( string assemblyQualifiedName )
		{
			return ( Type.GetType( assemblyQualifiedName ) );
		}


		/// <summary>
		/// Get the class type object
		/// </summary>
		/// <param name="dllName">DLL where the class is defined</param>
		/// <param name="className">Fully qualified name of the class</param>
		/// <returns>The type object of the class</returns>
		public static Type GetType( string dllName, string className )
		{
			string format = string.Format( "{0}, {1}", className, dllName);
			return ( GetType( format ) );
		}

		/// <summary>
		/// Get the class type object
		/// </summary>
		/// <param name="dllName">DLL where the class is defined</param>
		/// <param name="className">Fully qualified name of the class</param>
		/// <param name="version">The specific version to create</param>
		/// <param name="culture">The culture information</param>
		/// <param name="publicKeyToken">Public Key Token</param>
		/// <returns>The type object of the class</returns>
		public static Type GetType( string dllName, string className, Version version, string culture, string publicKeyToken )
		{
			string format = string.Format( "{0}, {1}, Version={2}, Culture={3}, PublicKeyToken={4}",
				className, dllName, version, culture, publicKeyToken );

			return ( GetType( format ) );
		}
	}
}
