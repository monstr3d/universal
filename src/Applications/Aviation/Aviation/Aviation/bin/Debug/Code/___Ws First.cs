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
			var_1 = (double[])measurement1.Parameter();
			var_2 = (double)measurement2.Parameter();
			currentArray = treeArray_3;
			currentArray[0] = var_1;
			currentArray[1] = var_2;
			var_3 = (object[])trees[3].Calculate(currentArray);
			var_4 = (double)measurement4.Parameter();
			var_5 = (double[])measurement5.Parameter();
			var_6 = (double)measurement6.Parameter();
			currentArray = treeArray_7;
			currentArray[0] = var_5;
			currentArray[1] = var_6;
			var_7 = (object[])trees[7].Calculate(currentArray);
			currentArray = treeArray_8;
			currentArray[0] = var_4;
			currentArray[1] = var_7;
			var_8 = (object[])trees[8].Calculate(currentArray);
			currentArray = treeArray_9;
			currentArray[0] = var_3;
			currentArray[1] = var_8;
			var_9 = (object[])trees[9].Calculate(currentArray);
			currentArray = treeArray_10;
			currentArray[0] = var_0;
			currentArray[1] = var_9;
			var_10 = (object[])trees[10].Calculate(currentArray);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
			measurement4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[4]);
			measurement5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[5]);
			measurement6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[6]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		DataPerformer.Interfaces.IMeasurement measurement1;
		DataPerformer.Interfaces.IMeasurement measurement2;
		object[] treeArray_3 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement4;
		DataPerformer.Interfaces.IMeasurement measurement5;
		DataPerformer.Interfaces.IMeasurement measurement6;
		object[] treeArray_7 = new object[2];
		object[] treeArray_8 = new object[2];
		object[] treeArray_9 = new object[2];
		object[] treeArray_10 = new object[2];
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 0;
		double[] var_1 = new double[417];
		double var_2 = 0;
		object[] var_3 = new object[417];
		double var_4 = 0;
		double[] var_5 = new double[417];
		double var_6 = 0;
		object[] var_7 = new object[417];
		object[] var_8 = new object[417];
		object[] var_9 = new object[417];
		object[] var_10 = new object[417];
		
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

	}
}
