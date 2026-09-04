"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ReferenceFrameData = void 0;
const ReferenceFrame_1 = require("../ReferenceFrame");
const RigidReferenceFrame_1 = require("./RigidReferenceFrame");
const NumberMeasurement_1 = require("../../Measurements/NumberMeasurement");
class ReferenceFrameData extends RigidReferenceFrame_1.RigidReferenceFrame {
    outmeasurements = [];
    /// <summary>
    /// Names of parametrers
    /// </summary>
    parametersList = [];
    /// <summary>
    /// Auxiliary variable
    /// </summary>
    qd = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]];
    /// <summary>
    /// Auxiliary variable
    /// </summary>
    der = [0, 0, 0, 0];
    /// <summary>
    /// External measurements
    /// </summary>
    measurementsData = [];
    /// <summary>
    /// Measurementrs
    /// </summary>
    measurements = [];
    /// <summary>
    /// Second derivations
    /// </summary>
    secondDeri = [0, 0, 0, 0, 0, 0, 0];
    /// <summary>
    /// Second derivations' measurements
    /// </summary>
    secondDeriM = [];
    /// <summary>
    /// Auxiliary variable
    /// </summary>
    angsec = [0, 0, 0, 0];
    om = [0, 0, 0];
    angularVelocity;
    velocityObject;
    any;
    /*
        private coordDel: IFunc<any>[] = [];
    
        private oriDel: IFunc<any>[] = [];
    
        private velocityDel: IFunc<any>[] = [];
    
        private angularDel: IFunc<any>[] = [];
    
        private isReset: boolean = false;*/
    names = [
        "x", "y", "z",
        "Vx", "Vy", "Vz", "Q0", "Q1", "Q2", "Q3",
        "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"
    ];
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "ReferenceFrameData";
        this.types.push("IDataConsumer");
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.types.push("ReferenceFrameData");
    }
    resetDataConsumer() {
    }
    getMeasurementName() {
        return "Frame";
    }
    getMeasurementType() {
        return "Frame";
    }
    getMeasurementValue() {
        return this.own;
    }
    getMeasurementsCount() {
        return this.outmeasurements.length;
    }
    getMeasurement(i) {
        return this.outmeasurements[i];
    }
    updateMeasurements() {
    }
    updateReferenceFrame() {
        this.measuremrntPerformrer.fullReset(this);
        var rel = this.relative;
        var x = rel.getPosition();
        // var parent = this.getParentFrame();
        for (let i = 0; i < 3; i++) {
            var o = this.measurements[i].getMeasurementValue();
            if (o === undefined) {
                return;
            }
            x[i] = this.performer.convert(o);
        }
        var vela = this.performer.convertObject(rel, "IVelocity");
        if (vela.length > 0) {
            var vel = vela[0];
            var v = vel.getVelocity();
            for (let i = 0; i < 3; i++) {
                let m = this.measurements[i];
                var dd = this.performer.convertObject(m, "IDerivation");
                if (dd.length > 0) {
                    var d = dd[0];
                    var der = d.getDerivation();
                    var val = der.getMeasurementValue();
                    var y = this.performer.convert(val);
                    v[i] = y;
                }
            }
        }
        var qua = rel.getQuaternion();
        for (let i = 0; i < 4; i++) {
            let m = this.measurements[i + 3];
            var val = m.getMeasurementValue();
            var y = this.performer.convert(val);
            qua[i] = y;
        }
        rel.setMatrix();
        // var matrix = rel.getMatrix()
        var anga = this.performer.convertObject(rel, "IAngularVelocity");
        if (anga.length > 0) {
            let ang = anga[0];
            this.om[0] = ang.getAngularVelocityX();
            this.om[1] = ang.getAngularVelocityY();
            this.om[2] = ang.getAngularVelocityZ();
            //   var ora = this.performer.convertObject<IOrientation, ReferenceFrame>(rel, "IOrientation");
            //     var or = ora[0];
            for (let i = 0; i < 4; i++) {
                let m = this.measurements[i + 3];
                var dd = this.performer.convertObject(m, "IDerivation");
                var d = dd[0];
                var der = d.getDerivation();
                var val = der.getMeasurementValue();
                var y = this.performer.convert(val);
                this.der[i] = y;
            }
            this.vp.calculateDynamics(qua, this.der, this.om, this.qd);
        }
        if (vela.length > 0) {
            let aa = this.performer.convertObject(rel, "IAcceleration");
            if (aa.length > 0) {
                var acc = aa[0];
                // var anc = this.performer.convertObject<IAngularAcceleration, ReferenceFrame>(rel, "IAngularAcceleration");
                // var angacc = anc[0].getAngularAcceleration();
                var linacc = acc.getRelativeAcceleration();
                for (let i = 0; i < 3; i++) {
                    let sd = this.secondDeriM[i].getMeasurementValue();
                    linacc[i] = this.performer.convert(sd);
                }
                for (let i = 0; i < 4; i++) {
                    let sd = this.secondDeriM[i + 3].getMeasurementValue();
                    this.angsec[i] = this.performer.convert(sd);
                }
                let av = anga[0];
                this.om[0] = av.getAngularVelocityX();
                this.om[1] = av.getAngularVelocityY();
                this.om[2] = av.getAngularVelocityZ();
                var rq = rel.getQuaternion();
                this.vp.calculateDynamics(rq, this.der, this.om, this.qd);
            }
        }
        super.updateReferenceFrame();
    }
    addMeasurement(measurement) {
        this.any = measurement;
    }
    getAllMeasurements() {
        return this.measurementsData;
    }
    addMeasurements(item) {
        this.measurementsData.push(item);
    }
    getFrame() {
        return this.own;
    }
    getX() {
        return this.own.getPosition()[0];
    }
    getY() {
        return this.own.getPosition()[1];
    }
    getZ() {
        return this.own.getPosition()[2];
    }
    getVx() {
        return this.velocityObject.getVelocity()[0];
    }
    getVy() {
        return this.velocityObject.getVelocity()[1];
    }
    getVz() {
        return this.velocityObject.getVelocity()[2];
    }
    getQ0() {
        return this.own.getQuaternion()[0];
    }
    getQ1() {
        return this.own.getQuaternion()[1];
    }
    getQ2() {
        return this.own.getQuaternion()[2];
    }
    getQ3() {
        return this.own.getQuaternion()[3];
    }
    getOmegaX() {
        return this.angularVelocity.getAngularVelocityX();
    }
    getOmegaY() {
        return this.angularVelocity.getAngularVelocityY();
    }
    getOmegaZ() {
        return this.angularVelocity.getAngularVelocityZ();
    }
    createMeasurements() {
        let lm = [];
        lm.push(this);
        for (let i = 0; i < 3; i++) {
            this.outmeasurements.push(new Coordinate(this.names[i], i, this.own));
        }
        for (let i = 0; i < 4; i++) {
            this.outmeasurements.push(new QuaternionMeasurement(this.names[i + 6], i, this.own));
        }
        if (this.own.imlplementsType("IVelocity")) {
            for (let i = 0; i < 3; i++) {
                this.outmeasurements.push(new Velocity(this.names[i + 3], i, this.velocityObject));
            }
        }
        if (this.own.imlplementsType("IAngularVelocity")) {
            for (let i = 0; i < 3; i++) {
                this.outmeasurements.push(new AngularVelocity(this.names[i + 10], i, this.angularVelocity));
            }
        }
    }
}
exports.ReferenceFrameData = ReferenceFrameData;
class Coordinate extends NumberMeasurement_1.NumberMeasurement {
    n = 0;
    frame = new ReferenceFrame_1.ReferenceFrame();
    constructor(name, n, frame) {
        super(name);
        this.n = n;
        this.frame = frame;
    }
    getMeasurementValue() {
        return this.frame.getPosition()[this.n];
    }
}
class QuaternionMeasurement extends NumberMeasurement_1.NumberMeasurement {
    n = 0;
    frame = new ReferenceFrame_1.ReferenceFrame();
    constructor(name, n, frame) {
        super(name);
        this.n = n;
        this.frame = frame;
    }
    getMeasurementValue() {
        return this.frame.getQuaternion()[this.n];
    }
}
class Velocity extends NumberMeasurement_1.NumberMeasurement {
    n = 0;
    velocity;
    constructor(name, n, velocity) {
        super(name);
        this.n = n;
        this.velocity = velocity;
    }
    getMeasurementValue() {
        return this.velocity.getVelocity()[this.n];
    }
}
class AngularVelocity extends NumberMeasurement_1.NumberMeasurement {
    n = 0;
    velocity;
    constructor(name, n, velocity) {
        super(name);
        this.n = n;
        this.velocity = velocity;
    }
    getMeasurementValue() {
        switch (this.n) {
            case 0: return this.velocity.getAngularVelocityX();
            case 1: return this.velocity.getAngularVelocityY();
        }
        return this.velocity.getAngularVelocityZ();
    }
}
