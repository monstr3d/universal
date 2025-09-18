import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { FeedbackAliasCollection } from "../Library/FeedbackAliasCollection";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { DifferentialEquationSolverFormula } from "../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class ODE_Feed_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["k", 3 ],
			["l", 5 ],
			["b", -0.73652631234982491 ],
			["a", -0.33822685902599364 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, -0);
		this.addVariableValue("Formula_2", 0, -3.6826315617491243);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.aliasName0.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.aliasName1.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_1 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.aliasName3.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_3 = this.convert<number>(this.variable);
			this.var_4 = this.getInternalTime();
			this.variable = (this.var_3) * (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = Math.sin(this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_6 = this.convert<number>(this.variable);
			this.variable = (this.var_2) * (this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
			this.variable = this.aliasName8.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_8 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_8);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
			this.variable = (this.var_3) * (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_10 = this.convert<number>(this.variable);
			this.variable = Math.cos(this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
			this.variable = (this.var_9) * (this.var_11);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_12 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "l");
		this.aliasName1 = new AliasName(this.alias, "a");
		this.aliasName3 = new AliasName(this.alias, "k");
		this.aliasName8 = new AliasName(this.alias, "b");
	}
	
	aliasName0 ! : IAliasName;
	aliasName1 ! : IAliasName;
	aliasName3 ! : IAliasName;
	aliasName8 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	var_6 : number  = 0;
	var_7 : number  = 0;
	var_8 : number  = 0;
	var_9 : number  = 0;
	var_10 : number  = 0;
	var_11 : number  = 0;
	var_12 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	
	get_2() : any
	{
		return this.success ? this.var_2 : undefined;
	}
	
	get_3() : any
	{
		return this.success ? this.var_3 : undefined;
	}
	
	get_4() : any
	{
		return this.success ? this.var_4 : undefined;
	}
	
	get_5() : any
	{
		return this.success ? this.var_5 : undefined;
	}
	
	get_6() : any
	{
		return this.success ? this.var_6 : undefined;
	}
	
	get_7() : any
	{
		return this.success ? this.var_7 : undefined;
	}
	
	get_8() : any
	{
		return this.success ? this.var_8 : undefined;
	}
	
	get_9() : any
	{
		return this.success ? this.var_9 : undefined;
	}
	
	get_10() : any
	{
		return this.success ? this.var_10 : undefined;
	}
	
	get_11() : any
	{
		return this.success ? this.var_11 : undefined;
	}
	
	get_12() : any
	{
		return this.success ? this.var_12 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_7());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_12());
	}
	
}

class ODE_Feed_CategoryObject_1 extends DifferentialEquationSolverFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["k", 0.10000000000000001 ],
			["l", 0.10000000000000001 ],
			["x", 0 ],
			["y", 1 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("x", 0, 0);
		this.addVariableValue("y", 0, 1);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.value0.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.variable = -(this.var_0);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = this.aliasName2.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.measurement3.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = (this.var_2) * (this.var_3);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
			this.variable = (this.var_1) + (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = this.value6.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_6 = this.convert<number>(this.variable);
			this.variable = this.aliasName7.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_7 = this.convert<number>(this.variable);
			this.variable = this.measurement8.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_8 = this.convert<number>(this.variable);
			this.variable = (this.var_7) * (this.var_8);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
			this.variable = (this.var_6) - (this.var_9);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_10 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.value0 = this.output[1];
		this.measurement3 = all[0].getMeasurement(0);
		this.value6 = this.output[0];
		this.measurement8 = all[0].getMeasurement(1);
		this.aliasName2 = new AliasName(this.alias, "k");
		this.aliasName7 = new AliasName(this.alias, "l");
	}
	
	value0 ! : IValue;
	measurement3 ! : IMeasurement;
	value6 ! : IValue;
	measurement8 ! : IMeasurement;
	aliasName2 ! : IAliasName;
	aliasName7 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	var_6 : number  = 0;
	var_7 : number  = 0;
	var_8 : number  = 0;
	var_9 : number  = 0;
	var_10 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	
	get_2() : any
	{
		return this.success ? this.var_2 : undefined;
	}
	
	get_3() : any
	{
		return this.success ? this.var_3 : undefined;
	}
	
	get_4() : any
	{
		return this.success ? this.var_4 : undefined;
	}
	
	get_5() : any
	{
		return this.success ? this.var_5 : undefined;
	}
	
	get_6() : any
	{
		return this.success ? this.var_6 : undefined;
	}
	
	get_7() : any
	{
		return this.success ? this.var_7 : undefined;
	}
	
	get_8() : any
	{
		return this.success ? this.var_8 : undefined;
	}
	
	get_9() : any
	{
		return this.success ? this.var_9 : undefined;
	}
	
	get_10() : any
	{
		return this.success ? this.var_10 : undefined;
	}
	save() : void {
		var v = this.derivations;
		var x0 = v.get("y");
		x0?.setIValue(this.get_10());
		var x1 = v.get("x");
		x1?.setIValue(this.get_5());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
			["y", "X.b" ],
			["x", "X.a" ]
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class ODE_Feed_CategoryObject_2 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
		this.addVariableValue("Formula_2", 0, 4.6826315617491243);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.measurement1.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = (this.var_0) + (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.measurement3.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = this.measurement4.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
			this.variable = (this.var_3) - (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement0 = all[0].getMeasurement(0);
		this.measurement1 = all[1].getMeasurement(0);
		this.measurement3 = all[0].getMeasurement(1);
		this.measurement4 = all[1].getMeasurement(1);
	}
	
	measurement0 ! : IMeasurement;
	measurement1 ! : IMeasurement;
	measurement3 ! : IMeasurement;
	measurement4 ! : IMeasurement;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	
	get_2() : any
	{
		return this.success ? this.var_2 : undefined;
	}
	
	get_3() : any
	{
		return this.success ? this.var_3 : undefined;
	}
	
	get_4() : any
	{
		return this.success ? this.var_4 : undefined;
	}
	
	get_5() : any
	{
		return this.success ? this.var_5 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_2());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_5());
	}
	
}

class ODE_Feed_CategoryObject_3 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feed_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feed_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feed_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feed_CategoryArrow_3 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feed_CategoryArrow_4 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class ODE_Feed extends Desktop
{
	constructor()
	{
		super();

		this.name = "ODE_Feed";

		new ODE_Feed_CategoryObject_0(this, "X");
		new ODE_Feed_CategoryObject_1(this, "Diff");
		new ODE_Feed_CategoryObject_2(this, "Y");
		new ODE_Feed_CategoryObject_3(this, "Chart");
		new ODE_Feed_CategoryArrow_0(this, "");
		new ODE_Feed_CategoryArrow_1(this, "");
		new ODE_Feed_CategoryArrow_2(this, "");
		new ODE_Feed_CategoryArrow_3(this, "");
		new ODE_Feed_CategoryArrow_4(this, "");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[1]);
		arrows[0].setTarget(objects[0]);
		arrows[1].setSource(objects[2]);
		arrows[1].setTarget(objects[1]);
		arrows[2].setSource(objects[2]);
		arrows[2].setTarget(objects[0]);
		arrows[3].setSource(objects[3]);
		arrows[3].setTarget(objects[1]);
		arrows[4].setSource(objects[3]);
		arrows[4].setTarget(objects[2]);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
	}
}
