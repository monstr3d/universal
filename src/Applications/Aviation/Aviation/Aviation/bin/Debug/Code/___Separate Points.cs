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
			var_2 = (var_0) > (var_1);
			var_3 = (double)aliasName3.Value;
			var_4 = (var_3) > (var_1);
			var_5 = (double)aliasName5.Value;
			var_6 = (var_5) > (var_1);
			var_7 = (var_4) | (var_6);
			var_8 = (double)aliasName8.Value;
			var_9 = (var_8) > (var_1);
			var_10 = (var_7) | (var_9);
			var_11 = (double)aliasName11.Value;
			var_12 = (var_11) > (var_1);
			var_13 = (var_10) | (var_12);
			var_14 = (double)aliasName14.Value;
			var_15 = (var_14) > (var_1);
			var_16 = (var_13) | (var_15);
			var_17 = (double)aliasName17.Value;
			var_18 = (var_17) > (var_1);
			var_19 = (var_16) | (var_18);
			var_20 = (double)aliasName20.Value;
			var_21 = (var_20) > (var_1);
			var_22 = (var_19) | (var_21);
			var_23 = (double)aliasName23.Value;
			var_24 = (var_23) > (var_1);
			var_25 = (var_22) | (var_24);
			var_26 = (var_2) & (var_25);
			var_27 = (double)aliasName27.Value;
			var_29 = (var_26) ? (var_27) : (var_28);
			var_30 = (double)aliasName30.Value;
			var_31 = (double)aliasName31.Value;
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
			aliasName1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[1]);
			aliasName3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[3]);
			aliasName5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[5]);
			aliasName8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[8]);
			aliasName11 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[11]);
			aliasName14 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[14]);
			aliasName17 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[17]);
			aliasName20 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[20]);
			aliasName23 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[23]);
			aliasName27 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[27]);
			aliasName30 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[30]);
			aliasName31 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[31]);
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
			dictionary[trees[13]] = Get_13;
			dictionary[trees[14]] = Get_14;
			dictionary[trees[15]] = Get_15;
			dictionary[trees[16]] = Get_16;
			dictionary[trees[17]] = Get_17;
			dictionary[trees[18]] = Get_18;
			dictionary[trees[19]] = Get_19;
			dictionary[trees[20]] = Get_20;
			dictionary[trees[21]] = Get_21;
			dictionary[trees[22]] = Get_22;
			dictionary[trees[23]] = Get_23;
			dictionary[trees[24]] = Get_24;
			dictionary[trees[25]] = Get_25;
			dictionary[trees[26]] = Get_26;
			dictionary[trees[27]] = Get_27;
			dictionary[trees[28]] = Get_28;
			dictionary[trees[29]] = Get_29;
			dictionary[trees[30]] = Get_30;
			dictionary[trees[31]] = Get_31;
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		Diagram.UI.Interfaces.IAliasName aliasName0;
		Diagram.UI.Interfaces.IAliasName aliasName1;
		Diagram.UI.Interfaces.IAliasName aliasName3;
		Diagram.UI.Interfaces.IAliasName aliasName5;
		Diagram.UI.Interfaces.IAliasName aliasName8;
		Diagram.UI.Interfaces.IAliasName aliasName11;
		Diagram.UI.Interfaces.IAliasName aliasName14;
		Diagram.UI.Interfaces.IAliasName aliasName17;
		Diagram.UI.Interfaces.IAliasName aliasName20;
		Diagram.UI.Interfaces.IAliasName aliasName23;
		Diagram.UI.Interfaces.IAliasName aliasName27;
		Diagram.UI.Interfaces.IAliasName aliasName30;
		Diagram.UI.Interfaces.IAliasName aliasName31;
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 0;
		double var_1 = 0;
		bool var_2 = false;
		double var_3 = 0;
		bool var_4 = false;
		double var_5 = 0;
		bool var_6 = false;
		bool var_7 = false;
		double var_8 = 0;
		bool var_9 = false;
		bool var_10 = false;
		double var_11 = 0;
		bool var_12 = false;
		bool var_13 = false;
		double var_14 = 0;
		bool var_15 = false;
		bool var_16 = false;
		double var_17 = 0;
		bool var_18 = false;
		bool var_19 = false;
		double var_20 = 0;
		bool var_21 = false;
		bool var_22 = false;
		double var_23 = 0;
		bool var_24 = false;
		bool var_25 = false;
		bool var_26 = false;
		double var_27 = 0;
		double var_28 = 0;
		double var_29 = 0;
		double var_30 = 0;
		double var_31 = 0;
		
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
		
		object Get_13()
		{
			return var_13;
		}
		
		object Get_14()
		{
			return var_14;
		}
		
		object Get_15()
		{
			return var_15;
		}
		
		object Get_16()
		{
			return var_16;
		}
		
		object Get_17()
		{
			return var_17;
		}
		
		object Get_18()
		{
			return var_18;
		}
		
		object Get_19()
		{
			return var_19;
		}
		
		object Get_20()
		{
			return var_20;
		}
		
		object Get_21()
		{
			return var_21;
		}
		
		object Get_22()
		{
			return var_22;
		}
		
		object Get_23()
		{
			return var_23;
		}
		
		object Get_24()
		{
			return var_24;
		}
		
		object Get_25()
		{
			return var_25;
		}
		
		object Get_26()
		{
			return var_26;
		}
		
		object Get_27()
		{
			return var_27;
		}
		
		object Get_28()
		{
			return var_28;
		}
		
		object Get_29()
		{
			return var_29;
		}
		
		object Get_30()
		{
			return var_30;
		}
		
		object Get_31()
		{
			return var_31;
		}

	}
}
