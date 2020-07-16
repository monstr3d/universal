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
				objects.Add(new IntrenalDesktop.OblectLabel1("Timer", this));
				objects.Add(new IntrenalDesktop.OblectLabel2("Relative to station", this));
				objects.Add(new IntrenalDesktop.OblectLabel3("Rigid Body", this));
				objects.Add(new IntrenalDesktop.OblectLabel4("Station frame", this));
				objects.Add(new IntrenalDesktop.OblectLabel5("X-Frame", this));
				objects.Add(new IntrenalDesktop.OblectLabel6("X-Control 1", this));
				objects.Add(new IntrenalDesktop.OblectLabel7("Oz-Control", this));
				objects.Add(new IntrenalDesktop.OblectLabel8("X-Frame-1", this));
				objects.Add(new IntrenalDesktop.OblectLabel9("Ox-Control", this));
				objects.Add(new IntrenalDesktop.OblectLabel10("Oy-Control", this));
				objects.Add(new IntrenalDesktop.OblectLabel11("X-Control 2", this));
				objects.Add(new IntrenalDesktop.OblectLabel12("Oz-Control 1", this));
				objects.Add(new IntrenalDesktop.OblectLabel13("Z-Control", this));
				objects.Add(new IntrenalDesktop.OblectLabel14("Y-Control", this));
				objects.Add(new IntrenalDesktop.OblectLabel15("Consumer", this));
				objects.Add(new IntrenalDesktop.OblectLabel16("Shifted Frame", this));
				objects.Add(new IntrenalDesktop.OblectLabel17("Aim 1", this));
				objects.Add(new IntrenalDesktop.OblectLabel18("Aim 2", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)16;
				currALabel.TargetNumber = (int)4;
				currALabel  = new IntrenalDesktop.ArrowLabel3("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel4("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)17;
				currALabel.TargetNumber = (int)16;
				currALabel  = new IntrenalDesktop.ArrowLabel5("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)5;
				currALabel  = new IntrenalDesktop.ArrowLabel6("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel7("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)16;
				currALabel  = new IntrenalDesktop.ArrowLabel8("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)6,"Mod" };
				currALabel.TargetNumber = (int)5;
				currALabel  = new IntrenalDesktop.ArrowLabel9("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)11,"Mod" };
				currALabel.TargetNumber = (int)8;
				currALabel  = new IntrenalDesktop.ArrowLabel10("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)6,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel11("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)11,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel12("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)14,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel13("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)14,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel14("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)13,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel15("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)13,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel16("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)7,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel17("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)7,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel18("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)12;
				currALabel.TargetNumber = new object[] {(int)7,"Mod" };
				currALabel  = new IntrenalDesktop.ArrowLabel19("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)12;
				currALabel.TargetNumber = new object[] {(int)7,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel20("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)12;
				currALabel  = new IntrenalDesktop.ArrowLabel21("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)16;
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel22("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)3;
				currALabel  = new IntrenalDesktop.ArrowLabel23("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)8;
				currALabel.TargetNumber = (int)3;
				currALabel  = new IntrenalDesktop.ArrowLabel24("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)3;
				currALabel  = new IntrenalDesktop.ArrowLabel25("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)17;
				currALabel.TargetNumber = (int)5;
				currALabel  = new IntrenalDesktop.ArrowLabel26("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)18;
				currALabel.TargetNumber = (int)8;
				currALabel  = new IntrenalDesktop.ArrowLabel27("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)10,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel28("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = new object[] {(int)9,"Epsilon" };
				currALabel  = new IntrenalDesktop.ArrowLabel29("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)9,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel30("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)10,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel31("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)15;
				currALabel.TargetNumber = (int)8;
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
		
				internal class CategoryObject : Event.Portable.Events.ForcedEventData
				{
				internal CategoryObject()
				{
					List<Tuple<string, object>> tt = new List<Tuple<string, object>>();
					tt.Add(new Tuple<string, object>("Fx", (System.Double)0));
					tt.Add(new Tuple<string, object>("Fy", (System.Double)0));
					tt.Add(new Tuple<string, object>("Fz", (System.Double)0));
					tt.Add(new Tuple<string, object>("Mx", (System.Double)0));
					tt.Add(new Tuple<string, object>("My", (System.Double)0));
					tt.Add(new Tuple<string, object>("Mz", (System.Double)0));
					tt.Add(new Tuple<string, object>("G", (System.Double)0));
					Types = tt;
					List<object> ini = new List<object>();
					ini.Add((System.Double)0);
					ini.Add((System.Double)0);
					ini.Add((System.Double)0);
					ini.Add((System.Double)0);
					ini.Add((System.Double)0);
					ini.Add((System.Double)0);
					ini.Add((System.Double)0);
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
				internal OblectLabel1(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel1.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.Timer
				{
				internal CategoryObject()
				{
				var ts = this as Event.Interfaces.ITimerEvent;
				ts.TimeSpan = TimeSpan.FromTicks(500000);
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
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
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
				"Force.Fx"
				, "Force.Fy"
				, "Force.Fz"
				, "Force.Mx"
				, "Force.My"
				, "Force.Mz"
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
		
			internal class OblectLabel4 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel4(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel4.CategoryObject();
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
				, 250
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
		
			internal class OblectLabel5 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel5(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel5.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
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
							objects.Add(new IntrenalDesktop.OblectLabel6.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel6.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel6.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel6.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel6.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel6.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../X-Frame.z",
										"y = ../X-Frame.Vz"
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
										{"b", (double)5000000 },
										{"a", (double)5000000 }
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
		
			internal class OblectLabel7 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel7(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel7.CategoryObject();
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
							objects.Add(new IntrenalDesktop.OblectLabel7.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel7.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel7.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel7.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel7.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel7.CategoryObject.Desktop.ArrowLabel2("", this);
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
		
			internal class OblectLabel8 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel8.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
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
							objects.Add(new IntrenalDesktop.OblectLabel9.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel9.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel9.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel9.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel9.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel9.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../Relative to station.Roll",
										"y = ../Relative to station.OMx"
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
										{"b", (double)500000 },
										{"a", (double)500000 }
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
		
			internal class OblectLabel10 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel10(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel10.CategoryObject();
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
							objects.Add(new IntrenalDesktop.OblectLabel10.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel10.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel10.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel10.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel10.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel10.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../Relative to station.Pitch",
										"y = ../Relative to station.OMy"
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
										{"b", (double)500000 },
										{"a", (double)500000 }
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
		
			internal class OblectLabel11 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel11(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel11.CategoryObject();
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
							objects.Add(new IntrenalDesktop.OblectLabel11.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel11.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel11.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel11.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel11.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel11.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../X-Frame-1.z",
										"y = ../X-Frame-1.Vz"
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
										{"b", (double)500 },
										{"a", (double)500 }
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
		
			internal class OblectLabel12 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel12.CategoryObject();
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
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"&gt;\" S=\"&gt;\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"?\" S=\"?\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\":\" S=\":\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"y\" S=\"y\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"k = Oz-Control/Mod.Formula_2",
							"x = Oz-Control/Mod.Formula_5",
							"y = Oz-Control/Epsilon.Formula_1"
						};
						parameters =new Dictionary<string, object>()
						{
							{"a", (double)2 }
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
							var_1 = (double)aliasName1.Value;
							var_2 = (var_0) > (var_1);
							var_3 = (double)measurement3.Parameter();
							var_4 = (double)measurement4.Parameter();
							var_5 = (var_2) ? (var_3) : (var_4);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees)
						{
							this.trees = trees;
							measurement0 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[0]);
							aliasName1 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToAliasName(trees[1]);
							measurement3 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[3]);
							measurement4 = DataPerformer.Formula.StaticExtensionDataPerformerFormula.ToMeasurement(trees[4]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
							dictionary[trees[2]] = Get_2;
							dictionary[trees[3]] = Get_3;
							dictionary[trees[4]] = Get_4;
							dictionary[trees[5]] = Get_5;
						}
						
						public FormulaEditor.GetValue this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue> dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, FormulaEditor.GetValue>();
						
						DataPerformer.Interfaces.IMeasurement measurement0;
						Diagram.UI.Interfaces.IAliasName aliasName1;
						DataPerformer.Interfaces.IMeasurement measurement3;
						DataPerformer.Interfaces.IMeasurement measurement4;
						FormulaEditor.ObjectFormulaTree currentTree = null;
						object[] currentArray = null;
						double doubleValue = 0;
						FormulaEditor.ObjectFormulaTree[] trees = null;
						double var_0 = 0;
						double var_1 = 0;
						bool var_2 = false;
						double var_3 = 0;
						double var_4 = 0;
						double var_5 = 0;
						
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
					
					}
				}
			}
		
			internal class OblectLabel13 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel13.CategoryObject();
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
							objects.Add(new IntrenalDesktop.OblectLabel13.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel13.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel13.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel13.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel13.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel13.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../Relative to station.x",
										"y = ../Relative to station.Vx"
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
		
			internal class OblectLabel14 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel14.CategoryObject();
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
							objects.Add(new IntrenalDesktop.OblectLabel14.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new IntrenalDesktop.OblectLabel14.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new IntrenalDesktop.OblectLabel14.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new IntrenalDesktop.OblectLabel14.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new IntrenalDesktop.OblectLabel14.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new IntrenalDesktop.OblectLabel14.CategoryObject.Desktop.ArrowLabel2("", this);
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
										"x = ../Relative to station.y",
										"y = ../Relative to station.Vy"
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
		
			internal class OblectLabel15 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel15(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel15.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
				}
				}
			}
		
			internal class OblectLabel16 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel16.CategoryObject();
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
				, -1
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
		
			internal class OblectLabel17 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel17.CategoryObject();
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
				, -0.10000000000000001
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
		
			internal class OblectLabel18 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel18.CategoryObject();
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
				, 0.01
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
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
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
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
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
		
				internal class CategoryArrow : Motion6D.Portable.ReferenceFrameArrow
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
		
			internal class ArrowLabel13 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel13.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
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
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel16 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel16.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel17 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel17.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel18 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel18.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel19 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel19(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel19.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel20 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel20(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel20.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel21 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel21(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel21.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel22 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel22(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel22.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel23 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel23(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel23.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel24 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel24(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel24.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel25 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel25(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel25.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel26 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel26(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel26.CategoryArrow();
				}
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
				{
				}
			}
		
			internal class ArrowLabel27 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel27(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel27.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel28 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel28(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel28.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel29 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel29(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel29.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel30 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel30(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel30.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel31 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel31(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel31.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
		}
		
	}
}
