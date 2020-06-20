using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace GeneratedProject
{
	public static class RigidBodyStation
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new IntrenalDesktop(); }

		internal class IntrenalDesktop : Diagram.UI.PureDesktop
		{
			internal IntrenalDesktop()
			{
				objects.Add(new IntrenalDesktop.OblectLabel0("Equations", this));
				objects.Add(new IntrenalDesktop.OblectLabel1("Cont", this));
				objects.Add(new IntrenalDesktop.OblectLabel2("Consumer", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)1,"Igla/Mod" };
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = new object[] {(int)1,"Limiter" };
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this); 
			}
		
			internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel0.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Formula.DifferentialEquationSolver, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
				{
				
					internal CategoryObject()
					{
						proxyFactory = this;
						feedback = new Dictionary<int, string>()
						{
						};
				
						vars = new Dictionary<object, object>()
						{
										{'y' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)(3)}}
							,			{'x' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)(7)}}
						};
						pars = new Dictionary<object, object>()
						{
						};
						aliases = new Dictionary<object, object>()
						{
										{"x" , (System.Double)(7)}
							,			{"y" , (System.Double)(3)}
							,			{"k" , (System.Double)(0)}
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
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
							var_1 = (double)aliasName1.Value;
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
							aliasName1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[1]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
						}
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						DataPerformer.Interfaces.IMeasurement measurement0;
						Diagram.UI.Interfaces.IAliasName aliasName1;
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						double var_1 = 0;
						
						object Get_0()
						{
							return var_0;
						}
						
						object Get_1()
						{
							return var_1;
						}
					
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
		
				internal class CategoryObject : Diagram.UI.ObjectContainerPortable
				{
					internal CategoryObject() : base(null)
					{
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0("Igla", this));
							objects.Add(new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel1("Limiter", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = new object[] {(int)0,"Epsilon" };
							currALabel  = new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = new object[] {(int)0,"Mod" };
						}
					
						internal class OblectLabel0 : Diagram.UI.Labels.PureObjectLabel
						{
							internal OblectLabel0(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
							{
								this.desktop = desktop;
								obj = new OblectLabel0.CategoryObject();
								obj.Object = this;
							}
					
							internal class CategoryObject : Diagram.UI.ObjectContainerPortable
							{
								internal CategoryObject() : base(null)
								{
									desktop = new Desktop(this);
									Load();
								}
							
								new internal class Desktop : Diagram.UI.PureDesktop
								{
									internal Desktop()
									{
										objects.Add(new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0.CategoryObject.Desktop.OblectLabel0("Mod", this));
										objects.Add(new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0.CategoryObject.Desktop.OblectLabel1("Force", this));
										objects.Add(new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
										Diagram.UI.Labels.PureArrowLabel currALabel = null;
										currALabel  = new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0.CategoryObject.Desktop.ArrowLabel0("", this);
										arrows.Add(currALabel);
										currALabel.SourceNumber = (int)1;
										currALabel.TargetNumber = (int)0;
										currALabel  = new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0.CategoryObject.Desktop.ArrowLabel1("", this);
										arrows.Add(currALabel);
										currALabel.SourceNumber = (int)2;
										currALabel.TargetNumber = (int)1;
										currALabel  = new IntrenalDesktop.OblectLabel1.CategoryObject.Desktop.OblectLabel0.CategoryObject.Desktop.ArrowLabel2("", this);
										arrows.Add(currALabel);
										currALabel.SourceNumber = (int)2;
										currALabel.TargetNumber = (int)0;
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
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.FractionSymbol\" symbol=\"F\" S=\"F\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"1\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>    </S>  </F></Root>",
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
												};
												isSerialized = true;
												calculateDerivation = false;
												deriOrder = 0;
												arguments =  new List<string>()
												{
													"x = ../../Equations.x",
													"y = ../../Equations.y"
												};
												parameters =new Dictionary<string, object>()
												{
													{"k", (double)0.40000000000000002 }
												};
												operationNames = new Dictionary<System.Int32,System.String>()
												{
												};
												Init();
											}
										
											FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
											{
												FormulaEditor.Interfaces.ITreeCollection f = this;
												var t = 
													FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
												var tt = t.ToArray();
												return new Calculation(tt);
											}
										
											internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
											{
												public void Update()
												{
													var_0 = (double)measurement0.Parameter();
													var_1 = Math.Abs(var_0);
													var_2 = (double)measurement2.Parameter();
													var_4 = Math.Pow(var_2, var_3);
													var_6 = (double)aliasName6.Value;
													var_7 = (var_5) * (var_6);
													var_8 = (var_4) / (var_7);
													var_9 = (var_1) > (var_8);
													var_11 = (var_0) > (var_10);
													var_12 = (double)measurement12.Parameter();
													var_14 = (var_12) > (var_13);
												}
												
												internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
												{
													this.trees = trees;
													measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
													measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
													aliasName6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[6]);
													measurement12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[12]);
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
												}
												
												public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
												{ get { return dictionary[tree]; }}
												
												Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
												
												DataPerformer.Interfaces.IMeasurement measurement0;
												DataPerformer.Interfaces.IMeasurement measurement2;
												Diagram.UI.Interfaces.IAliasName aliasName6;
												DataPerformer.Interfaces.IMeasurement measurement12;
												FormulaEditor.ObjectFormulaTree currentTree = null;
												object[] currentArray = null;
												double doubleValue = 0;
												FormulaEditor.ObjectFormulaTree[] trees = null;
												double var_0 = 0;
												double var_1 = 0;
												double var_2 = 0;
												double var_3 = 2;
												double var_4 = 0;
												double var_5 = 2;
												double var_6 = 0;
												double var_7 = 0;
												double var_8 = 0;
												bool var_9 = false;
												double var_10 = 0;
												bool var_11 = false;
												double var_12 = 0;
												double var_13 = 0;
												bool var_14 = false;
												
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
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"¬\" S=\"¬\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"¬\" S=\"¬\" Type=\"4\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"d\" S=\"d\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"d\" S=\"d\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>      </F>      <F />    </S>  </F></Root>"
												};
												isSerialized = true;
												calculateDerivation = false;
												deriOrder = 0;
												arguments =  new List<string>()
												{
													"d = Mod.Formula_1",
													"k = Mod.Formula_2",
													"a = Mod.Formula_3",
													"b = Mod.Formula_4"
												};
												parameters =new Dictionary<string, object>()
												{
												};
												operationNames = new Dictionary<System.Int32,System.String>()
												{
												};
												Init();
											}
										
											FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
											{
												FormulaEditor.Interfaces.ITreeCollection f = this;
												var t = 
													FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
												var tt = t.ToArray();
												return new Calculation(tt);
											}
										
											internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
											{
												public void Update()
												{
													var_0 = (bool)measurement0.Parameter();
													var_1 = (bool)measurement1.Parameter();
													var_2 = (var_0) & (var_1);
													var_3 = (double)measurement3.Parameter();
													var_4 = -(var_3);
													currentArray = treeArray_5;
													currentArray[0] = var_0;
													var_5 = (bool)trees[5].Calculate(currentArray);
													currentArray = treeArray_6;
													currentArray[0] = var_1;
													var_6 = (bool)trees[6].Calculate(currentArray);
													var_7 = (var_5) & (var_6);
													var_8 = (bool)measurement8.Parameter();
													var_9 = -(var_3);
													var_10 = (var_8) ? (var_9) : (var_3);
													var_11 = -(var_3);
													var_12 = (var_8) ? (var_3) : (var_11);
													var_13 = (var_0) ? (var_10) : (var_12);
													var_14 = (var_7) ? (var_3) : (var_13);
													var_15 = (var_2) ? (var_4) : (var_14);
												}
												
												internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
												{
													this.trees = trees;
													measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
													measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
													measurement3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[3]);
													measurement8 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[8]);
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
												}
												
												public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
												{ get { return dictionary[tree]; }}
												
												Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
												
												DataPerformer.Interfaces.IMeasurement measurement0;
												DataPerformer.Interfaces.IMeasurement measurement1;
												DataPerformer.Interfaces.IMeasurement measurement3;
												object[] treeArray_5 = new object[1];
												object[] treeArray_6 = new object[1];
												DataPerformer.Interfaces.IMeasurement measurement8;
												FormulaEditor.ObjectFormulaTree currentTree = null;
												object[] currentArray = null;
												double doubleValue = 0;
												FormulaEditor.ObjectFormulaTree[] trees = null;
												bool var_0 = false;
												bool var_1 = false;
												bool var_2 = false;
												double var_3 = 0;
												double var_4 = 0;
												bool var_5 = false;
												bool var_6 = false;
												bool var_7 = false;
												bool var_8 = false;
												double var_9 = 0;
												double var_10 = 0;
												double var_11 = 0;
												double var_12 = 0;
												double var_13 = 0;
												double var_14 = 0;
												double var_15 = 0;
												
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
													"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"1\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"2\" S=\"2\" Type=\"5\" Index=\"1\" Level=\"1\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&lt;\" S=\"&lt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"1\" S=\"1\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
												};
												isSerialized = true;
												calculateDerivation = false;
												deriOrder = 0;
												arguments =  new List<string>()
												{
													"f = Force.Formula_1",
													"x = Mod.Formula_5",
													"y = Mod.Formula_6"
												};
												parameters =new Dictionary<string, object>()
												{
													{"a", (double)500 },
													{"b", (double)500 }
												};
												operationNames = new Dictionary<System.Int32,System.String>()
												{
												};
												Init();
											}
										
											FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
											{
												FormulaEditor.Interfaces.ITreeCollection f = this;
												var t = 
													FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
												var tt = t.ToArray();
												return new Calculation(tt);
											}
										
											internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
											{
												public void Update()
												{
													var_0 = (double)aliasName0.Value;
													var_1 = (double)measurement1.Parameter();
													var_3 = Math.Pow(var_1, var_2);
													var_4 = (var_0) * (var_3);
													var_5 = (double)aliasName5.Value;
													var_6 = (double)measurement6.Parameter();
													var_8 = Math.Pow(var_6, var_7);
													var_9 = (var_5) * (var_8);
													var_10 = (var_4) + (var_9);
													var_12 = (var_10) < (var_11);
													var_14 = (double)measurement14.Parameter();
													var_15 = (var_12) ? (var_13) : (var_14);
												}
												
												internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
												{
													this.trees = trees;
													aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
													measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
													aliasName5 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[5]);
													measurement6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[6]);
													measurement14 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[14]);
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
												}
												
												public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
												{ get { return dictionary[tree]; }}
												
												Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
												
												Diagram.UI.Interfaces.IAliasName aliasName0;
												DataPerformer.Interfaces.IMeasurement measurement1;
												Diagram.UI.Interfaces.IAliasName aliasName5;
												DataPerformer.Interfaces.IMeasurement measurement6;
												DataPerformer.Interfaces.IMeasurement measurement14;
												FormulaEditor.ObjectFormulaTree currentTree = null;
												object[] currentArray = null;
												double doubleValue = 0;
												FormulaEditor.ObjectFormulaTree[] trees = null;
												double var_0 = 0;
												double var_1 = 0;
												double var_2 = 2;
												double var_3 = 0;
												double var_4 = 0;
												double var_5 = 0;
												double var_6 = 0;
												double var_7 = 2;
												double var_8 = 0;
												double var_9 = 0;
												double var_10 = 0;
												double var_11 = 1;
												bool var_12 = false;
												double var_13 = 0;
												double var_14 = 0;
												double var_15 = 0;
												
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
								
							
								CategoryTheory.ICategoryObject obj;
							
								internal Desktop(CategoryTheory.ICategoryObject obj) : this()
								{
									this.obj = obj;
								}
							
								public override Diagram.UI.Interfaces.IDesktop Root
								{
									get
									{
										Diagram.UI.Labels.INamedComponent nc = obj.Object as Diagram.UI.Labels.INamedComponent;
									return nc.Desktop.Root;
									}
								}
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
										{ 0,"../Equations.k" }
									};
							
									formulaString = new string[]
									{
										"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">      <F>        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&lt;\" S=\"&lt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.BracketsSymbol\" symbol=\"P\" S=\"( )\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"P\">          <F>            <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">              <F>                <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">                  <F />                </S>              </F>              <F />            </S>            <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />            <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">              <F />            </S>          </F>          <F />        </S>        <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"∖\" S=\"AND\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"z\" S=\"z\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
									};
									isSerialized = true;
									calculateDerivation = false;
									deriOrder = 0;
									arguments =  new List<string>()
									{
										"k = Igla/Epsilon.Formula_1",
										"z = Igla/Mod.Formula_1",
										"x = Igla/Mod.Formula_5",
										"y = Igla/Mod.Formula_6"
									};
									parameters =new Dictionary<string, object>()
									{
										{"a", (double)1 }
									};
									operationNames = new Dictionary<System.Int32,System.String>()
									{
									};
									Init();
								}
							
								FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Action<object> checkValue)
								{
									FormulaEditor.Interfaces.ITreeCollection f = this;
									var t = 
										FormulaEditor.ObjectFormulaTree.CreateList(f.Trees, new List<FormulaEditor.ObjectFormulaTree>());
									var tt = t.ToArray();
									return new Calculation(tt);
								}
							
								internal class Calculation : FormulaEditor.Interfaces.ITreeCollectionProxy
								{
									public void Update()
									{
										var_0 = (double)measurement0.Parameter();
										var_1 = (double)measurement1.Parameter();
										var_2 = (var_0) * (var_1);
										var_4 = (var_2) < (var_3);
										var_5 = Math.Abs(var_1);
										var_6 = (double)aliasName6.Value;
										var_7 = (var_5) > (var_6);
										var_8 = (var_4) & (var_7);
										var_9 = (bool)measurement9.Parameter();
										var_10 = (var_8) & (var_9);
										var_12 = (double)measurement12.Parameter();
										var_13 = (var_10) ? (var_11) : (var_12);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
									{
										this.trees = trees;
										measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[1]);
										aliasName6 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[6]);
										measurement9 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[9]);
										measurement12 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[12]);
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
									}
									
									public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									Diagram.UI.Interfaces.IAliasName aliasName6;
									DataPerformer.Interfaces.IMeasurement measurement9;
									DataPerformer.Interfaces.IMeasurement measurement12;
									FormulaEditor.ObjectFormulaTree currentTree = null;
									object[] currentArray = null;
									double doubleValue = 0;
									FormulaEditor.ObjectFormulaTree[] trees = null;
									double var_0 = 0;
									double var_1 = 0;
									double var_2 = 0;
									double var_3 = 0;
									bool var_4 = false;
									double var_5 = 0;
									double var_6 = 0;
									bool var_7 = false;
									bool var_8 = false;
									bool var_9 = false;
									bool var_10 = false;
									double var_11 = 0;
									double var_12 = 0;
									double var_13 = 0;
									
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
					
				
					CategoryTheory.ICategoryObject obj;
				
					internal Desktop(CategoryTheory.ICategoryObject obj) : this()
					{
						this.obj = obj;
					}
				
					public override Diagram.UI.Interfaces.IDesktop Root
					{
						get
						{
							Diagram.UI.Labels.INamedComponent nc = obj.Object as Diagram.UI.Labels.INamedComponent;
						return nc.Desktop.Root;
						}
					}
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
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
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
		
		}
		
	}
}
