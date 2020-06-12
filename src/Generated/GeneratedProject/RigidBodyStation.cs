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
				objects.Add(new IntrenalDesktop.OblectLabel5("Consumer", this));
				objects.Add(new IntrenalDesktop.OblectLabel6("Shifted Frame", this));
				Diagram.UI.Labels.PureArrowLabel currALabel = null;
				currALabel  = new IntrenalDesktop.ArrowLabel0("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel1("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)1;
				currALabel  = new IntrenalDesktop.ArrowLabel2("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)3;
				currALabel.TargetNumber = (int)2;
				currALabel  = new IntrenalDesktop.ArrowLabel3("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)4;
				currALabel  = new IntrenalDesktop.ArrowLabel4("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)3;
				currALabel  = new IntrenalDesktop.ArrowLabel5("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)0;
				currALabel  = new IntrenalDesktop.ArrowLabel6("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)6;
				currALabel.TargetNumber = (int)4;
				currALabel  = new IntrenalDesktop.ArrowLabel7("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)2;
				currALabel.TargetNumber = (int)6;
				currALabel  = new IntrenalDesktop.ArrowLabel8("", this);
				arrows.Add(currALabel);
				currALabel.SourceNumber = (int)5;
				currALabel.TargetNumber = (int)2;
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
				, 0
				, 0
				, 0
				, 0
				, 1
				, 0
				, 0
				, 0
				, 0.10000000000000001
				, 0.10000000000000001
				, 1
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
		
				internal class CategoryObject : DataPerformer.Portable.DataConsumer
				{
				internal CategoryObject() : base(0)
				{
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
		
				internal class CategoryArrow : Motion6D.Portable.RelativeMeasurementsLink
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
		
		}
		
	}
}
