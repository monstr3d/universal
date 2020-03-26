using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.Configuration.Assemblies;
using System.Resources;


using FormulaEditor.Interfaces;
using FormulaEditor.Drawing;
using FormulaEditor.Drawing.Interfaces;
using FormulaEditor.Drawing.Symbols;
using FormulaEditor.Symbols;


namespace FormulaEditor
{
	/// <summary>
	/// Performs all dynamic formula editior operations
	/// </summary>
	public class FormulaEditorPerformer : FormulaEditor.Drawing.FormulaEditorPerformer, IKeySymbol
	{

		#region Fields


		/// <summary>
		/// The editor component
		/// </summary>
		private Control control;


		/// <summary>
		/// Cursor for image moving 
		/// </summary>
		static readonly private Cursor CURSOR_MOVE = Cursors.Cross;

		/// <summary>
		/// Cursor for symbol select/delete
		/// </summary>
		static readonly private Cursor CURSOR_EDIT = Cursors.Default;


		/// <summary>
		/// Key symbol
		/// </summary>
		private IKeySymbol keySymbol;

		/// <summary>
		/// Key event handler
		/// </summary>
		private KeyPressEventHandler keyPressEventHandler;

		/// <summary>
		/// Key event handler
		/// </summary>
		private KeyEventHandler keyUpEventHandler;


 
		#endregion

		#region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="control">component the editor component</param>
        /// <param name="formula">formula the formula for edit</param>
        public FormulaEditorPerformer(Control control, MathFormulaDrawable formula)
            : base(new ControlWrapper(control), formula)
        {
            this.control = control;
            keyPressEventHandler = new KeyPressEventHandler(keyPress);
            keyUpEventHandler = new KeyEventHandler(keyUp);
            keySymbol = this;
        }
 
		#endregion

        #region IKeySymbol Members

        /// <summary>
        /// Gets symbol from keyboard
        /// </summary>
        /// <param name="args">Argumets of key press event</param>
        /// <returns>Pressed symbol</returns>
        public MathSymbol GetSymbol(KeyPressEventArgs args)
        {
            char c = args.KeyChar;
            return new SimpleSymbolDrawable(new SimpleSymbol(c, 0x0, false, false));
        }

        #endregion

		#region Specific Members

		/// <summary>
		/// Event handlers initialization
		/// </summary>
		public void InitEventHandlers()
		{
			control.Paint += new PaintEventHandler(onPaint);
			control.MouseUp += new MouseEventHandler(onMouseClicked);
			control.MouseMove += new MouseEventHandler(onMouseMove);
			control.KeyPress += new KeyPressEventHandler(keyPress);
			control.KeyUp += new KeyEventHandler(keyUp);
		}

		/// <summary>
		/// Key press event handler
		/// </summary>
		public KeyPressEventHandler KeyPressEventHandler
		{
			get
			{
				return keyPressEventHandler;
			}
			set
			{
				keyPressEventHandler = value;
			}
		}

		/// <summary>
		/// Key press event handler
		/// </summary>
		public KeyEventHandler KeyUpEventHandler
		{
			get
			{
				return keyUpEventHandler;
			}
		}

		/// <summary>
		/// Key symbol
		/// </summary>
		public IKeySymbol KeySymbol
		{
			set
			{
				keySymbol = value;
			}
		}

        /// <summary>
        /// Sets key event to control and all its childrem
        /// </summary>
        /// <param name="c">The control</param>
        /// <param name="exc">List of excluded controls</param>
        public void SetKeyEvents(Control c, List<Control> exc)
        {
            if (keyUpEventHandler == null)
            {
                return;
            }
            if (c == control)
            {
                return;
            }
            if (exc != null)
            {
                if (exc.Contains(c))
                {
                    return;
                }
            }
            c.KeyUp += keyUpEventHandler;
            c.KeyPress += keyPressEventHandler;
            foreach (Control cont in c.Controls)
            {
                SetKeyEvents(cont, exc);
            }
        }

		/// <summary>
		/// Painting
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onPaint(object sender, PaintEventArgs e)
		{
			e.Graphics.DrawImage(iTemp, transPoint.X, transPoint.Y);
		}

		/// <summary>
		/// Key up
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="args">Arguments</param>
		private void keyUp(object sender, KeyEventArgs args)
		{
			if (args.KeyData != Keys.Back)
			{
				return;
			}
			MathSymbol sym = formula.Last;
			if (sym != null)
			{
				sym.Remove();
				DrawFormulaOnComponent();
			}

		}



		/// <summary>
		/// Key up
		/// </summary>
		/// <param name="sender">Sender</param>
		/// <param name="args">Arguments</param>
		private void keyPress(object sender, KeyPressEventArgs args)
		{
			if (keySymbol != null)
			{
				MathSymbol sym = keySymbol.GetSymbol(args);
				if (sym == null)
				{
					return;
				}
				sym = Find(sym);
				if (sym == null)
				{
					return;
				}
				if (newCursor is MathSymbol)
				{
					MathSymbol ds = newCursor as MathSymbol;
					newCursor = MathSymbolDrawable.InsertObject(ds, sym) as IInsertedObject;
				}
				else if (newCursor is MathFormulaDrawable)
				{
					MathFormulaDrawable mf = newCursor as MathFormulaDrawable;
					newCursor = mf.InsertObject(sym) as IInsertedObject;
				}
				//newCursor = newCursor.InsertObject(movedSymbol);
				movedSymbol = null;
				DrawCursor();
				DrawFormulaOnComponent();
				oldCursor = movedSymbol as IInsertedObject;
				control.Cursor = CURSOR_EDIT;
			}
		}


		/// <summary>
		/// The "on click" event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		private void onMouseClicked(object sender, MouseEventArgs e)
		{
			translate(e);
			if (movedSymbol == null)
			{
				movedSymbol = newSymbol;
				if (movedSymbol != null)
				{
                    if (movedSymbol is DateTimeSymbol)
                    {
                        DateTimeSymbol dts = movedSymbol as DateTimeSymbol;
                        dts.DateTime = dateTime.DateTime;
                    }
					IDrawableSymbol ds = movedSymbol as IDrawableSymbol;
					wImage = ds.PureDrawable.SymbolImage.Width;
					hImage = ds.PureDrawable.SymbolImage.Height;
					control.Cursor = CURSOR_MOVE;
					oldX = imagePoint.X;
					oldY = imagePoint.Y;
					DrawCursor();
					if (newCursor != null)
					{
						DrawCursor(newCursor, true, true);
					}
				}
				if (newRemoveCursor != null)
				{
					MathSymbol s = (MathSymbol)newRemoveCursor;
					if (s.Contains(newCursor))
					{
						newCursor = null;
						oldCursor = null;
					}
					s.Remove();
					newRemoveCursor = null;
					oldRemoveCursor = null;
					DrawFormulaOnComponent();
				}
			}
			else
			{
				if(newCursor == null)
				{
					movedSymbol = null;
					DrawCursor();
					newCursor = null;
					oldCursor = null;
					control.Cursor = CURSOR_EDIT;
				}
				else
				{
					if (newCursor is MathSymbol)
					{
						MathSymbol ds = newCursor as MathSymbol;
						newCursor = MathSymbolDrawable.InsertObject(ds, movedSymbol) as IInsertedObject;
					}
					else if (newCursor is MathFormulaDrawable)
					{
						MathFormulaDrawable mf = newCursor as MathFormulaDrawable;
						newCursor = mf.InsertObject(movedSymbol) as IInsertedObject;
					}
					//newCursor = newCursor.InsertObject(movedSymbol);
					movedSymbol = null;
					DrawCursor();
					DrawFormulaOnComponent();
					oldCursor = movedSymbol as IInsertedObject;
					control.Cursor = CURSOR_EDIT;
				}
			}
		}

		/// <summary>
		/// The "on mouse move" event handler
		/// </summary>
		/// <param name="sender">The sender</param>
		/// <param name="e">The event arguments</param>
		public void onMouseMove(object sender, MouseEventArgs e)
		{
			translate(e);
			if (movedSymbol == null)
			{
				selectDelete();
			}
			else
			{
				move();
			}
		}

        /// <summary>
        /// Thranslate mouse position to editor position
        /// </summary>
        /// <param name="e">The mouse even</param>
        private void translate(MouseEventArgs e)
        {
            imagePoint.X = e.X;
            imagePoint.Y = e.Y;
            imagePoint.X += invTransPoint.X;
            imagePoint.Y += invTransPoint.Y;
        }

        /// <summary>
        /// Mouse event handler in select/delete mode
        /// </summary>
        private void selectDelete()
        {
            newSymbol = choosenSymbol;
            if (newSymbol != oldSymbol)
            {
                DrawSymbol(newSymbol, false);
                DrawSymbol(oldSymbol, true);
                ShowSybmol(newSymbol);
                ShowSybmol(oldSymbol);
                oldSymbol = newSymbol;
            }
            newRemoveCursor = formula.GetRemovedSymbol(imagePoint);
            if (newRemoveCursor != oldRemoveCursor)
            {
                DrawCursor(oldRemoveCursor, false, false);
                DrawCursor(newRemoveCursor, true, false);
                oldRemoveCursor = newRemoveCursor;
            }
        }




		#endregion


        #region ControlWrapper class

        class ControlWrapper : IControl
        {
            #region Fields

            Control control;

            #endregion

            #region Ctor

            internal ControlWrapper(Control control)
            {
                this.control = control;
            }

            #endregion


            #region IControl Members

            Graphics IControl.Graphics
            {
                get { return Graphics.FromHwnd(control.Handle); }
            }

            #endregion
        }

        #endregion

    }


}