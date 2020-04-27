using System;
using System.Collections.Generic;
using System.Text;


namespace GeneratedProject
{
	public static class StaticExtensionGeneratedProject
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new IntrenalDesktop(); }

		internal class IntrenalDesktop : Diagram.UI.PureDesktop
		{
			internal IntrenalDesktop()
			{
				objects.Add(new IntrenalDesktop.OblectLabel0("Input"));
				objects.Add(new IntrenalDesktop.OblectLabel1("Timer"));
				objects.Add(new IntrenalDesktop.OblectLabel2("Motion"));
				objects.Add(new IntrenalDesktop.OblectLabel3("Consumer"));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("");
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel1("");
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel2("");
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel3("");
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)2;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
			}
		
			internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel0(string name) : base(name, "", "", 0, 0)
				{
					obj = new OblectLabel0.CategoryObject();
				}
		
				internal class CategoryObject : Event.Portable.Events.ForcedEventData
				{
				internal CategoryObject()
				{
					List<Tuple<string, object>> tt = new List<Tuple<string, object>>();
					tt.Add(new Tuple<string, object>("a", (System.Double)0));
					tt.Add(new Tuple<string, object>("b", (System.Double)0));
					Types = tt;
					List<object> ini = new List<object>();
					ini.Add((System.Double)1);
					ini.Add((System.Double)1);
					initial = new object[ini.Count];
					for (int i = 0; i < ini.Count; i++)
					{
						initial[i] = ini[i];
					}
				}
				}
			}
		
			internal class OblectLabel1 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel1(string name) : base(name, "", "", 0, 0)
				{
					obj = new OblectLabel1.CategoryObject();
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
		
			internal class OblectLabel2 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel2(string name) : base(name, "", "", 0, 0)
				{
					obj = new OblectLabel2.CategoryObject();
				}
		
				internal class CategoryObject : DataPerformer.Formula.DifferentialEquationSolver, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
				{
				
					internal CategoryObject()
					{
						proxyFactory = this;
						vars = new Dictionary<object, object>()
						{
										{'y' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"w\" S=\"w\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)0}}
							,			{'v' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)0}}
							,			{'x' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"v\" S=\"v\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)0}}
							,			{'w' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)0}}
						};
						pars = new Dictionary<object, object>()
						{
										{'a' , "Input.a"}
							,			{'b' , "Input.b"}
						};
						aliases = new Dictionary<object, object>()
						{
										{"x" , (System.Double)0}
							,			{"y" , (System.Double)0}
							,			{"v" , (System.Double)0}
							,			{"w" , (System.Double)0}
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"a = Input.a",
							"b = Input.b"
						};
					}
					FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
					{
						FormulaEditor.Interfaces.ITreeCollection f = this;
						FormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);
						return new Calculation(trees);
					}
				
					internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
					{
						public void Update()
						{
							var_0 = (double)measurement0.Parameter();
							var_1 = -(var_0);
							var_2 = (double)measurement2.Parameter();
							var_3 = (var_1) + (var_2);
							var_4 = (double)measurement4.Parameter();
							var_5 = -(var_4);
							var_6 = (double)measurement6.Parameter();
							var_7 = (var_5) + (var_6);
							var_8 = (double)measurement8.Parameter();
							var_9 = (double)measurement9.Parameter();
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
							measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
							measurement4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[4]);
							measurement6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[6]);
							measurement8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[8]);
							measurement9 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[9]);
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
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						DataPerformer.Interfaces.IMeasurement measurement0;
						DataPerformer.Interfaces.IMeasurement measurement2;
						DataPerformer.Interfaces.IMeasurement measurement4;
						DataPerformer.Interfaces.IMeasurement measurement6;
						DataPerformer.Interfaces.IMeasurement measurement8;
						DataPerformer.Interfaces.IMeasurement measurement9;
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
					
					}
				}
			}
		
			internal class OblectLabel3 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel3(string name) : base(name, "", "", 0, 0)
				{
					obj = new OblectLabel3.CategoryObject();
				}
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
				}
				}
			}
		
			internal class ArrowLabel0 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel0(string name) : base(name, "", "", 0, 0)
				{
					arrow = new ArrowLabel0.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel1 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel1(string name) : base(name, "", "", 0, 0)
				{
					arrow = new ArrowLabel1.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel2 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel2(string name) : base(name, "", "", 0, 0)
				{
					arrow = new ArrowLabel2.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel3 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel3(string name) : base(name, "", "", 0, 0)
				{
					arrow = new ArrowLabel3.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
		}
		
	}
}
