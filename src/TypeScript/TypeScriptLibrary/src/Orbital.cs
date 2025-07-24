using System;
using System.Collections.Generic;
using System.Linq;



namespace GeneratedProject
{
	public static class Orbital
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new InternalDesktop(); }

		internal class InternalDesktop : Diagram.UI.PureDesktop
		{
			internal InternalDesktop()
			{
				objects.Add(new InternalDesktop.OblectLabel0("input", this));
				objects.Add(new InternalDesktop.OblectLabel1("Output", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new InternalDesktop.ArrowLabel0("22", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)1;
				currALabel.TargetNumber = (int)0;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this);
				Name = "Orbital"; 
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
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"s\" S=\"sin\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"1\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"t = Time"
						};
						parameters =new Dictionary<string, object>()
						{
							{"a", (double)5 },
							{"b", (double)1 }
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
							variable = measurement0.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_0 = (double)variable;
							variable = aliasName1.Value;
							if (checkValue(variable)) { success = false; return; }
							var_1 = (double)variable;
							var_2 = (var_0) * (var_1);
							variable = aliasName3.Value;
							if (checkValue(variable)) { success = false; return; }
							var_3 = (double)variable;
							var_4 = (var_3) * (var_0);
							variable = measurement5.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_5 = (double)variable;
							var_7 = Math.Pow(var_5, var_6);
							var_8 = Math.Sin(var_7);
							var_9 = (var_4) + (var_8);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
							aliasName1 = dataPerformerFormula.ToAliasName(trees[1]);
							aliasName3 = dataPerformerFormula.ToAliasName(trees[3]);
							measurement5 = dataPerformerFormula.ToMeasurement(trees[5]);
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
						}
						
						public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
						
						DataPerformer.Interfaces.IMeasurement measurement0;
						Diagram.UI.Interfaces.IAliasName aliasName1;
						Diagram.UI.Interfaces.IAliasName aliasName3;
						DataPerformer.Interfaces.IMeasurement measurement5;
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
						double var_6 = 2;
						double var_7 = 0;
						double var_8 = 0;
						double var_9 = 0;
						
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
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"1\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"cos\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"l\" S=\"l\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"l = Time"
						};
						parameters =new Dictionary<string, object>()
						{
							{"a", (double)7 },
							{"b", (double)8 }
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
							var_2 = Math.Pow(var_0, var_1);
							variable = aliasName3.Value;
							if (checkValue(variable)) { success = false; return; }
							var_3 = (double)variable;
							var_4 = Math.Cos(var_3);
							variable = aliasName5.Value;
							if (checkValue(variable)) { success = false; return; }
							var_5 = (double)variable;
							variable = measurement6.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_6 = (double)variable;
							var_7 = (var_5) * (var_6);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
							aliasName3 = dataPerformerFormula.ToAliasName(trees[3]);
							aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
							measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
							dictionary[trees[2]] = Get_2;
							dictionary[trees[3]] = Get_3;
							dictionary[trees[4]] = Get_4;
							dictionary[trees[5]] = Get_5;
							dictionary[trees[6]] = Get_6;
							dictionary[trees[7]] = Get_7;
						}
						
						public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
						
						Diagram.UI.Interfaces.IAliasName aliasName0;
						Diagram.UI.Interfaces.IAliasName aliasName3;
						Diagram.UI.Interfaces.IAliasName aliasName5;
						DataPerformer.Interfaces.IMeasurement measurement6;
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						double var_1 = 2;
						double var_2 = 0;
						double var_3 = 0;
						double var_4 = 0;
						double var_5 = 0;
						double var_6 = 0;
						double var_7 = 0;
						
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
						
						Func<object, bool> checkValue = (o) => false;
						object variable;
						bool success = true;
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
					
					}
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
		
		}
		
	}
}
