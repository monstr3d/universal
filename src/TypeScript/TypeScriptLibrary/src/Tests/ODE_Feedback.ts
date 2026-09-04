import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { DifferentialEquationSolverFormula } from "../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class ODE_Feedback_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 1 ],
			["k", 2 ],
			["d", -0.17015052092374328 ],
			["b", 1 ],
			["c", 0.31314560830292659 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0.017747760535215762);
		this.addVariableValue("Formula_2", 0, 0.31314560830292659);
		this.addVariableValue("Formula_3", 0, -0.17015052092374328);
		this.addVariableValue("Formula_4", 0, 2);
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
			this.var_2 = this.getInternalTime();
			this.variable = (this.var_1) * (this.var_2);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = Math.sin(this.var_3);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = this.aliasName6.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_6 = this.convert<number>(this.variable);
			this.variable = this.aliasName7.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_7 = this.convert<number>(this.variable);
			this.variable = this.aliasName8.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_8 = this.convert<number>(this.variable);
			this.variable = (this.var_7) - (this.var_8);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
			this.variable = (this.var_6) * (this.var_9);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_10 = this.convert<number>(this.variable);
			this.variable = (this.var_5) + (this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "a");
		this.aliasName1 = new AliasName(this.alias, "b");
		this.aliasName6 = new AliasName(this.alias, "k");
		this.aliasName7 = new AliasName(this.alias, "c");
		this.aliasName8 = new AliasName(this.alias, "d");
	}
	
	aliasName0 ! : IAliasName;
	aliasName1 ! : IAliasName;
	aliasName6 ! : IAliasName;
	aliasName7 ! : IAliasName;
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
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_11());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_7());
		var x2 = v.get("Formula_3");
		x2?.setIValue(this.get_8());
		var x3 = v.get("Formula_4");
		x3?.setIValue(this.get_6());
	}
	
}

class ODE_Feedback_CategoryObject_1 extends DifferentialEquationSolverFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 1 ],
			["y", 1 ],
			["x", 0 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("x", 0, 0);
		this.addVariableValue("y", 0, 1);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.aliasName0.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.variable = -(this.var_0);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = this.value2.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = (this.var_1) * (this.var_2);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = this.value4.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_4 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = this.measurement6.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_6 = this.convert<number>(this.variable);
			this.variable = (this.var_5) + (this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.value2 = this.output[1];
		this.value4 = this.output[0];
		this.measurement6 = all[0].getMeasurement(0);
		this.aliasName0 = new AliasName(this.alias, "a");
	}
	
	value2 ! : IValue;
	value4 ! : IValue;
	measurement6 ! : IMeasurement;
	aliasName0 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	var_6 : number  = 0;
	var_7 : number  = 0;
	
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
	save() : void {
		var v = this.derivations;
		var x0 = v.get("y");
		x0?.setIValue(this.get_7());
		var x1 = v.get("x");
		x1?.setIValue(this.get_3());
	}
	
}

class ODE_Feedback_CategoryObject_2 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feedback_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_Feedback_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class ODE_Feedback extends Desktop
{
	constructor()
	{
		super();

		this.name = "ODE_Feedback";

		new ODE_Feedback_CategoryObject_0(this, "Init");
		new ODE_Feedback_CategoryObject_1(this, "ODE");
		new ODE_Feedback_CategoryObject_2(this, "Chart");
		new ODE_Feedback_CategoryArrow_0(this, "1");
		new ODE_Feedback_CategoryArrow_1(this, "");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[1]);
		arrows[0].setTarget(objects[0]);
		arrows[1].setSource(objects[2]);
		arrows[1].setTarget(objects[1]);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
	}
}
