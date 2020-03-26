using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using CustomControls.Data;


namespace CustomControls.ComboBox
{
    /// <summary>
    /// Combobox Grid list
    /// </summary>
	public class ListGridComboBox : GridComboBox
	{
		#region Methods - Private

		/// <summary>
		/// Create a new object and send notification if requested
		/// </summary>
		/// <param name="context"></param>
		/// <returns>An instantiated object</returns>
		private object CreateNewObject( ITypeDescriptorContext context )
		{
			object obj = null;

			DataListAttribute attribute = base.ListAttribute as DataListAttribute;
			if ( ( attribute != null ) && ( attribute.AddNew ) )
			{
				obj = Reflect.CreateInstance( context.PropertyDescriptor.PropertyType, null );
				SendOnAddNotification( context, obj );
			}

			return ( obj );
		}

		/// <summary>
		/// Send notification of object creation
		/// </summary>
		/// <param name="context"></param>
		/// <param name="obj"></param>
		private void SendOnAddNotification( ITypeDescriptorContext context, object obj )
		{
			DataListAttribute attribute = base.ListAttribute as DataListAttribute;
			if ( ( obj != null ) && ( attribute != null ) && ( attribute.EventHandler != null ) )
			{
				ObjectCreatedEventArgs arg = new ObjectCreatedEventArgs( obj );
				Reflect.CallMethod( context.Instance, attribute.EventHandler, this, arg );
			}
		}


		/// <summary>
		/// Get the class instance of a field/property/method
		/// </summary>
		/// <param name="path"></param>
		/// <param name="property"></param>
		/// <returns></returns>
		private static object GetLocalProperty( IEnumerable<string> path, object property )
		{
			foreach ( string segment in path )
			{
				Property propertyInfo = PathParser.BreakVariable( segment );
				property = Reflect.CallGeneric( property, propertyInfo.Name );

				// If there was a subscript get the data object
				if ( ( property is IList ) && ( propertyInfo.Index != null ) )
				{
					if ( property is IDictionary )
					{
						property = ( (IDictionary)property )[propertyInfo.Index];
					}
					else
					{
						property = ( (IList)property )[(int)propertyInfo.Index];
					}
				}
			}

			return property;
		}

		/// <summary>
		/// Get the static field/property/method of the class
		/// </summary>
		/// <param name="attribute"></param>
		/// <param name="path"></param>
		/// <returns></returns>
		private static object GetStaticProperty( DataListAttribute attribute, IList<string> path )
		{
			Type type;
			object property;
			string segment;
			int count = 0;

			type = ClassType.GetType( attribute.DllName, attribute.ClassName );

			segment = path[count++];
			property = Reflect.GetStaticDataMember( type, segment );


			for ( ; count < path.Count; count++ )
			{
				segment = path[count];

				Property propertyInfo = PathParser.BreakVariable( segment );
				property = Reflect.GetDataMember( property, propertyInfo.Name );

				// If there was a subscript get the data object
				if ( propertyInfo.Index != null )
				{
					if ( property is IDictionary )
					{
						property = ( (IDictionary)property )[propertyInfo.Index];
					}
					else if ( property is IList )
					{
						property = ( (IList)property )[(int)propertyInfo.Index];
					}
				}
			}

			return property;
		}

		#endregion

		#region Overrides

		/// <summary>
		/// Get the object selected and create a new object if <Add New...> was selected
		/// </summary>
		/// <returns></returns>
		protected override object GetDataObjectSelected( ITypeDescriptorContext context )
		{
			object dataObject = base.ListBox.SelectedItem;

			if ( ( dataObject is string ) && ( dataObject.Equals( "<Add New...>" ) ) )
			{
				return ( CreateNewObject( context ) );
			}

			return ( dataObject );
		}


		/// <summary>
		/// Find the list of data to populate the ListBox with
		/// </summary>
		/// <param name="context"></param>
		protected override void RetrieveDataList( ITypeDescriptorContext context )
		{
			DataListAttribute dataListAttribute = null;
			object property = null;

			// Find the Attribute that has the path to the List of Items
			foreach ( Attribute attribute in context.PropertyDescriptor.Attributes )
			{
				if ( attribute is DataListAttribute )
				{
					dataListAttribute = attribute as DataListAttribute;
					base.ListAttribute = dataListAttribute;
					break;
				}
			}

			// If we found the Attribute, find the Data List
			if ( dataListAttribute != null )
			{
				// Split the path 
				List<string> path = PathParser.GetPathParts( dataListAttribute.Path );

				// The path has 1 or more parts
				if ( ( path != null ) && ( path.Count > 0 ) )
				{
					if ( dataListAttribute.IsStatic )
					{
						property = GetStaticProperty( dataListAttribute, path );
					}
					else
					{
						// Set the property to the current object
						property = GetLocalProperty( path, context.Instance );
					}
				}
			}

			// We don't have List of items
			if ( ( property == null ) || ( !( property is IList ) ) )
			{
				base.DataList = null;
			}
			else
			{
				// Save the DataList
				base.DataList = property as IList;
			}
		}

		#endregion
	}
}