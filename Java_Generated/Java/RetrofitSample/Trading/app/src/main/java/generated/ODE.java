package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class ODE extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			setMap(map);
					Object o;
					o = new double[0];
					addVariableValue("Formula_1", o);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])aliasName0.getAliasNameValue())[0];
						if (check(var_0)) { success = false; return; }
						var_1[0] = ((double[])aliasName1.getAliasNameValue())[0];
						if (check(var_1)) { success = false; return; }
						var_2[0] = this.getInternalTime();
						var_3[0] = ((var_1[0]) * (var_2[0]));
						if (check(var_3)) { success = false; return; } 
						var_4[0] = (Math.sin(var_3[0]));
						if (check(var_4)) { success = false; return; } 
						var_5[0] = ((var_0[0]) * (var_4[0]));
						if (check(var_5)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					aliasName0 = new general_service.AliasName(this, "a");
					aliasName1 = new general_service.AliasName(this, "b");
				}
				
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IAliasName aliasName1;
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
					x0.setIValue(this.get_5());
				}
				
			}
	

	protected class CategoryObject1 extends measurements.differential_equations.DifferentialEquationSolverFormula
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			map.put("x", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
			map.put("y", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
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
						var_0[0] = ((double[])aliasName0.getAliasNameValue())[0];
						if (check(var_0)) { success = false; return; }
						var_1[0] = ( -(var_0[0]));
						if (check(var_1)) { success = false; return; } 
						variable = value2.getIValue();
						if (check(variable)) { success = false; return; }
						var_2[0] = ((double[])variable)[0];
						var_3[0] = ((var_1[0]) * (var_2[0]));
						if (check(var_3)) { success = false; return; } 
						variable = value4.getIValue();
						if (check(variable)) { success = false; return; }
						var_4[0] = ((double[])variable)[0];
						var_5[0] = ((var_0[0]) * (var_4[0]));
						if (check(var_5)) { success = false; return; } 
						var_6[0] = ((double[])measurement6.getMeasurementValue())[0];
						if (check(var_6)) { success = false; return; } 
						var_7[0] = ((var_5[0]) + (var_6[0]));
						if (check(var_7)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					value2 = this.output[1];
					value4 = this.output[0];
					measurement6 = all[0].getMeasurement(0);
					aliasName0 = new general_service.AliasName(this, "a");
				}
				
				general_service.interfaces.IValue  value2;
				general_service.interfaces.IValue  value4;
				measurements.interfaces.IMeasurement measurement6;
				general_service.interfaces.IAliasName aliasName0;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				double[]  var_5 = new double[]{0};
				double[]  var_6 = new double[]{0};
				double[]  var_7 = new double[]{0};
				
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
				@Override
				protected void save(){
					var v = derivations;
					var x0 = v.get("y");
					x0.setIValue(this.get_7());
					var x1 = v.get("x");
					x1.setIValue(this.get_3());
				}
				
			}
	

	protected class CategoryObject2 extends measurements.DataConsumer
	{
		public CategoryObject2(String name, IDesktop desktop) {
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
	

	public ODE() {
		super();
	}

	public ODE(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new ODE.CategoryObject0("Init", this);
		new ODE.CategoryObject1("ODE", this);
		new ODE.CategoryObject2("Chart", this);
		new ODE.CategoryArrow0("1", this);
		new ODE.CategoryArrow1("", this);
		arrows.get(0).setSource(objects.get(1));
		arrows.get(0).setTarget(objects.get(0));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(1));
		postSet();
	}


}
