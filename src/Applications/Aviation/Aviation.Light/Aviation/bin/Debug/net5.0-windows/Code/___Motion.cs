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
			var_1 = (double)aliasName1.Value;
			var_2 = (double)measurement2.Parameter();
			var_3 = (var_1) * (var_2);
			var_4 = Math.Cos(var_3);
			var_5 = (var_0) * (var_4);
			var_6 = Math.Sin(var_3);
			var_7 = -(var_6);
			var_8 = (double)measurement8.Parameter();
			var_9 = (var_1) * (var_8);
			var_10 = (var_7) * (var_9);
			var_11 = (var_0) * (var_10);
			var_12 = (double)measurement12.Parameter();
			var_13 = (var_1) * (var_12);
			var_14 = (var_7) * (var_13);
			var_15 = -(var_6);
			var_16 = Math.Cos(var_3);
			var_17 = (var_1) * (var_8);
			var_18 = (var_16) * (var_17);
			var_19 = (var_15) * (var_18);
			var_20 = (var_9) * (var_19);
			var_21 = (var_14) + (var_20);
			var_22 = (var_0) * (var_21);
			var_23 = (var_1) * (var_2);
			var_24 = Math.Sin(var_23);
			var_25 = (var_0) * (var_24);
			var_26 = Math.Cos(var_23);
			var_27 = (var_1) * (var_8);
			var_28 = (var_26) * (var_27);
			var_29 = (var_0) * (var_28);
			var_30 = (var_1) * (var_12);
			var_31 = (var_26) * (var_30);
			var_32 = Math.Sin(var_23);
			var_33 = -(var_32);
			var_34 = (var_1) * (var_8);
			var_35 = (var_33) * (var_34);
			var_36 = (var_27) * (var_35);
			var_37 = (var_31) + (var_36);
			var_38 = (var_0) * (var_37);
			var_39 = (double)aliasName39.Value;
			var_40 = Math.Sin(var_39);
			var_42 = Math.Cos(var_39);
			var_43 = (double)aliasName43.Value;
			var_44 = Math.Cos(var_43);
			var_45 = Math.Sin(var_43);
			var_46 = (double)aliasName46.Value;
			var_47 = (var_46) * (var_2);
			var_48 = Math.Cos(var_47);
			var_49 = Math.Sin(var_47);
			var_50 = -(var_49);
			var_51 = (var_46) * (var_8);
			var_52 = (var_50) * (var_51);
			var_53 = (var_46) * (var_12);
			var_54 = (var_50) * (var_53);
			var_55 = -(var_49);
			var_56 = Math.Cos(var_47);
			var_57 = (var_46) * (var_8);
			var_58 = (var_56) * (var_57);
			var_59 = (var_55) * (var_58);
			var_60 = (var_51) * (var_59);
			var_61 = (var_54) + (var_60);
			var_62 = (var_46) * (var_2);
			var_63 = Math.Sin(var_62);
			var_64 = Math.Cos(var_62);
			var_65 = (var_46) * (var_8);
			var_66 = (var_64) * (var_65);
			var_67 = (var_46) * (var_12);
			var_68 = (var_64) * (var_67);
			var_69 = Math.Sin(var_62);
			var_70 = -(var_69);
			var_71 = (var_46) * (var_8);
			var_72 = (var_70) * (var_71);
			var_73 = (var_65) * (var_72);
			var_74 = (var_68) + (var_73);
		}
		
		public Calculate(FormulaEditor.ObjectFormulaTree[] trees)
		{
			this.trees = trees;
			aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
			aliasName1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[1]);
			measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
			measurement8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[8]);
			measurement12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[12]);
			aliasName39 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[39]);
			aliasName43 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[43]);
			aliasName46 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[46]);
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
			dictionary[trees[36]] = Get_36;
			dictionary[trees[37]] = Get_37;
			dictionary[trees[38]] = Get_38;
			dictionary[trees[39]] = Get_39;
			dictionary[trees[40]] = Get_40;
			dictionary[trees[41]] = Get_41;
			dictionary[trees[42]] = Get_42;
			dictionary[trees[43]] = Get_43;
			dictionary[trees[44]] = Get_44;
			dictionary[trees[45]] = Get_45;
			dictionary[trees[46]] = Get_46;
			dictionary[trees[47]] = Get_47;
			dictionary[trees[48]] = Get_48;
			dictionary[trees[49]] = Get_49;
			dictionary[trees[50]] = Get_50;
			dictionary[trees[51]] = Get_51;
			dictionary[trees[52]] = Get_52;
			dictionary[trees[53]] = Get_53;
			dictionary[trees[54]] = Get_54;
			dictionary[trees[55]] = Get_55;
			dictionary[trees[56]] = Get_56;
			dictionary[trees[57]] = Get_57;
			dictionary[trees[58]] = Get_58;
			dictionary[trees[59]] = Get_59;
			dictionary[trees[60]] = Get_60;
			dictionary[trees[61]] = Get_61;
			dictionary[trees[62]] = Get_62;
			dictionary[trees[63]] = Get_63;
			dictionary[trees[64]] = Get_64;
			dictionary[trees[65]] = Get_65;
			dictionary[trees[66]] = Get_66;
			dictionary[trees[67]] = Get_67;
			dictionary[trees[68]] = Get_68;
			dictionary[trees[69]] = Get_69;
			dictionary[trees[70]] = Get_70;
			dictionary[trees[71]] = Get_71;
			dictionary[trees[72]] = Get_72;
			dictionary[trees[73]] = Get_73;
			dictionary[trees[74]] = Get_74;
			dictionary[trees[75]] = Get_75;
			dictionary[trees[76]] = Get_76;
		}
		
		public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
		{ get { return dictionary[tree]; }}
		
		Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
		
		Diagram.UI.Interfaces.IAliasName aliasName0;
		Diagram.UI.Interfaces.IAliasName aliasName1;
		DataPerformer.Interfaces.IMeasurement measurement2;
		DataPerformer.Interfaces.IMeasurement measurement8;
		DataPerformer.Interfaces.IMeasurement measurement12;
		Diagram.UI.Interfaces.IAliasName aliasName39;
		Diagram.UI.Interfaces.IAliasName aliasName43;
		Diagram.UI.Interfaces.IAliasName aliasName46;
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
		double var_27 = 0;
		double var_28 = 0;
		double var_29 = 0;
		double var_30 = 0;
		double var_31 = 0;
		double var_32 = 0;
		double var_33 = 0;
		double var_34 = 0;
		double var_35 = 0;
		double var_36 = 0;
		double var_37 = 0;
		double var_38 = 0;
		double var_39 = 0;
		double var_40 = 0;
		double var_41 = 0;
		double var_42 = 0;
		double var_43 = 0;
		double var_44 = 0;
		double var_45 = 0;
		double var_46 = 0;
		double var_47 = 0;
		double var_48 = 0;
		double var_49 = 0;
		double var_50 = 0;
		double var_51 = 0;
		double var_52 = 0;
		double var_53 = 0;
		double var_54 = 0;
		double var_55 = 0;
		double var_56 = 0;
		double var_57 = 0;
		double var_58 = 0;
		double var_59 = 0;
		double var_60 = 0;
		double var_61 = 0;
		double var_62 = 0;
		double var_63 = 0;
		double var_64 = 0;
		double var_65 = 0;
		double var_66 = 0;
		double var_67 = 0;
		double var_68 = 0;
		double var_69 = 0;
		double var_70 = 0;
		double var_71 = 0;
		double var_72 = 0;
		double var_73 = 0;
		double var_74 = 0;
		double var_75 = 1;
		double var_76 = 0;
		
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
		
		object Get_36()
		{
			return var_36;
		}
		
		object Get_37()
		{
			return var_37;
		}
		
		object Get_38()
		{
			return var_38;
		}
		
		object Get_39()
		{
			return var_39;
		}
		
		object Get_40()
		{
			return var_40;
		}
		
		object Get_41()
		{
			return var_41;
		}
		
		object Get_42()
		{
			return var_42;
		}
		
		object Get_43()
		{
			return var_43;
		}
		
		object Get_44()
		{
			return var_44;
		}
		
		object Get_45()
		{
			return var_45;
		}
		
		object Get_46()
		{
			return var_46;
		}
		
		object Get_47()
		{
			return var_47;
		}
		
		object Get_48()
		{
			return var_48;
		}
		
		object Get_49()
		{
			return var_49;
		}
		
		object Get_50()
		{
			return var_50;
		}
		
		object Get_51()
		{
			return var_51;
		}
		
		object Get_52()
		{
			return var_52;
		}
		
		object Get_53()
		{
			return var_53;
		}
		
		object Get_54()
		{
			return var_54;
		}
		
		object Get_55()
		{
			return var_55;
		}
		
		object Get_56()
		{
			return var_56;
		}
		
		object Get_57()
		{
			return var_57;
		}
		
		object Get_58()
		{
			return var_58;
		}
		
		object Get_59()
		{
			return var_59;
		}
		
		object Get_60()
		{
			return var_60;
		}
		
		object Get_61()
		{
			return var_61;
		}
		
		object Get_62()
		{
			return var_62;
		}
		
		object Get_63()
		{
			return var_63;
		}
		
		object Get_64()
		{
			return var_64;
		}
		
		object Get_65()
		{
			return var_65;
		}
		
		object Get_66()
		{
			return var_66;
		}
		
		object Get_67()
		{
			return var_67;
		}
		
		object Get_68()
		{
			return var_68;
		}
		
		object Get_69()
		{
			return var_69;
		}
		
		object Get_70()
		{
			return var_70;
		}
		
		object Get_71()
		{
			return var_71;
		}
		
		object Get_72()
		{
			return var_72;
		}
		
		object Get_73()
		{
			return var_73;
		}
		
		object Get_74()
		{
			return var_74;
		}
		
		object Get_75()
		{
			return var_75;
		}
		
		object Get_76()
		{
			return var_76;
		}

	}
}
