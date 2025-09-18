import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { FeedbackAliasCollection } from "../Library/FeedbackAliasCollection";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { Variable } from "../Library/Measurements/Variables/Variable";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class ConditionTest_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
		]);
		this.performer.setAliasMap(map, this);
		this.addVariable(new Variable("Formula_1", 0, 0));
	}

		calculateTree() : void
		{
			this.success = true;
			this.var_0 = this.getInternalTime();
			this.variable = Math.sin(this.var_0);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
	}
	
	var_0 : number  = 0;
	var_1 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	
	get_1() : any
	{
		return this.success ? this.var_1 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_1());
	}
	
	setFeedback(): void {
		let map = new Map<string, string>(
		[
		]);
	}
}

class ConditionTest_CategoryObject_1 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 0.995 ]
		]);
		this.performer.setAliasMap(map, this);
		this.addVariable(new Variable("Formula_1", false, false));
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.aliasName1.getAliasNameValue()
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_1 = this.convert<number>(this.variable);
			this.variable = (this.var_0) > (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<boolean>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
		this.measurement0 = all[0].getMeasurement(0);
		this.aliasName1 = new AliasName(this.alias, "a");
	}
	
	measurement0 ! : IMeasurement;
	aliasName1 ! : IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : boolean  = false;
	
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
		]);
	}
}

class ConditionTest_CategoryObject_2 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ConditionTest_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ConditionTest_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class ConditionTest_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class ConditionTest extends Desktop
{
	constructor()
	{
		super();

		this.name = "ConditionTest";

		new ConditionTest_CategoryObject_0(this, "Input");
		new ConditionTest_CategoryObject_1(this, "Condition");
		new ConditionTest_CategoryObject_2(this, "Chart");
		new ConditionTest_CategoryArrow_0(this, "");
		new ConditionTest_CategoryArrow_1(this, "");
		new ConditionTest_CategoryArrow_2(this, "");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[1]);
		arrows[0].setTarget(objects[0]);
		arrows[1].setSource(objects[2]);
		arrows[1].setTarget(objects[1]);
		arrows[2].setSource(objects[2]);
		arrows[2].setTarget(objects[0]);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
	}
}
