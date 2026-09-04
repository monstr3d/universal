import { AliasName } from "../Library/AliasName";
import { Desktop } from "../Library/Desktop";
import { IAliasName } from "../Library/Interfaces/IAliasName";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { Variable } from "../Library/Measurements/Variables/Variable";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class Orbital_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 5 ],
			["b", 1 ]
		]);
		this.addVariable(new Variable("Formula_1", 0, 0));
		this.addVariable(new Variable("Formula_2", 0, 0));
		this.performer.setAliasMap(map, this);
	}

		calculateTree() : void
		{
			this.success = true;
			this.var_0 = this.getInternalTime();
			this.variable = this.aliasName1.getAliasNameValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = (this.var_0) * (this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.aliasName3.getAliasNameValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = (this.var_3) * (this.var_0);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
			this.var_5 = this.getInternalTime();
			this.variable = Math.pow(this.var_5, this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
			this.variable = Math.sin(this.var_7);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_8 = this.convert<number>(this.variable);
			this.variable = (this.var_4) + (this.var_8);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_9 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		this.aliasName1 = new AliasName(this.alias, "b");
		this.aliasName3 = new AliasName(this.alias, "a");
	}
	aliasName1 !: IAliasName;
	aliasName3 !: IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	var_6 : number  = 2;
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
	}
	
}

class Orbital_CategoryObject_1 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["a", 7 ],
			["b", 8 ]
		]);
		this.addVariable(new Variable("Formula_1", 0, 0));
		this.addVariable(new Variable("Formula_2", 0, 0));
		this.addVariable(new Variable("Formula_3", 0, 0));
		this.performer.setAliasMap(map, this);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.aliasName0.getAliasNameValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = Math.pow(this.var_0, this.var_1);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.aliasName3.getAliasNameValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_3 = this.convert<number>(this.variable);
			this.variable = Math.cos(this.var_3);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_4 = this.convert<number>(this.variable);
			this.variable = this.aliasName5.getAliasNameValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_5 = this.convert<number>(this.variable);
			this.var_6 = this.getInternalTime();
			this.variable = (this.var_5) * (this.var_6);
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_7 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		this.aliasName0 = new AliasName(this.alias, "a");
		this.aliasName3 = new AliasName(this.alias, "b");
		this.aliasName5 = new AliasName(this.alias, "a");
	}
	aliasName0 !: IAliasName;
	aliasName3 !: IAliasName;
	aliasName5 !: IAliasName;
	var_0 : number  = 0;
	var_1 : number  = 2;
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
	}
	
}

class Orbital_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Orbital extends Desktop
{
	constructor()
	{
		super();

		this.name = "Orbital";

		new Orbital_CategoryObject_0(this, "input");
		new Orbital_CategoryObject_1(this, "Output");
		new Orbital_CategoryArrow_0(this, "22");

		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		arrows[0].setSource(objects[1]);
		arrows[0].setTarget(objects[0]);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
	}
}
