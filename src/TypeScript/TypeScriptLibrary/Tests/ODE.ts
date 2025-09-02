import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { FeedbackAliasCollection } from "../Library/FeedbackAliasCollection";
import { FictiveAliasName } from "../Library/Fiction/FictiveAliasName";
import { FictiveMeasurement } from "../Library/Fiction/FictiveMeasurement";
import { FictiveValue } from "../Library/Fiction/FictiveValue";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { DifferentialEquationSolverFormula } from "../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class ODE_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["b", 1 ],
			["a", 1 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
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
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "a");
		this.aliasName1 = new AliasName(this.alias, "b");
	}
	
	aliasName0 : IAliasName =  new FictiveAliasName();
	aliasName1 : IAliasName =  new FictiveAliasName();
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
		x0?.setIValue(this.get_5());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class ODE_CategoryObject_1 extends DifferentialEquationSolverFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 1 ],
			["y", 1 ],
			["x", 0 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("x", 0, 0);
		this.addVariableValue("y", 0, 0);
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
	
	value2 : IValue = new FictiveValue();
	value4 : IValue = new FictiveValue();
	measurement6 : IMeasurement = new FictiveMeasurement();
	aliasName0 : IAliasName =  new FictiveAliasName();
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
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class ODE_CategoryObject_2 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ODE_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class ODE extends Desktop
{
	constructor()
	{
		super();

		this.name = "ODE";

		new ODE_CategoryObject_0(this, "Init");
		new ODE_CategoryObject_1(this, "ODE");
		new ODE_CategoryObject_2(this, "Chart");
		new ODE_CategoryArrow_0(this, "1");
		new ODE_CategoryArrow_1(this, "");

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
