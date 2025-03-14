using System;
using System.Collections.Generic;
using System.Linq;



namespace GeneratedProject
{
	public static class RigidBodyStation
	{

		 static public bool SuccessLoad { get; private set; } = true;

		public static  Diagram.UI.Interfaces.IDesktop Desktop { get => new InternalDesktop(); }

		internal class InternalDesktop : Diagram.UI.PureDesktop
		{
			internal InternalDesktop()
			{
				objects.Add(new InternalDesktop.OblectLabel0("Force", this));
				objects.Add(new InternalDesktop.OblectLabel1("Timer", this));
				objects.Add(new InternalDesktop.OblectLabel2("Relative to station", this));
				objects.Add(new InternalDesktop.OblectLabel3("Rigid Body", this));
				objects.Add(new InternalDesktop.OblectLabel4("Station frame", this));
				objects.Add(new InternalDesktop.OblectLabel5("X-Frame", this));
				objects.Add(new InternalDesktop.OblectLabel6("X-Control 1", this));
				objects.Add(new InternalDesktop.OblectLabel7("Calculations", this));
				objects.Add(new InternalDesktop.OblectLabel8("Oz-Control", this));
				objects.Add(new InternalDesktop.OblectLabel9("Dist short", this));
				objects.Add(new InternalDesktop.OblectLabel10("Light", this));
				objects.Add(new InternalDesktop.OblectLabel11("X-Frame-1", this));
				objects.Add(new InternalDesktop.OblectLabel12("Ox-Control", this));
				objects.Add(new InternalDesktop.OblectLabel13("Fuel rate", this));
				objects.Add(new InternalDesktop.OblectLabel14("Oy-Control", this));
				objects.Add(new InternalDesktop.OblectLabel15("X-Control 2", this));
				objects.Add(new InternalDesktop.OblectLabel16("Oz-Control 1", this));
				objects.Add(new InternalDesktop.OblectLabel17("Z-Control", this));
				objects.Add(new InternalDesktop.OblectLabel18("Y-Control", this));
				objects.Add(new InternalDesktop.OblectLabel19("Consumer", this));
				objects.Add(new InternalDesktop.OblectLabel20("Shifted Frame", this));
				objects.Add(new InternalDesktop.OblectLabel21("Aim 1", this));
				objects.Add(new InternalDesktop.OblectLabel22("Aim 2", this));
				objects.Add(new InternalDesktop.OblectLabel23("Fuel over", this));
				objects.Add(new InternalDesktop.OblectLabel24("Dist long", this));
				objects.Add(new InternalDesktop.OblectLabel25("Start Event", this));
				objects.Add(new InternalDesktop.OblectLabel26("Time over", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new InternalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)20;
				currALabel.TargetNumber = (int)4;
				currALabel  = new InternalDesktop.ArrowLabel3("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel4("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)21;
				currALabel.TargetNumber = (int)20;
				currALabel  = new InternalDesktop.ArrowLabel5("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel6("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel7("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)22;
				currALabel.TargetNumber = (int)20;
				currALabel  = new InternalDesktop.ArrowLabel8("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)6,"Mod" };
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel9("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)15,"Mod" };
				currALabel.TargetNumber = (int)11;
				currALabel  = new InternalDesktop.ArrowLabel10("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)6,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel11("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)15,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel12("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)18,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel13("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)18,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel14("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)17,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel15("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)17,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel16("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)8,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel17("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)8,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel18("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)16;
				currALabel.TargetNumber = new object[] {(int)8,"Mod" };
				currALabel  = new InternalDesktop.ArrowLabel19("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)16;
				currALabel.TargetNumber = new object[] {(int)8,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel20("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)16;
				currALabel  = new InternalDesktop.ArrowLabel21("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)20;
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel22("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)3;
				currALabel  = new InternalDesktop.ArrowLabel23("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)11;
				currALabel.TargetNumber = (int)3;
				currALabel  = new InternalDesktop.ArrowLabel24("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)3;
				currALabel  = new InternalDesktop.ArrowLabel25("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)21;
				currALabel.TargetNumber = (int)5;
				currALabel  = new InternalDesktop.ArrowLabel26("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)22;
				currALabel.TargetNumber = (int)11;
				currALabel  = new InternalDesktop.ArrowLabel27("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)14,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel28("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = new object[] {(int)12,"Epsilon" };
				currALabel  = new InternalDesktop.ArrowLabel29("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)12,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel30("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = new object[] {(int)14,"Mod" };
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel31("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)11;
				currALabel  = new InternalDesktop.ArrowLabel32("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)13;
				currALabel.TargetNumber = (int)0;
				currALabel  = new InternalDesktop.ArrowLabel33("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)13;
				currALabel  = new InternalDesktop.ArrowLabel34("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)13;
				currALabel.TargetNumber = (int)10;
				currALabel  = new InternalDesktop.ArrowLabel35("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)23;
				currALabel.TargetNumber = (int)13;
				currALabel  = new InternalDesktop.ArrowLabel36("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)23;
				currALabel  = new InternalDesktop.ArrowLabel37("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)23;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel38("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)7;
				currALabel.TargetNumber = (int)2;
				currALabel  = new InternalDesktop.ArrowLabel39("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)9;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel40("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)24;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel41("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)9;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel42("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)24;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel43("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)9;
				currALabel  = new InternalDesktop.ArrowLabel44("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)24;
				currALabel  = new InternalDesktop.ArrowLabel45("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)25;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel46("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)26;
				currALabel.TargetNumber = (int)7;
				currALabel  = new InternalDesktop.ArrowLabel47("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)25;
				currALabel  = new InternalDesktop.ArrowLabel48("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)19;
				currALabel.TargetNumber = (int)26;
				currALabel  = new InternalDesktop.ArrowLabel49("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)25;
				currALabel.TargetNumber = (int)1;
				currALabel  = new InternalDesktop.ArrowLabel50("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)26;
				currALabel.TargetNumber = (int)1;
				bool pl = PostLoad();
				bool pd = PostDeserialize();
				SuccessLoad = pl & pd;
				PostLoad(this);
				Name = "RigidBodyStation"; 
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
					obj = new OblectLabel6.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel6.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel6.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel6.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel6.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel6.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel6.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										{"a", (double)50000 },
										{"b", (double)50000 }
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"x\" S=\"x\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"c\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>",
							"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"d\" S=\"d\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"-\" S=\"-\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"t\" S=\"t\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>"
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"x = Relative to station.Distance",
							"t = Time"
						};
						parameters =new Dictionary<string, object>()
						{
							{"d", (double)0 },
							{"a", (double)10 },
							{"c", (double)1 },
							{"b", (double)20 }
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
							variable = measurement1.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_1 = (double)variable;
							variable = aliasName2.Value;
							if (checkValue(variable)) { success = false; return; }
							var_2 = (double)variable;
							var_3 = (var_1) - (var_2);
							variable = aliasName4.Value;
							if (checkValue(variable)) { success = false; return; }
							var_4 = (double)variable;
							var_5 = (var_1) - (var_4);
							variable = aliasName6.Value;
							if (checkValue(variable)) { success = false; return; }
							var_6 = (double)variable;
							var_7 = (var_6) - (var_0);
							variable = aliasName8.Value;
							if (checkValue(variable)) { success = false; return; }
							var_8 = (double)variable;
							var_9 = (var_8) - (var_0);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
							measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
							aliasName2 = dataPerformerFormula.ToAliasName(trees[2]);
							aliasName4 = dataPerformerFormula.ToAliasName(trees[4]);
							aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
							aliasName8 = dataPerformerFormula.ToAliasName(trees[8]);
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
						DataPerformer.Interfaces.IMeasurement measurement1;
						Diagram.UI.Interfaces.IAliasName aliasName2;
						Diagram.UI.Interfaces.IAliasName aliasName4;
						Diagram.UI.Interfaces.IAliasName aliasName6;
						Diagram.UI.Interfaces.IAliasName aliasName8;
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
		
			internal class OblectLabel8 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel8(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel8.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel8.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel8.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel8.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel8.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel8.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel8.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										{"a", (double)50000 },
										{"b", (double)50000 }
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
		
			internal class OblectLabel9 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel9(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel9.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.ThresholdEvent
				{
				internal CategoryObject()
				{
					Type = (double)0;
					Measurement = "Calculations.Formula_2";
					Decrease = true;
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
		
				internal class CategoryObject : Event.Portable.Events.ForcedEventData
				{
				internal CategoryObject()
				{
					List<Tuple<string, object>> tt = new List<Tuple<string, object>>();
					tt.Add(new Tuple<string, object>("Value", (System.Double)0));
					Types = tt;
					List<object> ini = new List<object>();
					ini.Add((System.Double)0);
					initial = new object[ini.Count];
					for (int i = 0; i < ini.Count; i++)
					{
						initial[i] = ini[i];
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
		
				internal class CategoryObject : Motion6D.Portable.RelativeMeasurements
				{
				}
			}
		
			internal class OblectLabel12 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel12(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel12.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel12.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel12.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel12.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel12.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel12.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel12.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										{"a", (double)500000 },
										{"b", (double)500000 }
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
		
			internal class OblectLabel13 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel13(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel13.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Formula.DifferentialEquationSolver, FormulaEditor.Interfaces.ITreeCollectionProxyFactory
				{
				
					internal CategoryObject()
					{
						proxyFactory = this;
						aliasNames  = new Dictionary<object, object>()
						{
						};
				
						feedback = new Dictionary<int, string>()
						{
						};
				
						vars = new Dictionary<object, object>()
						{
										{'y' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"o\" S=\"o\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"q\" S=\"q\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>  </F></Root>" , (System.Double)(1)}}
							,			{'x' , new object[] {"<Root>  <F>    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"a\" S=\"a\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"h\" S=\"h\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"b\" S=\"b\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"i\" S=\"i\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"c\" S=\"c\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"j\" S=\"j\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"d\" S=\"d\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"k\" S=\"k\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"f\" S=\"f\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"l\" S=\"l\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>    <S type=\"FormulaEditor.Symbols.BinarySymbol\" symbol=\"+\" S=\"+\" Type=\"3\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"0\" Bold=\"1\" Sb=\"\" />    <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"g\" S=\"g\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">      <F />    </S>    <S type=\"FormulaEditor.Symbols.AbsSymbol\" symbol=\"M\" S=\"| |\" Type=\"2\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"M\">      <F>        <S type=\"FormulaEditor.Symbols.SimpleSymbol\" symbol=\"m\" S=\"m\" Type=\"1\" Index=\"1\" Level=\"0\" DoubleValue=\"0\" UlongValue=\"0\" BoolValue=\"False\" Italic=\"1\" Bold=\"1\" Sb=\"\">          <F />        </S>      </F>      <F />    </S>  </F></Root>" , (System.Double)(1)}}
						};
						pars = new Dictionary<object, object>()
						{
										{'m' , "Force.Mz"}
							,			{'l' , "Force.My"}
							,			{'k' , "Force.Mx"}
							,			{'j' , "Force.Fz"}
							,			{'i' , "Force.Fy"}
							,			{'q' , "Light.Value"}
							,			{'h' , "Force.Fx"}
						};
						aliases = new Dictionary<object, object>()
						{
										{"b" , (System.Double)(-0.01)}
							,			{"a" , (System.Double)(-0.01)}
							,			{"x" , (System.Double)(1)}
							,			{"d" , (System.Double)(-0.01)}
							,			{"y" , (System.Double)(1)}
							,			{"c" , (System.Double)(-0.01)}
							,			{"f" , (System.Double)(-0.01)}
							,			{"o" , (System.Double)(-0.01)}
							,			{"g" , (System.Double)(-0.01)}
						};
						isSerialized = true;
						calculateDerivation = false;
						deriOrder = 0;
						arguments =  new List<string>()
						{
							"h = Force.Fx",
							"i = Force.Fy",
							"j = Force.Fz",
							"k = Force.Mx",
							"l = Force.My",
							"m = Force.Mz",
							"q = Light.Value"
						};
					}
					FormulaEditor.Interfaces.ITreeCollectionProxy FormulaEditor.Interfaces.ITreeCollectionProxyFactory.CreateProxy(FormulaEditor.Interfaces.ITreeCollection collection, Func<object, bool> checkValue)
					{
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = new (this);
						FormulaEditor.Interfaces.ITreeCollection f = this;
						FormulaEditor.ObjectFormulaTree[] trees = FormulaEditor.StaticExtensionFormulaEditor.Transform(f.Trees);
						return new Calculation(trees, checkValue, dataPerformerFormula);
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
							variable = measurement1.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_1 = (double)variable;
							var_2 = Math.Abs(var_1);
							var_3 = (var_0) * (var_2);
							variable = aliasName4.Value;
							if (checkValue(variable)) { success = false; return; }
							var_4 = (double)variable;
							variable = measurement5.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_5 = (double)variable;
							var_6 = Math.Abs(var_5);
							var_7 = (var_4) * (var_6);
							var_8 = (var_3) + (var_7);
							variable = aliasName9.Value;
							if (checkValue(variable)) { success = false; return; }
							var_9 = (double)variable;
							variable = measurement10.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_10 = (double)variable;
							var_11 = Math.Abs(var_10);
							var_12 = (var_9) * (var_11);
							var_13 = (var_8) + (var_12);
							variable = aliasName14.Value;
							if (checkValue(variable)) { success = false; return; }
							var_14 = (double)variable;
							variable = measurement15.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_15 = (double)variable;
							var_16 = Math.Abs(var_15);
							var_17 = (var_14) * (var_16);
							var_18 = (var_13) + (var_17);
							variable = aliasName19.Value;
							if (checkValue(variable)) { success = false; return; }
							var_19 = (double)variable;
							variable = measurement20.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_20 = (double)variable;
							var_21 = Math.Abs(var_20);
							var_22 = (var_19) * (var_21);
							var_23 = (var_18) + (var_22);
							variable = aliasName24.Value;
							if (checkValue(variable)) { success = false; return; }
							var_24 = (double)variable;
							variable = measurement25.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_25 = (double)variable;
							var_26 = Math.Abs(var_25);
							var_27 = (var_24) * (var_26);
							var_28 = (var_23) + (var_27);
							variable = aliasName29.Value;
							if (checkValue(variable)) { success = false; return; }
							var_29 = (double)variable;
							variable = measurement30.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_30 = (double)variable;
							var_31 = (var_29) * (var_30);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
							measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
							aliasName4 = dataPerformerFormula.ToAliasName(trees[4]);
							measurement5 = dataPerformerFormula.ToMeasurement(trees[5]);
							aliasName9 = dataPerformerFormula.ToAliasName(trees[9]);
							measurement10 = dataPerformerFormula.ToMeasurement(trees[10]);
							aliasName14 = dataPerformerFormula.ToAliasName(trees[14]);
							measurement15 = dataPerformerFormula.ToMeasurement(trees[15]);
							aliasName19 = dataPerformerFormula.ToAliasName(trees[19]);
							measurement20 = dataPerformerFormula.ToMeasurement(trees[20]);
							aliasName24 = dataPerformerFormula.ToAliasName(trees[24]);
							measurement25 = dataPerformerFormula.ToMeasurement(trees[25]);
							aliasName29 = dataPerformerFormula.ToAliasName(trees[29]);
							measurement30 = dataPerformerFormula.ToMeasurement(trees[30]);
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
						}
						
						public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
						
						Diagram.UI.Interfaces.IAliasName aliasName0;
						DataPerformer.Interfaces.IMeasurement measurement1;
						Diagram.UI.Interfaces.IAliasName aliasName4;
						DataPerformer.Interfaces.IMeasurement measurement5;
						Diagram.UI.Interfaces.IAliasName aliasName9;
						DataPerformer.Interfaces.IMeasurement measurement10;
						Diagram.UI.Interfaces.IAliasName aliasName14;
						DataPerformer.Interfaces.IMeasurement measurement15;
						Diagram.UI.Interfaces.IAliasName aliasName19;
						DataPerformer.Interfaces.IMeasurement measurement20;
						Diagram.UI.Interfaces.IAliasName aliasName24;
						DataPerformer.Interfaces.IMeasurement measurement25;
						Diagram.UI.Interfaces.IAliasName aliasName29;
						DataPerformer.Interfaces.IMeasurement measurement30;
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
						
						Func<object, bool> checkValue = (o) => false;
						object variable;
						bool success = true;
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
					
					}
				}
			}
		
			internal class OblectLabel14 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel14(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel14.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel14.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel14.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel14.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel14.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel14.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel14.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										{"a", (double)500000 },
										{"b", (double)500000 }
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
					obj = new OblectLabel15.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel15.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel15.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel15.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel15.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel15.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel15.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
		
			internal class OblectLabel16 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel16(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel16.CategoryObject();
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
							var_2 = (var_0) > (var_1);
							variable = measurement3.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_3 = (double)variable;
							variable = measurement4.Parameter();
							if (checkValue(variable)) { success = false; return; }
							var_4 = (double)variable;
							var_5 = (var_2) ? (var_3) : (var_4);
						}
						
						internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
						{
							success = true;
							this.trees = trees;
							this.checkValue = checkValue;
							this.dataPerformerFormula = dataPerformerFormula;
							measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
							aliasName1 = dataPerformerFormula.ToAliasName(trees[1]);
							measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
							measurement4 = dataPerformerFormula.ToMeasurement(trees[4]);
							dictionary[trees[0]] = Get_0;
							dictionary[trees[1]] = Get_1;
							dictionary[trees[2]] = Get_2;
							dictionary[trees[3]] = Get_3;
							dictionary[trees[4]] = Get_4;
							dictionary[trees[5]] = Get_5;
						}
						
						public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
						{ get { return dictionary[tree]; }}
						
						Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
						
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
						
						Func<object, bool> checkValue = (o) => false;
						object variable;
						bool success = true;
						DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
					
					}
				}
			}
		
			internal class OblectLabel17 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel17(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel17.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel17.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel17.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel17.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel17.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel17.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel17.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										{"a", (double)50000 },
										{"b", (double)50000 }
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
		
			internal class OblectLabel18 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel18(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel18.CategoryObject(this);
					obj.Object = this;
				}
		
				internal class CategoryObject : Diagram.UI.Portable.ObjectContainer
				{
					internal CategoryObject(Diagram.UI.Labels.IObjectLabel label) : base(null)
					{
						Object = label;
						desktop = new Desktop(this);
						Load();
					}
				
					new internal class Desktop : Diagram.UI.PureDesktop
					{
						internal Desktop()
						{
							objects.Add(new InternalDesktop.OblectLabel18.CategoryObject.Desktop.OblectLabel0("Mod", this));
							objects.Add(new InternalDesktop.OblectLabel18.CategoryObject.Desktop.OblectLabel1("Force", this));
							objects.Add(new InternalDesktop.OblectLabel18.CategoryObject.Desktop.OblectLabel2("Epsilon", this));
							Diagram.UI.Labels.PureArrowLabel currALabel = null;
							currALabel  = new InternalDesktop.OblectLabel18.CategoryObject.Desktop.ArrowLabel0("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)1;
							currALabel.TargetNumber = (int)0;
							currALabel  = new InternalDesktop.OblectLabel18.CategoryObject.Desktop.ArrowLabel1("", this);
							arrows.Add(currALabel);
							currALabel.SourceNumber = (int)2;
							currALabel.TargetNumber = (int)1;
							currALabel  = new InternalDesktop.OblectLabel18.CategoryObject.Desktop.ArrowLabel2("", this);
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
										var_1 = Math.Abs(var_0);
										variable = measurement2.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_2 = (double)variable;
										var_4 = Math.Pow(var_2, var_3);
										variable = aliasName6.Value;
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_7 = (var_5) * (var_6);
										var_8 = (var_4) / (var_7);
										var_9 = (var_1) > (var_8);
										var_11 = (var_0) > (var_10);
										variable = measurement12.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_12 = (double)variable;
										var_14 = (var_12) > (var_13);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement2 = dataPerformerFormula.ToMeasurement(trees[2]);
										aliasName6 = dataPerformerFormula.ToAliasName(trees[6]);
										measurement12 = dataPerformerFormula.ToMeasurement(trees[12]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
										var_0 = (bool)variable;
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (bool)variable;
										var_2 = (var_0) & (var_1);
										variable = measurement3.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_3 = (double)variable;
										var_4 = -(var_3);
										var_5 = !var_0;
										var_6 = !var_1;
										var_7 = (var_5) & (var_6);
										variable = measurement8.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_8 = (bool)variable;
										var_9 = -(var_3);
										var_10 = (var_8) ? (var_9) : (var_3);
										var_11 = -(var_3);
										var_12 = (var_8) ? (var_3) : (var_11);
										var_13 = (var_0) ? (var_10) : (var_12);
										var_14 = (var_7) ? (var_3) : (var_13);
										var_15 = (var_2) ? (var_4) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										measurement0 = dataPerformerFormula.ToMeasurement(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										measurement3 = dataPerformerFormula.ToMeasurement(trees[3]);
										measurement8 = dataPerformerFormula.ToMeasurement(trees[8]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
									DataPerformer.Interfaces.IMeasurement measurement0;
									DataPerformer.Interfaces.IMeasurement measurement1;
									DataPerformer.Interfaces.IMeasurement measurement3;
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
									
									Func<object, bool> checkValue = (o) => false;
									object variable;
									bool success = true;
									DataPerformer.Formula.DataPerformerFormula dataPerformerFormula = null;
								
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
										{"a", (double)50000 },
										{"b", (double)50000 }
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
										variable = measurement1.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_1 = (double)variable;
										var_3 = Math.Pow(var_1, var_2);
										var_4 = (var_0) * (var_3);
										variable = aliasName5.Value;
										if (checkValue(variable)) { success = false; return; }
										var_5 = (double)variable;
										variable = measurement6.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_6 = (double)variable;
										var_8 = Math.Pow(var_6, var_7);
										var_9 = (var_5) * (var_8);
										var_10 = (var_4) + (var_9);
										var_12 = (var_10) < (var_11);
										variable = measurement14.Parameter();
										if (checkValue(variable)) { success = false; return; }
										var_14 = (double)variable;
										var_15 = (var_12) ? (var_13) : (var_14);
									}
									
									internal  Calculation(FormulaEditor.ObjectFormulaTree[] trees, Func<object, bool> checkValue, DataPerformer.Formula.DataPerformerFormula dataPerformerFormula)
									{
										success = true;
										this.trees = trees;
										this.checkValue = checkValue;
										this.dataPerformerFormula = dataPerformerFormula;
										aliasName0 = dataPerformerFormula.ToAliasName(trees[0]);
										measurement1 = dataPerformerFormula.ToMeasurement(trees[1]);
										aliasName5 = dataPerformerFormula.ToAliasName(trees[5]);
										measurement6 = dataPerformerFormula.ToMeasurement(trees[6]);
										measurement14 = dataPerformerFormula.ToMeasurement(trees[14]);
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
									
									public Func<object> this[FormulaEditor.ObjectFormulaTree tree]
									{ get { return dictionary[tree]; }}
									
									Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> > dictionary = new Dictionary<FormulaEditor.ObjectFormulaTree, Func<object> >();
									
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
		
			internal class OblectLabel19 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel19(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel19.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
				}
				}
			}
		
			internal class OblectLabel20 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel20(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel20.CategoryObject();
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
				, -0.80000000000000004
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
		
			internal class OblectLabel21 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel21(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel21.CategoryObject();
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
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel22 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel22(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel22.CategoryObject();
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
				
						Init();
					}
				
				}
				
			}
		
			internal class OblectLabel23 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel23(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel23.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.ThresholdEvent
				{
				internal CategoryObject()
				{
					Type = (double)0;
					Measurement = "Fuel rate.x";
					Decrease = true;
					}
				}
			}
		
			internal class OblectLabel24 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel24(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel24.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.ThresholdEvent
				{
				internal CategoryObject()
				{
					Type = (double)0;
					Measurement = "Calculations.Formula_3";
					Decrease = true;
					}
				}
			}
		
			internal class OblectLabel25 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel25(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel25.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.ThresholdEvent
				{
				internal CategoryObject()
				{
					Type = (double)0;
					Measurement = "Calculations.Formula_4";
					Decrease = true;
					}
				}
			}
		
			internal class OblectLabel26 : Diagram.UI.Labels.PureObjectLabel
			{
				internal OblectLabel26(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					obj = new OblectLabel26.CategoryObject();
					obj.Object = this;
				}
		
				internal class CategoryObject : Event.Portable.Events.ThresholdEvent
				{
				internal CategoryObject()
				{
					Type = (double)0;
					Measurement = "Calculations.Formula_5";
					Decrease = true;
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
		
			internal class ArrowLabel32 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel32(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel32.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel33 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel33(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel33.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel34 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel34(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel34.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel35 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel35(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel35.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel36 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel36(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel36.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.Portable.BelongsToCollection
				{
				}
			}
		
			internal class ArrowLabel37 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel37(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel37.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel38 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel38(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel38.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel39 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel39(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel39.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel40 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel40(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel40.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel41 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel41(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel41.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel42 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel42(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel42.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel43 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel43(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel43.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.Portable.BelongsToCollection
				{
				}
			}
		
			internal class ArrowLabel44 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel44(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel44.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.Portable.BelongsToCollection
				{
				}
			}
		
			internal class ArrowLabel45 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel45(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel45.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel46 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel46(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel46.CategoryArrow();
				}
		
				internal class CategoryArrow : DataPerformer.Portable.DataLink
				{
				}
			}
		
			internal class ArrowLabel47 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel47(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel47.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.Portable.BelongsToCollection
				{
				}
			}
		
			internal class ArrowLabel48 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel48(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel48.CategoryArrow();
				}
		
				internal class CategoryArrow : Diagram.UI.Portable.BelongsToCollection
				{
				}
			}
		
			internal class ArrowLabel49 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel49(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel49.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
			internal class ArrowLabel50 : Diagram.UI.Labels.PureArrowLabel
			{
				internal ArrowLabel50(string name, Diagram.UI.Interfaces.IDesktop desktop) : base(name, "", "", 0, 0)
				{
					this.desktop = desktop;
					arrow = new ArrowLabel50.CategoryArrow();
				}
		
				internal class CategoryArrow : Event.Portable.Arrows.EventLink
				{
				}
			}
		
		}
		
	}
}
