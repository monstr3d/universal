package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class ODE_Feed extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{-0.33822685902599364}));
			map.put("l", new general_service.Entry<Object, Object>(new double[0], new double[]{5}));
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{-0.73652631234982491}));
			map.put("k", new general_service.Entry<Object, Object>(new double[0], new double[]{3}));
			setMap(map);
					Object o;
					o = new double[0];
					addVariableValue("Formula_1", o);
					o = new double[0];
					addVariableValue("Formula_2", o);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])aliasName0.getAliasNameValue())[0];
						if (check(var_0)) { success = false; return; }
						var_1[0] = ((double[])aliasName1.getAliasNameValue())[0];
						if (check(var_1)) { success = false; return; }
						var_2[0] = ((var_0[0]) * (var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])aliasName3.getAliasNameValue())[0];
						if (check(var_3)) { success = false; return; }
						var_4[0] = this.getInternalTime();
						var_5[0] = ((var_3[0]) * (var_4[0]));
						if (check(var_5)) { success = false; return; } 
						var_6[0] = (Math.sin(var_5[0]));
						if (check(var_6)) { success = false; return; } 
						var_7[0] = ((var_2[0]) * (var_6[0]));
						if (check(var_7)) { success = false; return; } 
						var_8[0] = ((double[])aliasName8.getAliasNameValue())[0];
						if (check(var_8)) { success = false; return; }
						var_9[0] = ((var_0[0]) * (var_8[0]));
						if (check(var_9)) { success = false; return; } 
						var_10[0] = ((var_3[0]) * (var_4[0]));
						if (check(var_10)) { success = false; return; } 
						var_11[0] = (Math.cos(var_10[0]));
						if (check(var_11)) { success = false; return; } 
						var_12[0] = ((var_9[0]) * (var_11[0]));
						if (check(var_12)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					aliasName0 = new general_service.AliasName(this, "l");
					aliasName1 = new general_service.AliasName(this, "a");
					aliasName3 = new general_service.AliasName(this, "k");
					aliasName8 = new general_service.AliasName(this, "b");
				}
				
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IAliasName aliasName1;
				general_service.interfaces.IAliasName aliasName3;
				general_service.interfaces.IAliasName aliasName8;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				double[]  var_5 = new double[]{0};
				double[]  var_6 = new double[]{0};
				double[]  var_7 = new double[]{0};
				double[]  var_8 = new double[]{0};
				double[]  var_9 = new double[]{0};
				double[]  var_10 = new double[]{0};
				double[]  var_11 = new double[]{0};
				double[]  var_12 = new double[]{0};
				
				Object get_0()
				{
					return success ? this.var_0 : null;
				}
				
				Object get_1()
				{
					return success ? this.var_1 : null;
				}
				
				Object get_2()
				{
					return success ? this.var_2 : null;
				}
				
				Object get_3()
				{
					return success ? this.var_3 : null;
				}
				
				Object get_4()
				{
					return success ? this.var_4 : null;
				}
				
				Object get_5()
				{
					return success ? this.var_5 : null;
				}
				
				Object get_6()
				{
					return success ? this.var_6 : null;
				}
				
				Object get_7()
				{
					return success ? this.var_7 : null;
				}
				
				Object get_8()
				{
					return success ? this.var_8 : null;
				}
				
				Object get_9()
				{
					return success ? this.var_9 : null;
				}
				
				Object get_10()
				{
					return success ? this.var_10 : null;
				}
				
				Object get_11()
				{
					return success ? this.var_11 : null;
				}
				
				Object get_12()
				{
					return success ? this.var_12 : null;
				}
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("Formula_1");
					x0.setIValue(this.get_7());
					var x1 = v.get("Formula_2");
					x1.setIValue(this.get_12());
				}
				
			}
	

	protected class CategoryObject1 extends measurements.differential_equations.DifferentialEquationSolverFormula
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("l", new general_service.Entry<Object, Object>(new double[0], new double[]{0.10000000000000001}));
			map.put("y", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			map.put("x", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
			map.put("k", new general_service.Entry<Object, Object>(new double[0], new double[]{0.10000000000000001}));
			setMap(map);
					Object o;
					o = new double[0];
					addVariableValue("x", o);
					o = new double[0];
					addVariableValue("y", o);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						variable = value0.getIValue();
						if (check(variable)) { success = false; return; }
						var_0[0] = ((double[])variable)[0];
						var_1[0] = ( -(var_0[0]));
						if (check(var_1)) { success = false; return; } 
						var_2[0] = ((double[])aliasName2.getAliasNameValue())[0];
						if (check(var_2)) { success = false; return; }
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_4[0] = ((var_2[0]) * (var_3[0]));
						if (check(var_4)) { success = false; return; } 
						var_5[0] = ((var_1[0]) + (var_4[0]));
						if (check(var_5)) { success = false; return; } 
						variable = value6.getIValue();
						if (check(variable)) { success = false; return; }
						var_6[0] = ((double[])variable)[0];
						var_7[0] = ((double[])aliasName7.getAliasNameValue())[0];
						if (check(var_7)) { success = false; return; }
						var_8[0] = ((double[])measurement8.getMeasurementValue())[0];
						if (check(var_8)) { success = false; return; } 
						var_9[0] = ((var_7[0]) * (var_8[0]));
						if (check(var_9)) { success = false; return; } 
						var_10[0] = ((var_6[0]) - (var_9[0]));
						if (check(var_10)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					value0 = this.output[1];
					measurement3 = all[0].getMeasurement(0);
					value6 = this.output[0];
					measurement8 = all[0].getMeasurement(1);
					aliasName2 = new general_service.AliasName(this, "k");
					aliasName7 = new general_service.AliasName(this, "l");
				}
				
				general_service.interfaces.IValue  value0;
				measurements.interfaces.IMeasurement measurement3;
				general_service.interfaces.IValue  value6;
				measurements.interfaces.IMeasurement measurement8;
				general_service.interfaces.IAliasName aliasName2;
				general_service.interfaces.IAliasName aliasName7;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				double[]  var_5 = new double[]{0};
				double[]  var_6 = new double[]{0};
				double[]  var_7 = new double[]{0};
				double[]  var_8 = new double[]{0};
				double[]  var_9 = new double[]{0};
				double[]  var_10 = new double[]{0};
				
				Object get_0()
				{
					return success ? this.var_0 : null;
				}
				
				Object get_1()
				{
					return success ? this.var_1 : null;
				}
				
				Object get_2()
				{
					return success ? this.var_2 : null;
				}
				
				Object get_3()
				{
					return success ? this.var_3 : null;
				}
				
				Object get_4()
				{
					return success ? this.var_4 : null;
				}
				
				Object get_5()
				{
					return success ? this.var_5 : null;
				}
				
				Object get_6()
				{
					return success ? this.var_6 : null;
				}
				
				Object get_7()
				{
					return success ? this.var_7 : null;
				}
				
				Object get_8()
				{
					return success ? this.var_8 : null;
				}
				
				Object get_9()
				{
					return success ? this.var_9 : null;
				}
				
				Object get_10()
				{
					return success ? this.var_10 : null;
				}
				@Override
				protected void save(){
					var v = derivations;
					var x0 = v.get("y");
					x0.setIValue(this.get_10());
					var x1 = v.get("x");
					x1.setIValue(this.get_5());
				}
				
				@Override
				protected void createFeedback() {
					java.util.List<general_service.Entry<int[], String>> list = new java.util.ArrayList<>();
					list.add(new general_service.Entry(new int[] {0, 0}, "a" ));
					list.add(new general_service.Entry(new int[] {0, 1}, "b" ));
					setFeedback(list);
				}
			}
	

	protected class CategoryObject2 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject2(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			setMap(map);
					Object o;
					o = new double[0];
					addVariableValue("Formula_1", o);
					o = new double[0];
					addVariableValue("Formula_2", o);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])measurement0.getMeasurementValue())[0];
						if (check(var_0)) { success = false; return; } 
						var_1[0] = ((double[])measurement1.getMeasurementValue())[0];
						if (check(var_1)) { success = false; return; } 
						var_2[0] = ((var_0[0]) + (var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_4[0] = ((double[])measurement4.getMeasurementValue())[0];
						if (check(var_4)) { success = false; return; } 
						var_5[0] = ((var_3[0]) - (var_4[0]));
						if (check(var_5)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					measurement0 = all[0].getMeasurement(0);
					measurement1 = all[1].getMeasurement(0);
					measurement3 = all[0].getMeasurement(1);
					measurement4 = all[1].getMeasurement(1);
				}
				
				measurements.interfaces.IMeasurement measurement0;
				measurements.interfaces.IMeasurement measurement1;
				measurements.interfaces.IMeasurement measurement3;
				measurements.interfaces.IMeasurement measurement4;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				double[]  var_5 = new double[]{0};
				
				Object get_0()
				{
					return success ? this.var_0 : null;
				}
				
				Object get_1()
				{
					return success ? this.var_1 : null;
				}
				
				Object get_2()
				{
					return success ? this.var_2 : null;
				}
				
				Object get_3()
				{
					return success ? this.var_3 : null;
				}
				
				Object get_4()
				{
					return success ? this.var_4 : null;
				}
				
				Object get_5()
				{
					return success ? this.var_5 : null;
				}
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("Formula_1");
					x0.setIValue(this.get_2());
					var x1 = v.get("Formula_2");
					x1.setIValue(this.get_5());
				}
				
			}
	

	protected class CategoryObject3 extends measurements.DataConsumer
	{
		public CategoryObject3(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow0 extends measurements.arrows.DataLink
	{
		public CategoryArrow0(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow1 extends measurements.arrows.DataLink
	{
		public CategoryArrow1(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow2 extends measurements.arrows.DataLink
	{
		public CategoryArrow2(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow3 extends measurements.arrows.DataLink
	{
		public CategoryArrow3(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow4 extends measurements.arrows.DataLink
	{
		public CategoryArrow4(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	public ODE_Feed() {
		super();
	}

	public ODE_Feed(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new ODE_Feed.CategoryObject0("X", this);
		new ODE_Feed.CategoryObject1("Diff", this);
		new ODE_Feed.CategoryObject2("Y", this);
		new ODE_Feed.CategoryObject3("Chart", this);
		new ODE_Feed.CategoryArrow0("", this);
		new ODE_Feed.CategoryArrow1("", this);
		new ODE_Feed.CategoryArrow2("", this);
		new ODE_Feed.CategoryArrow3("", this);
		new ODE_Feed.CategoryArrow4("", this);
		arrows.get(0).setSource(objects.get(1));
		arrows.get(0).setTarget(objects.get(0));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(1));
		arrows.get(2).setSource(objects.get(2));
		arrows.get(2).setTarget(objects.get(0));
		arrows.get(3).setSource(objects.get(3));
		arrows.get(3).setTarget(objects.get(1));
		arrows.get(4).setSource(objects.get(3));
		arrows.get(4).setTarget(objects.get(2));
		postSet();
	}


}
