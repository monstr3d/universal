using System;

using FormulaEditor.Interfaces;

namespace FormulaEditor
{
	
    /// <summary>
    /// Simplification of formula
    /// </summary>
	public class FormulaSimplification : IFormulaSimplification
	{
		
		
		#region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
		protected FormulaSimplification()
		{
		}

		#endregion
		
		#region IFormulaSimplification Members

        /// <summary>
        /// Simplfies tree
        /// </summary>
        /// <param name="tree">Simplfied tree</param>
        /// <returns>Simplfication result</returns>
        public virtual ObjectFormulaTree Simplify(ObjectFormulaTree tree)
		{
			return tree;
		}

		#endregion

		#region Specific Members

        /// <summary>
        /// Composes simplifications
        /// </summary>
        /// <param name="f">First simplification</param>
        /// <param name="g">Second simplification</param>
        /// <returns>Composition</returns>
		static public FormulaSimplification operator * (FormulaSimplification f, IFormulaSimplification g)
		{
			return Compose(f, g);
		}

        /// <summary>
        /// Composes simplifications
        /// </summary>
        /// <param name="f">First simplification</param>
        /// <param name="g">Second simplification</param>
        /// <returns>Composition</returns>
        static public FormulaSimplification Compose(IFormulaSimplification f, IFormulaSimplification g)
		{
			return new FormulaSimplificationComposition(g, f);
		}

		#endregion
	}

    /// <summary>
    /// Simplification composition
    /// </summary>
	public class FormulaSimplificationComposition : FormulaSimplification
	{
		
		private IFormulaSimplification first;
		private IFormulaSimplification next;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="first">First simplification</param>
        /// <param name="next">Next simplification</param>
		public FormulaSimplificationComposition(IFormulaSimplification first, IFormulaSimplification next)
		{
			this.first = first;
			this.next = next;
		}
		
		#region IFormulaSimplification Members

        /// <summary>
        /// Simplfies tree
        /// </summary>
        /// <param name="tree">Simplfied tree</param>
        /// <returns>Simplfication result</returns>
        public override ObjectFormulaTree Simplify(ObjectFormulaTree tree)
		{
			ObjectFormulaTree t = first.Simplify(tree);
			return next.Simplify(t);
		}

		#endregion
	}
}
