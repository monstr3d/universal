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
			currentArray = treeArray_1;
			currentArray[0] = var_0;
			var_1 = (object[])trees[1].Calculate(currentArray);
			var_2 = (object[])measurement2.Parameter();
			currentArray = treeArray_3;
			currentArray[0] = var_1;
			currentArray[1] = var_2;
			var_3 = (object[])trees[3].Calculate(currentArray);
			currentArray = treeArray_4;
			currentArray[0] = var_0;
			var_4 = (object[])trees[4].Calculate(currentArray);
			var_5 = (object[])measurement5.Parameter();
			currentArray = treeArray_6;
			currentArray[0] = var_4;
			currentArray[1] = var_5;
			var_6 = (object[])trees[6].Calculate(currentArray);
			currentArray = treeArray_7;
			currentArray[0] = var_0;
			var_7 = (object[])trees[7].Calculate(currentArray);
			var_8 = (object[])measurement8.Parameter();
			currentArray = treeArray_9;
			currentArray[0] = var_7;
			currentArray[1] = var_8;
			var_9 = (object[])trees[9].Calculate(currentArray);
			var_10 = (object[])measurement10.Parameter();
			currentArray = treeArray_11;
			currentArray[0] = var_10;
			var_11 = (object[])trees[11].Calculate(currentArray);
			var_12 = (object[])measurement12.Parameter();
			currentArray = treeArray_13;
			currentArray[0] = var_11;
			currentArray[1] = var_12;
			var_13 = (object[])trees[13].Calculate(currentArray);
			currentArray = treeArray_14;
			currentArray[0] = var_10;
			var_14 = (object[])trees[14].Calculate(currentArray);
			var_15 = (object[])measurement15.Parameter();
			currentArray = treeArray_16;
			currentArray[0] = var_14;
			currentArray[1] = var_15;
			var_16 = (object[])trees[16].Calculate(currentArray);
			currentArray = treeArray_17;
			currentArray[0] = var_10;
			var_17 = (object[])trees[17].Calculate(currentArray);
			var_18 = (object[])measurement18.Parameter();
			currentArray = treeArray_19;
			currentArray[0] = var_17;
			currentArray[1] = var_18;
			var_19 = (object[])trees[19].Calculate(currentArray);
			currentArray = treeArray_20;
			currentArray[0] = var_10;
			var_20 = (object[])trees[20].Calculate(currentArray);
			currentArray = treeArray_21;
			currentArray[0] = var_10;
			var_21 = (object[])trees[21].Calculate(currentArray);
			currentArray = treeArray_22;
			currentArray[0] = var_10;
			var_22 = (object[])trees[22].Calculate(currentArray);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
			measurement5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[5]);
			measurement8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[8]);
			measurement10 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[10]);
			measurement12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[12]);
			measurement15 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[15]);
			measurement18 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[18]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		object[] treeArray_1 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement2;
		object[] treeArray_3 = new object[2];
		object[] treeArray_4 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement5;
		object[] treeArray_6 = new object[2];
		object[] treeArray_7 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement8;
		object[] treeArray_9 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement10;
		object[] treeArray_11 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement12;
		object[] treeArray_13 = new object[2];
		object[] treeArray_14 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement15;
		object[] treeArray_16 = new object[2];
		object[] treeArray_17 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement18;
		object[] treeArray_19 = new object[2];
		object[] treeArray_20 = new object[1];
		object[] treeArray_21 = new object[1];
		object[] treeArray_22 = new object[1];
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
		object[] var_20 = new object[790];
		object[] var_21 = new object[790];
		object[] var_22 = new object[790];
		
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

	}
}
