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
			currentArray = treeArray_2;
			currentArray[0] = var_0;
			currentArray[1] = var_1;
			var_2 = (object[])trees[2].Calculate(currentArray);
			var_3 = (object[])measurement3.Parameter();
			currentArray = treeArray_5;
			currentArray[0] = var_3;
			currentArray[1] = var_4;
			var_5 = (object[])trees[5].Calculate(currentArray);
			currentArray = treeArray_6;
			currentArray[0] = var_2;
			currentArray[1] = var_5;
			var_6 = (object[])trees[6].Calculate(currentArray);
			var_7 = (object[])measurement7.Parameter();
			currentArray = treeArray_9;
			currentArray[0] = var_7;
			currentArray[1] = var_8;
			var_9 = (object[])trees[9].Calculate(currentArray);
			currentArray = treeArray_10;
			currentArray[0] = var_6;
			currentArray[1] = var_9;
			var_10 = (object[])trees[10].Calculate(currentArray);
			currentArray = treeArray_11;
			currentArray[0] = var_10;
			var_11 = (object[])trees[11].Calculate(currentArray);
			var_12 = (object[])measurement12.Parameter();
			var_13 = (object[])measurement13.Parameter();
			currentArray = treeArray_14;
			currentArray[0] = var_12;
			currentArray[1] = var_13;
			var_14 = (object[])trees[14].Calculate(currentArray);
			var_15 = (object[])measurement15.Parameter();
			var_16 = (object[])measurement16.Parameter();
			currentArray = treeArray_17;
			currentArray[0] = var_15;
			currentArray[1] = var_16;
			var_17 = (object[])trees[17].Calculate(currentArray);
			currentArray = treeArray_18;
			currentArray[0] = var_14;
			currentArray[1] = var_17;
			var_18 = (object[])trees[18].Calculate(currentArray);
			var_19 = (object[])measurement19.Parameter();
			var_20 = (object[])measurement20.Parameter();
			currentArray = treeArray_21;
			currentArray[0] = var_19;
			currentArray[1] = var_20;
			var_21 = (object[])trees[21].Calculate(currentArray);
			currentArray = treeArray_22;
			currentArray[0] = var_18;
			currentArray[1] = var_21;
			var_22 = (object[])trees[22].Calculate(currentArray);
			var_23 = (object[])measurement23.Parameter();
			currentArray = treeArray_25;
			currentArray[0] = var_23;
			currentArray[1] = var_24;
			var_25 = (object[])trees[25].Calculate(currentArray);
			var_26 = (object[])measurement26.Parameter();
			currentArray = treeArray_28;
			currentArray[0] = var_26;
			currentArray[1] = var_27;
			var_28 = (object[])trees[28].Calculate(currentArray);
			currentArray = treeArray_29;
			currentArray[0] = var_25;
			currentArray[1] = var_28;
			var_29 = (object[])trees[29].Calculate(currentArray);
			var_30 = (object[])measurement30.Parameter();
			currentArray = treeArray_32;
			currentArray[0] = var_30;
			currentArray[1] = var_31;
			var_32 = (object[])trees[32].Calculate(currentArray);
			currentArray = treeArray_33;
			currentArray[0] = var_29;
			currentArray[1] = var_32;
			var_33 = (object[])trees[33].Calculate(currentArray);
			currentArray = treeArray_34;
			currentArray[0] = var_33;
			var_34 = (object[])trees[34].Calculate(currentArray);
			currentArray = treeArray_35;
			currentArray[0] = var_22;
			currentArray[1] = var_34;
			var_35 = (object[])trees[35].Calculate(currentArray);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
			measurement3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[3]);
			measurement7 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[7]);
			measurement12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[12]);
			measurement13 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[13]);
			measurement15 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[15]);
			measurement16 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[16]);
			measurement19 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[19]);
			measurement20 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[20]);
			measurement23 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[23]);
			measurement26 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[26]);
			measurement30 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[30]);
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
			dictionary[trees[32]] = Get_32;
			dictionary[trees[33]] = Get_33;
			dictionary[trees[34]] = Get_34;
			dictionary[trees[35]] = Get_35;
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		DataPerformer.Interfaces.IMeasurement measurement0;
		object[] treeArray_2 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement3;
		object[] treeArray_5 = new object[2];
		object[] treeArray_6 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement7;
		object[] treeArray_9 = new object[2];
		object[] treeArray_10 = new object[2];
		object[] treeArray_11 = new object[1];
		DataPerformer.Interfaces.IMeasurement measurement12;
		DataPerformer.Interfaces.IMeasurement measurement13;
		object[] treeArray_14 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement15;
		DataPerformer.Interfaces.IMeasurement measurement16;
		object[] treeArray_17 = new object[2];
		object[] treeArray_18 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement19;
		DataPerformer.Interfaces.IMeasurement measurement20;
		object[] treeArray_21 = new object[2];
		object[] treeArray_22 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement23;
		object[] treeArray_25 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement26;
		object[] treeArray_28 = new object[2];
		object[] treeArray_29 = new object[2];
		DataPerformer.Interfaces.IMeasurement measurement30;
		object[] treeArray_32 = new object[2];
		object[] treeArray_33 = new object[2];
		object[] treeArray_34 = new object[1];
		object[] treeArray_35 = new object[2];
		FormulaEditor.ObjectFormulaTree currentTree = null;
		object[] currentArray = null;
		double doubleValue = 0;
		FormulaEditor.ObjectFormulaTree[] trees = null;
		object[] var_0 = new object[790];
		double var_1 = 2;
		object[] var_2 = new object[790];
		object[] var_3 = new object[790];
		double var_4 = 2;
		object[] var_5 = new object[790];
		object[] var_6 = new object[790];
		object[] var_7 = new object[790];
		double var_8 = 2;
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
		object[] var_23 = new object[790];
		double var_24 = 2;
		object[] var_25 = new object[790];
		object[] var_26 = new object[790];
		double var_27 = 2;
		object[] var_28 = new object[790];
		object[] var_29 = new object[790];
		object[] var_30 = new object[790];
		double var_31 = 2;
		object[] var_32 = new object[790];
		object[] var_33 = new object[790];
		object[] var_34 = new object[790];
		object[] var_35 = new object[790];
		
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
		
		object Get_32()
		{
			return var_32;
		}
		
		object Get_33()
		{
			return var_33;
		}
		
		object Get_34()
		{
			return var_34;
		}
		
		object Get_35()
		{
			return var_35;
		}

	}
}
