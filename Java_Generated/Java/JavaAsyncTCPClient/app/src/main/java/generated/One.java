package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class One extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{2}));
			map.put("c", new general_service.Entry<Object, Object>(new double[0], new double[]{3}));
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			setMap(map);
				}
			
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
						var_4[0] = (Math.cos(var_3[0]));
						if (check(var_4)) { success = false; return; } 
						var_5[0] = ((var_0[0]) * (var_4[0]));
						if (check(var_5)) { success = false; return; } 
						var_6[0] = ((double[])aliasName6.getAliasNameValue())[0];
						if (check(var_6)) { success = false; return; }
						var_7[0] = this.getInternalTime();
						var_9[0] = (Math.pow(var_7[0], var_8[0]));
						if (check(var_9)) { success = false; return; } 
						var_10[0] = (Math.atan2(var_2[0], var_9[0]));
						if (check(var_10)) { success = false; return; } 
						var_11[0] = ((var_6[0]) * (var_10[0]));
						if (check(var_11)) { success = false;
                        }
					}
				
				public void init()
				{
					var all = this.getAllMeasurements();
					aliasName0 = new general_service.AliasName(this, "a");
					aliasName1 = new general_service.AliasName(this, "b");
					aliasName6 = new general_service.AliasName(this, "c");
				}
				
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IAliasName aliasName1;
				general_service.interfaces.IAliasName aliasName6;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				double[]  var_4 = new double[]{0};
				double[]  var_5 = new double[]{0};
				double[]  var_6 = new double[]{0};
				double[]  var_7 = new double[]{0};
				double[]  var_8 =  new double[] { 2 };
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
	

	public One() {
		super();
	}

	public One(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new One.CategoryObject0("F", this);
		postSet();
	}


}
