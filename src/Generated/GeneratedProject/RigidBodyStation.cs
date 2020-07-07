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
				objects.Add(new IntrenalDesktop.OblectLabel0("Force", this));
				objects.Add(new IntrenalDesktop.OblectLabel1("Relative to station", this));
				objects.Add(new IntrenalDesktop.OblectLabel2("Rigid Body", this));
				objects.Add(new IntrenalDesktop.OblectLabel3("Station frame", this));
				objects.Add(new IntrenalDesktop.OblectLabel4("Oz-Control", this));
				objects.Add(new IntrenalDesktop.OblectLabel5("Diff", this));
				objects.Add(new IntrenalDesktop.OblectLabel6("Consumer", this));
				objects.Add(new IntrenalDesktop.OblectLabel7("Shifted Frame", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)7;
				currALabel.TargetNumber = (int)3;
				currALabel  = new IntrenalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)1;
				currALabel.TargetNumber = (int)7;
				currALabel  = new IntrenalDesktop.ArrowLabel3("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel4("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)4,"Mod" };
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel5("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = new object[] {(int)4,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel6("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel7("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)4,"Mod" };
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel8("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel9("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel10("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = new object[] {(int)4,"Mod" };
				currALabel  = new IntrenalDesktop.ArrowLabel11("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)3;
				currALabel  = new IntrenalDesktop.ArrowLabel12("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)5;
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
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"0\" S=\"0\" Type=\"5\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
						};
						parameters =new Dictionary<string, object>()
						{
							{"k", (double)0.001 }
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
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
						}
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						Diagram.UI.Interfaces.IAliasName aliasName0;
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
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
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
		
				internal class CategoryObject : Motion6D.Portable.AggregableWrapper
				{
				
					internal CategoryObject()
					{
						aggregate = new MechanicalAggregate();
						Prepare();
					}
						internal class MechanicalAggregate :
				Motion6D.Portable.Aggregates.RigidBody
				{
				
					internal MechanicalAggregate()
					{
						momentOfInertia =  new double[,]
						{
					{
						1,
						0,
						0
				},
					{
						0,
						1,
						0
				},
					{
						0,
						0,
						1
				}
						};
				
						aliasNames =  new Dictionary<int, string>()
						{
						};
				
						inerialAccelerationStr =  new string[]
						{
				""
				, ""
				, ""
						};
				
						forcesStr =  new string[]
						{
				"Force.Formula_2"
				, "Force.Formula_2"
				, "Force.Formula_2"
				, "Force.Formula_2"
				, "Force.Formula_2"
				, "Force.Formula_1"
						};
				
						mass = 1;
				
						initialState =  new double[]
						{
				0
				, 0
				, 0
				, 0
				, 0
				, 0
				, 1
				, 0
				, 0
				, 0
				, 0
				, 0
				, 0
						};
				
					}
				
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
		
				internal class CategoryObject : Motion6D.Portable.AggregableWrapper
				{
				
					internal CategoryObject()
					{
						aggregate = new MechanicalAggregate();
						Prepare();
					}
						internal class MechanicalAggregate :
				Motion6D.Portable.Aggregates.RigidBody
				{
				
					internal MechanicalAggregate()
					{
						momentOfInertia =  new double[,]
						{
					{
						1,
						0,
						0
				},
					{
						0,
						10,
						0
				},
					{
						0,
						0,
						20
				}
						};
				
						aliasNames =  new Dictionary<int, string>()
						{
						};
				
						inerialAccelerationStr =  new string[]
						{
				""
				, ""
				, ""
						};
				
						forcesStr =  new string[]
						{
				""
				, ""
				, ""
				, ""
				, ""
				, ""
						};
				
						mass = 1;
				
						initialState =  new double[]
						{
				0
				, 0
				, 0.25
				, 0
				, 0
				, 0
				, 0.00049999981250012111
				, 0
				, 0
				, 0.99999987500008591
				, 0
				, 0
				, 0.02
						};
				
					}
				
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
							objects.Add(new IntrenalDesktop.OblectLabel4.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel4.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel4.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel4.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel4.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel4.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../Relative to station.Yaw",
										"y = ../Relative to station.OMz"
									};
									parameters =new Dictionary<string, object>()
									{
										{"k", (double)0 }
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
										{ 0,"Mod.k" }
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
										{"b", (double)50000 },
										{"a", (double)50000 }
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
		
			internal class OblectLabel5 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel5.CategoryObject();
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
										{'x' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)(5)}}
						};
						pars = new Dictionary<object, object>()
						{
						};
						aliases = new Dictionary<object, object>()
						{
										{"x" , (System.Double)(5)}
							,			{"a" , (System.Double)(1)}
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
							var_0 = (double)aliasName0.Value;
							var_1 = -(var_0);
							var_2 = (double)measurement2.Parameter();
							var_3 = (var_1) * (var_2);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							aliasName0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[0]);
							measurement2 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[2]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
							dictionary[trees[2]] = Get_2;
							dictionary[trees[3]] = Get_3;
						}
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						Diagram.UI.Interfaces.IAliasName aliasName0;
						DataPerformer.Interfaces.IMeasurement measurement2;
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						double var_1 = 0;
						double var_2 = 0;
						double var_3 = 0;
						
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
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
				}
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
				, -2
						};
				
						relativeQuaternion = new double[]
						{
				1
				, 0
				, 0
				, 0
						};
				
						isSerialized = true;
						Init();
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
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
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
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
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
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
		}
		
	}
}
