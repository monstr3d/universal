import { TestObjectTransformer } from "../ExternalObjects/Test_Obects/TestObjectTransformer";
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
import { ObjectTransformerLink } from "../Library/Measurements/Arrows/ObjectTransformerLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { ObjectTransformer } from "../Library/Measurements/ObjectTransformer";
import { RecursiveFormula } from "../Library/Measurements/RecursiveFormula";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class TransformerRecursive_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 0.19290093047446638 ],
			["d", 9 ],
			["b", 0.0021041577613234159 ],
			["c", 0.52807761014574284 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0.19290093047446638);
		this.addVariableValue("Formula_2", 0, 0.0021041577613234159);
		this.addVariableValue("Formula_3", 0, 0.52807761014574284);
		this.addVariableValue("Formula_4", 0, 9);
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
			this.variable = this.aliasName2.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.aliasName3.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_3 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.aliasName0 = new AliasName(this.alias, "a");
		this.aliasName1 = new AliasName(this.alias, "b");
		this.aliasName2 = new AliasName(this.alias, "c");
		this.aliasName3 = new AliasName(this.alias, "d");
	}
	
	aliasName0 : IAliasName =  new FictiveAliasName();
	aliasName1 : IAliasName =  new FictiveAliasName();
	aliasName2 : IAliasName =  new FictiveAliasName();
	aliasName3 : IAliasName =  new FictiveAliasName();
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
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_0());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_1());
		var x2 = v.get("Formula_3");
		x2?.setIValue(this.get_2());
		var x3 = v.get("Formula_4");
		x3?.setIValue(this.get_3());
	}
	
}

class TransformerRecursive_CategoryObject_1 extends TestObjectTransformer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.coefficient = 0.24;
	}
}

class TransformerRecursive_CategoryObject_2 extends ObjectTransformer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	let map = new Map<string, string>(
	[
		["a", "Vector.Formula_1" ],
		["b", "Vector.Formula_2" ],
		["c", "Vector.Formula_3" ],
		["d", "Vector.Formula_4" ]
	]);
		this.setLinks(map);
	}
}

class TransformerRecursive_CategoryObject_3 extends RecursiveFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["k", 0.69999999999999996 ],
			["l", 0.01 ],
			["a", 1 ],
			["b", 3 ],
			["c", 5 ],
			["d", 4 ],
			["f", 1 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("a", 0, 1);
		this.addVariableValue("b", 0, 3);
		this.addVariableValue("c", 0, 5);
		this.addVariableValue("d", 0, 4);
		this.addVariableValue("f", 0, 1);
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
			this.variable = this.value2.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_2 = this.convert<number>(this.variable);
			this.variable = (this.var_1) + (this.var_2);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_3);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
			this.variable = this.measurement5.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.variable = this.value6.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_6 = this.convert<number>(this.variable);
			this.variable = (this.var_5) + (this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_8 = this.convert<number>(this.variable);
			this.variable = this.measurement9.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
			this.variable = this.value10.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_10 = this.convert<number>(this.variable);
			this.variable = (this.var_9) + (this.var_10);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_11 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_11);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_12 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_13 = this.convert<number>(this.variable);
			this.variable = this.aliasName14.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_14 = this.convert<number>(this.variable);
			this.var_15 = this.getInternalTime();
			this.variable = (this.var_14) * (this.var_15);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_16 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement1 = all[0].getMeasurement(0);
		this.value2 = this.output[0];
		this.measurement5 = all[0].getMeasurement(1);
		this.value6 = this.output[1];
		this.measurement9 = all[0].getMeasurement(2);
		this.value10 = this.output[2];
		this.aliasName0 = new AliasName(this.alias, "k");
		this.aliasName14 = new AliasName(this.alias, "l");
	}
	
	measurement1 : IMeasurement = new FictiveMeasurement();
	measurement5 : IMeasurement = new FictiveMeasurement();
	measurement9 : IMeasurement = new FictiveMeasurement();
	aliasName0 : IAliasName =  new FictiveAliasName();
	value2 : IValue = new FictiveValue();
	value6 : IValue = new FictiveValue();
	value10 : IValue = new FictiveValue();
	aliasName14 : IAliasName =  new FictiveAliasName();
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
	var_13 : number  = 0;
	var_14 : number  = 0;
	var_15 : number  = 0;
	var_16 : number  = 0;
	
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
	
	get_13() : any
	{
		return this.success ? this.var_13 : undefined;
	}
	
	get_14() : any
	{
		return this.success ? this.var_14 : undefined;
	}
	
	get_15() : any
	{
		return this.success ? this.var_15 : undefined;
	}
	
	get_16() : any
	{
		return this.success ? this.var_16 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("a");
		x0?.setIValue(this.get_4());
		var x1 = v.get("b");
		x1?.setIValue(this.get_8());
		var x2 = v.get("c");
		x2?.setIValue(this.get_12());
		var x3 = v.get("d");
		x3?.setIValue(this.get_13());
		var x4 = v.get("f");
		x4?.setIValue(this.get_16());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
			["a", "Vector.a" ],
			["c", "Vector.c" ],
			["b", "Vector.b" ]
		]);
		this.feedback = new FeedbackAliasCollection(map, this, this);
	}
}

class TransformerRecursive_CategoryObject_4 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class TransformerRecursive_CategoryArrow_0 extends ObjectTransformerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class TransformerRecursive_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class TransformerRecursive_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class TransformerRecursive_CategoryArrow_3 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class TransformerRecursive_CategoryArrow_4 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class TransformerRecursive_CategoryArrow_5 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class TransformerRecursive extends Desktop
{
	constructor()
	{
		super();

		this.name = "TransformerRecursive";

		new TransformerRecursive_CategoryObject_0(this, "Vector");
		new TransformerRecursive_CategoryObject_1(this, "Source");
		new TransformerRecursive_CategoryObject_2(this, "Transformer");
		new TransformerRecursive_CategoryObject_3(this, "Recursive");
		new TransformerRecursive_CategoryObject_4(this, "Chart");
		new TransformerRecursive_CategoryArrow_0(this, "");
		new TransformerRecursive_CategoryArrow_1(this, "");
		new TransformerRecursive_CategoryArrow_2(this, "");
		new TransformerRecursive_CategoryArrow_3(this, "");
		new TransformerRecursive_CategoryArrow_4(this, "");
		new TransformerRecursive_CategoryArrow_5(this, "");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[2]);
		arrows[0].setTarget(objects[1]);
		arrows[1].setSource(objects[2]);
		arrows[1].setTarget(objects[0]);
		arrows[2].setSource(objects[3]);
		arrows[2].setTarget(objects[2]);
		arrows[3].setSource(objects[3]);
		arrows[3].setTarget(objects[0]);
		arrows[4].setSource(objects[4]);
		arrows[4].setTarget(objects[3]);
		arrows[5].setSource(objects[4]);
		arrows[5].setTarget(objects[2]);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
		(objects[3] as unknown as IPostSetArrow).postSetArrow();
	}
}
