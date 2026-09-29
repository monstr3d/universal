package generated;

import java.util.concurrent.CompletableFuture;

import java.util.concurrent.ExecutionException;

import cancellation.interfaces.ICancellation;

import diagram.Desktop;

import diagram.interfaces.IDesktop;

import error_handler.interfaces.ICheck;

import error_handler.interfaces.IErrorHandler;

public class TradingJava extends Desktop
{

	public static IDesktop getDesktop(ICheck check, IErrorHandler errorHandler, ICancellation cancellation)
	{
	try {
		var desktop = new TradingJava(check, errorHandler);
		var inits = desktop.getTaskInitializers(cancellation);
		var all = CompletableFuture.allOf(
			inits.get(0),
			inits.get(1)
		);
		all.get();
		desktop.finish();
return desktop;
	}
catch (InterruptedException | ExecutionException e) {
throw new RuntimeException(e); }
	}

		protected class CategoryObject0 extends external.trading.library.objects.DataQuery
		{
			public CategoryObject0(String name, IDesktop desktop) {
				super(name,  desktop);
					id =  "34f44a39-a8ad-46b7-9c7c-4527ad1ce959";
					period = "1 day";
					begin = 44929;
					end = 45260;
				}
				}
		
	
		protected class CategoryObject1 extends measurements.FilterWrapper
		{
			public CategoryObject1(String name, IDesktop desktop) {
				super(name,  desktop);
					input = "Trading.Close";
				}
				}
		
	
		protected class CategoryObject2 extends measurements.FilterWrapper
		{
			public CategoryObject2(String name, IDesktop desktop) {
				super(name,  desktop);
					input = "Trading.Close";
				}
				}
		
	
		protected class CategoryObject3 extends measurements.FilterWrapper
		{
			public CategoryObject3(String name, IDesktop desktop) {
				super(name,  desktop);
					input = "Trading.High";
				}
				}
		
	
		protected class CategoryObject4 extends measurements.FilterWrapper
		{
			public CategoryObject4(String name, IDesktop desktop) {
				super(name,  desktop);
					input = "Trading.Low";
				}
				}
		
	
		protected class CategoryObject5 extends measurements.RecursiveFormula
		{
			public CategoryObject5(String name, IDesktop desktop) {
				super(name,  desktop);
				java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
				map.put("t", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
				map.put("x", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
				map.put("y", new general_service.Entry<Object, Object>(new double[0], new double[]{0}));
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
							var_1[0] = ((double[])aliasName1.getAliasNameValue())[0];
							if (check(var_1)) { success = false; return; }
						}
					
					@Override
					protected void init()
					{
						var all = this.getAllMeasurements();
						this.value0 = this.output[1];
						aliasName1 = new general_service.AliasName(this, "t");
					}
					
					general_service.interfaces.IValue value0;
					general_service.interfaces.IAliasName aliasName1;
					double[]  var_0 = new double[]{0};
					double[]  var_1 = new double[]{0};
					
					Object get_0()
					{
						return success ? this.var_0 : null;
					}
					
					Object get_1()
					{
						return success ? this.var_1 : null;
					}
					@Override
					protected void save(){
						var v = variables;
						var x0 = v.get("x");
						x0.setIValue(this.get_0());
						var x1 = v.get("y");
						x1.setIValue(this.get_1());
					}
					
				}
		
	
		protected class CategoryObject6 extends measurements.VectorFormulaConsumer
		{
			public CategoryObject6(String name, IDesktop desktop) {
				super(name,  desktop);
				java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
				setMap(map);
						Object o;
						o = new boolean[0];
						addVariableValue("Formula_1", o);
						o = new boolean[0];
						addVariableValue("Formula_2", o);
						o = new boolean[0];
						addVariableValue("Formula_3", o);
						o = new double[0];
						addVariableValue("Formula_4", o);
						o = new boolean[0];
						addVariableValue("Formula_5", o);
						o = new boolean[0];
						addVariableValue("Formula_6", o);
						o = new boolean[0];
						addVariableValue("Formula_7", o);
					}
				
						@Override
						protected void calculateTree()
						{
							success = true;
							var_0[0] = ((double[])measurement0.getMeasurementValue())[0];
							if (check(var_0)) { success = false; return; } 
							var_1[0] = ((double[])measurement1.getMeasurementValue())[0];
							if (check(var_1)) { success = false; return; } 
							var_2[0] = ((var_0[0]) < (var_1[0]));
							if (check(var_2)) { success = false; return; } 
							var_3[0] = ((double[])measurement3.getMeasurementValue())[0];
							if (check(var_3)) { success = false; return; } 
							var_4[0] = ((double[])measurement4.getMeasurementValue())[0];
							if (check(var_4)) { success = false; return; } 
							var_5[0] = ((var_3[0]) < (var_4[0]));
							if (check(var_5)) { success = false; return; } 
							var_6[0] = ((double[])measurement6.getMeasurementValue())[0];
							if (check(var_6)) { success = false; return; } 
							var_7[0] = ((double[])measurement7.getMeasurementValue())[0];
							if (check(var_7)) { success = false; return; } 
							var_8[0] = ((var_6[0]) > (var_7[0]));
							if (check(var_8)) { success = false; return; } 
							var_9[0] = ((double[])measurement9.getMeasurementValue())[0];
							if (check(var_9)) { success = false; return; } 
							var_11[0] = ((var_9[0]) == (var_10[0]));
							if (check(var_11)) { success = false; return; } 
							var_13[0] = ((var_9[0]) == (var_12[0]));
							if (check(var_13)) { success = false; return; } 
							var_15[0] = ((var_9[0]) == (var_14[0]));
							if (check(var_15)) { success = false; return; } 
						}
					
					@Override
					protected void init()
					{
						var all = this.getAllMeasurements();
						measurement0 = all[5].getMeasurement(0);
						measurement1 = all[4].getMeasurement(0);
						measurement3 = all[0].getMeasurement(1);
						measurement4 = all[2].getMeasurement(0);
						measurement6 = all[0].getMeasurement(2);
						measurement7 = all[3].getMeasurement(0);
						measurement9 = all[1].getMeasurement(1);
					}
					
					measurements.interfaces.IMeasurement measurement0;
					measurements.interfaces.IMeasurement measurement1;
					measurements.interfaces.IMeasurement measurement3;
					measurements.interfaces.IMeasurement measurement4;
					measurements.interfaces.IMeasurement measurement6;
					measurements.interfaces.IMeasurement measurement7;
					measurements.interfaces.IMeasurement measurement9;
					double[]  var_0 = new double[]{0};
					double[]  var_1 = new double[]{0};
					boolean[]  var_2 = new boolean[]{true};
					double[]  var_3 = new double[]{0};
					double[]  var_4 = new double[]{0};
					boolean[]  var_5 = new boolean[]{true};
					double[]  var_6 = new double[]{0};
					double[]  var_7 = new double[]{0};
					boolean[]  var_8 = new boolean[]{true};
					double[]  var_9 = new double[]{0};
					double[]  var_10 =  new double[] { 0 };
					boolean[]  var_11 = new boolean[]{true};
					double[]  var_12 =  new double[] { 1 };
					boolean[]  var_13 = new boolean[]{true};
					double[]  var_14 =  new double[] { 2 };
					boolean[]  var_15 = new boolean[]{true};
					
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
					@Override
					protected void save(){
						var v = variables;
						var x0 = v.get("Formula_1");
						x0.setIValue(this.get_2());
						var x1 = v.get("Formula_2");
						x1.setIValue(this.get_5());
						var x2 = v.get("Formula_3");
						x2.setIValue(this.get_8());
						var x3 = v.get("Formula_4");
						x3.setIValue(this.get_9());
						var x4 = v.get("Formula_5");
						x4.setIValue(this.get_11());
						var x5 = v.get("Formula_6");
						x5.setIValue(this.get_13());
						var x6 = v.get("Formula_7");
						x6.setIValue(this.get_15());
					}
					
				}
		
	
		protected class CategoryObject7 extends measurements.VectorFormulaConsumer
		{
			public CategoryObject7(String name, IDesktop desktop) {
				super(name,  desktop);
				java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
				setMap(map);
						Object o;
						o = new boolean[0];
						addVariableValue("Formula_1", o);
						o = new boolean[0];
						addVariableValue("Formula_2", o);
						o = new double[0];
						addVariableValue("Formula_3", o);
						o = new double[0];
						addVariableValue("Formula_4", o);
						o = new double[0];
						addVariableValue("Formula_5", o);
						o = new double[0];
						addVariableValue("Formula_6", o);
						o = new double[0];
						addVariableValue("Formula_7", o);
					}
				
						@Override
						protected void calculateTree()
						{
							success = true;
							var_0[0] = ((boolean[])measurement0.getMeasurementValue())[0];
							if (check(var_0)) { success = false; return; } 
							var_1[0] = ((double[])measurement1.getMeasurementValue())[0];
							if (check(var_1)) { success = false; return; } 
							var_3[0] = ((var_1[0]) == (var_2[0]));
							if (check(var_3)) { success = false; return; } 
							var_4[0] = ((var_0[0]) & (var_3[0]));
							if (check(var_4)) { success = false; return; } 
							var_5[0] = ((boolean[])measurement5.getMeasurementValue())[0];
							if (check(var_5)) { success = false; return; } 
							var_6[0] = ((var_4[0]) & (var_5[0]));
							if (check(var_6)) { success = false; return; } 
							var_7[0] = (!var_0[0]);
							if (check(var_7)) { success = false; return; } 
							var_9[0] = ((var_1[0]) == (var_8[0]));
							if (check(var_9)) { success = false; return; } 
							var_10[0] = ((var_7[0]) & (var_9[0]));
							if (check(var_10)) { success = false; return; } 
							var_11[0] = ((var_10[0]) & (var_5[0]));
							if (check(var_11)) { success = false; return; } 
							var_12[0] = ((var_6[0]) | (var_11[0]));
							if (check(var_12)) { success = false; return; } 
							var_14[0] = ((var_1[0]) == (var_13[0]));
							if (check(var_14)) { success = false; return; } 
							var_15[0] = ((boolean[])measurement15.getMeasurementValue())[0];
							if (check(var_15)) { success = false; return; } 
							var_16[0] = ((var_14[0]) & (var_15[0]));
							if (check(var_16)) { success = false; return; } 
							var_18[0] = ((var_1[0]) == (var_17[0]));
							if (check(var_18)) { success = false; return; } 
							var_19[0] = ((var_18[0]) & (var_15[0]));
							if (check(var_19)) { success = false; return; } 
							var_20[0] = ((var_0[0]) ? (var_16[0]) : (var_19[0]));;
							if (check(var_20)) { success = false; return; } 
							var_21[0] = ((boolean[])measurement21.getMeasurementValue())[0];
							if (check(var_21)) { success = false; return; } 
							var_22[0] = ((var_21[0]) & (var_5[0]));
							if (check(var_22)) { success = false; return; } 
							var_24[0] = ((boolean[])measurement24.getMeasurementValue())[0];
							if (check(var_24)) { success = false; return; } 
							var_25[0] = ((var_24[0]) & (var_15[0]));
							if (check(var_25)) { success = false; return; } 
							var_27[0] = ((var_25[0]) ? (var_26[0]) : (var_1[0]));;
							if (check(var_27)) { success = false; return; } 
							var_28[0] = ((var_22[0]) ? (var_23[0]) : (var_27[0]));;
							if (check(var_28)) { success = false; return; } 
							var_29[0] = ((var_21[0]) & (var_15[0]));
							if (check(var_29)) { success = false; return; } 
							var_31[0] = ((boolean[])measurement31.getMeasurementValue())[0];
							if (check(var_31)) { success = false; return; } 
							var_32[0] = ((var_31[0]) & (var_5[0]));
							if (check(var_32)) { success = false; return; } 
							var_34[0] = ((var_32[0]) ? (var_33[0]) : (var_1[0]));;
							if (check(var_34)) { success = false; return; } 
							var_35[0] = ((var_29[0]) ? (var_30[0]) : (var_34[0]));;
							if (check(var_35)) { success = false; return; } 
							var_36[0] = ((var_0[0]) ? (var_28[0]) : (var_35[0]));;
							if (check(var_36)) { success = false; return; } 
							var_39[0] = ((var_0[0]) ? (var_37[0]) : (var_38[0]));;
							if (check(var_39)) { success = false; return; } 
							var_42[0] = ((var_5[0]) ? (var_40[0]) : (var_41[0]));;
							if (check(var_42)) { success = false; return; } 
							var_45[0] = ((var_15[0]) ? (var_43[0]) : (var_44[0]));;
							if (check(var_45)) { success = false; return; } 
							var_46[0] = ((double[])measurement46.getMeasurementValue())[0];
							if (check(var_46)) { success = false; return; } 
						}
					
					@Override
					protected void init()
					{
						var all = this.getAllMeasurements();
						measurement0 = all[0].getMeasurement(0);
						measurement1 = all[1].getMeasurement(1);
						measurement5 = all[0].getMeasurement(1);
						measurement15 = all[0].getMeasurement(2);
						measurement21 = all[0].getMeasurement(4);
						measurement24 = all[0].getMeasurement(5);
						measurement31 = all[0].getMeasurement(6);
						measurement46 = all[0].getMeasurement(3);
					}
					
					measurements.interfaces.IMeasurement measurement0;
					measurements.interfaces.IMeasurement measurement1;
					measurements.interfaces.IMeasurement measurement5;
					measurements.interfaces.IMeasurement measurement15;
					measurements.interfaces.IMeasurement measurement21;
					measurements.interfaces.IMeasurement measurement24;
					measurements.interfaces.IMeasurement measurement31;
					measurements.interfaces.IMeasurement measurement46;
					boolean[]  var_0 = new boolean[]{true};
					double[]  var_1 = new double[]{0};
					double[]  var_2 =  new double[] { 0 };
					boolean[]  var_3 = new boolean[]{true};
					boolean[]  var_4 = new boolean[]{true};
					boolean[]  var_5 = new boolean[]{true};
					boolean[]  var_6 = new boolean[]{true};
					boolean[]  var_7 = new boolean[]{true};
					double[]  var_8 =  new double[] { 2 };
					boolean[]  var_9 = new boolean[]{true};
					boolean[]  var_10 = new boolean[]{true};
					boolean[]  var_11 = new boolean[]{true};
					boolean[]  var_12 = new boolean[]{true};
					double[]  var_13 =  new double[] { 1 };
					boolean[]  var_14 = new boolean[]{true};
					boolean[]  var_15 = new boolean[]{true};
					boolean[]  var_16 = new boolean[]{true};
					double[]  var_17 =  new double[] { 0 };
					boolean[]  var_18 = new boolean[]{true};
					boolean[]  var_19 = new boolean[]{true};
					boolean[]  var_20 = new boolean[]{true};
					boolean[]  var_21 = new boolean[]{true};
					boolean[]  var_22 = new boolean[]{true};
					double[]  var_23 =  new double[] { 1 };
					boolean[]  var_24 = new boolean[]{true};
					boolean[]  var_25 = new boolean[]{true};
					double[]  var_26 =  new double[] { 0 };
					double[]  var_27 = new double[]{0};
					double[]  var_28 = new double[]{0};
					boolean[]  var_29 = new boolean[]{true};
					double[]  var_30 =  new double[] { 2 };
					boolean[]  var_31 = new boolean[]{true};
					boolean[]  var_32 = new boolean[]{true};
					double[]  var_33 =  new double[] { 0 };
					double[]  var_34 = new double[]{0};
					double[]  var_35 = new double[]{0};
					double[]  var_36 = new double[]{0};
					double[]  var_37 =  new double[] { 1 };
					double[]  var_38 =  new double[] { 0 };
					double[]  var_39 = new double[]{0};
					double[]  var_40 =  new double[] { 1 };
					double[]  var_41 =  new double[] { 0 };
					double[]  var_42 = new double[]{0};
					double[]  var_43 =  new double[] { 1 };
					double[]  var_44 =  new double[] { 0 };
					double[]  var_45 = new double[]{0};
					double[]  var_46 = new double[]{0};
					
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
					
					Object get_17()
					{
						return success ? this.var_17 : null;
					}
					
					Object get_18()
					{
						return success ? this.var_18 : null;
					}
					
					Object get_19()
					{
						return success ? this.var_19 : null;
					}
					
					Object get_20()
					{
						return success ? this.var_20 : null;
					}
					
					Object get_21()
					{
						return success ? this.var_21 : null;
					}
					
					Object get_22()
					{
						return success ? this.var_22 : null;
					}
					
					Object get_23()
					{
						return success ? this.var_23 : null;
					}
					
					Object get_24()
					{
						return success ? this.var_24 : null;
					}
					
					Object get_25()
					{
						return success ? this.var_25 : null;
					}
					
					Object get_26()
					{
						return success ? this.var_26 : null;
					}
					
					Object get_27()
					{
						return success ? this.var_27 : null;
					}
					
					Object get_28()
					{
						return success ? this.var_28 : null;
					}
					
					Object get_29()
					{
						return success ? this.var_29 : null;
					}
					
					Object get_30()
					{
						return success ? this.var_30 : null;
					}
					
					Object get_31()
					{
						return success ? this.var_31 : null;
					}
					
					Object get_32()
					{
						return success ? this.var_32 : null;
					}
					
					Object get_33()
					{
						return success ? this.var_33 : null;
					}
					
					Object get_34()
					{
						return success ? this.var_34 : null;
					}
					
					Object get_35()
					{
						return success ? this.var_35 : null;
					}
					
					Object get_36()
					{
						return success ? this.var_36 : null;
					}
					
					Object get_37()
					{
						return success ? this.var_37 : null;
					}
					
					Object get_38()
					{
						return success ? this.var_38 : null;
					}
					
					Object get_39()
					{
						return success ? this.var_39 : null;
					}
					
					Object get_40()
					{
						return success ? this.var_40 : null;
					}
					
					Object get_41()
					{
						return success ? this.var_41 : null;
					}
					
					Object get_42()
					{
						return success ? this.var_42 : null;
					}
					
					Object get_43()
					{
						return success ? this.var_43 : null;
					}
					
					Object get_44()
					{
						return success ? this.var_44 : null;
					}
					
					Object get_45()
					{
						return success ? this.var_45 : null;
					}
					
					Object get_46()
					{
						return success ? this.var_46 : null;
					}
					@Override
					protected void save(){
						var v = variables;
						var x0 = v.get("Formula_1");
						x0.setIValue(this.get_12());
						var x1 = v.get("Formula_2");
						x1.setIValue(this.get_20());
						var x2 = v.get("Formula_3");
						x2.setIValue(this.get_36());
						var x3 = v.get("Formula_4");
						x3.setIValue(this.get_39());
						var x4 = v.get("Formula_5");
						x4.setIValue(this.get_42());
						var x5 = v.get("Formula_6");
						x5.setIValue(this.get_45());
						var x6 = v.get("Formula_7");
						x6.setIValue(this.get_46());
					}
					
				}
		
	
		protected class CategoryObject8 extends measurements.VectorFormulaConsumer
		{
			public CategoryObject8(String name, IDesktop desktop) {
				super(name,  desktop);
				java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
				setMap(map);
						Object o;
						o = new double[0];
						addVariableValue("Formula_1", o);
						o = new double[0];
						addVariableValue("Formula_2", o);
						o = new double[0];
						addVariableValue("Formula_3", o);
						o = new double[0];
						addVariableValue("Formula_4", o);
						o = new double[0];
						addVariableValue("Formula_5", o);
					}
				
						@Override
						protected void calculateTree()
						{
							success = true;
							var_0[0] = ((boolean[])measurement0.getMeasurementValue())[0];
							if (check(var_0)) { success = false; return; } 
							var_3[0] = ((var_0[0]) ? (var_1[0]) : (var_2[0]));;
							if (check(var_3)) { success = false; return; } 
							var_4[0] = ((boolean[])measurement4.getMeasurementValue())[0];
							if (check(var_4)) { success = false; return; } 
							var_7[0] = ((var_4[0]) ? (var_5[0]) : (var_6[0]));;
							if (check(var_7)) { success = false; return; } 
							var_8[0] = ((boolean[])measurement8.getMeasurementValue())[0];
							if (check(var_8)) { success = false; return; } 
							var_11[0] = ((var_8[0]) ? (var_9[0]) : (var_10[0]));;
							if (check(var_11)) { success = false; return; } 
							var_12[0] = ((boolean[])measurement12.getMeasurementValue())[0];
							if (check(var_12)) { success = false; return; } 
							var_15[0] = ((var_12[0]) ? (var_13[0]) : (var_14[0]));;
							if (check(var_15)) { success = false; return; } 
							var_16[0] = ((boolean[])measurement16.getMeasurementValue())[0];
							if (check(var_16)) { success = false; return; } 
							var_19[0] = ((var_16[0]) ? (var_17[0]) : (var_18[0]));;
							if (check(var_19)) { success = false; return; } 
						}
					
					@Override
					protected void init()
					{
						var all = this.getAllMeasurements();
						measurement0 = all[0].getMeasurement(0);
						measurement4 = all[0].getMeasurement(1);
						measurement8 = all[1].getMeasurement(4);
						measurement12 = all[1].getMeasurement(5);
						measurement16 = all[1].getMeasurement(6);
					}
					
					measurements.interfaces.IMeasurement measurement0;
					measurements.interfaces.IMeasurement measurement4;
					measurements.interfaces.IMeasurement measurement8;
					measurements.interfaces.IMeasurement measurement12;
					measurements.interfaces.IMeasurement measurement16;
					boolean[]  var_0 = new boolean[]{true};
					double[]  var_1 =  new double[] { 1 };
					double[]  var_2 =  new double[] { 0 };
					double[]  var_3 = new double[]{0};
					boolean[]  var_4 = new boolean[]{true};
					double[]  var_5 =  new double[] { 1 };
					double[]  var_6 =  new double[] { 0 };
					double[]  var_7 = new double[]{0};
					boolean[]  var_8 = new boolean[]{true};
					double[]  var_9 =  new double[] { 1 };
					double[]  var_10 =  new double[] { 0 };
					double[]  var_11 = new double[]{0};
					boolean[]  var_12 = new boolean[]{true};
					double[]  var_13 =  new double[] { 1 };
					double[]  var_14 =  new double[] { 0 };
					double[]  var_15 = new double[]{0};
					boolean[]  var_16 = new boolean[]{true};
					double[]  var_17 =  new double[] { 1 };
					double[]  var_18 =  new double[] { 0 };
					double[]  var_19 = new double[]{0};
					
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
					
					Object get_17()
					{
						return success ? this.var_17 : null;
					}
					
					Object get_18()
					{
						return success ? this.var_18 : null;
					}
					
					Object get_19()
					{
						return success ? this.var_19 : null;
					}
					@Override
					protected void save(){
						var v = variables;
						var x0 = v.get("Formula_1");
						x0.setIValue(this.get_3());
						var x1 = v.get("Formula_2");
						x1.setIValue(this.get_7());
						var x2 = v.get("Formula_3");
						x2.setIValue(this.get_11());
						var x3 = v.get("Formula_4");
						x3.setIValue(this.get_15());
						var x4 = v.get("Formula_5");
						x4.setIValue(this.get_19());
					}
					
				}
		
	
		protected class CategoryObject9 extends measurements.VectorFormulaConsumer
		{
			public CategoryObject9(String name, IDesktop desktop) {
				super(name,  desktop);
				java.util.Map< String, general_service.Entry<Object, Object >> map = new java.util.HashMap<>();
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
							var_2[0] = ((var_0[0]) == (var_1[0]));
							if (check(var_2)) { success = false; return; } 
							var_5[0] = ((var_4[0]) - (var_0[0]));
							if (check(var_5)) { success = false; return; } 
							var_6[0] = ((var_2[0]) ? (var_3[0]) : (var_5[0]));;
							if (check(var_6)) { success = false; return; } 
						}
					
					@Override
					protected void init()
					{
						var all = this.getAllMeasurements();
						measurement0 = all[0].getMeasurement(2);
					}
					
					measurements.interfaces.IMeasurement measurement0;
					double[]  var_0 = new double[]{0};
					double[]  var_1 =  new double[] { 0 };
					boolean[]  var_2 = new boolean[]{true};
					double[]  var_3 =  new double[] { 0 };
					double[]  var_4 =  new double[] { 3 };
					double[]  var_5 = new double[]{0};
					double[]  var_6 = new double[]{0};
					
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
					@Override
					protected void save(){
						var v = variables;
						var x0 = v.get("Formula_1");
						x0.setIValue(this.get_6());
					}
					
				}
		
	
		protected class CategoryObject10 extends external.trading.library.objects.Order
		{
			public CategoryObject10(String name, IDesktop desktop) {
				super(name,  desktop);
					buyPrice =  "Trading.Close";
					sellPrice = "Trading.Close";
					position = "Sell Buy.Formula_3";
				}
				}
		
	
		protected class CategoryObject11 extends measurements.DataConsumer
		{
			public CategoryObject11(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryObject12 extends external.trading.library.objects.Fiction
		{
			public CategoryObject12(String name, IDesktop desktop) {
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
		
	
		protected class CategoryArrow5 extends measurements.arrows.DataLink
		{
			public CategoryArrow5(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow6 extends measurements.arrows.DataLink
		{
			public CategoryArrow6(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow7 extends measurements.arrows.DataLink
		{
			public CategoryArrow7(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow8 extends measurements.arrows.DataLink
		{
			public CategoryArrow8(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow9 extends measurements.arrows.DataLink
		{
			public CategoryArrow9(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow10 extends measurements.arrows.DataLink
		{
			public CategoryArrow10(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow11 extends measurements.arrows.DataLink
		{
			public CategoryArrow11(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow12 extends measurements.arrows.DataLink
		{
			public CategoryArrow12(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow13 extends measurements.arrows.DataLink
		{
			public CategoryArrow13(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow14 extends measurements.arrows.DataLink
		{
			public CategoryArrow14(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow15 extends measurements.arrows.DataLink
		{
			public CategoryArrow15(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow16 extends measurements.arrows.DataLink
		{
			public CategoryArrow16(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow17 extends measurements.arrows.IteratorConsumerLink
		{
			public CategoryArrow17(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow18 extends measurements.arrows.DataLink
		{
			public CategoryArrow18(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow19 extends measurements.arrows.DataLink
		{
			public CategoryArrow19(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow20 extends measurements.arrows.DataLink
		{
			public CategoryArrow20(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow21 extends measurements.arrows.DataLink
		{
			public CategoryArrow21(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow22 extends measurements.arrows.DataLink
		{
			public CategoryArrow22(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow23 extends measurements.arrows.DataLink
		{
			public CategoryArrow23(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow24 extends measurements.arrows.DataLink
		{
			public CategoryArrow24(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow25 extends measurements.arrows.DataLink
		{
			public CategoryArrow25(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow26 extends measurements.arrows.DataLink
		{
			public CategoryArrow26(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow27 extends measurements.arrows.DataLink
		{
			public CategoryArrow27(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow28 extends measurements.arrows.DataLink
		{
			public CategoryArrow28(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
		protected class CategoryArrow29 extends measurements.arrows.DataLink
		{
			public CategoryArrow29(String name, IDesktop desktop) {
				super(name,  desktop);
				}
				}
		
	
	public TradingJava() {
		super();
	}

	public TradingJava(ICheck check, IErrorHandler errorHandler) {
		super(check, errorHandler);
	}


	@Override
	public void init()
	{
			new TradingJava.CategoryObject0("Trading", this);
			new TradingJava.CategoryObject1("Average Short", this);
			new TradingJava.CategoryObject2("Average Long", this);
			new TradingJava.CategoryObject3("Donchian maximum", this);
			new TradingJava.CategoryObject4("Donchian minimum", this);
			new TradingJava.CategoryObject5("Current Position", this);
			new TradingJava.CategoryObject6("Conditions", this);
			new TradingJava.CategoryObject7("Sell Buy", this);
			new TradingJava.CategoryObject8("Additional", this);
			new TradingJava.CategoryObject9("Position", this);
			new TradingJava.CategoryObject10("Order", this);
			new TradingJava.CategoryObject11("Chart", this);
			new TradingJava.CategoryObject12("Fiction", this);
			new TradingJava.CategoryArrow0("", this);
			new TradingJava.CategoryArrow1("", this);
			new TradingJava.CategoryArrow2("", this);
			new TradingJava.CategoryArrow3("", this);
			new TradingJava.CategoryArrow4("", this);
			new TradingJava.CategoryArrow5("", this);
			new TradingJava.CategoryArrow6("", this);
			new TradingJava.CategoryArrow7("", this);
			new TradingJava.CategoryArrow8("", this);
			new TradingJava.CategoryArrow9("", this);
			new TradingJava.CategoryArrow10("", this);
			new TradingJava.CategoryArrow11("", this);
			new TradingJava.CategoryArrow12("", this);
			new TradingJava.CategoryArrow13("", this);
			new TradingJava.CategoryArrow14("", this);
			new TradingJava.CategoryArrow15("", this);
			new TradingJava.CategoryArrow16("", this);
			new TradingJava.CategoryArrow17("", this);
			new TradingJava.CategoryArrow18("", this);
			new TradingJava.CategoryArrow19("", this);
			new TradingJava.CategoryArrow20("", this);
			new TradingJava.CategoryArrow21("", this);
			new TradingJava.CategoryArrow22("", this);
			new TradingJava.CategoryArrow23("", this);
			new TradingJava.CategoryArrow24("", this);
			new TradingJava.CategoryArrow25("", this);
			new TradingJava.CategoryArrow26("", this);
			new TradingJava.CategoryArrow27("", this);
			new TradingJava.CategoryArrow28("", this);
			new TradingJava.CategoryArrow29("", this);
	}

	@Override
	protected void finish()
	{
				arrows.get(0).setSource(objects.get(6));
				arrows.get(0).setTarget(objects.get(0));
				arrows.get(1).setSource(objects.get(7));
				arrows.get(1).setTarget(objects.get(6));
				arrows.get(2).setSource(objects.get(8));
				arrows.get(2).setTarget(objects.get(7));
				arrows.get(3).setSource(objects.get(8));
				arrows.get(3).setTarget(objects.get(6));
				arrows.get(4).setSource(objects.get(7));
				arrows.get(4).setTarget(objects.get(5));
				arrows.get(5).setSource(objects.get(6));
				arrows.get(5).setTarget(objects.get(5));
				arrows.get(6).setSource(objects.get(3));
				arrows.get(6).setTarget(objects.get(0));
				arrows.get(7).setSource(objects.get(4));
				arrows.get(7).setTarget(objects.get(0));
				arrows.get(8).setSource(objects.get(1));
				arrows.get(8).setTarget(objects.get(0));
				arrows.get(9).setSource(objects.get(6));
				arrows.get(9).setTarget(objects.get(3));
				arrows.get(10).setSource(objects.get(6));
				arrows.get(10).setTarget(objects.get(4));
				arrows.get(11).setSource(objects.get(2));
				arrows.get(11).setTarget(objects.get(0));
				arrows.get(12).setSource(objects.get(8));
				arrows.get(12).setTarget(objects.get(2));
				arrows.get(13).setSource(objects.get(8));
				arrows.get(13).setTarget(objects.get(1));
				arrows.get(14).setSource(objects.get(6));
				arrows.get(14).setTarget(objects.get(2));
				arrows.get(15).setSource(objects.get(6));
				arrows.get(15).setTarget(objects.get(1));
				arrows.get(16).setSource(objects.get(11));
				arrows.get(16).setTarget(objects.get(7));
				arrows.get(17).setSource(objects.get(11));
				arrows.get(17).setTarget(objects.get(0));
				arrows.get(18).setSource(objects.get(11));
				arrows.get(18).setTarget(objects.get(0));
				arrows.get(19).setSource(objects.get(10));
				arrows.get(19).setTarget(objects.get(0));
				arrows.get(20).setSource(objects.get(10));
				arrows.get(20).setTarget(objects.get(7));
				arrows.get(21).setSource(objects.get(11));
				arrows.get(21).setTarget(objects.get(5));
				arrows.get(22).setSource(objects.get(10));
				arrows.get(22).setTarget(objects.get(5));
				arrows.get(23).setSource(objects.get(11));
				arrows.get(23).setTarget(objects.get(3));
				arrows.get(24).setSource(objects.get(11));
				arrows.get(24).setTarget(objects.get(4));
				arrows.get(25).setSource(objects.get(11));
				arrows.get(25).setTarget(objects.get(2));
				arrows.get(26).setSource(objects.get(11));
				arrows.get(26).setTarget(objects.get(1));
				arrows.get(27).setSource(objects.get(11));
				arrows.get(27).setTarget(objects.get(10));
				arrows.get(28).setSource(objects.get(9));
				arrows.get(28).setTarget(objects.get(7));
				arrows.get(29).setSource(objects.get(10));
				arrows.get(29).setTarget(objects.get(9));
		postSet();
	}


}
