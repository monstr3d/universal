package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class PI extends Desktop
{

	protected class CategoryObject0 extends measurements.RandomGenerator
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryObject1 extends measurements.RandomGenerator
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryObject2 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject2(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("f", new general_service.Entry<Object, Object>(new double[0], new double[]{0.0040000000000000001}));
			setMap(map);
					Object o;
					o = new double[0];
					addVariableValue("Formula_1", o);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])measurement0.getMeasurementValue())[0];
						if (check(var_0)) { success = false; return; } 
						var_2[0] = (Math.pow(var_0[0], var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_5[0] = (Math.pow(var_3[0], var_4[0]));
						if (check(var_5)) { success = false; return; } 
						var_6[0] = ((var_2[0]) + (var_5[0]));
						if (check(var_6)) { success = false; return; } 
						var_8[0] = ((var_6[0]) > (var_7[0]));
						if (check(var_8)) { success = false; return; } 
						var_10[0] = ((double[])aliasName10.getAliasNameValue())[0];
						if (check(var_10)) { success = false; return; }
						var_11[0] = ((var_8[0]) ? (var_9[0]) : (var_10[0]));
						if (check(var_11)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					measurement0 = all[0].getMeasurement(0);
					measurement3 = all[1].getMeasurement(0);
					aliasName10 = new general_service.AliasName(this, "f");
				}
				
				measurements.interfaces.IMeasurement measurement0;
				measurements.interfaces.IMeasurement measurement3;
				general_service.interfaces.IAliasName aliasName10;
				double[]  var_0 = new double[]{0};
				double[]  var_1 =  new double[] { 2 };
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 =  new double[] { 2 };
				double[]  var_5 = new double[]{0};
				double[]  var_6 = new double[]{0};
				double[]  var_7 =  new double[] { 1 };
				boolean[]  var_8 = new boolean[]{true};
				double[]  var_9 =  new double[] { 0 };
				double[]  var_10 = new double[]{0};
				double[]  var_11 = new double[]{0};
				
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
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("Formula_1");
					x0.setIValue(this.get_11());
				}
				
			}
	

	protected class CategoryObject3 extends measurements.RecursiveFormula
	{
		public CategoryObject3(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("d", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
			map.put("c", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
			setMap(map);
					Object o;
					o = new double[0];
					addVariableValue("a", o);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						variable = value0.getIValue();
						if (check(variable)) { success = false; return; }
						var_0[0] = ((double[])variable)[0];
						var_1[0] = ((double[])measurement1.getMeasurementValue())[0];
						if (check(var_1)) { success = false; return; } 
						var_2[0] = ((var_0[0]) + (var_1[0]));
						if (check(var_2)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					this.value0 = this.output[0];
					measurement1 = all[0].getMeasurement(0);
				}
				
				measurements.interfaces.IMeasurement measurement1;
				general_service.interfaces.IValue value0;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				
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
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("a");
					x0.setIValue(this.get_2());
				}
				
			}
	

	protected class CategoryObject4 extends measurements.DataConsumer
	{
		public CategoryObject4(String name, IDesktop desktop) {
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
	

	public PI() {
		super();
	}

	public PI(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new PI.CategoryObject0("X", this);
		new PI.CategoryObject1("Y", this);
		new PI.CategoryObject2("Data", this);
		new PI.CategoryObject3("Recursive", this);
		new PI.CategoryObject4("Chart", this);
		new PI.CategoryArrow0("2", this);
		new PI.CategoryArrow1("1", this);
		new PI.CategoryArrow2("3", this);
		new PI.CategoryArrow3("4", this);
		arrows.get(0).setSource(objects.get(2));
		arrows.get(0).setTarget(objects.get(1));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(0));
		arrows.get(2).setSource(objects.get(3));
		arrows.get(2).setTarget(objects.get(2));
		arrows.get(3).setSource(objects.get(4));
		arrows.get(3).setTarget(objects.get(3));
		postSet();
	}


}
