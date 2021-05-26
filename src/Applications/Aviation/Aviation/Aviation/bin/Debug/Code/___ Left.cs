using System;
using System.Collections.Generic;
using System.Text;


namespace Calculation
{

	public class Calculate : FormulaEditor.Interfaces.ITreeCollectionProxy
	{

		
		public void Update()
		{
			var_0 = (double)aliasName0.Value;
			var_1 = (double)aliasName1.Value;
			var_2 = (var_0) < (var_1);
			var_3 = (double)aliasName3.Value;
			var_4 = (double)aliasName4.Value;
			var_5 = (var_3) > (var_4);
			var_6 = (var_2) & (var_5);
			var_9 = (var_6) ? (var_7) : (var_8);
			var_10 = (double)aliasName10.Value;
			var_11 = (double)aliasName11.Value;
			var_12 = (double)aliasName12.Value;
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
			aliasName1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[1]);
			aliasName3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[3]);
			aliasName4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[4]);
			aliasName10 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[10]);
			aliasName11 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[11]);
			aliasName12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[12]);
			dictionary[trees[0]] = Get_0;
			dictionary[trees[1]] = Get_1;
			dictionary[trees[2]] = Get_2;
			dictionary[trees[3]] = Get_3;
			dictionary[trees[4]] = Get_4;
			dictionary[trees[5]] = Get_5;
			dictionary[trees[6]] = Get_6;
			dictionary[trees[7]] = Get_7;
			dictionary[trees[8]] = Get_8;
			dictionary[trees[9]] = Get_9;
			dictionary[trees[10]] = Get_10;
			dictionary[trees[11]] = Get_11;
			dictionary[trees[12]] = Get_12;
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		Diagram.UI.Interfaces.IAliasName aliasName0;
		Diagram.UI.Interfaces.IAliasName aliasName1;
		Diagram.UI.Interfaces.IAliasName aliasName3;
		Diagram.UI.Interfaces.IAliasName aliasName4;
		Diagram.UI.Interfaces.IAliasName aliasName10;
		Diagram.UI.Interfaces.IAliasName aliasName11;
		Diagram.UI.Interfaces.IAliasName aliasName12;
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 0;
		double var_1 = 0;
		bool var_2 = false;
		double var_3 = 0;
		double var_4 = 0;
		bool var_5 = false;
		bool var_6 = false;
		double var_7 = 0;
		double var_8 = 1;
		double var_9 = 0;
		double var_10 = 0;
		double var_11 = 0;
		double var_12 = 0;
		
		object Get_0()
		{
			return var_0;
		}
		
		object Get_1()
		{
			return var_1;
		}
		
		object Get_2()
		{
			return var_2;
		}
		
		object Get_3()
		{
			return var_3;
		}
		
		object Get_4()
		{
			return var_4;
		}
		
		object Get_5()
		{
			return var_5;
		}
		
		object Get_6()
		{
			return var_6;
		}
		
		object Get_7()
		{
			return var_7;
		}
		
		object Get_8()
		{
			return var_8;
		}
		
		object Get_9()
		{
			return var_9;
		}
		
		object Get_10()
		{
			return var_10;
		}
		
		object Get_11()
		{
			return var_11;
		}
		
		object Get_12()
		{
			return var_12;
		}

	}
}
