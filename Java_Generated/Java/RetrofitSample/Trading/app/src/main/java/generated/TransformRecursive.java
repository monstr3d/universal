package generated;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class TransformRecursive extends Desktop
{

	protected class CategoryObject0 extends measurements.VectorFormulaConsumer
	{
		public CategoryObject0(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("c", new general_service.Entry<Object, Object>(new double[0], new double[]{0.52807761014574284}));
			map.put("d", new general_service.Entry<Object, Object>(new double[0], new double[]{9}));
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{0.19290093047446638}));
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{0.0021041577613234159}));
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
						var_2[0] = ((double[])aliasName2.getAliasNameValue())[0];
						if (check(var_2)) { success = false; return; }
						var_3[0] = ((double[])aliasName3.getAliasNameValue())[0];
						if (check(var_3)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					aliasName0 = new general_service.AliasName(this, "a");
					aliasName1 = new general_service.AliasName(this, "b");
					aliasName2 = new general_service.AliasName(this, "c");
					aliasName3 = new general_service.AliasName(this, "d");
				}
				
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IAliasName aliasName1;
				general_service.interfaces.IAliasName aliasName2;
				general_service.interfaces.IAliasName aliasName3;
				double[]  var_0 = new double[]{0};
				double[]  var_1 = new double[]{0};
				double[]  var_2 = new double[]{0};
				double[]  var_3 = new double[]{0};
				
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
			}
	

	protected class CategoryObject1 extends external.test.TestObjectTransformer
	{
		public CategoryObject1(String name, IDesktop desktop) {
			super(name,  desktop);
				coefficient = 0.23999999999999999;
			}
			}
	

	protected class CategoryObject2 extends measurements.ObjectTransformer
	{
		public CategoryObject2(String name, IDesktop desktop) {
			super(name,  desktop);
			int[] x = null;
			java.util.ArrayList<int[]> array = new java.util.ArrayList<>();
			x = new int[]{
			0,
			0
			};
			array.add(x);
			x = new int[]{
			0,
			1
			};
			array.add(x);
			x = new int[]{
			0,
			2
			};
			array.add(x);
			x = new int[]{
			0,
			3
			};
			array.add(x);
			this.array = array;
			}
			}
	

	protected class CategoryObject3 extends measurements.RecursiveFormula
	{
		public CategoryObject3(String name, IDesktop desktop) {
			super(name,  desktop);
			java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
			map.put("k", new general_service.Entry<Object, Object>(new double[0], new double[]{0.69999999999999996}));
			map.put("l", new general_service.Entry<Object, Object>(new double[0], new double[]{0.01}));
			map.put("a", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			map.put("b", new general_service.Entry<Object, Object>(new double[0], new double[]{3}));
			map.put("c", new general_service.Entry<Object, Object>(new double[0], new double[]{5}));
			map.put("d", new general_service.Entry<Object, Object>(new double[0], new double[]{4}));
			map.put("f", new general_service.Entry<Object, Object>(new double[0], new double[]{1}));
			setMap(map);
				}
			
					@Override
					protected void calculateTree()
					{
						success = true;
						var_0[0] = ((double[])aliasName0.getAliasNameValue())[0];
						if (check(var_0)) { success = false; return; }
						var_1[0] = ((double[])measurement1.getMeasurementValue())[0];
						if (check(var_1)) { success = false; return; } 
						variable = value2.getIValue();
						if (check(variable)) { success = false; return; }
						var_2[0] = ((double[])variable)[0];
						var_3[0] = ((var_1[0]) + (var_2[0]));
						if (check(var_3)) { success = false; return; } 
						var_4[0] = ((var_0[0]) * (var_3[0]));
						if (check(var_4)) { success = false; return; } 
						var_5[0] = ((double[])measurement5.getMeasurementValue())[0];
						if (check(var_5)) { success = false; return; } 
						variable = value6.getIValue();
						if (check(variable)) { success = false; return; }
						var_6[0] = ((double[])variable)[0];
						var_7[0] = ((var_5[0]) + (var_6[0]));
						if (check(var_7)) { success = false; return; } 
						var_8[0] = ((var_0[0]) * (var_7[0]));
						if (check(var_8)) { success = false; return; } 
						var_9[0] = ((double[])measurement9.getMeasurementValue())[0];
						if (check(var_9)) { success = false; return; } 
						variable = value10.getIValue();
						if (check(variable)) { success = false; return; }
						var_10[0] = ((double[])variable)[0];
						var_11[0] = ((var_9[0]) + (var_10[0]));
						if (check(var_11)) { success = false; return; } 
						var_12[0] = ((var_0[0]) * (var_11[0]));
						if (check(var_12)) { success = false; return; } 
						var_13[0] = ((var_0[0]) * (var_1[0]));
						if (check(var_13)) { success = false; return; } 
						var_14[0] = ((double[])aliasName14.getAliasNameValue())[0];
						if (check(var_14)) { success = false; return; }
						var_15[0] = this.getInternalTime();
						var_16[0] = ((var_14[0]) * (var_15[0]));
						if (check(var_16)) { success = false;
                        }
					}
				
				@Override
				protected void init()
				{
					var all = this.getAllMeasurements();
					measurement1 = all[0].getMeasurement(0);
					this.value2 = this.output[0];
					measurement5 = all[0].getMeasurement(1);
					this.value6 = this.output[1];
					measurement9 = all[0].getMeasurement(2);
					this.value10 = this.output[2];
					aliasName0 = new general_service.AliasName(this, "k");
					aliasName14 = new general_service.AliasName(this, "l");
				}
				
				measurements.interfaces.IMeasurement measurement1;
				measurements.interfaces.IMeasurement measurement5;
				measurements.interfaces.IMeasurement measurement9;
				general_service.interfaces.IAliasName aliasName0;
				general_service.interfaces.IValue value2;
				general_service.interfaces.IValue value6;
				general_service.interfaces.IValue value10;
				general_service.interfaces.IAliasName aliasName14;
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
				double[]  var_13 = new double[]{0};
				double[]  var_14 = new double[]{0};
				double[]  var_15 = new double[]{0};
				double[]  var_16 = new double[]{0};
				
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
				
				Object get_13()
				{
					return success ? this.var_13 : null;
				}
				
				Object get_14()
				{
					return success ? this.var_14 : null;
				}
				
				Object get_15()
				{
					return success ? this.var_15 : null;
				}
				
				Object get_16()
				{
					return success ? this.var_16 : null;
				}
				@Override
				protected void save(){
					var v = variables;
					var x0 = v.get("a");
					x0.setIValue(this.get_4());
					var x1 = v.get("b");
					x1.setIValue(this.get_8());
					var x2 = v.get("c");
					x2.setIValue(this.get_12());
					var x3 = v.get("d");
					x3.setIValue(this.get_13());
					var x4 = v.get("f");
					x4.setIValue(this.get_16());
				}
				
				@Override
				protected void createFeedback() {
					java.util.List<general_service.Entry<int[], String>> list = new java.util.ArrayList<>();
					list.add(new general_service.Entry(new int[] {0, 0}, "a" ));
					list.add(new general_service.Entry(new int[] {0, 1}, "b" ));
					list.add(new general_service.Entry(new int[] {0, 2}, "c" ));
					setFeedback(list);
				}
			}
	

	protected class CategoryObject4 extends measurements.DataConsumer
	{
		public CategoryObject4(String name, IDesktop desktop) {
			super(name,  desktop);
			}
			}
	

	protected class CategoryArrow0 extends measurements.arrows.ObjectTransformerLink
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
	

	public TransformRecursive() {
		super();
	}

	public TransformRecursive(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
		new TransformRecursive.CategoryObject0("Vector", this);
		new TransformRecursive.CategoryObject1("Source", this);
		new TransformRecursive.CategoryObject2("Transformer", this);
		new TransformRecursive.CategoryObject3("Recursive", this);
		new TransformRecursive.CategoryObject4("Chart", this);
		new TransformRecursive.CategoryArrow0("", this);
		new TransformRecursive.CategoryArrow1("", this);
		new TransformRecursive.CategoryArrow2("", this);
		new TransformRecursive.CategoryArrow3("", this);
		new TransformRecursive.CategoryArrow4("", this);
		new TransformRecursive.CategoryArrow5("", this);
		arrows.get(0).setSource(objects.get(2));
		arrows.get(0).setTarget(objects.get(1));
		arrows.get(1).setSource(objects.get(2));
		arrows.get(1).setTarget(objects.get(0));
		arrows.get(2).setSource(objects.get(3));
		arrows.get(2).setTarget(objects.get(2));
		arrows.get(3).setSource(objects.get(3));
		arrows.get(3).setTarget(objects.get(0));
		arrows.get(4).setSource(objects.get(4));
		arrows.get(4).setTarget(objects.get(3));
		arrows.get(5).setSource(objects.get(4));
		arrows.get(5).setTarget(objects.get(2));
		postSet();
	}


}
