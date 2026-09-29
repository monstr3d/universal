package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class Complicated extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{5}));
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			setMap(map);
				}
			
					protected void calculateTree()
					{
						success = true;
						var_0[0] = this.getInternalTime();
						var_1[0] = ((double[])aliasName1.getAliasNameValue())[0];
						if (check(var_1)) { success = false; return; }
						var_2[0] = ((var_0[0]) * (var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])aliasName3.getAliasNameValue())[0];
						if (check(var_3)) { success = false; return; }
						var_4[0] = ((var_3[0]) * (var_0[0]));
						if (check(var_4)) { success = false; return; } 
						var_5[0] = this.getInternalTime();
						var_7[0] = (Math.pow(var_5[0], var_6[0]));
						if (check(var_7)) { success = false; return; } 
						var_8[0] = (Math.sin(var_7[0]));
						if (check(var_8)) { success = false; return; } 
						var_9[0] = ((var_4[0]) + (var_8[0]));
						if (check(var_9)) { success = false;
                        }
					}
				
				public void init()
				{
					var all = this.getAllMeasurements();
					aliasName1 = new general_service.AliasName(this, "b");
					aliasName3 = new general_service.AliasName(this, "a");
				}
				
				general_service.interfaces.IAliasName aliasName1;
				general_service.interfaces.IAliasName aliasName3;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				double[]  var_5 = new double[]{0};
				double[]  var_6 =  new double[] { 2 };
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
			}
	

	protected class CategoryObject1 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{7}));
			setMap(map);
				}
			
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])aliasName0.getAliasNameValue())[0];
						if (check(var_0)) { success = false; return; }
						var_2[0] = (Math.pow(var_0[0], var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_4[0] = (Math.cos(var_3[0]));
						if (check(var_4)) { success = false; return; } 
						var_5[0] = ((double[])aliasName5.getAliasNameValue())[0];
						if (check(var_5)) { success = false; return; }
						var_6[0] = this.getInternalTime();
						var_7[0] = ((var_5[0]) * (var_6[0]));
						if (check(var_7)) { success = false;
                        }
					}
				
				public void init()
				{
					var all = this.getAllMeasurements();
					measurement3 = all[0].getMeasurement(1);
					aliasName0 = new general_service.AliasName(this, "a");
					aliasName5 = new general_service.AliasName(this, "a");
				}
				
				measurements.interfaces.IMeasurement measurement3;
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IAliasName aliasName5;
				double[]  var_0 = new double[]{0};
				double[]  var_1 =  new double[] { 2 };
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
			}
	

	protected class CategoryObject2 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject2(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			setMap(map);
				}
			
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])measurement0.getMeasurementValue())[0];
						if (check(var_0)) { success = false; return; } 
						var_2[0] = (Math.pow(var_0[0], var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_4[0] = (Math.cos(var_3[0]));
						if (check(var_4)) { success = false;
                        }
					}
				
				public void init()
				{
					var all = this.getAllMeasurements();
					measurement0 = all[0].getMeasurement(1);
					measurement3 = all[1].getMeasurement(2);
				}
				
				measurements.interfaces.IMeasurement measurement0;
				measurements.interfaces.IMeasurement measurement3;
				double[]  var_0 = new double[]{0};
				double[]  var_1 =  new double[] { 3 };
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
			}
	

	protected class CategoryObject3 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject3(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			setMap(map);
				}
			
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])measurement0.getMeasurementValue())[0];
						if (check(var_0)) { success = false; return; } 
						var_1[0] = this.getInternalTime();
						var_2[0] = ((var_0[0]) * (var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
						if (check(var_3)) { success = false; return; } 
						var_5[0] = (Math.pow(var_3[0], var_4[0]));
						if (check(var_5)) { success = false; return; } 
						var_6[0] = ((double[])measurement6.getMeasurementValue())[0];
						if (check(var_6)) { success = false; return; } 
						var_7[0] = (Math.cos(var_6[0]));
						if (check(var_7)) { success = false;
                        }
					}
				
				public void init()
				{
					var all = this.getAllMeasurements();
					measurement0 = all[0].getMeasurement(1);
					measurement3 = all[1].getMeasurement(0);
					measurement6 = all[2].getMeasurement(0);
				}
				
				measurements.interfaces.IMeasurement measurement0;
				measurements.interfaces.IMeasurement measurement3;
				measurements.interfaces.IMeasurement measurement6;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 =  new double[] { 2 };
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
	

	protected class CategoryArrow5 extends measurements.arrows.DataLink
	{
		public CategoryArrow5(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	public Complicated() {
		super();
	}

	public Complicated(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new Complicated.CategoryObject0("input", this);
		new Complicated.CategoryObject1("Output", this);
		new Complicated.CategoryObject2("Consumer", this);
		new Complicated.CategoryObject3("Finish", this);
		new Complicated.CategoryArrow0("22", this);
		new Complicated.CategoryArrow1("6", this);
		new Complicated.CategoryArrow2("4", this);
		new Complicated.CategoryArrow3("", this);
		new Complicated.CategoryArrow4("66", this);
		new Complicated.CategoryArrow5("10", this);
		arrows.get(0).setSource(objects.get(1));
		arrows.get(0).setTarget(objects.get(0));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(0));
		arrows.get(2).setSource(objects.get(2));
		arrows.get(2).setTarget(objects.get(1));
		arrows.get(3).setSource(objects.get(3));
		arrows.get(3).setTarget(objects.get(0));
		arrows.get(4).setSource(objects.get(3));
		arrows.get(4).setTarget(objects.get(2));
		arrows.get(5).setSource(objects.get(3));
		arrows.get(5).setTarget(objects.get(1));
		postSet();
	}


}
