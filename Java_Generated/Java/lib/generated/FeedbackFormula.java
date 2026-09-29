package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class FeedbackFormula extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{2}));
			map.put("f", new general_service.Entry<Object, Object>(new double[0], new double[]{4}));
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{5.1027395021932582}));
			map.put("c", new general_service.Entry<Object, Object>(new double[0], new double[]{3}));
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
						var_2[0] = ((var_0[0]) + (var_1[0]));
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
						var_9[0] = ((var_8[0]) * (var_4[0]));
						if (check(var_9)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					aliasName0 = new general_service.AliasName(this, "a");
					aliasName1 = new general_service.AliasName(this, "b");
					aliasName3 = new general_service.AliasName(this, "c");
					aliasName8 = new general_service.AliasName(this, "f");
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
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("Formula_1");
					x0.setIValue(this.get_7());
					var x1 = v.get("Formula_2");
					x1.setIValue(this.get_9());
				}
				
			}
	

	protected class CategoryObject1 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("k", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
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
						var_1[0] = ((double[])measurement1.getMeasurementValue())[0];
						if (check(var_1)) { success = false; return; } 
						var_2[0] = ((var_0[0]) * (var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_4[0] = ((var_0[0]) * (var_3[0]));
						if (check(var_4)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					measurement1 = all[0].getMeasurement(0);
					measurement3 = all[0].getMeasurement(1);
					aliasName0 = new general_service.AliasName(this, "k");
				}
				
				measurements.interfaces.IMeasurement measurement1;
				measurements.interfaces.IMeasurement measurement3;
				general_service.interfaces.IAliasName aliasName0;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				
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
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("Formula_1");
					x0.setIValue(this.get_2());
					var x1 = v.get("Formula_2");
					x1.setIValue(this.get_4());
				}
				
				@Override
				protected void createFeedback() {
					java.util.List<general_service.Entry<int[], String>> list = new java.util.ArrayList<>();
					list.add(new general_service.Entry(new int[] {0, 0}, "a" ));
					setFeedback(list);
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
	

	public FeedbackFormula() {
		super();
	}

	public FeedbackFormula(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new FeedbackFormula.CategoryObject0("X", this);
		new FeedbackFormula.CategoryObject1("Y", this);
		new FeedbackFormula.CategoryObject2("Chart", this);
		new FeedbackFormula.CategoryArrow0("", this);
		new FeedbackFormula.CategoryArrow1("", this);
		arrows.get(0).setSource(objects.get(1));
		arrows.get(0).setTarget(objects.get(0));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(1));
		postSet();
	}


}
