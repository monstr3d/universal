using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;


using CategoryTheory;
using Diagram.UI;
using Diagram.UI.Interfaces;


using FormulaEditor;

using BitmapConsumer;

namespace ImageTransformations
{
	/// <summary>
	/// Transformer of colors
	/// </summary>
	[Serializable()]
	public class ColorTransformer : CategoryObject, ISerializable, 
        IBitmapProvider, IBitmapConsumer, IAlias, IRemovableObject
	{
		#region Fields

		private string[] formulaStrings = new string[]{"", "", ""}; 
		private MathFormula[] formulas = new MathFormula[3]; 
		private ObjectFormulaTree[] trees = new ObjectFormulaTree[3];
		private ElementaryObjectArgument arg = new ElementaryObjectArgument();
		private Bitmap bitmap;
		private Hashtable aliases = new Hashtable();
		private byte[] comments;
        /// <summary>
        /// Add remove event
        /// </summary>
        event Action<IBitmapProvider, bool> addRemove =
            (IBitmapProvider p, bool b) => { };
 
		
		/// <summary>
		/// Provider
		/// </summary>
		private IBitmapProvider provider;

        /// <summary>
        /// Change alias event
        /// </summary>
        event Action<IAlias, string> onChange = (IAlias a, string name) => { };

		#endregion

		#region Constructors

		public ColorTransformer()
		{
		}

		public ColorTransformer(SerializationInfo info, StreamingContext context)
		{
			formulaStrings = info.GetValue("Formulas", typeof(string[])) as string[];
			comments = (byte[]) info.GetValue("Comments", typeof(byte[]));
			init();
		}

        ~ColorTransformer()
        {
            IRemovableObject r = this;
            r.RemoveObject();
        }


		#endregion

		#region ISerializable Members

		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Formulas", formulaStrings);
            if (comments != null)
            {
                info.AddValue("Comments", comments);
            }
		}

		#endregion

		#region IBitmapProvider Members

		public Bitmap Bitmap
		{
			get
			{
				return bitmap;
			}
		}

		#endregion

		#region IBitmapConsumer Members

		public void Process()
		{
			if (provider == null)
			{
				return;
			}
			if (provider.Bitmap == null)
			{
				return;
			}
			Bitmap bmp = provider.Bitmap;
			if (bitmap == null)
			{
				bitmap = new Bitmap(bmp.Width, bmp.Height);
			}
			else if ((bitmap.Width != bmp.Width) | (bitmap.Height != bmp.Height))
			{
				bitmap = new Bitmap(bmp.Width, bmp.Height);
			}
			byte[] res = new byte[]{0xFF, 0, 0, 0};
			foreach (object o in aliases.Keys)
			{
				arg[o] = aliases[o];
			}
			for (int i = 0; i < bmp.Width; i++)
			{
				for (int j = 0; j < bmp.Height; j++)
				{
					Color c = bmp.GetPixel(i, j);
					double r = (double) c.R;
					double g = (double) c.B;
					double b = (double) c.G;
					try
					{
						arg['r'] = r;
					}
					catch (Exception ex)
					{
                        ex.ShowError(10);
                    }
					try
					{
						arg['g'] = g;
					}
					catch (Exception exc)
					{
                        exc.ShowError(10);
                    }
					try
					{
						arg['b'] = b;
					}
					catch (Exception exce)
					{
                        exce.ShowError(10);
                    }
					try
					{
						arg['x'] = (double) i;
					}
					catch (Exception excep)
					{
                        excep.ShowError(10);
                    }
					try
					{
						arg['y'] = (double) j;
					}
                    catch (Exception except)
					{
                        except.ShowError(10);
					}
					for (int k = 0; k < 3; k++)
					{
						double a = (double) trees[k].Result;
						if (a < 0)
						{
							a = 0;
						}
						if (a > 255)
						{
							a = 255;
						}
						res[k + 1] = (byte) a;
						Color col = Color.FromArgb(res[1], res[2], res[3]);
						bitmap.SetPixel(i, j, col);
					}
				}
			}
		}

         /// <summary>
        /// Providers
        /// </summary>
        IEnumerable<IBitmapProvider> IBitmapConsumer.Providers
        {
            get
            {
                if (provider != null)
                {
                    yield return provider;
                }
            }
        }

        /// <summary>
        /// Adds a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Add(IBitmapProvider provider)
        {
            this.provider = provider;
        }

        /// <summary>
        /// Removes a provider
        /// </summary>
        /// <param name="provider">The provider</param>
        void IBitmapConsumer.Remove(IBitmapProvider provider)
        {
            this.provider = null;
        }

        /// <summary>
        /// Add remove event of provider. If "bool" is true then adding
        /// </summary>
        event Action<IBitmapProvider, bool> IBitmapConsumer.AddRemove
        {
            add { addRemove += value; }
            remove { addRemove -= value; }
        }

		#endregion

		#region IAlias Members

		public IList<string> AliasNames
		{
			get
			{
                List<string> l = new List<string>();
				foreach (char c in aliases.Keys)
				{
					l.Add(c + "");
				}
				return l;
			}
		}

		public object this[string alias]
		{
			get
			{
				return aliases[alias[0]];
			}
			set
			{
				aliases[alias[0]] = value;
			}
		}

        public object GetType(string name)
        {
            Double a = 0;
            return a;
        }

        event Action<IAlias, string> IAlias.OnChange
        {
            add { onChange += value; }
            remove { onChange -= value; }
        }

        #endregion

        #region IRemovableObject Members

        void IRemovableObject.RemoveObject()
        {
            if (bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
        }

        #endregion

        #region Specific Members



		public string[] Formulas
		{
			get
			{
				return formulaStrings;
			}
			set
			{
				if (value.Length != 3)
				{
					throw new Exception("You should use three formulas");
				}
				formulaStrings = value;
				init();
				setAliases();
			}
		}

		private void init()
		{
			arg.Clear(); 
			for (int i = 0; i < 3; i++)
			{
				MathFormula f = MathFormula.FromString(MathSymbolFactory.Sizes, formulaStrings[i]);
				formulas[i] = f;
				f = f.FullTransform(null);
				ObjectFormulaTree t = ObjectFormulaTree.CreateTree(f);
				trees[i] = t;
				arg.Add(t);
			}
		}

		private void setAliases()
		{
			aliases.Clear();
			string s = arg.Variables;
			double a = 0;
			foreach (char c in s)
			{
				if ((c == 'r') | (c == 'g') | (c == 'b') | (c == 'x') | (c == 'y'))
				{
					continue;
				}
				aliases[c] = a;
			}
		}


		#endregion

    }

}
