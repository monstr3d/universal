import { BelongsToCollection } from "../Library/Arrows/BelognsToCollection";
import { Desktop } from "../Library/Desktop";
import { EventLink } from "../Library/Event/Objects/EventLink";
import { TimerObject } from "../Library/Event/Objects/TimerObject";
import { IDesktop } from "../Library/Interfaces/IDesktop";
import { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { ReferenceFrameArrow } from "../Library/Motion6D/Arrows/ReferenceFrameArrow";
import { RigidReferenceFrame } from "../Library/Motion6D/Objects/RigidReferenceFrame";
import { SerializablePosition } from "../Library/Motion6D/Objects/SerializablePosition";
import { Basic3DShape } from "../Library/Motion6D/Objects/Shapes/Basic3DShape";
import { BasicCamera } from "../Library/Motion6D/Visible/BasicCamera";
import { IVisible } from "../Library/Motion6D/Visible/Interfaces/IVisible";
import { VisibleConsumerLink } from "../Library/Motion6D/Visible/VisibleConsumerLink";
import { TimeSpan } from "../Library/Utilities/DateTime/TimeSpan";

		class Cesna_CategoryObject_0_Visible extends Basic3DShape
		{
			constructor(desktop: IDesktop, name: string)
			{
				super(desktop, name);
			}
		}
class Cesna_CategoryObject_0 extends SerializablePosition
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.setParameters(new Cesna_CategoryObject_0(desktop, name))
	}
}

class Cesna_CategoryObject_2 extends BasicCamera
{
    postVisibleObject(object: IVisible): void {
        throw new Error("Method not implemented.");
    }
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryObject_3 extends TimerObject
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.span = new TimeSpan(100)
	}
}

class Cesna_CategoryObject_4 extends RigidReferenceFrame
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(40);
		this.relativePosition.push(40);
		this.relativePosition.push(40);
	
		this.relativePosition = [];
		this.relativePosition.push(0.88047623921714935);
		this.relativePosition.push(-0.27984814233312139);
		this.relativePosition.push(0.36470519963100095);
		this.relativePosition.push(0.11591689595929504);
	
	}
}

class Cesna_CategoryObject_5 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
	}

		calculateTree() : void
		{
			this.success = true;
			this.var_0 = this.getInternalTime();
		}
	
	init() : void
	{
		var all = this.getAllMeasurements();
	}
	
	var_0 : number  = 0;
	
	get_0() : any
	{
		return this.success ? this.var_0 : undefined;
	}
	save() : void {
		var v = this.variables;
		var x0 = v.get("Formula_1");
		x0?.setIValue(this.get_0());
	}
	
}

class Cesna_CategoryObject_6 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_0 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_1 extends VisibleConsumerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_2 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_3 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_4 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_5 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Cesna_CategoryArrow_6 extends EventLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Cesna extends Desktop
{
	constructor()
	{
		super();

		this.name = "Cesna";

		this.mapObjects.set("Cesna_CategoryObject_0", new Cesna_CategoryObject_0(this, "pLANE"))
		this.mapObjects.set("Cesna_CategoryObject_0_Visible", new Cesna_CategoryObject_0_Visible(this, "pLANE"))
		this.mapObjects.set("Cesna_CategoryObject_2", new Cesna_CategoryObject_2(this, "Camera"))
		this.mapObjects.set("Cesna_CategoryObject_3", new Cesna_CategoryObject_3(this, "Timer"))
		this.mapObjects.set("Cesna_CategoryObject_4", new Cesna_CategoryObject_4(this, ""))
		this.mapObjects.set("Cesna_CategoryObject_5", new Cesna_CategoryObject_5(this, "Time"))
		this.mapObjects.set("Cesna_CategoryObject_6", new Cesna_CategoryObject_6(this, "Chart"))
		new Cesna_CategoryArrow_0(this, "");
		new Cesna_CategoryArrow_1(this, "");
		new Cesna_CategoryArrow_2(this, "");
		new Cesna_CategoryArrow_3(this, "");
		new Cesna_CategoryArrow_4(this, "");
		new Cesna_CategoryArrow_5(this, "");
		new Cesna_CategoryArrow_6(this, "");
	this.finish()
}

finish() : void
{
		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		let s0 = this.mapObjects.get("Cesna_CategoryObject_2")
		if(s0 != undefined)    arrows[0].setSource(s0);
		let t0 = this.mapObjects.get("Cesna_CategoryObject_4")
		if(t0 != undefined)    arrows[0].setTarget(t0);
		let s1 = this.mapObjects.get("Cesna_CategoryObject_2")
		if(s1 != undefined)    arrows[1].setSource(s1);
		let t1 = this.mapObjects.get("Cesna_CategoryObject_0_Visible")
		if(t1 != undefined)    arrows[1].setTarget(t1);
		let s2 = this.mapObjects.get("Cesna_CategoryObject_6")
		if(s2 != undefined)    arrows[2].setSource(s2);
		let t2 = this.mapObjects.get("Cesna_CategoryObject_2")
		if(t2 != undefined)    arrows[2].setTarget(t2);
		let s3 = this.mapObjects.get("Cesna_CategoryObject_6")
		if(s3 != undefined)    arrows[3].setSource(s3);
		let t3 = this.mapObjects.get("Cesna_CategoryObject_4")
		if(t3 != undefined)    arrows[3].setTarget(t3);
		let s4 = this.mapObjects.get("Cesna_CategoryObject_6")
		if(s4 != undefined)    arrows[4].setSource(s4);
		let t4 = this.mapObjects.get("Cesna_CategoryObject_0")
		if(t4 != undefined)    arrows[4].setTarget(t4);
		let s5 = this.mapObjects.get("Cesna_CategoryObject_6")
		if(s5 != undefined)    arrows[5].setSource(s5);
		let t5 = this.mapObjects.get("Cesna_CategoryObject_5")
		if(t5 != undefined)    arrows[5].setTarget(t5);
		let s6 = this.mapObjects.get("Cesna_CategoryObject_6")
		if(s6 != undefined)    arrows[6].setSource(s6);
		let t6 = this.mapObjects.get("Cesna_CategoryObject_3")
		if(t6 != undefined)    arrows[6].setTarget(t6);
		(objects[0] as unknown as IPostSetArrow).postSetArrow();
		(objects[4] as unknown as IPostSetArrow).postSetArrow();
		(objects[5] as unknown as IPostSetArrow).postSetArrow();
		(objects[6] as unknown as IPostSetArrow).postSetArrow();
	}
}
