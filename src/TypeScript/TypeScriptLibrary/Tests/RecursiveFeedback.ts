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
import { RecursiveFormula } from "../Library/Measurements/RecursiveFormula";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class RecursiveFeedback_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["c", 3 ],
			["a", 7.1237279830727527 ],
			["f", 4 ],
			["b", 253.52416418337546 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 172.80153239213379);
		this.addVariableValue("Formula_2", 0, 11.600000000000001);
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
			this.variable = (this.var_0) + (this.var_1);
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
			this.variable = (this.var_8) * (this.var_4);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "a");
		this.aliasName1 = new AliasName(this.alias, "b");
		this.aliasName3 = new AliasName(this.alias, "c");
		this.aliasName8 = new AliasName(this.alias, "f");
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
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_7());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_9());
	}
	
}

class RecursiveFeedback_CategoryObject_1 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["k", 1 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 172.80153239213379);
		this.addVariableValue("Formula_2", 0, 11.600000000000001);
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
			this.variable = this.measurement3.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_3);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement1 = all[0].getMeasurement(0);
		this.measurement3 = all[0].getMeasurement(1);
		this.aliasName0 = new AliasName(this.alias, "k");
	}
	
	measurement1 ! : IMeasurement;
	measurement3 ! : IMeasurement;
	aliasName0 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	
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
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_2());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_4());
	}
	
}

class RecursiveFeedback_CategoryObject_2 extends RecursiveFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["k", 1 ],
			["a", 0 ],
			["b", 1 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("a", 0, 0);
		this.addVariableValue("b", 0, 1);
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
			this.variable = this.aliasName3.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_3 = this.convert<number>(this.variable);
			this.variable = this.value4.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_4 = this.convert<number>(this.variable);
			this.variable = this.measurement5.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = (this.var_4) + (this.var_5);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_6 = this.convert<number>(this.variable);
			this.variable = (this.var_3) * (this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.value0 = this.output[1];
		this.measurement1 = all[0].getMeasurement(0);
		this.value4 = this.output[0];
		this.measurement5 = all[0].getMeasurement(1);
		this.aliasName3 = new AliasName(this.alias, "k");
	}
	
	measurement1 ! : IMeasurement;
	measurement5 ! : IMeasurement;
	value0 ! : IValue;
	aliasName3 ! : IAliasName;
	value4 ! : IValue;
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
		var v = this.variables;
		var x0 = v.get("a");
		x0?.setIValue(this.get_2());
		var x1 = v.get("b");
		x1?.setIValue(this.get_7());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
			["b", "X.b" ]
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class RecursiveFeedback_CategoryObject_3 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class RecursiveFeedback_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class RecursiveFeedback_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class RecursiveFeedback_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class RecursiveFeedback_CategoryArrow_3 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class RecursiveFeedback extends Desktop
{
	constructor()
	{
		super();

		this.name = "RecursiveFeedback";

		new RecursiveFeedback_CategoryObject_0(this, "X");
		new RecursiveFeedback_CategoryObject_1(this, "Y");
		new RecursiveFeedback_CategoryObject_2(this, "Rec");
		new RecursiveFeedback_CategoryObject_3(this, "Chart");
		new RecursiveFeedback_CategoryArrow_0(this, "");
		new RecursiveFeedback_CategoryArrow_1(this, "");
		new RecursiveFeedback_CategoryArrow_2(this, "");
		new RecursiveFeedback_CategoryArrow_3(this, "");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[1]);
		arrows[0].setTarget(objects[0]);
		arrows[1].setSource(objects[3]);
		arrows[1].setTarget(objects[1]);
		arrows[2].setSource(objects[2]);
		arrows[2].setTarget(objects[0]);
		arrows[3].setSource(objects[3]);
		arrows[3].setTarget(objects[2]);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
	}
}
