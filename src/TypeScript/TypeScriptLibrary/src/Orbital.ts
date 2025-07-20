class Orbital_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["b", 1 ],
			["a", 5 ]
		]);
		this.performer.SetAliasMap(map, this);
		let feed = new Map<number, string>(
		[
		]);
		this.performer.copyMap(feed, this.feedback);
		this.arguments.push("t = Time");
		let ops = new Map<number, string>(
		[
		]);
		this.performer.copyMap(ops, this.operationNames);
		this.init();
	}

		calculateTree() : void
		{
			this.success = true;
			var_0 = this.measurement.getOperation()();
			var_1 = this.aliasName.getAliasNameValue();
			var_2 = (var_0) * (var_1);
			var_3 = this.aliasName.getAliasNameValue();
			var_4 = (var_3) * (var_0);
			var_5 = this.measurement.getOperation()();
			var_7 = Math.pow(var_5, var_6);
			var_8 = Math.sin(var_7);
			var_9 = (var_4) + (var_8);
		}
	
	init() : void
	{
		this.mapOperations.set(0, this.get_0);
		this.mapOperations.set(1, this.get_1);
		this.mapOperations.set(2, this.get_2);
		this.mapOperations.set(3, this.get_3);
		this.mapOperations.set(4, this.get_4);
		this.mapOperations.set(5, this.get_5);
		this.mapOperations.set(6, this.get_6);
		this.mapOperations.set(7, this.get_7);
		this.mapOperations.set(8, this.get_8);
		this.mapOperations.set(9, this.get_9);
	}
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
	



export class Orbital extends Desktop
{
	constructor()
	{
		super();

		this.name = "Orbital";

		new Orbital_CategoryObject_0(this, "input");

		let arrows  = this.getArrows();
		let objects = this.getObjects();

		(objects[0] as unknown as IPostSetArrow).postSetArrow();
	}
}
