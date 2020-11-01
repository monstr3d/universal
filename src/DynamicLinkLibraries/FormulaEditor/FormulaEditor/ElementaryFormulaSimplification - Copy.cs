using System;
using System.Collections;
using System.Collections.Generic;

using BaseTypes.Interfaces;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
	/// <summary>
	/// Summary description for ElementaryFormulaSimplification.
	/// </summary>
	public class ElementaryFormulaSimplification : FormulaSimplification
	{
		//private IFormulaCreatorOperation creator;

		private static readonly Double a = 0;

        /// <summary>
        /// Singleton
        /// </summary>
        public static readonly ElementaryFormulaSimplification Object = new ElementaryFormulaSimplification();

		private ElementaryFormulaSimplification()
		{
			//this.creator = creator;
		}
		
		#region IFormulaSimplification Members

        /// <summary>
        /// Simplfies tree
        /// </summary>
        /// <param name="tree">Simplfied tree</param>
        /// <returns>Simplfication result</returns>
        public override ObjectFormulaTree Simplify(ObjectFormulaTree tree)
		{
            ObjectFormulaTree t = tree;//.Clone() as ObjectFormulaTree;
            t = simplify(t);
            t = PolyMult.MultMult(t);
            t = simplify(t);
			return PolyMult.MultMultReverse(t);
		}




		#endregion



        private ObjectFormulaTree simplify(ObjectFormulaTree tree)
        {
            ObjectFormulaTree t = tree;
            while (true)
            {
                bool b;
                t = PolyMult.simplify(t, out b);
                t = PolySum.Simplify(t, ref b);
                if (b)
                {
                    break;
                }
            }
            return t;
        }

        /// <summary>
        /// Checks whether tree is const
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>True in case of const and false otherwise</returns>
		public static bool IsConst(ObjectFormulaTree tree)
		{
			for (int i = 0; i < tree.Count; i++)
			{
				if (!IsConst(tree[i]))
				{
					return false;
				}
			}
			IObjectOperation op = tree.Operation;
			if (op is ElementaryRealConstant)
			{
				return true;
			}
			return false;
		}

        /// <summary>
        /// Gets conditional value of tree
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <returns>Conditional value</returns>
		public static object GetValue(ObjectFormulaTree tree)
		{
			if (!IsConst(tree))
			{
				return null;
			}
			return tree.Result;
		}

        /// <summary>
        /// Simplifies constants
        /// </summary>
        /// <param name="tree">The tree</param>
        /// <param name="completed">The "completed" sign</param>
        /// <returns>Simplified tree</returns>
		public static ObjectFormulaTree SimplifyContstants(ObjectFormulaTree tree, out bool completed)
		{
			bool comp = true;
			completed = true;
			if (IsConst(tree))
			{
				if (tree.Operation is ElementaryRealConstant)
				{
					completed = true;
					return tree;
				}
				if (tree.ReturnType.Equals(a))
				{
					ElementaryRealConstant x = new ElementaryRealConstant((double) tree.Result);
					completed = false;
					return new ObjectFormulaTree(x, new List<ObjectFormulaTree>());
				}
			}
			List<ObjectFormulaTree> l = new List<ObjectFormulaTree>();
			for (int i = 0; i < tree.Count; i++)
			{
				ObjectFormulaTree t = SimplifyContstants(tree[i], out comp);
				if (!comp)
				{
					completed = false;
				}
				l.Add(t);
			}
			return new ObjectFormulaTree(tree.Operation, l);
		}
	}

}
