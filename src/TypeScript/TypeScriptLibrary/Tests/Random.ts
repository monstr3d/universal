import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { FeedbackAliasCollection } from "../Library/FeedbackAliasCollection";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { RandomGenerator } from "../Library/Measurements/RandomGenerator";
import { RecursiveFormula } from "../Library/Measurements/RecursiveFormula";
import { Variable } from "../Library/Measurements/Variables/Variable";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class Random_CategoryObject_0 extends RandomGenerator
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Random_CategoryObject_1 extends RandomGenerator
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Random_CategoryObject_2 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["f", 0.0040000000000000001 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariable(new Variable("Formula_1", 0, 0));
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = Math.pow(this.var_0, this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.measurement3.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = Math.pow(this.var_3, this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = (this.var_2) + (this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_6 = this.convert<number>(this.variable);
			this.variable = (this.var_6) > (this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_8 = this.convert<boolean>(this.variable);
			this.variable = this.aliasName10.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_10 = this.convert<number>(this.variable);
			this.variable = (this.var_8) ? (this.var_9) : (this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement0 = all[0].getMeasurement(0);
		this.measurement3 = all[1].getMeasurement(0);
		this.aliasName10 = new AliasName(this.alias, "f");
	}
	
	measurement0 ! : IMeasurement;
	measurement3 ! : IMeasurement;
	aliasName10 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 2;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 2;
	var_5 : number  = 0;
	var_6 : number  = 0;
	var_7 : number  = 1;
	var_8 : boolean  = false;
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
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
		]);
	}
}

class Random_CategoryObject_3 extends RecursiveFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["d", 0 ],
			["c", 0 ],
			["a", 0 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariable(new Variable("a", 0, 0));
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.value0.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.measurement1.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = (this.var_0) + (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.value0 = this.output[0];
		this.measurement1 = all[0].getMeasurement(0);
	}
	
	value0 ! : IValue;
	measurement1 ! : IMeasurement;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	
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
	save() : void {
		var v = this.variables;
		var x0 = v.get("a");
		x0?.setIValue(this.get_2());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
		]);
	}
}

class Random_CategoryObject_4 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Random_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Random_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Random_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Random_CategoryArrow_3 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Random extends Desktop
{
	constructor()
	{
		super();

		this.name = "Random";

		new Random_CategoryObject_0(this, "X");
		new Random_CategoryObject_1(this, "Y");
		new Random_CategoryObject_2(this, "Data");
		new Random_CategoryObject_3(this, "Recursive");
		new Random_CategoryObject_4(this, "Chart");
		new Random_CategoryArrow_0(this, "2");
		new Random_CategoryArrow_1(this, "1");
		new Random_CategoryArrow_2(this, "3");
		new Random_CategoryArrow_3(this, "4");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[2]);
		arrows[0].setTarget(objects[1]);
		arrows[1].setSource(objects[2]);
		arrows[1].setTarget(objects[0]);
		arrows[2].setSource(objects[3]);
		arrows[2].setTarget(objects[2]);
		arrows[3].setSource(objects[4]);
		arrows[3].setTarget(objects[3]);
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
		(objects[3] as unknown as IPostSetArrow).postSetArrow();
	}
}
