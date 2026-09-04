import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IFactory } from "../Library/Interfaces/IFactory";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { FeedbackAliasCollection } from "../Library/Measurements/FeedBack/FeedbackAliasCollection";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { RecursiveFormula } from "../Library/Measurements/RecursiveFormula";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class DonchianDesktop_CategoryObject_0 extends RecursiveFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["t", -0.058407839907797091 ],
			["x", 2 ],
			["y", 3 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("x", 0, 2);
		this.addVariableValue("y", 0, 3);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.aliasName0.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.value1.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_1 = this.convert<number>(this.variable);
			this.variable = this.value2.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = (this.var_1) + (this.var_2);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements()
		this.fic = all
		this.value1 = this.output[0];
		this.value2 = this.output[1];
		this.aliasName0 = new AliasName(this.alias, "t");
	}
	
	aliasName0 ! : IAliasName;
	value1 ! : IValue;
	value2 ! : IValue;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	
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
	save() : void {
		var v = this.variables;
		var x0 = v.get("x");
		x0?.setIValue(this.get_0());
		var x1 = v.get("y");
		x1?.setIValue(this.get_3());
	}
	
}

class DonchianDesktop_CategoryObject_1 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", -0.10000000000000001 ]
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
			this.variable = this.measurement1.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements()
		this.fic = all
		this.measurement1 = all[0].getMeasurement(1);
		this.aliasName0 = new AliasName(this.alias, "a");
	}
	
	measurement1 ! : IMeasurement;
	aliasName0 ! : IAliasName;
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
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_2());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
			["Formula_1", "R.t" ]
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class DonchianDesktop_CategoryObject_2 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class DonchianDesktop_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class DonchianDesktop_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class DonchianDesktop_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class DonchianDesktop extends Desktop
{

	public static async getDesktopAsync(controller : AbortController, factory?: IFactory): Promise<IDesktop> {
		let d = new DonchianDesktop(factory)
		await d.loadAsync(controller)
		return d
	}

	constructor(factory? : IFactory)
	{
		super(factory);

		this.name = "DonchianDesktop";

		this.mapObjects.set("DonchianDesktop_CategoryObject_0", new DonchianDesktop_CategoryObject_0(this, "R"))
		this.mapObjects.set("DonchianDesktop_CategoryObject_1", new DonchianDesktop_CategoryObject_1(this, "F"))
		this.mapObjects.set("DonchianDesktop_CategoryObject_2", new DonchianDesktop_CategoryObject_2(this, "Chart"))
		new DonchianDesktop_CategoryArrow_0(this, "");
		new DonchianDesktop_CategoryArrow_1(this, "");
		new DonchianDesktop_CategoryArrow_2(this, "");
	this.finish()
}

finish() : void
{
		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		let s0 = this.mapObjects.get("DonchianDesktop_CategoryObject_1")
		if(s0 != undefined)    arrows[0].setSource(s0);
		let t0 = this.mapObjects.get("DonchianDesktop_CategoryObject_0")
		if(t0 != undefined)    arrows[0].setTarget(t0);
		let s1 = this.mapObjects.get("DonchianDesktop_CategoryObject_2")
		if(s1 != undefined)    arrows[1].setSource(s1);
		let t1 = this.mapObjects.get("DonchianDesktop_CategoryObject_0")
		if(t1 != undefined)    arrows[1].setTarget(t1);
		let s2 = this.mapObjects.get("DonchianDesktop_CategoryObject_2")
		if(s2 != undefined)    arrows[2].setSource(s2);
		let t2 = this.mapObjects.get("DonchianDesktop_CategoryObject_1")
		if(t2 != undefined)    arrows[2].setTarget(t2);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
	}
}
