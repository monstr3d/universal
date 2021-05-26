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
			currentArray = treeArray_2;
			currentArray[0] = var_0;
			currentArray[1] = var_1;
			var_2 = (double[])trees[2].Calculate(currentArray);
			var_3 = (double)measurement3.Parameter();
			currentArray = treeArray_4;
			currentArray[0] = var_2;
			currentArray[1] = var_3;
			var_4 = (object[])trees[4].Calculate(currentArray);
			var_5 = (double[])measurement5.Parameter();
			currentArray = treeArray_6;
			currentArray[0] = var_0;
			currentArray[1] = var_5;
			var_6 = (double[])trees[6].Calculate(currentArray);
			var_7 = (double)measurement7.Parameter();
			currentArray = treeArray_8;
			currentArray[0] = var_6;
			currentArray[1] = var_7;
			var_8 = (object[])trees[8].Calculate(currentArray);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			measurement3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[3]);
			measurement5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[5]);
			measurement7 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[7]);
			dictionary[trees[0]] = Get_0;
			dictionary[trees[1]] = Get_1;
			dictionary[trees[2]] = Get_2;
			dictionary[trees[3]] = Get_3;
			dictionary[trees[4]] = Get_4;
			dictionary[trees[5]] = Get_5;
			dictionary[trees[6]] = Get_6;
			dictionary[trees[7]] = Get_7;
			dictionary[trees[8]] = Get_8;
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		DataPerformer.Interfaces.IMeasurement measurement1;
		object[] treeArray_2 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement3;
		object[] treeArray_4 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement5;
		object[] treeArray_6 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement7;
		object[] treeArray_8 = new object[2];
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		double var_0 = 0;
		double[] var_1 = new double[40];
		double[] var_2 = new double[40];
		double var_3 = 0;
		object[] var_4 = new object[40];
		double[] var_5 = new double[107];
		double[] var_6 = new double[107];
		double var_7 = 0;
		object[] var_8 = new object[107];
		
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

	}
}
