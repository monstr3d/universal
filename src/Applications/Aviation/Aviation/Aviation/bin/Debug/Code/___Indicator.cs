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
			var_1 = (double)measurement1.Parameter();
			var_2 = (double)measurement2.Parameter();
			var_3 = (double)measurement3.Parameter();
			var_4 = (var_2) * (var_3);
			var_5 = (double)measurement5.Parameter();
			var_6 = (var_4) + (var_5);
			var_7 = Math.Sin(var_6);
			var_8 = (var_1) * (var_7);
			var_9 = (var_0) + (var_8);
			var_10 = (double)measurement10.Parameter();
			var_11 = (double)measurement11.Parameter();
			var_12 = (var_2) * (var_3);
			var_13 = (double)measurement13.Parameter();
			var_14 = (var_12) + (var_13);
			var_15 = Math.Sin(var_14);
			var_16 = (var_11) * (var_15);
			var_17 = (var_10) + (var_16);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
			measurement3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[3]);
			measurement5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[5]);
			measurement10 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[10]);
			measurement11 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[11]);
			measurement13 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[13]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		DataPerformer.Interfaces.IMeasurement measurement1;
		DataPerformer.Interfaces.IMeasurement measurement2;
		DataPerformer.Interfaces.IMeasurement measurement3;
		DataPerformer.Interfaces.IMeasurement measurement5;
		DataPerformer.Interfaces.IMeasurement measurement10;
		DataPerformer.Interfaces.IMeasurement measurement11;
		DataPerformer.Interfaces.IMeasurement measurement13;
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

	}
}
