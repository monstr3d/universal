using System;
using System.Collections.Generic;
using System.Text;


namespace Calculation
{

	public class Calculate : FormulaEditor.Interfaces.ITreeCollectionProxy
	{

		
		public void Update()
		{
			var_0 = (object[])measurement0.Parameter();
			var_1 = (object[])measurement1.Parameter();
			currentArray = treeArray_2;
			currentArray[0] = var_1;
			var_2 = (object[])trees[2].Calculate(currentArray);
			currentArray = treeArray_3;
			currentArray[0] = var_0;
			currentArray[1] = var_2;
			var_3 = (object[])trees[3].Calculate(currentArray);
			var_4 = (object[])measurement4.Parameter();
			currentArray = treeArray_5;
			currentArray[0] = var_1;
			var_5 = (object[])trees[5].Calculate(currentArray);
			currentArray = treeArray_6;
			currentArray[0] = var_4;
			currentArray[1] = var_5;
			var_6 = (object[])trees[6].Calculate(currentArray);
			var_7 = (object[])measurement7.Parameter();
			currentArray = treeArray_8;
			currentArray[0] = var_1;
			var_8 = (object[])trees[8].Calculate(currentArray);
			currentArray = treeArray_9;
			currentArray[0] = var_7;
			currentArray[1] = var_8;
			var_9 = (object[])trees[9].Calculate(currentArray);
			var_10 = (object[])measurement10.Parameter();
			var_11 = (object[])measurement11.Parameter();
			currentArray = treeArray_12;
			currentArray[0] = var_11;
			var_12 = (object[])trees[12].Calculate(currentArray);
			currentArray = treeArray_13;
			currentArray[0] = var_10;
			currentArray[1] = var_12;
			var_13 = (object[])trees[13].Calculate(currentArray);
			var_14 = (object[])measurement14.Parameter();
			currentArray = treeArray_15;
			currentArray[0] = var_11;
			var_15 = (object[])trees[15].Calculate(currentArray);
			currentArray = treeArray_16;
			currentArray[0] = var_14;
			currentArray[1] = var_15;
			var_16 = (object[])trees[16].Calculate(currentArray);
			var_17 = (object[])measurement17.Parameter();
			currentArray = treeArray_18;
			currentArray[0] = var_11;
			var_18 = (object[])trees[18].Calculate(currentArray);
			currentArray = treeArray_19;
			currentArray[0] = var_17;
			currentArray[1] = var_18;
			var_19 = (object[])trees[19].Calculate(currentArray);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			measurement4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[4]);
			measurement7 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[7]);
			measurement10 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[10]);
			measurement11 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[11]);
			measurement14 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[14]);
			measurement17 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[17]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		DataPerformer.Interfaces.IMeasurement measurement1;
		object[] treeArray_2 = new object[1];
		object[] treeArray_3 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement4;
		object[] treeArray_5 = new object[1];
		object[] treeArray_6 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement7;
		object[] treeArray_8 = new object[1];
		object[] treeArray_9 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement10;
		DataPerformer.Interfaces.IMeasurement measurement11;
		object[] treeArray_12 = new object[1];
		object[] treeArray_13 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement14;
		object[] treeArray_15 = new object[1];
		object[] treeArray_16 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement17;
		object[] treeArray_18 = new object[1];
		object[] treeArray_19 = new object[2];
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		object[] var_0 = new object[790];
		object[] var_1 = new object[790];
		object[] var_2 = new object[790];
		object[] var_3 = new object[790];
		object[] var_4 = new object[790];
		object[] var_5 = new object[790];
		object[] var_6 = new object[790];
		object[] var_7 = new object[790];
		object[] var_8 = new object[790];
		object[] var_9 = new object[790];
		object[] var_10 = new object[790];
		object[] var_11 = new object[790];
		object[] var_12 = new object[790];
		object[] var_13 = new object[790];
		object[] var_14 = new object[790];
		object[] var_15 = new object[790];
		object[] var_16 = new object[790];
		object[] var_17 = new object[790];
		object[] var_18 = new object[790];
		object[] var_19 = new object[790];
		
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

	}
}
