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
			currentArray = treeArray_3;
			currentArray[0] = var_1;
			currentArray[1] = var_2;
			var_3 = (object[])trees[3].Calculate(currentArray);
			var_4 = (object[])measurement4.Parameter();
			currentArray = treeArray_6;
			currentArray[0] = var_4;
			currentArray[1] = var_5;
			var_6 = (object[])trees[6].Calculate(currentArray);
			currentArray = treeArray_7;
			currentArray[0] = var_3;
			currentArray[1] = var_6;
			var_7 = (object[])trees[7].Calculate(currentArray);
			var_8 = (object[])measurement8.Parameter();
			currentArray = treeArray_10;
			currentArray[0] = var_8;
			currentArray[1] = var_9;
			var_10 = (object[])trees[10].Calculate(currentArray);
			currentArray = treeArray_11;
			currentArray[0] = var_7;
			currentArray[1] = var_10;
			var_11 = (object[])trees[11].Calculate(currentArray);
			currentArray = treeArray_12;
			currentArray[0] = var_11;
			var_12 = (object[])trees[12].Calculate(currentArray);
			var_13 = (double)aliasName13.Value;
			currentArray = treeArray_14;
			currentArray[0] = var_12;
			currentArray[1] = var_13;
			var_14 = (object[])trees[14].Calculate(currentArray);
			currentArray = treeArray_15;
			currentArray[0] = var_0;
			currentArray[1] = var_14;
			var_15 = (object[])trees[15].Calculate(currentArray);
			var_16 = (object[])measurement16.Parameter();
			var_17 = (object[])measurement17.Parameter();
			currentArray = treeArray_19;
			currentArray[0] = var_17;
			currentArray[1] = var_18;
			var_19 = (object[])trees[19].Calculate(currentArray);
			var_20 = (object[])measurement20.Parameter();
			currentArray = treeArray_22;
			currentArray[0] = var_20;
			currentArray[1] = var_21;
			var_22 = (object[])trees[22].Calculate(currentArray);
			currentArray = treeArray_23;
			currentArray[0] = var_19;
			currentArray[1] = var_22;
			var_23 = (object[])trees[23].Calculate(currentArray);
			var_24 = (object[])measurement24.Parameter();
			currentArray = treeArray_26;
			currentArray[0] = var_24;
			currentArray[1] = var_25;
			var_26 = (object[])trees[26].Calculate(currentArray);
			currentArray = treeArray_27;
			currentArray[0] = var_23;
			currentArray[1] = var_26;
			var_27 = (object[])trees[27].Calculate(currentArray);
			currentArray = treeArray_28;
			currentArray[0] = var_27;
			var_28 = (object[])trees[28].Calculate(currentArray);
			currentArray = treeArray_29;
			currentArray[0] = var_28;
			currentArray[1] = var_13;
			var_29 = (object[])trees[29].Calculate(currentArray);
			currentArray = treeArray_30;
			currentArray[0] = var_16;
			currentArray[1] = var_29;
			var_30 = (object[])trees[30].Calculate(currentArray);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
			measurement4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[4]);
			measurement8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[8]);
			aliasName13 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[13]);
			measurement16 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[16]);
			measurement17 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[17]);
			measurement20 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[20]);
			measurement24 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[24]);
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
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		DataPerformer.Interfaces.IMeasurement measurement1;
		object[] treeArray_3 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement4;
		object[] treeArray_6 = new object[2];
		object[] treeArray_7 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement8;
		object[] treeArray_10 = new object[2];
		object[] treeArray_11 = new object[2];
		object[] treeArray_12 = new object[1];
		Diagram.UI.Interfaces.IAliasName aliasName13;
		object[] treeArray_14 = new object[2];
		object[] treeArray_15 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement16;
		DataPerformer.Interfaces.IMeasurement measurement17;
		object[] treeArray_19 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement20;
		object[] treeArray_22 = new object[2];
		object[] treeArray_23 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement24;
		object[] treeArray_26 = new object[2];
		object[] treeArray_27 = new object[2];
		object[] treeArray_28 = new object[1];
		object[] treeArray_29 = new object[2];
		object[] treeArray_30 = new object[2];
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		object[] var_0 = new object[790];
		object[] var_1 = new object[790];
		double var_2 = 2;
		object[] var_3 = new object[790];
		object[] var_4 = new object[790];
		double var_5 = 2;
		object[] var_6 = new object[790];
		object[] var_7 = new object[790];
		object[] var_8 = new object[790];
		double var_9 = 2;
		object[] var_10 = new object[790];
		object[] var_11 = new object[790];
		object[] var_12 = new object[790];
		double var_13 = 0;
		object[] var_14 = new object[790];
		object[] var_15 = new object[790];
		object[] var_16 = new object[790];
		object[] var_17 = new object[790];
		double var_18 = 2;
		object[] var_19 = new object[790];
		object[] var_20 = new object[790];
		double var_21 = 2;
		object[] var_22 = new object[790];
		object[] var_23 = new object[790];
		object[] var_24 = new object[790];
		double var_25 = 2;
		object[] var_26 = new object[790];
		object[] var_27 = new object[790];
		object[] var_28 = new object[790];
		object[] var_29 = new object[790];
		object[] var_30 = new object[790];
		
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

	}
}
