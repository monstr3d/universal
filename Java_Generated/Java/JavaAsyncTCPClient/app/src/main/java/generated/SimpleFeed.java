package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class SimpleFeed extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{0.0089878549198011051}));
			map.put("f", new general_service.Entry<Object, Object>(new double[0], new double[]{0.20000000000000001}));
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{0.20553585603787045}));
			map.put("c", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
			map.put("k", new general_service.Entry<Object, Object>(new double[0], new double[]{0.29999999999999999}));
			map.put("g", new general_service.Entry<Object, Object>(new double[0], new double[]{0.80000000000000004}));
			setMap(map);
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
						var_4[0] = ((double[])aliasName4.getAliasNameValue())[0];
						if (check(var_4)) { success = false; return; }
						var_5[0] = this.getInternalTime();
						var_6[0] = ((var_4[0]) * (var_5[0]));
						if (check(var_6)) { success = false; return; } 
						var_7[0] = (Math.cos(var_6[0]));
						if (check(var_7)) { success = false; return; } 
						var_8[0] = ((var_3[0]) * (var_7[0]));
						if (check(var_8)) { success = false; return; } 
						var_9[0] = ((var_2[0]) + (var_8[0]));
						if (check(var_9)) { success = false; return; } 
						var_10[0] = ((double[])aliasName10.getAliasNameValue())[0];
						if (check(var_10)) { success = false; return; }
						var_11[0] = ((double[])aliasName11.getAliasNameValue())[0];
						if (check(var_11)) { success = false;
                        }
					}
				
				@Override
				public void init()
				{
					var all = this.getAllMeasurements();
					aliasName0 = new general_service.AliasName(this, "a");
					aliasName1 = new general_service.AliasName(this, "k");
					aliasName3 = new general_service.AliasName(this, "f");
					aliasName4 = new general_service.AliasName(this, "g");
					aliasName10 = new general_service.AliasName(this, "b");
					aliasName11 = new general_service.AliasName(this, "c");
				}
				
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IAliasName aliasName1;
				general_service.interfaces.IAliasName aliasName3;
				general_service.interfaces.IAliasName aliasName4;
				general_service.interfaces.IAliasName aliasName10;
				general_service.interfaces.IAliasName aliasName11;
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
			}
	

	protected class CategoryObject1 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("k", new general_service.Entry<Object, Object>(new double[0], new double[]{0.5}));
			setMap(map);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])aliasName0.getAliasNameValue())[0];
						if (check(var_0)) { success = false; return; }
						var_1[0] = this.getInternalTime();
						var_2[0] = (Math.sin(var_1[0]));
						if (check(var_2)) { success = false; return; } 
						var_3[0] = ((var_0[0]) * (var_2[0]));
						if (check(var_3)) { success = false; return; } 
						var_4[0] = ((double[])measurement4.getMeasurementValue())[0];
						if (check(var_4)) { success = false;
                        }
					}
				
				@Override
				public void init()
				{
					var all = this.getAllMeasurements();
					measurement4 = all[0].getMeasurement(0);
					aliasName0 = new general_service.AliasName(this, "k");
				}
				
				measurements.interfaces.IMeasurement measurement4;
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
	

	public SimpleFeed() {
		super();
	}

	public SimpleFeed(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new SimpleFeed.CategoryObject0("A", this);
		new SimpleFeed.CategoryObject1("Output", this);
		new SimpleFeed.CategoryObject2("Chart", this);
		new SimpleFeed.CategoryArrow0("", this);
		new SimpleFeed.CategoryArrow1("", this);
		arrows.get(0).setSource(objects.get(1));
		arrows.get(0).setTarget(objects.get(0));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(1));
		postSet();
	}


}
