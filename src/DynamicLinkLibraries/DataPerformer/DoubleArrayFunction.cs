using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Xml;


using CategoryTheory;
using Diagram.UI;
using BaseTypes;
using BaseTypes.Interfaces;


using GeneralLinearMethod;

using FormulaEditor;
using FormulaEditor.Interfaces;


namespace DataPerformer
{
	/// <summary>
	/// Function of double array.
	/// </summary>
	[Serializable()]
    public class DoubleArrayFunction : CategoryObject, ISerializable, IObjectOperation, IPowered, IOperationAcceptor, IPostSetArrow
	{
		
		#region Fields
		
		private static readonly Double a = 0;
		private object returnType = null;
		private Hashtable table = new Hashtable();
		private ArrayList arg = new ArrayList();
		private int[][] ranks;
		private int[] rank;
		private object[][] yy;
		private double step = 0;
		private double begin;
        private object[] y;

		
		#endregion

		#region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type">Type of element</param>
		public DoubleArrayFunction(object type)
		{
			if (type == null)
			{
				return;
			}
			returnType = type;
			init();
		}

        /// <summary>
        /// Deserialization constructor
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public DoubleArrayFunction(SerializationInfo info, StreamingContext context)
		{
			returnType = info.GetValue("Type", typeof(object));
			table = info.GetValue("Table", typeof(Hashtable)) as Hashtable;
			init();
		}

		#endregion

		#region ISerializable Members

        /// <summary>
        /// ISerializable interface implementation
        /// </summary>
        /// <param name="info">Serialization info</param>
        /// <param name="context">Streaming context</param>
        public void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("Type", returnType);
			info.AddValue("Table", table);
		}

		#endregion

		#region IObjectOperation Members

        /// <summary>
        /// Calculates result of this operation
        /// </summary>
        public object this[object[] x]
		{
			get
			{
				double a = (double) x[0];
				return this[a];
			}
		}

        /// <summary>
        /// Return type
        /// </summary>
        public object ReturnType
		{
			get
			{
				return returnType;
			}
		}

        object[] IObjectOperation.InputTypes
        {
            get { return new object[]{(double)0}; }
        }

        /// <summary>
        /// The "is powered" sign
        /// </summary>
        bool IPowered.IsPowered
		{
			get
			{
				return true;
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
			if (type.Equals(a))
			{
				return this;
			}
			return null;
		}

		#endregion

		#region IPostSetArrow Members

        /// <summary>
        /// The operation that performs after arrows setting
        /// </summary>
        public void PostSetArrow()
		{
			arg = new ArrayList(table.Keys);
			arg.Sort();
			begin = (double) arg[0];
			double b = (double) arg[1];
			step = b - begin;
			for (int i = 2; i < arg.Count; i++)
			{
				double c = (double) arg[i];
				if (Math.Abs((c - b) - step) > (0.0000000000001 * step))
				{
					step = 0;
					return;
				}
				b = c;
			}
		}

		#endregion

		#region Specific Members
		
        /// <summary>
        /// Calculation
        /// </summary>
        /// <param name="x">Argument</param>
        /// <returns>Calculation result</returns>
		public object this[double x]
		{
			get
			{
				double a = begin;
				if (x < a)
				{
					return table[a];
				}
				if (step != 0)
				{
					int n = (int) ((x - begin) / step);
					if (n >= arg.Count)
					{
						return table[arg[arg.Count - 1]];
					}
					double c = (double) arg[n];
					return table[c];
				}
				foreach (double b in arg)
				{
					if (b >= x)
					{
						return table[b];
					}
				}
				return table[arg[arg.Count - 1]];
			}
			set
			{
				object[] o = newArray;
				setObject(value, o);
				table[x] = o;
			}
		}

		private object[] newArray
		{
			get
			{
				return createArray(returnType as object[]);
			}
		}

		private object[] createArray(object[] o)
		{
			object[] ob = new object[o.Length];
			if (o[0] is object[])
			{
				for (int i = 0; i < o.Length; i++)
				{
					ob[i] = createArray(o[i] as object[]);
				}
				return ob;
			}
			double x = 0;
			for (int i = 0; i < o.Length; i++)
			{
				ob[i] = x;
			}
			return ob;
		}

		private void setObject(object o1, object o2)
		{
			object[] ob1 = o1 as object[];
			object[] ob2 = o2 as object[];
			if (!(ob1[0] is object[]))
			{
				for (int i = 0; i < ob1.Length; i++)
				{
					ob2[i] = ob1[i];
				}
				return;
			}
			for (int i = 0; i < ob1.Length; i++)
			{
				setObject(ob1[i], ob2[i]);
			}
		}

		private void init()
		{
			ArrayOperation.CreateAllArrays(this, new object[]{a}, out y, out yy, out rank, out ranks);
            returnType = new ArrayReturnType(a, rank, true);
		}

		#endregion

	}
}
