using System;
using System.Collections.Generic;
using System.Text;


namespace Calculation
{

	public class Calculate : FormulaEditor.Interfaces.ITreeCollectionProxy
	{

		
		public void Update()
		{
			var_0 = (double)measurement0.Parameter();
			var_1 = Math.Abs(var_0);
			var_2 = (double)measurement2.Parameter();
			var_4 = Math.Pow(var_2, var_3);
			var_6 = (double)aliasName6.Value;
			var_7 = (var_5) * (var_6);
			var_8 = (var_4) / (var_7);
			var_9 = (var_1) > (var_8);
			var_11 = (var_0) > (var_10);
			var_12 = (double)measurement12.Parameter();
			var_14 = (var_12) > (var_13);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
			aliasName6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[6]);
			measurement12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[12]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		DataPerformer.Interfaces.IMeasurement measurement2;
		Diagram.UI.Interfaces.IAliasName aliasName6;
		DataPerformer.Interfaces.IMeasurement measurement12;
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 0;
		double var_1 = 0;
		double var_2 = 0;
		double var_3 = 2;
		double var_4 = 0;
		double var_5 = 2;
		double var_6 = 0;
		double var_7 = 0;
		double var_8 = 0;
		bool var_9 = false;
		double var_10 = 0;
		bool var_11 = false;
		double var_12 = 0;
		double var_13 = 0;
		bool var_14 = false;
		
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

	}
}
