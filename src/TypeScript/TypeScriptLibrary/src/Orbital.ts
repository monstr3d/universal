import { Desktop } from "../Library/Desktop";
import { IDesktop } from "../Library/IDesktop";
import { IPostSetArrow } from "../Library/IPostSetArrow";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

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
	}



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

		(objects[0] as unknown as IPostSetArrow).PostSetArrow();
	}
}
