import { Desktop } from "../Library/Desktop";
import { IDesktop } from "../Library/IDesktop";
import { IPostSetArrow } from "../Library/IPostSetArrow";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { DataLink } from "../Library/Measurements/DataLink";
import { RandomGenerator } from "../Library/Measurements/RandomGenerator";
import { Recursive } from "../Library/Measurements/Recursive";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";

class Orbital_CategoryObject_0 extends RandomGenerator
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryObject_1 extends RandomGenerator
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryObject_2 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryObject_3 extends Recursive
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryObject_4 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Orbital_CategoryArrow_3 extends DataLink
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

		new Orbital_CategoryObject_0(this, "X");
		new Orbital_CategoryObject_1(this, "Y");
		new Orbital_CategoryObject_2(this, "Data");
		new Orbital_CategoryObject_3(this, "Recursive");
		new Orbital_CategoryObject_4(this, "Chart");
		new Orbital_CategoryArrow_0(this, "2");
		new Orbital_CategoryArrow_1(this, "1");
		new Orbital_CategoryArrow_2(this, "3");
		new Orbital_CategoryArrow_3(this, "4");

		let arrows  = this.getArrows();
		let objects = this.getObjects();

		arrows[0].setSource(objects[2]);
		arrows[0].setTarget(objects[1]);
		arrows[1].setSource(objects[2]);
		arrows[1].setTarget(objects[0]);
		arrows[2].setSource(objects[3]);
		arrows[2].setTarget(objects[2]);
		arrows[3].setSource(objects[4]);
		arrows[3].setTarget(objects[3]);
		(objects[2] as unknown as IPostSetArrow).PostSetArrow();
		(objects[3] as unknown as IPostSetArrow).PostSetArrow();
	}
}
