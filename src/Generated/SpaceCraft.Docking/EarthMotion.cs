using System;
using System.Collections.Generic;
using System.Linq;



namespace GeneratedProject
{
	public static class EarthMotion
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new InternalDesktop(); }

		internal class InternalDesktop : Diagram.UI.PureDesktop
		{
			internal InternalDesktop()
			{
				objects.Add(new InternalDesktop.OblectLabel0("Motion", this));
				objects.Add(new InternalDesktop.OblectLabel1("Linear", this));
				objects.Add(new InternalDesktop.OblectLabel2("Orbit rotation 1", this));
				objects.Add(new InternalDesktop.OblectLabel3("Orbit rotation 2", this));
				objects.Add(new InternalDesktop.OblectLabel4("Earth", this));
				objects.Add(new InternalDesktop.OblectLabel5("Timer", this));
				objects.Add(new InternalDesktop.OblectLabel6("Relative", this));
				objects.Add(new InternalDesktop.OblectLabel7("Base frame", this));
				objects.Add(new InternalDesktop.OblectLabel8("Consumer", this));
				objects.Add(new InternalDesktop.OblectLabel9("Sun", this));
				objects.Add(new InternalDesktop.OblectLabel10("Relative Sun", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new InternalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)1;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel3("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)4;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel4("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel5("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel6("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)4;
				currALabel.TargetNumber = (int)3;
				currALabel  = new InternalDesktop.ArrowLabel7("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel8("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel9("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = (int)4;
				currALabel  = new InternalDesktop.ArrowLabel10("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel11("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)4;
				currALabel.TargetNumber = (int)6;
				currALabel  = new InternalDesktop.ArrowLabel12("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = (int)6;
				currALabel  = new InternalDesktop.ArrowLabel13("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)9;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel14("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)9;
				currALabel.TargetNumber = (int)10;
				currALabel  = new InternalDesktop.ArrowLabel15("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)10;
				currALabel.TargetNumber = (int)7;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this);
				Name = "EarthMotion"; 
			}
		
			internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel0.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Formula.VectorFormulaConsumer, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
				{
				
					internal CategoryObject()
					{
						proxyFactory = this;
						feedback = new Dictionary<int, string>()
						{
						};
				
						formulaString = new string[]
						{
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"p\" S=\"p\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"s\" S=\"sin\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"p\" S=\"p\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"s\" S=\"sin\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"c\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"s\" S=\"sin\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"c\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"q\" S=\"q\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"s\" S=\"sin\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"q\" S=\"q\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 2;
						arguments =  new List<string>()
						{
							"t = Time"
						};
						parameters =new Dictionary<string, object>()
						{
							{"c", (double)-0.20000000000000001 },
							{"a", (double)5 },
							{"b", (double)0.10000000000000001 },
							{"q", (double)0.10000000000000001 },
							{"p", (double)0.10000000000000001 }
						};
						operationNames = new Dictionary<System.Int32,System.String>()
						{
						};
						Init();
					}
				
					FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
					{
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
						FormulaEditor.Interfaces.ITreeCollection f = this;
						var t = 
							FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
						var tt = t.ToArray();
						return new Calculation(tt, checkValue, dataPerformerFormula);
					}
				
					internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
					{
						public bool Success { get => success; }
						
						public void Update()
						{
							success = true;
							variable = aliasName0.Value;
							if (checkValue(variable)) { success = false; return; }
							var_0 = (double)variable;
							variable = aliasName1.Value;
							if (checkValue(variable)) { success = false; return; }
							var_1 = (double)variable;
							variable = measurement2.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_2 = (double)variable;
							var_3 = (var_1) * (var_2);
							var_4 = Math.Cos(var_3);
							var_5 = (var_0) * (var_4);
							var_6 = Math.Sin(var_3);
							var_7 = -(var_6);
							variable = measurement8.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_8 = (double)variable;
							var_9 = (var_1) * (var_8);
							var_10 = (var_7) * (var_9);
							var_11 = (var_0) * (var_10);
							variable = measurement12.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_12 = (double)variable;
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
							variable = aliasName39.Value;
							if (checkValue(variable)) { success = false; return; }
							var_39 = (double)variable;
							var_40 = Math.Sin(var_39);
							var_42 = Math.Cos(var_39);
							variable = aliasName43.Value;
							if (checkValue(variable)) { success = false; return; }
							var_43 = (double)variable;
							var_44 = Math.Cos(var_43);
							var_45 = Math.Sin(var_43);
							variable = aliasName46.Value;
							if (checkValue(variable)) { success = false; return; }
							var_46 = (double)variable;
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
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
							aliasName1 = dataPerformerFormula.ToAliasName(trees[1]);
							measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
							measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
							measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
							aliasName39 = dataPerformerFormula.ToAliasName(trees[39]);
							aliasName43 = dataPerformerFormula.ToAliasName(trees[43]);
							aliasName46 = dataPerformerFormula.ToAliasName(trees[46]);
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
						
						public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
						
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
							return success ? var_0 : null;
						}
						
						object Get_1()
						{
							return success ? var_1 : null;
						}
						
						object Get_2()
						{
							return success ? var_2 : null;
						}
						
						object Get_3()
						{
							return success ? var_3 : null;
						}
						
						object Get_4()
						{
							return success ? var_4 : null;
						}
						
						object Get_5()
						{
							return success ? var_5 : null;
						}
						
						object Get_6()
						{
							return success ? var_6 : null;
						}
						
						object Get_7()
						{
							return success ? var_7 : null;
						}
						
						object Get_8()
						{
							return success ? var_8 : null;
						}
						
						object Get_9()
						{
							return success ? var_9 : null;
						}
						
						object Get_10()
						{
							return success ? var_10 : null;
						}
						
						object Get_11()
						{
							return success ? var_11 : null;
						}
						
						object Get_12()
						{
							return success ? var_12 : null;
						}
						
						object Get_13()
						{
							return success ? var_13 : null;
						}
						
						object Get_14()
						{
							return success ? var_14 : null;
						}
						
						object Get_15()
						{
							return success ? var_15 : null;
						}
						
						object Get_16()
						{
							return success ? var_16 : null;
						}
						
						object Get_17()
						{
							return success ? var_17 : null;
						}
						
						object Get_18()
						{
							return success ? var_18 : null;
						}
						
						object Get_19()
						{
							return success ? var_19 : null;
						}
						
						object Get_20()
						{
							return success ? var_20 : null;
						}
						
						object Get_21()
						{
							return success ? var_21 : null;
						}
						
						object Get_22()
						{
							return success ? var_22 : null;
						}
						
						object Get_23()
						{
							return success ? var_23 : null;
						}
						
						object Get_24()
						{
							return success ? var_24 : null;
						}
						
						object Get_25()
						{
							return success ? var_25 : null;
						}
						
						object Get_26()
						{
							return success ? var_26 : null;
						}
						
						object Get_27()
						{
							return success ? var_27 : null;
						}
						
						object Get_28()
						{
							return success ? var_28 : null;
						}
						
						object Get_29()
						{
							return success ? var_29 : null;
						}
						
						object Get_30()
						{
							return success ? var_30 : null;
						}
						
						object Get_31()
						{
							return success ? var_31 : null;
						}
						
						object Get_32()
						{
							return success ? var_32 : null;
						}
						
						object Get_33()
						{
							return success ? var_33 : null;
						}
						
						object Get_34()
						{
							return success ? var_34 : null;
						}
						
						object Get_35()
						{
							return success ? var_35 : null;
						}
						
						object Get_36()
						{
							return success ? var_36 : null;
						}
						
						object Get_37()
						{
							return success ? var_37 : null;
						}
						
						object Get_38()
						{
							return success ? var_38 : null;
						}
						
						object Get_39()
						{
							return success ? var_39 : null;
						}
						
						object Get_40()
						{
							return success ? var_40 : null;
						}
						
						object Get_41()
						{
							return success ? var_41 : null;
						}
						
						object Get_42()
						{
							return success ? var_42 : null;
						}
						
						object Get_43()
						{
							return success ? var_43 : null;
						}
						
						object Get_44()
						{
							return success ? var_44 : null;
						}
						
						object Get_45()
						{
							return success ? var_45 : null;
						}
						
						object Get_46()
						{
							return success ? var_46 : null;
						}
						
						object Get_47()
						{
							return success ? var_47 : null;
						}
						
						object Get_48()
						{
							return success ? var_48 : null;
						}
						
						object Get_49()
						{
							return success ? var_49 : null;
						}
						
						object Get_50()
						{
							return success ? var_50 : null;
						}
						
						object Get_51()
						{
							return success ? var_51 : null;
						}
						
						object Get_52()
						{
							return success ? var_52 : null;
						}
						
						object Get_53()
						{
							return success ? var_53 : null;
						}
						
						object Get_54()
						{
							return success ? var_54 : null;
						}
						
						object Get_55()
						{
							return success ? var_55 : null;
						}
						
						object Get_56()
						{
							return success ? var_56 : null;
						}
						
						object Get_57()
						{
							return success ? var_57 : null;
						}
						
						object Get_58()
						{
							return success ? var_58 : null;
						}
						
						object Get_59()
						{
							return success ? var_59 : null;
						}
						
						object Get_60()
						{
							return success ? var_60 : null;
						}
						
						object Get_61()
						{
							return success ? var_61 : null;
						}
						
						object Get_62()
						{
							return success ? var_62 : null;
						}
						
						object Get_63()
						{
							return success ? var_63 : null;
						}
						
						object Get_64()
						{
							return success ? var_64 : null;
						}
						
						object Get_65()
						{
							return success ? var_65 : null;
						}
						
						object Get_66()
						{
							return success ? var_66 : null;
						}
						
						object Get_67()
						{
							return success ? var_67 : null;
						}
						
						object Get_68()
						{
							return success ? var_68 : null;
						}
						
						object Get_69()
						{
							return success ? var_69 : null;
						}
						
						object Get_70()
						{
							return success ? var_70 : null;
						}
						
						object Get_71()
						{
							return success ? var_71 : null;
						}
						
						object Get_72()
						{
							return success ? var_72 : null;
						}
						
						object Get_73()
						{
							return success ? var_73 : null;
						}
						
						object Get_74()
						{
							return success ? var_74 : null;
						}
						
						object Get_75()
						{
							return success ? var_75 : null;
						}
						
						object Get_76()
						{
							return success ? var_76 : null;
						}
						
						Func<object, bool> checkValue = (o) => false;
						object variable;
						bool success = true;
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
					
					}
				}
			}
		
			internal class OblectLabel1 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel1.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.ReferenceFrameDataBase
				{
				
					internal CategoryObject()
					{
						parameters = new List<string>()
						{
				"Motion.Formula_2",
				"Motion.Formula_10",
				"Motion.Formula_1",
				"Motion.Formula_9",
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_10"
						};
					}
				
				}
			}
		
			internal class OblectLabel2 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel2(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel2.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.ReferenceFrameDataBase
				{
				
					internal CategoryObject()
					{
						parameters = new List<string>()
						{
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_4",
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_3"
						};
					}
				
				}
			}
		
			internal class OblectLabel3 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel3(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel3.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.ReferenceFrameDataBase
				{
				
					internal CategoryObject()
					{
						parameters = new List<string>()
						{
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_5",
				"Motion.Formula_6",
				"Motion.Formula_10",
				"Motion.Formula_10"
						};
					}
				
				}
			}
		
			internal class OblectLabel4 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel4.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.ReferenceFrameDataBase
				{
				
					internal CategoryObject()
					{
						parameters = new List<string>()
						{
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_7",
				"Motion.Formula_10",
				"Motion.Formula_10",
				"Motion.Formula_8"
						};
					}
				
				}
			}
		
			internal class OblectLabel5 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel5.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.Timer
				{
				internal CategoryObject()
				{
				var ts = this as Event.Interfaces.ITimerEvent;
				ts.TimeSpan = TimeSpan.FromTicks(1000000);
				}
				}
			}
		
			internal class OblectLabel6 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel6(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel6.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
				}
			}
		
			internal class OblectLabel7 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel7.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				0
				, 0
				, 0
						};
				
						relativeQuaternion = new double[]
						{
				1
				, 0
				, 0
				, 0
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel8 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel8.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
				}
				}
			}
		
			internal class OblectLabel9 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel9.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RigidReferenceFrame
				{
				
					internal CategoryObject()
					{
						relativePosition = new double[]
						{
				5
				, 5
				, 5
						};
				
						relativeQuaternion = new double[]
						{
				1
				, 0
				, 0
				, 0
						};
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel10 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel10.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
				}
			}
		
			internal class ArrowLabel0 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel0.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel1 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel1.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel2 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel2(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel2.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel3 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel3(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel3.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel4 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel4.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel5 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel5.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel6 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel6(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel6.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel7 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel7.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel8 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel8.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel9 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel9.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.Portable.BelongsToCollection
				{
				}
			}
		
			internal class ArrowLabel10 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel10.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel11 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel11(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel11.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel12 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel12.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel13 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel13.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
				{
				}
			}
		
			internal class ArrowLabel14 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel14.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel15 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel15(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel15.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
		}
		
	}
}
