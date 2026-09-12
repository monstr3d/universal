import { BelongsToCollection } from "../Library/Arrows/BelognsToCollection";
import { Desktop } from "../Library/Desktop";
import { Input } from "../Library/Event/Input";
import { EventLink } from "../Library/Event/Objects/EventLink";
import { TimerObject } from "../Library/Event/Objects/TimerObject";
import type { IDesktop } from "../Library/Interfaces/IDesktop";
import type { IPostSetArrow } from "../Library/Interfaces/IPostSetArrow";
import type { IValue } from "../Library/Interfaces/IValue";
import { DataLink } from "../Library/Measurements/Arrows/DataLink";
import { DataConsumer } from "../Library/Measurements/DataConsumer";
import { DifferentialEquationSolverFormula } from "../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula";
import type { IMeasurement } from "../Library/Measurements/Interfaces/IMeasurement";
import { VectorFormulaConsumer } from "../Library/Measurements/VectorFormulaConsumer";
import { ReferenceFrameArrow } from "../Library/Motion6D/Arrows/ReferenceFrameArrow";
import { ReferenceFrameData } from "../Library/Motion6D/Objects/ReferenceFrameData";
import { RigidReferenceFrame } from "../Library/Motion6D/Objects/RigidReferenceFrame";
import { SerializablePosition } from "../Library/Motion6D/Objects/SerializablePosition";
import { Basic3DShape } from "../Library/Motion6D/Objects/Shapes/Basic3DShape";
import { BasicCamera } from "../Library/Motion6D/Visible/BasicCamera";
import type { IVisible } from "../Library/Motion6D/Visible/Interfaces/IVisible";
import { VisibleConsumerLink } from "../Library/Motion6D/Visible/VisibleConsumerLink";
import { TimeSpan } from "../Library/Utilities/DateTime/TimeSpan";

class Airplane_CategoryObject_0 extends Input
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.array.push([ "X" ,0, 0])
		this.array.push([ "Y" ,0, 0])
		this.array.push([ "Z" ,0, 0])
		this.createAll()
	}
}

class Airplane_CategoryObject_1 extends DifferentialEquationSolverFormula
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
			["z", 0 ],
			["y", 0 ],
			["x", 0 ],
			["v", 0 ],
			["w", 0 ],
			["u", 0 ],
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("u", 0, 0);
		this.addVariableValue("v", 0, 0);
		this.addVariableValue("w", 0, 0);
		this.addVariableValue("x", 0, 0);
		this.addVariableValue("y", 0, 0);
		this.addVariableValue("z", 0, 0);
	}

		calculateTree() : void
		{
			this.success = true;
			this.variable = this.measurement0.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_0 = this.convert<number>(this.variable);
			this.variable = this.measurement1.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_1 = this.convert<number>(this.variable);
			this.variable = this.measurement2.getMeasurementValue();
			if (this.check(this.variable)) { this.success = false; return; } 
			this.var_2 = this.convert<number>(this.variable);
			this.variable = this.value3.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_3 = this.convert<number>(this.variable);
			this.variable = this.value4.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_4 = this.convert<number>(this.variable);
			this.variable = this.value5.getIValue();
			if (this.check(this.variable)) { this.success = false; return; }
			this.var_5 = this.convert<number>(this.variable);
		}
	
	init() : void
	{
		var all = this.getAllMeasurements()
		this.fic = all
		this.measurement0 = all[0].getMeasurement(0);
		this.measurement1 = all[0].getMeasurement(1);
		this.measurement2 = all[0].getMeasurement(2);
		this.value3 = this.output[0];
		this.value4 = this.output[1];
		this.value5 = this.output[2];
	}
	
	measurement0 ! : IMeasurement;
	measurement1 ! : IMeasurement;
	measurement2 ! : IMeasurement;
	value3 ! : IValue;
	value4 ! : IValue;
	value5 ! : IValue;
	var_0 : number  = 0;
	var_1 : number  = 0;
	var_2 : number  = 0;
	var_3 : number  = 0;
	var_4 : number  = 0;
	var_5 : number  = 0;
	
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
	save() : void {
		var v = this.derivations;
		var x0 = v.get("v");
		x0?.setIValue(this.get_1());
		var x1 = v.get("u");
		x1?.setIValue(this.get_0());
		var x2 = v.get("z");
		x2?.setIValue(this.get_5());
		var x3 = v.get("y");
		x3?.setIValue(this.get_4());
		var x4 = v.get("x");
		x4?.setIValue(this.get_3());
		var x5 = v.get("w");
		x5?.setIValue(this.get_2());
	}
	
}

class Airplane_CategoryObject_2 extends VectorFormulaConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		let map = new Map<string, any>(
		[
		]);
		this.performer.setAliasMap(map, this);
		this.addVariableValue("Formula_1", 0, 0);
		this.addVariableValue("Formula_2", 0, 1);
	}

		calculateTree() : void
		{
			this.success = true;
		}
	
	init() : void
	{
		var all = this.getAllMeasurements()
		this.fic = all
	}
	
	var_0 : number  = 0;
	var_1 : number  = 1;
	
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
		x0?.setIValue(this.get_0());
		var x1 = v.get("Formula_2");
		x1?.setIValue(this.get_1());
	}
	
}

class Airplane_CategoryObject_3 extends ReferenceFrameData
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
this.parametersList.push("ODE.x");
this.parametersList.push("ODE.y");
this.parametersList.push("ODE.z");
this.parametersList.push("Const.Formula_2");
this.parametersList.push("Const.Formula_1");
this.parametersList.push("Const.Formula_1");
this.parametersList.push("Const.Formula_1");
	}
}

class Airplane_CategoryObject_4_Visible0 extends Basic3DShape
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.addResource("Cessna_208_Caravan.obj", "pLANE/Cessna_208_Caravan.obj", "text", ".obj")
		this.addResource("master.mtl", "pLANE/master.mtl", "text", ".mtl")
		this.addResource("mat0_c.jpg", "pLANE/mat0_c.jpg", "image", ".jpg")
	}
}

class Airplane_CategoryObject_4 extends SerializablePosition
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.addChildT(new Airplane_CategoryObject_4_Visible0(desktop, name))
	}
}

class Airplane_CategoryObject_5 extends BasicCamera
{
    postVisibleObject(object: IVisible): void {
        throw new Error("Method not implemented.");
    }
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.fieldOfView = 30
		this.nearDistance = 1
		this.farDistance = 200
	}
}

class Airplane_CategoryObject_6 extends TimerObject
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.span = TimeSpan.fromMilliseconds(100)
	}
}

class Airplane_CategoryObject_7 extends RigidReferenceFrame
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
	
		this.relativeQuaternion = [];
		this.relativeQuaternion.push(0.88047623921714935);
		this.relativeQuaternion.push(-0.27984814233312139);
		this.relativeQuaternion.push(0.36470519963100095);
		this.relativeQuaternion.push(0.11591689595929504);
	
	}
}

class Airplane_CategoryObject_8 extends VectorFormulaConsumer
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
		var all = this.getAllMeasurements()
		this.fic = all
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

class Airplane_CategoryObject_9 extends DataConsumer
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryObject_10 extends RigidReferenceFrame
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
		this.relativePosition = []
		this.relativeQuaternion = []
		this.relativePosition = [];
		this.relativePosition.push(0);
		this.relativePosition.push(0);
		this.relativePosition.push(0);
	
		this.relativeQuaternion = [];
		this.relativeQuaternion.push(1);
		this.relativeQuaternion.push(0);
		this.relativeQuaternion.push(0);
		this.relativeQuaternion.push(0);
	
	}
}

class Airplane_CategoryArrow_0 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_1 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_2 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_3 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_4 extends VisibleConsumerLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_5 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_6 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_7 extends BelongsToCollection
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_8 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_9 extends EventLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_10 extends EventLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_11 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_12 extends DataLink
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_13 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}

class Airplane_CategoryArrow_14 extends ReferenceFrameArrow
{
	constructor(desktop: IDesktop, name: string)
	{
		super(desktop, name);
	}
}



export class Airplane extends Desktop
{
	constructor()
	{
		super();

		this.name = "Airplane";

		this.mapObjects.set("Airplane_CategoryObject_0", new Airplane_CategoryObject_0(this, "Force"))
		this.mapObjects.set("Airplane_CategoryObject_1", new Airplane_CategoryObject_1(this, "ODE"))
		this.mapObjects.set("Airplane_CategoryObject_2", new Airplane_CategoryObject_2(this, "Const"))
		this.mapObjects.set("Airplane_CategoryObject_3", new Airplane_CategoryObject_3(this, "Frame"))
		this.mapObjects.set("Airplane_CategoryObject_4", new Airplane_CategoryObject_4(this, "pLANE"))
		this.mapObjects.set("Airplane_CategoryObject_5", new Airplane_CategoryObject_5(this, "Camera"))
		this.mapObjects.set("Airplane_CategoryObject_6", new Airplane_CategoryObject_6(this, "Timer"))
		this.mapObjects.set("Airplane_CategoryObject_7", new Airplane_CategoryObject_7(this, ""))
		this.mapObjects.set("Airplane_CategoryObject_8", new Airplane_CategoryObject_8(this, "Time"))
		this.mapObjects.set("Airplane_CategoryObject_9", new Airplane_CategoryObject_9(this, "Chart"))
		this.mapObjects.set("Airplane_CategoryObject_10", new Airplane_CategoryObject_10(this, "Base"))
		new Airplane_CategoryArrow_0(this, "");
		new Airplane_CategoryArrow_1(this, "");
		new Airplane_CategoryArrow_2(this, "");
		new Airplane_CategoryArrow_3(this, "");
		new Airplane_CategoryArrow_4(this, "");
		new Airplane_CategoryArrow_5(this, "");
		new Airplane_CategoryArrow_6(this, "");
		new Airplane_CategoryArrow_7(this, "");
		new Airplane_CategoryArrow_8(this, "");
		new Airplane_CategoryArrow_9(this, "");
		new Airplane_CategoryArrow_10(this, "");
		new Airplane_CategoryArrow_11(this, "");
		new Airplane_CategoryArrow_12(this, "");
		new Airplane_CategoryArrow_13(this, "");
		new Airplane_CategoryArrow_14(this, "");
	this.finish()
}

finish() : void
{
		let objects = this.getCategoryObjects();
		let arrows = this.getCategoryArrows();

		let s0 = this.mapObjects.get("Airplane_CategoryObject_1")
		if(s0 != undefined)    arrows[0].setSource(s0);
		let t0 = this.mapObjects.get("Airplane_CategoryObject_0")
		if(t0 != undefined)    arrows[0].setTarget(t0);
		let s1 = this.mapObjects.get("Airplane_CategoryObject_3")
		if(s1 != undefined)    arrows[1].setSource(s1);
		let t1 = this.mapObjects.get("Airplane_CategoryObject_1")
		if(t1 != undefined)    arrows[1].setTarget(t1);
		let s2 = this.mapObjects.get("Airplane_CategoryObject_3")
		if(s2 != undefined)    arrows[2].setSource(s2);
		let t2 = this.mapObjects.get("Airplane_CategoryObject_2")
		if(t2 != undefined)    arrows[2].setTarget(t2);
		let s3 = this.mapObjects.get("Airplane_CategoryObject_5")
		if(s3 != undefined)    arrows[3].setSource(s3);
		let t3 = this.mapObjects.get("Airplane_CategoryObject_7")
		if(t3 != undefined)    arrows[3].setTarget(t3);
		let s4 = this.mapObjects.get("Airplane_CategoryObject_5")
		if(s4 != undefined)    arrows[4].setSource(s4);
		let t4 = this.mapObjects.get("Airplane_CategoryObject_4_Visible0")
		if(t4 != undefined)    arrows[4].setTarget(t4);
		let s5 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s5 != undefined)    arrows[5].setSource(s5);
		let t5 = this.mapObjects.get("Airplane_CategoryObject_5")
		if(t5 != undefined)    arrows[5].setTarget(t5);
		let s6 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s6 != undefined)    arrows[6].setSource(s6);
		let t6 = this.mapObjects.get("Airplane_CategoryObject_7")
		if(t6 != undefined)    arrows[6].setTarget(t6);
		let s7 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s7 != undefined)    arrows[7].setSource(s7);
		let t7 = this.mapObjects.get("Airplane_CategoryObject_4")
		if(t7 != undefined)    arrows[7].setTarget(t7);
		let s8 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s8 != undefined)    arrows[8].setSource(s8);
		let t8 = this.mapObjects.get("Airplane_CategoryObject_8")
		if(t8 != undefined)    arrows[8].setTarget(t8);
		let s9 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s9 != undefined)    arrows[9].setSource(s9);
		let t9 = this.mapObjects.get("Airplane_CategoryObject_6")
		if(t9 != undefined)    arrows[9].setTarget(t9);
		let s10 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s10 != undefined)    arrows[10].setSource(s10);
		let t10 = this.mapObjects.get("Airplane_CategoryObject_0")
		if(t10 != undefined)    arrows[10].setTarget(t10);
		let s11 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s11 != undefined)    arrows[11].setSource(s11);
		let t11 = this.mapObjects.get("Airplane_CategoryObject_0")
		if(t11 != undefined)    arrows[11].setTarget(t11);
		let s12 = this.mapObjects.get("Airplane_CategoryObject_9")
		if(s12 != undefined)    arrows[12].setSource(s12);
		let t12 = this.mapObjects.get("Airplane_CategoryObject_1")
		if(t12 != undefined)    arrows[12].setTarget(t12);
		let s13 = this.mapObjects.get("Airplane_CategoryObject_3")
		if(s13 != undefined)    arrows[13].setSource(s13);
		let t13 = this.mapObjects.get("Airplane_CategoryObject_10")
		if(t13 != undefined)    arrows[13].setTarget(t13);
		let s14 = this.mapObjects.get("Airplane_CategoryObject_4")
		if(s14 != undefined)    arrows[14].setSource(s14);
		let t14 = this.mapObjects.get("Airplane_CategoryObject_3")
		if(t14 != undefined)    arrows[14].setTarget(t14);
		(objects[1] as unknown as IPostSetArrow).postSetArrow();
		(objects[2] as unknown as IPostSetArrow).postSetArrow();
		(objects[3] as unknown as IPostSetArrow).postSetArrow();
		(objects[4] as unknown as IPostSetArrow).postSetArrow();
		(objects[8] as unknown as IPostSetArrow).postSetArrow();
		(objects[9] as unknown as IPostSetArrow).postSetArrow();
		(objects[10] as unknown as IPostSetArrow).postSetArrow();
		(objects[11] as unknown as IPostSetArrow).postSetArrow();
	}
}
