using System;
using System.Collections.Generic;
using System.Text;


namespace Calculation
{

	public class Calculate : FormulaEditor.Interfaces.ITreeCollectionProxy
	{

		
		public void Update()
		{
			var_1 = (double)measurement1.Parameter();
			var_3 = Math.Pow(var_1, var_2);
			var_4 = (var_0) - (var_3);
			var_5 = Math.Sqrt(var_4);
			var_7 = (double)measurement7.Parameter();
			var_9 = Math.Pow(var_7, var_8);
			var_10 = (var_6) - (var_9);
			var_11 = Math.Sqrt(var_10);
			var_13 = (double)measurement13.Parameter();
			var_15 = Math.Pow(var_13, var_14);
			var_16 = (var_12) - (var_15);
			var_17 = Math.Sqrt(var_16);
			var_19 = (double)measurement19.Parameter();
			var_21 = Math.Pow(var_19, var_20);
			var_22 = (var_18) - (var_21);
			var_23 = Math.Sqrt(var_22);
			var_25 = (double)measurement25.Parameter();
			var_27 = Math.Pow(var_25, var_26);
			var_28 = (var_24) - (var_27);
			var_29 = Math.Sqrt(var_28);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			measurement7 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[7]);
			measurement13 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[13]);
			measurement19 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[19]);
			measurement25 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[25]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement1;
		DataPerformer.Interfaces.IMeasurement measurement7;
		DataPerformer.Interfaces.IMeasurement measurement13;
		DataPerformer.Interfaces.IMeasurement measurement19;
		DataPerformer.Interfaces.IMeasurement measurement25;
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 1;
		double var_1 = 0;
		double var_2 = 2;
		double var_3 = 0;
		double var_4 = 0;
		double var_5 = 0;
		double var_6 = 1;
		double var_7 = 0;
		double var_8 = 2;
		double var_9 = 0;
		double var_10 = 0;
		double var_11 = 0;
		double var_12 = 1;
		double var_13 = 0;
		double var_14 = 2;
		double var_15 = 0;
		double var_16 = 0;
		double var_17 = 0;
		double var_18 = 1;
		double var_19 = 0;
		double var_20 = 2;
		double var_21 = 0;
		double var_22 = 0;
		double var_23 = 0;
		double var_24 = 1;
		double var_25 = 0;
		double var_26 = 2;
		double var_27 = 0;
		double var_28 = 0;
		double var_29 = 0;
		
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

	}
}
