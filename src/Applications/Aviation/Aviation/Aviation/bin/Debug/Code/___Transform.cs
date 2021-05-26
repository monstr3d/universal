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
			var_1 = (double)measurement1.Parameter();
			var_2 = (var_0) * (var_1);
			var_3 = (double)aliasName3.Value;
			var_4 = (double)measurement4.Parameter();
			var_5 = (var_3) * (var_4);
			var_6 = (var_2) + (var_5);
			var_7 = (double)aliasName7.Value;
			var_8 = (double)measurement8.Parameter();
			var_9 = (var_7) * (var_8);
			var_10 = (var_6) + (var_9);
			var_11 = (double)aliasName11.Value;
			var_12 = (var_11) * (var_1);
			var_13 = (double)aliasName13.Value;
			var_14 = (var_13) * (var_4);
			var_15 = (var_12) + (var_14);
			var_16 = (double)aliasName16.Value;
			var_17 = (var_16) * (var_8);
			var_18 = (var_15) + (var_17);
			var_19 = (double)aliasName19.Value;
			var_20 = (var_19) * (var_1);
			var_21 = (double)aliasName21.Value;
			var_22 = (var_21) * (var_4);
			var_23 = (var_20) + (var_22);
			var_24 = (double)aliasName24.Value;
			var_25 = (var_24) * (var_8);
			var_26 = (var_23) + (var_25);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			aliasName3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[3]);
			measurement4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[4]);
			aliasName7 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[7]);
			measurement8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[8]);
			aliasName11 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[11]);
			aliasName13 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[13]);
			aliasName16 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[16]);
			aliasName19 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[19]);
			aliasName21 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[21]);
			aliasName24 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[24]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		Diagram.UI.Interfaces.IAliasName aliasName0;
		DataPerformer.Interfaces.IMeasurement measurement1;
		Diagram.UI.Interfaces.IAliasName aliasName3;
		DataPerformer.Interfaces.IMeasurement measurement4;
		Diagram.UI.Interfaces.IAliasName aliasName7;
		DataPerformer.Interfaces.IMeasurement measurement8;
		Diagram.UI.Interfaces.IAliasName aliasName11;
		Diagram.UI.Interfaces.IAliasName aliasName13;
		Diagram.UI.Interfaces.IAliasName aliasName16;
		Diagram.UI.Interfaces.IAliasName aliasName19;
		Diagram.UI.Interfaces.IAliasName aliasName21;
		Diagram.UI.Interfaces.IAliasName aliasName24;
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 0;
		double var_1 = 0;
		double var_2 = 0;
		double var_3 = 0;
		double var_4 = 0;
		double var_5 = 0;
		double var_6 = 0;
		double var_7 = 0;
		double var_8 = 0;
		double var_9 = 0;
		double var_10 = 0;
		double var_11 = 0;
		double var_12 = 0;
		double var_13 = 0;
		double var_14 = 0;
		double var_15 = 0;
		double var_16 = 0;
		double var_17 = 0;
		double var_18 = 0;
		double var_19 = 0;
		double var_20 = 0;
		double var_21 = 0;
		double var_22 = 0;
		double var_23 = 0;
		double var_24 = 0;
		double var_25 = 0;
		double var_26 = 0;
		
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

	}
}
