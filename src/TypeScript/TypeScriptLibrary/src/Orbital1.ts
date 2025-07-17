import { IDesktop } from "../Library/IDesktop";
import { DataLink } from "../Library/Measurements/DataLink";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { Desktop } from "../Library/Desktop"
import { IPostSetArrow } from "../Library/IPostSetArrow";

class Orbital1_CategoryObject_0 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital1_CategoryObject_1 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital1_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Orbital1 extends Desktop
{
	constructor()
	{
		super();
		new Orbital1_CategoryObject_0(this, "input");
		new Orbital1_CategoryObject_1(this, "Output");
		new Orbital1_CategoryArrow_0(this, "1");

		let arrows  = this.getArrows();
		let objects = this.getObjects();

		arrows[0].setSource(objects[1]);
		arrows[0].setTarget(objects[0]);
		(objects[0] as unknown as IPostSetArrow).PostSetArrow();
		(objects[1] as unknown as IPostSetArrow).PostSetArrow();
	}
}
