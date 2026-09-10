"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Airplane = void 0;
const BelognsToCollection_1 = require("../Library/Arrows/BelognsToCollection");
const Desktop_1 = require("../Library/Desktop");
const Input_1 = require("../Library/Event/Input");
const EventLink_1 = require("../Library/Event/Objects/EventLink");
const TimerObject_1 = require("../Library/Event/Objects/TimerObject");
const DataLink_1 = require("../Library/Measurements/Arrows/DataLink");
const DataConsumer_1 = require("../Library/Measurements/DataConsumer");
const DifferentialEquationSolverFormula_1 = require("../Library/Measurements/DifferentialEquations/Solvers/DifferentialEquationSolverFormula");
const VectorFormulaConsumer_1 = require("../Library/Measurements/VectorFormulaConsumer");
const ReferenceFrameArrow_1 = require("../Library/Motion6D/Arrows/ReferenceFrameArrow");
const ReferenceFrameData_1 = require("../Library/Motion6D/Objects/ReferenceFrameData");
const RigidReferenceFrame_1 = require("../Library/Motion6D/Objects/RigidReferenceFrame");
const SerializablePosition_1 = require("../Library/Motion6D/Objects/SerializablePosition");
const Basic3DShape_1 = require("../Library/Motion6D/Objects/Shapes/Basic3DShape");
const BasicCamera_1 = require("../Library/Motion6D/Visible/BasicCamera");
const VisibleConsumerLink_1 = require("../Library/Motion6D/Visible/VisibleConsumerLink");
const TimeSpan_1 = require("../Library/Utilities/DateTime/TimeSpan");
class Airplane_CategoryObject_0 extends Input_1.Input {
    constructor(desktop, name) {
        super(desktop, name);
        this.array.push(["X", 0, 0]);
        this.array.push(["Y", 0, 0]);
        this.array.push(["Z", 0, 0]);
        this.createAll();
    }
}
class Airplane_CategoryObject_1 extends DifferentialEquationSolverFormula_1.DifferentialEquationSolverFormula {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 0;
        this.var_2 = 0;
        this.var_3 = 0;
        this.var_4 = 0;
        this.var_5 = 0;
        let map = new Map([
            ["z", 0],
            ["y", 0],
            ["x", 0],
            ["v", 0],
            ["w", 0],
            ["u", 0],
        ]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("u", 0, 0);
        this.addVariableValue("v", 0, 0);
        this.addVariableValue("w", 0, 0);
        this.addVariableValue("x", 0, 0);
        this.addVariableValue("y", 0, 0);
        this.addVariableValue("z", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.variable = this.measurement0.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_0 = this.convert(this.variable);
        this.variable = this.measurement1.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_1 = this.convert(this.variable);
        this.variable = this.measurement2.getMeasurementValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_2 = this.convert(this.variable);
        this.variable = this.value3.getIValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_3 = this.convert(this.variable);
        this.variable = this.value4.getIValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_4 = this.convert(this.variable);
        this.variable = this.value5.getIValue();
        if (this.check(this.variable)) {
            this.success = false;
            return;
        }
        this.var_5 = this.convert(this.variable);
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
        this.measurement0 = all[0].getMeasurement(0);
        this.measurement1 = all[0].getMeasurement(1);
        this.measurement2 = all[0].getMeasurement(2);
        this.value3 = this.output[0];
        this.value4 = this.output[1];
        this.value5 = this.output[2];
    }
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    get_2() {
        return this.success ? this.var_2 : undefined;
    }
    get_3() {
        return this.success ? this.var_3 : undefined;
    }
    get_4() {
        return this.success ? this.var_4 : undefined;
    }
    get_5() {
        return this.success ? this.var_5 : undefined;
    }
    save() {
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
class Airplane_CategoryObject_2 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        this.var_1 = 1;
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
        this.addVariableValue("Formula_2", 0, 1);
    }
    calculateTree() {
        this.success = true;
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
    }
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    get_1() {
        return this.success ? this.var_1 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_0());
        var x1 = v.get("Formula_2");
        x1?.setIValue(this.get_1());
    }
}
class Airplane_CategoryObject_3 extends ReferenceFrameData_1.ReferenceFrameData {
    constructor(desktop, name) {
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
class Airplane_CategoryObject_4_Visible0 extends Basic3DShape_1.Basic3DShape {
    constructor(desktop, name) {
        super(desktop, name);
        this.addResource("Cessna_208_Caravan.obj", "pLANE/Cessna_208_Caravan.obj", "text", ".obj");
        this.addResource("master.mtl", "pLANE/master.mtl", "text", ".mtl");
        this.addResource("mat0_c.jpg", "pLANE/mat0_c.jpg", "image", ".jpg");
    }
}
class Airplane_CategoryObject_4 extends SerializablePosition_1.SerializablePosition {
    constructor(desktop, name) {
        super(desktop, name);
        this.addChildT(new Airplane_CategoryObject_4_Visible0(desktop, name));
    }
}
class Airplane_CategoryObject_5 extends BasicCamera_1.BasicCamera {
    constructor(desktop, name) {
        super(desktop, name);
        this.fieldOfView = 30;
        this.nearDistance = 1;
        this.farDistance = 200;
    }
}
class Airplane_CategoryObject_6 extends TimerObject_1.TimerObject {
    constructor(desktop, name) {
        super(desktop, name);
        this.span = TimeSpan_1.TimeSpan.fromMilliseconds(100);
    }
}
class Airplane_CategoryObject_7 extends RigidReferenceFrame_1.RigidReferenceFrame {
    constructor(desktop, name) {
        super(desktop, name);
        this.relativePosition = [];
        this.relativeQuaternion = [];
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
class Airplane_CategoryObject_8 extends VectorFormulaConsumer_1.VectorFormulaConsumer {
    constructor(desktop, name) {
        super(desktop, name);
        this.var_0 = 0;
        let map = new Map([]);
        this.performer.setAliasMap(map, this);
        this.addVariableValue("Formula_1", 0, 0);
    }
    calculateTree() {
        this.success = true;
        this.var_0 = this.getInternalTime();
    }
    init() {
        var all = this.getAllMeasurements();
        this.fic = all;
    }
    get_0() {
        return this.success ? this.var_0 : undefined;
    }
    save() {
        var v = this.variables;
        var x0 = v.get("Formula_1");
        x0?.setIValue(this.get_0());
    }
}
class Airplane_CategoryObject_9 extends DataConsumer_1.DataConsumer {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryObject_10 extends RigidReferenceFrame_1.RigidReferenceFrame {
    constructor(desktop, name) {
        super(desktop, name);
        this.relativePosition = [];
        this.relativeQuaternion = [];
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
class Airplane_CategoryArrow_0 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_1 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_2 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_3 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_4 extends VisibleConsumerLink_1.VisibleConsumerLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_5 extends BelognsToCollection_1.BelongsToCollection {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_6 extends BelognsToCollection_1.BelongsToCollection {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_7 extends BelognsToCollection_1.BelongsToCollection {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_8 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_9 extends EventLink_1.EventLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_10 extends EventLink_1.EventLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_11 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_12 extends DataLink_1.DataLink {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_13 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane_CategoryArrow_14 extends ReferenceFrameArrow_1.ReferenceFrameArrow {
    constructor(desktop, name) {
        super(desktop, name);
    }
}
class Airplane extends Desktop_1.Desktop {
    constructor() {
        super();
        this.name = "Airplane";
        this.mapObjects.set("Airplane_CategoryObject_0", new Airplane_CategoryObject_0(this, "Force"));
        this.mapObjects.set("Airplane_CategoryObject_1", new Airplane_CategoryObject_1(this, "ODE"));
        this.mapObjects.set("Airplane_CategoryObject_2", new Airplane_CategoryObject_2(this, "Const"));
        this.mapObjects.set("Airplane_CategoryObject_3", new Airplane_CategoryObject_3(this, "Frame"));
        this.mapObjects.set("Airplane_CategoryObject_4", new Airplane_CategoryObject_4(this, "pLANE"));
        this.mapObjects.set("Airplane_CategoryObject_5", new Airplane_CategoryObject_5(this, "Camera"));
        this.mapObjects.set("Airplane_CategoryObject_6", new Airplane_CategoryObject_6(this, "Timer"));
        this.mapObjects.set("Airplane_CategoryObject_7", new Airplane_CategoryObject_7(this, ""));
        this.mapObjects.set("Airplane_CategoryObject_8", new Airplane_CategoryObject_8(this, "Time"));
        this.mapObjects.set("Airplane_CategoryObject_9", new Airplane_CategoryObject_9(this, "Chart"));
        this.mapObjects.set("Airplane_CategoryObject_10", new Airplane_CategoryObject_10(this, "Base"));
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
        this.finish();
    }
    finish() {
        let objects = this.getCategoryObjects();
        let arrows = this.getCategoryArrows();
        let s0 = this.mapObjects.get("Airplane_CategoryObject_1");
        if (s0 != undefined)
            arrows[0].setSource(s0);
        let t0 = this.mapObjects.get("Airplane_CategoryObject_0");
        if (t0 != undefined)
            arrows[0].setTarget(t0);
        let s1 = this.mapObjects.get("Airplane_CategoryObject_3");
        if (s1 != undefined)
            arrows[1].setSource(s1);
        let t1 = this.mapObjects.get("Airplane_CategoryObject_1");
        if (t1 != undefined)
            arrows[1].setTarget(t1);
        let s2 = this.mapObjects.get("Airplane_CategoryObject_3");
        if (s2 != undefined)
            arrows[2].setSource(s2);
        let t2 = this.mapObjects.get("Airplane_CategoryObject_2");
        if (t2 != undefined)
            arrows[2].setTarget(t2);
        let s3 = this.mapObjects.get("Airplane_CategoryObject_5");
        if (s3 != undefined)
            arrows[3].setSource(s3);
        let t3 = this.mapObjects.get("Airplane_CategoryObject_7");
        if (t3 != undefined)
            arrows[3].setTarget(t3);
        let s4 = this.mapObjects.get("Airplane_CategoryObject_5");
        if (s4 != undefined)
            arrows[4].setSource(s4);
        let t4 = this.mapObjects.get("Airplane_CategoryObject_4_Visible0");
        if (t4 != undefined)
            arrows[4].setTarget(t4);
        let s5 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s5 != undefined)
            arrows[5].setSource(s5);
        let t5 = this.mapObjects.get("Airplane_CategoryObject_5");
        if (t5 != undefined)
            arrows[5].setTarget(t5);
        let s6 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s6 != undefined)
            arrows[6].setSource(s6);
        let t6 = this.mapObjects.get("Airplane_CategoryObject_7");
        if (t6 != undefined)
            arrows[6].setTarget(t6);
        let s7 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s7 != undefined)
            arrows[7].setSource(s7);
        let t7 = this.mapObjects.get("Airplane_CategoryObject_4");
        if (t7 != undefined)
            arrows[7].setTarget(t7);
        let s8 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s8 != undefined)
            arrows[8].setSource(s8);
        let t8 = this.mapObjects.get("Airplane_CategoryObject_8");
        if (t8 != undefined)
            arrows[8].setTarget(t8);
        let s9 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s9 != undefined)
            arrows[9].setSource(s9);
        let t9 = this.mapObjects.get("Airplane_CategoryObject_6");
        if (t9 != undefined)
            arrows[9].setTarget(t9);
        let s10 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s10 != undefined)
            arrows[10].setSource(s10);
        let t10 = this.mapObjects.get("Airplane_CategoryObject_0");
        if (t10 != undefined)
            arrows[10].setTarget(t10);
        let s11 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s11 != undefined)
            arrows[11].setSource(s11);
        let t11 = this.mapObjects.get("Airplane_CategoryObject_0");
        if (t11 != undefined)
            arrows[11].setTarget(t11);
        let s12 = this.mapObjects.get("Airplane_CategoryObject_9");
        if (s12 != undefined)
            arrows[12].setSource(s12);
        let t12 = this.mapObjects.get("Airplane_CategoryObject_1");
        if (t12 != undefined)
            arrows[12].setTarget(t12);
        let s13 = this.mapObjects.get("Airplane_CategoryObject_3");
        if (s13 != undefined)
            arrows[13].setSource(s13);
        let t13 = this.mapObjects.get("Airplane_CategoryObject_10");
        if (t13 != undefined)
            arrows[13].setTarget(t13);
        let s14 = this.mapObjects.get("Airplane_CategoryObject_4");
        if (s14 != undefined)
            arrows[14].setSource(s14);
        let t14 = this.mapObjects.get("Airplane_CategoryObject_3");
        if (t14 != undefined)
            arrows[14].setTarget(t14);
        objects[1].postSetArrow();
        objects[2].postSetArrow();
        objects[3].postSetArrow();
        objects[4].postSetArrow();
        objects[8].postSetArrow();
        objects[9].postSetArrow();
        objects[10].postSetArrow();
        objects[11].postSetArrow();
    }
}
exports.Airplane = Airplane;
//# sourceMappingURL=Airplane.js.map