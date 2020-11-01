using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using CustomControls.Data;

namespace CustomControls.ComboBox
{
	public abstract class GridComboBox : UITypeEditor
	{
		#region Constants

		private const string StrAddNew = "<Add New...>";

		#endregion

		#region Data Members

		private IList _dataList;
		private readonly ListBox _listBox;
		private Boolean _escKeyPressed;
		private ListAttribute _listAttribute;
		private IWindowsFormsEditorService _editorService;

		#endregion

		#region Constructors

		/// <summary>
		/// Constructor
		/// </summary>
		public GridComboBox()
		{
			_listBox = new ListBox();

			// Properties
			_listBox.BorderStyle = BorderStyle.None;

			// Events
			_listBox.Click += myListBox_Click;
			_listBox.PreviewKeyDown += myListBox_PreviewKeyDown;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Get/Set for ListBox
		/// </summary>
		protected ListBox ListBox
		{
			get { return ( _listBox ); }
		}

		/// <summary>
		/// Get/Set for DataList
		/// </summary>
		protected IList DataList
		{
			get { return ( _dataList ); }
			set { _dataList = value; }
		}

		/// <summary>
		/// Get/Set for ListAttribute
		/// </summary>
		protected ListAttribute ListAttribute
		{
			get { return ( _listAttribute ); }
			set { _listAttribute = value; }
		}

		#endregion

		#region Methods - Public

		/// <summary>
		/// Close DropDown window to finish editing
		/// </summary>
		public void CloseDropDownWindow()
		{
			if ( _editorService != null )
				_editorService.CloseDropDown();
		}

		#endregion

		#region Methods - Private

		/// <summary>
		/// Populate the ListBox with data items
		/// </summary>
		/// <param name="context"></param>
		/// <param name="currentValue"></param>
		private void PopulateListBox( ITypeDescriptorContext context, Object currentValue )
		{
			// Clear List
			_listBox.Items.Clear();

			// Retrieve the reference to the items to be displayed in the list
			if ( _dataList == null )
				RetrieveDataList( context );

			if ( _dataList != null )
			{
				if ( ( _listAttribute is IAddNew ) && ( ( (IAddNew)_listAttribute ).AddNew ) )
					_listBox.Items.Add( StrAddNew );

				// Add Items to the ListBox
				foreach ( object obj in _dataList )
				{
					_listBox.Items.Add( obj );
				}

				// Select current item 
				if ( currentValue != null )
					_listBox.SelectedItem = currentValue;
			}

			// Set the height based on the Items in the ListBox
			_listBox.Height = _listBox.PreferredHeight;
		}

		#endregion

		#region Methods - Protected

		/// <summary>
		/// Get the object selected in the ComboBox
		/// </summary>
		/// <returns>Selected Object</returns>
		protected abstract object GetDataObjectSelected( ITypeDescriptorContext context );

		/// <summary>
		/// Find the list of data items to populate the ListBox
		/// </summary>
		/// <param name="context"></param>
		protected abstract void RetrieveDataList( ITypeDescriptorContext context );

		#endregion

		#region Event Handlers

		/// <summary>
		/// Preview Key Pressed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void myListBox_PreviewKeyDown( object sender, PreviewKeyDownEventArgs e )
		{
			if ( e.KeyCode == Keys.Escape )
				_escKeyPressed = true;
		}

		/// <summary>
		/// ListBox Click Event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void myListBox_Click( object sender, EventArgs e )
		{
			//when user clicks on an item, the edit process is done.
			this.CloseDropDownWindow();
		}

		#endregion

		#region Overrides

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <param name="provider"></param>
		/// <param name="value"></param>
		/// <returns></returns>
		public override object EditValue( ITypeDescriptorContext context, IServiceProvider provider, object value )
		{
			if ( ( context != null ) && ( provider != null ) )
			{
				//Uses the IWindowsFormsEditorService to display a 
				// drop-down UI in the Properties window:
				_editorService = provider.GetService(
				                 	typeof( IWindowsFormsEditorService ) )
				                 as IWindowsFormsEditorService;

				if ( _editorService != null )
				{
					// Add Values to the ListBox
					PopulateListBox( context, value );

					// Set to false before showing the control
					_escKeyPressed = false;

					// Attach the ListBox to the DropDown Control
					_editorService.DropDownControl( _listBox );

					// User pressed the ESC key --> Return the Old Value
					if ( !_escKeyPressed )
					{
						// Get the Selected Object
						object obj = GetDataObjectSelected( context );

						// If an Object is Selected --> Return it
						if ( obj != null )
							return ( obj );
					}
				}
			}

			return ( value );
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="context"></param>
		/// <returns></returns>
		public override UITypeEditorEditStyle GetEditStyle( ITypeDescriptorContext context )
		{
			return ( UITypeEditorEditStyle.DropDown );
		}

		#endregion
	}
}