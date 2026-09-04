"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.UpdateCoinDistanceAct = exports.UpdateRelativePositionAct = exports.UpdateCoinVelocityAct = exports.UpdateAngularVelocityAct = exports.UpdateFrameAngularVelocityAct = exports.UpdateFrameAct = exports.UpdateOrientationVelocityAct = exports.UpdateOrientationCoordinatesAct = exports.AddAngularVelocityAct = exports.UpdateQuaternionAct = exports.UpdateVelocityRotationAct = exports.VelocityScalarMeasurement = exports.DistanceMeasurement = exports.QuaternionMeasurement = exports.OmegaMeasurement = exports.VelocityMeasurement = exports.CoordMeasurement = exports.RelativeMeasurements = void 0;
const CategoryObject_1 = require("../../CategoryObject");
const OwnError_1 = require("../../ErrorHandler/OwnError");
const MeasurementDerivation_1 = require("../../Measurements/MeasurementDerivation");
const RealMatrix_1 = require("../../RealMatrixProcessor/RealMatrix");
const EulerAngles_1 = require("../../Vector3D/EulerAngles");
const Vector3DProcessor_1 = require("../../Vector3D/Vector3DProcessor");
const EulerMeasurement_1 = require("../Measurements/EulerMeasurement");
const Motion6DAcceleratedFrame_1 = require("../Motion6DAcceleratedFrame");
const Motion6DPerformer_1 = require("../Motion6DPerformer");
const ReferenceFrame_1 = require("../ReferenceFrame");
const ActionArray_1 = require("../../Utilities/Generic/ActionArray");
const NumberMeasurement_1 = require("../../Measurements/NumberMeasurement");
const OwnNotImplemented_1 = require("../../ErrorHandler/OwnNotImplemented");
class RelativeMeasurements extends CategoryObject_1.CategoryObject {
    m6dPerformer = new Motion6DPerformer_1.Motion6DPerformer();
    vp = new Vector3DProcessor_1.Vector3DProcessor();
    realMatrix = new RealMatrix_1.RealMatrix();
    own = new Motion6DAcceleratedFrame_1.Motion6DAcceleratedFrame();
    relative = [0, 0, 0];
    mPerformer = new Motion6DPerformer_1.Motion6DPerformer();
    angles = new EulerAngles_1.EulerAngles(0, 0, 0);
    coordMeasurements = [];
    velocityMeasurements = [];
    omegaMeasurements = [];
    quaternionMeasurements = [];
    angleMeasurements = [];
    velocityArr = [];
    orientationArr = [];
    omArr = [];
    names = [
        "x", "y", "z", "Distance",
        "Vx", "Vy", "Vz", "Velocity", "Q0", "Q1", "Q2", "Q3", "Roll", "Pitch", "Yaw",
        "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"
    ];
    constructor(desktop, name) {
        super(desktop, name);
        this.typeName = "RelativeMeasurements";
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.types.push("RelativeMeasurements");
        this.createActions();
        let em = new EulerMeasurement_1.EulerMeasurement("", this.angles);
        this.angleMeasurements = [em.getRoll("Roll", this.angles), em.getPitch("Pitch", this.angles), em.getYaw("Yaw", this.angles)];
        for (let i = 0; i < 3; i++) {
            this.coordMeasurements.push(new CoordMeasurement(this.names[i], this, i));
            this.velocityMeasurements.push(new VelocityMeasurement(this.names[i + 4], this, i));
            this.omegaMeasurements.push(new OmegaMeasurement(this.names[i + 15], this, i));
        }
        for (let i = 0; i < 4; i++) {
            this.quaternionMeasurements.push(new QuaternionMeasurement(this.names[i + 8], this, i));
        }
        this.velocityScalar = new VelocityScalarMeasurement(this.names[7], this);
        this.distanceScalar = new DistanceMeasurement(this.names[3], this);
    }
    postSetArrow() {
        this.createMeasurements();
    }
    getMeasurementName() {
        return "Frame";
    }
    getMeasurementType() {
        return "ReferenceFrame";
    }
    getMeasurementValue() {
        return this.relativeFrame;
    }
    getMeasurementsCount() {
        return this.measurements.length;
    }
    getMeasurement(i) {
        return this.measurements[i];
    }
    updateMeasurements() {
        this.performer.executeAction(this.updateAll);
        this.performer.executeAction(this.updFrame);
    }
    source;
    target;
    vSource;
    vTarget;
    oSource;
    oTarget;
    aSource;
    aTarget;
    relativePos = [0, 0, 0];
    relativeP = [0, 0, 0];
    relativeVelocity = [0, 0, 0];
    quaternion = [0, 0, 0, 0];
    measurementFrame;
    velocityScalar;
    distanceScalar;
    measurements = [];
    distance = 0;
    velocity = 0;
    targetFrame = new ReferenceFrame_1.ReferenceFrame();
    sourceFrame = new ReferenceFrame_1.ReferenceFrame();
    relativeFrame = new ReferenceFrame_1.ReferenceFrame();
    omegaRProduct = [0, 0, 0];
    matrixPosition = [0, 0, 0];
    matrixVelocity = [0, 0, 0];
    omegaRelative = [0, 0, 0];
    aux = [0, 0, 0];
    angularVelocity;
    ivelocity;
    updFrame;
    updateAll;
    updateFrameAct;
    updateFrameAngularVelocityAct;
    updateAngularVelocityAct;
    updateCoinVelocityAct;
    updateCoinDistanceAct;
    updateRelativePositionAct;
    updateOrientationCoordinatesAct;
    updateOrientationVelocityAct;
    updateQuaternionAct;
    addAngularVelocityAct;
    updateVelocityRotationAct;
    createActions() {
        this.updateFrameAct = new UpdateFrameAct(this);
        this.updateFrameAngularVelocityAct = new UpdateFrameAngularVelocityAct(this);
        this.updateAngularVelocityAct = new UpdateAngularVelocityAct(this);
        this.updateCoinVelocityAct = new UpdateCoinVelocityAct(this);
        this.updateCoinDistanceAct = new UpdateCoinDistanceAct(this);
        this.updateRelativePositionAct = new UpdateRelativePositionAct(this);
        this.updateOrientationCoordinatesAct = new UpdateOrientationCoordinatesAct(this);
        this.updateOrientationVelocityAct = new UpdateOrientationVelocityAct(this);
        this.updateQuaternionAct = new UpdateQuaternionAct(this);
        this.addAngularVelocityAct = new AddAngularVelocityAct(this);
        this.updateVelocityRotationAct = new UpdateVelocityRotationAct(this);
    }
    updateFrame() {
        this.performer.copyArray(this.relativePos, this.relativeFrame.getPosition());
        this.performer.copyArray(this.quaternion, this.relativeFrame.getQuaternion());
        this.vp.quaternionToeulerAngles(this.angles, this.quaternion);
    }
    updateFrameAngularVelocity() {
        this.performer.copyArray(this.omegaRelative, this.angularVelocity.getOmega());
    }
    updateAngularVelocity() {
        this.realMatrix.multiplyLeft(this.aTarget.getOmega(), this.relativeFrame.getMatrix(), this.aux);
        let om = this.aSource.getOmega();
        for (let i = 0; i < 3; i++) {
            this.omegaRelative[i] = om[i] - this.aux[i];
        }
    }
    updateCoinVelocity() {
        let vs = this.vSource.getVelocity();
        let vt = this.vTarget.getVelocity();
        let a = 0;
        for (let i = 0; i < 3; i++) {
            let x = vs[i] - vt[i];
            this.relativeVelocity[i] = x;
            a += x * this.relativePos[i];
        }
        this.velocity = a / this.distance;
        this.performer.copyArray(this.relativeVelocity, this.ivelocity.getVelocity());
    }
    updateCoinDistance() {
        let y = this.source.getPosition();
        let x = this.target.getPosition();
        let a = 0;
        for (let i = 0; i < 3; i++) {
            let z = y[i] - x[i];
            this.relativePos[i] = z;
            a += z * z;
        }
        this.distance = Math.sqrt(a);
    }
    updateRelativePosition() {
        let y = this.source.getPosition();
        let x = this.target.getPosition();
        let dist = 0;
        for (let i = 0; i < 3; i++) {
            let dd = y[i] - x[i];
            dist += dd * dd;
            this.relative[i] = dd;
        }
        this.distance = Math.sqrt(dist);
        var f = this.m6dPerformer.getOwnFrame(this.target);
        if (f === undefined) {
        }
        else {
            f.calculateRotatedPosition(this.relative, this.relativePos);
        }
    }
    getParameters(p, velocity, orientation, om) {
        let pa = p;
        if (velocity.length > 0)
            velocity.pop();
        if (om.length > 0)
            om.pop();
        if (orientation.length > 0)
            orientation.pop();
        let rf = this.performer.convertObject(p, "IReferenceFrame");
        if (rf.length > 0) {
            let pp = rf[0].getOwnFrame();
            if (pp === undefined) {
            }
            else {
                pa = pp;
            }
        }
        let vf = this.performer.convertObject(pa, "IVelocity");
        this.performer.reoplaceArrayValue(vf, velocity);
        let oof = this.performer.convertObject(pa, "IOrientation");
        this.performer.reoplaceArrayValue(oof, orientation);
        let omf = this.performer.convertObject(pa, "IAngularVelocityMotion6D");
        this.performer.reoplaceArrayValue(omf, om);
    }
    getDistance() {
        return this.distance;
    }
    getOmega() {
        return this.omegaRelative;
    }
    getQuaternion() {
        return this.quaternion;
    }
    getCoordinate() {
        return this.relativePos;
    }
    getVelocity() {
        return this.relativeVelocity;
    }
    getVelocityScalar() {
        return this.velocity;
    }
    updateOrientation(x, aux) {
        let m = this.oTarget.getMatrix();
        this.realMatrix.multiplyLeft(x, m, aux);
        this.performer.copyArray(aux, x);
    }
    updateOrientationCoordinates() {
        this.updateOrientation(this.relativePos, this.matrixPosition);
    }
    updateOrientationVelocity() {
        this.updateOrientation(this.relativeVelocity, this.matrixVelocity);
    }
    addAngularVelocity() {
        let om = this.aTarget.getOmega();
        this.vp.vectorProduct(this.relativePos, om, this.omegaRProduct);
        this.realMatrix.plusEqual(this.relativeVelocity, this.omegaRProduct);
    }
    updateQuaternion() {
        this.vp.quaternionInvertMultiply(this.oTarget.getQuaternion(), this.oSource.getQuaternion(), this.quaternion);
        this.performer.copyArray(this.quaternion, this.relativeFrame.getQuaternion());
        this.relativeFrame.setMatrix();
    }
    createAccMeasurements() {
        return [];
    }
    createConside() {
        let ua = new ActionArray_1.ActionArray();
        let rf = this.performer.convertObject(this.target, "IReferenceFrame");
        if (rf.length == 0) {
            this.updateAll = this.updateCoinDistanceAct;
            this.measurements = [
                new DistanceMeasurement(this.names[3], this)
            ];
            return false;
        }
        let f = rf[0];
        let o = f.getOwnFrame();
        var p = this.m6dPerformer.getOwnFrame(this.source);
        if (p == o) {
            return false;
        }
        ua.addAction(this.updateCoinDistanceAct);
        if ((this.oSource != undefined) && (this.oTarget != undefined)) {
            ua.addAction(this.updateRelativePositionAct);
        }
        let vs = this.performer.convertObject(this.source, "IVelocity");
        let vt = this.performer.convertObject(this.target, "IVelocity");
        if ((vs.length > 0) && (vt.length > 0)) {
            this.vSource = vs[0];
            this.vTarget = vt[0];
            ua.addAction(this.updateCoinVelocityAct);
        }
        let ot = this.performer.convertObject(this.target, "IOrientation");
        let os = this.performer.convertObject(this.source, "IOrientation");
        if (ot.length > 0) {
            this.oTarget = ot[0];
            ua.addAction(this.updateOrientationCoordinatesAct);
            ua.addAction(this.updateOrientationVelocityAct);
        }
        if (this.aTarget != undefined) {
            ua.addAction(this.addAngularVelocityAct);
        }
        ua.addAction(this.addAngularVelocityAct);
        if ((os.length > 0) && (ot.length > 0)) {
            ua.addAction(this.updateQuaternionAct);
            ua.addAction(this.addAngularVelocityAct);
            let vs = this.performer.convertObject(this.source, "IVelocity");
            let vt = this.performer.convertObject(this.target, "IVelocity");
            if ((vs.length > 0) && (vt.length > 0)) {
                ua.addAction(this.updateVelocityRotationAct);
            }
        }
        if (ua === undefined) {
        }
        else {
            this.updateAll = ua;
        }
        return true;
    }
    updateVelocityRotation() {
        let f = this.m6dPerformer.getOwnFrame(this.target);
        if (f === undefined) {
        }
        else {
            f.calculateRotatedPosition(this.relativeVelocity, this.aux);
            this.performer.copyArray(this.aux, this.relativeVelocity);
            this.performer.copyArray(this.relativeVelocity, this.ivelocity.getVelocity());
        }
    }
    createCoordMeasurements(vel) {
        let meas = [];
        for (let i = 0; i < 3; i++) {
            if (vel.length < 3) {
                meas.push(this.coordMeasurements[i]);
            }
            else {
                meas.push(new MeasurementDerivation_1.MeasurementDerivation(this.coordMeasurements[i], this.velocityMeasurements[i]));
            }
        }
        if (vel.length < 3) {
            meas.push(new DistanceMeasurement(this.names[3], this));
        }
        else {
            meas.push(new MeasurementDerivation_1.MeasurementDerivation(new DistanceMeasurement(this.names[3], this), new VelocityScalarMeasurement(this.names[7], this)));
        }
        return meas;
    }
    createQuatenionMeasurements() {
        if ((this.oSource === undefined) || (this.oTarget == undefined)) {
            return [];
        }
        return [this.quaternionMeasurements[0], this.quaternionMeasurements[1], this.quaternionMeasurements[2],
            this.quaternionMeasurements[3], this.angleMeasurements[0], this.angleMeasurements[1], this.angleMeasurements[2]];
    }
    createAngularVelicity() {
        if ((this.aSource === undefined) || (this.aTarget === undefined)) {
            return [];
        }
        let measurements = [];
        for (let i = 0; i < 3; i++) {
            measurements.push(this.omegaMeasurements[i]);
        }
        return measurements;
    }
    createVelocityMeasurements(acc) {
        if ((this.vSource === undefined) || (this.vTarget === null)) {
            return [];
        }
        let meas = [];
        for (let i = 0; i < 3; i++) {
            if (acc.length > 0) {
                meas.push(new MeasurementDerivation_1.MeasurementDerivation(this.velocityMeasurements[i], acc[i]));
            }
            else {
                meas.push(this.velocityMeasurements[i]);
            }
        }
        meas.push(this.velocityScalar);
        return meas;
    }
    getSource() {
        return this.source;
    }
    getTarget() {
        return this.target;
    }
    setSource(value) {
        if (this.source != null && value != null) {
            throw new OwnError_1.OwnError("Souce already exists", "", "");
        }
        this.source = value;
        this.getParameters(this.source, this.velocityArr, this.orientationArr, this.omArr);
        this.vSource = this.velocityArr[0];
        this.oSource = this.orientationArr[0];
        this.aSource = this.omArr[0];
        this.createMeasurements();
    }
    setTaget(value) {
        if (this.target != null && value != null) {
            throw new OwnError_1.OwnError("Souce already exists", "", "");
        }
        this.target = value;
        this.getParameters(this.target, this.velocityArr, this.orientationArr, this.omArr);
        this.vTarget = this.velocityArr[0];
        this.oTarget = this.orientationArr[0];
        this.aTarget = this.omArr[0];
        this.createMeasurements();
    }
    createMeasurements() {
        if (this.source == undefined || this.target == undefined) {
            return;
        }
        if (!this.createConside()) {
            return;
        }
        this.getParameters(this.source, this.velocityArr, this.orientationArr, this.omArr);
        this.vSource = this.velocityArr[0];
        this.oSource = this.orientationArr[0];
        this.aSource = this.omArr[0];
        this.getParameters(this.target, this.velocityArr, this.orientationArr, this.omArr);
        this.vTarget = this.velocityArr[0];
        this.oTarget = this.orientationArr[0];
        this.aTarget = this.omArr[0];
        this.createConside();
        let sf = this.m6dPerformer.getOwnFrame(this.source);
        if (sf != undefined) {
            this.sourceFrame = sf;
        }
        let tf = this.m6dPerformer.getOwnFrame(this.target);
        if (tf != undefined) {
            this.targetFrame = tf;
        }
        this.postCreateMeasurements();
    }
    postCreateMeasurements() {
        let up = new ActionArray_1.ActionArray();
        this.createConside();
        let acc = this.createAccMeasurements();
        let vel = this.createVelocityMeasurements(acc);
        let coord = this.createCoordMeasurements(vel);
        let m = [];
        if (vel.length > 0) {
            this.performer.addArray(m, coord);
            this.performer.addArray(m, vel);
            up.addAction(this.updateCoinDistanceAct);
            up.addAction(this.updateCoinVelocityAct);
            if (this.oTarget != undefined) {
                up.addAction(this.updateOrientationCoordinatesAct);
            }
            if (this.oTarget != undefined) {
                up.addAction(this.updateOrientationVelocityAct);
            }
            if (this.aTarget != null) {
                up.addAction(this.addAngularVelocityAct);
            }
            if ((this.oSource != undefined) && (this.oTarget != undefined)) {
                up.addAction(this.updateQuaternionAct);
            }
            if ((this.aSource != undefined) && (this.aTarget != undefined)) {
                up.addAction(this.updateAngularVelocityAct);
            }
        }
        else {
            this.performer.addArray(m, this.coordMeasurements);
        }
        if (up === undefined) {
        }
        else {
            this.updateAll = up;
        }
        this.relativeFrame = this.m6dPerformer.getRelative(this.targetFrame, this.sourceFrame);
        this.performer.addArray(m, this.createQuatenionMeasurements());
        this.performer.addArray(m, this.createAngularVelicity());
        m.push(this);
        this.measurements = m;
        let upf = new ActionArray_1.ActionArray();
        upf.addAction(this.updateFrameAct);
        var av = this.performer.convertObject(this.relativeFrame, "IAngularVelocityMotion6D");
        if (av.length > 0) {
            this.angularVelocity = av[0];
            upf.addAction(this.updateFrameAngularVelocityAct);
        }
        var iv = this.performer.convertObject(this.relativeFrame, "IVelocity");
        if (iv.length > 0) {
            this.ivelocity = iv[0];
        }
        if (upf === undefined) {
        }
        else {
            this.updFrame = upf;
        }
    }
}
exports.RelativeMeasurements = RelativeMeasurements;
class RelativeMeasurement extends NumberMeasurement_1.NumberMeasurement {
    relative;
    constructor(name, relative) {
        super(name);
        this.relative = relative;
    }
}
class RelativeMeasurementNumber extends RelativeMeasurement {
    num = 0;
    constructor(name, relative, num) {
        super(name, relative);
        this.num = num;
    }
}
class CoordMeasurement extends RelativeMeasurementNumber {
    constructor(name, relative, num) {
        super(name, relative, num);
    }
    getMeasurementValue() {
        return this.relative.getCoordinate()[this.num];
    }
}
exports.CoordMeasurement = CoordMeasurement;
class VelocityMeasurement extends RelativeMeasurementNumber {
    constructor(name, relative, num) {
        super(name, relative, num);
    }
    getMeasurementValue() {
        return this.relative.getVelocity()[this.num];
    }
}
exports.VelocityMeasurement = VelocityMeasurement;
class OmegaMeasurement extends RelativeMeasurementNumber {
    constructor(name, relative, num) {
        super(name, relative, num);
    }
    getMeasurementValue() {
        return this.relative.getOmega()[this.num];
    }
}
exports.OmegaMeasurement = OmegaMeasurement;
class QuaternionMeasurement extends RelativeMeasurementNumber {
    constructor(name, relative, num) {
        super(name, relative, num);
    }
    getMeasurementValue() {
        return this.relative.getQuaternion()[this.num];
    }
}
exports.QuaternionMeasurement = QuaternionMeasurement;
class DistanceMeasurement extends RelativeMeasurement {
    constructor(name, relative) {
        super(name, relative);
    }
    getMeasurementValue() {
        return this.relative.getDistance();
    }
}
exports.DistanceMeasurement = DistanceMeasurement;
class VelocityScalarMeasurement extends RelativeMeasurement {
    constructor(name, relative) {
        super(name, relative);
    }
    getMeasurementValue() {
        return this.relative.getVelocityScalar();
    }
}
exports.VelocityScalarMeasurement = VelocityScalarMeasurement;
class UpdateAct {
    relative;
    constructor(relative) {
        this.relative = relative;
    }
    action() {
        throw new OwnNotImplemented_1.OwnNotImplemented("UpdateAct");
    }
    isEmptyAction() { return false; }
}
class UpdateVelocityRotationAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateVelocityRotation();
    }
}
exports.UpdateVelocityRotationAct = UpdateVelocityRotationAct;
class UpdateQuaternionAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateQuaternion();
    }
}
exports.UpdateQuaternionAct = UpdateQuaternionAct;
class AddAngularVelocityAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.addAngularVelocity();
    }
}
exports.AddAngularVelocityAct = AddAngularVelocityAct;
class UpdateOrientationCoordinatesAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateOrientationCoordinates();
    }
}
exports.UpdateOrientationCoordinatesAct = UpdateOrientationCoordinatesAct;
class UpdateOrientationVelocityAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateOrientationVelocity();
    }
}
exports.UpdateOrientationVelocityAct = UpdateOrientationVelocityAct;
class UpdateFrameAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateFrame();
    }
}
exports.UpdateFrameAct = UpdateFrameAct;
class UpdateFrameAngularVelocityAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateFrameAngularVelocity();
    }
}
exports.UpdateFrameAngularVelocityAct = UpdateFrameAngularVelocityAct;
class UpdateAngularVelocityAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateAngularVelocity();
    }
}
exports.UpdateAngularVelocityAct = UpdateAngularVelocityAct;
class UpdateCoinVelocityAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateCoinVelocity();
    }
}
exports.UpdateCoinVelocityAct = UpdateCoinVelocityAct;
class UpdateRelativePositionAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateRelativePosition();
    }
}
exports.UpdateRelativePositionAct = UpdateRelativePositionAct;
class UpdateCoinDistanceAct extends UpdateAct {
    constructor(relative) {
        super(relative);
    }
    action() {
        this.relative.updateCoinDistance();
    }
}
exports.UpdateCoinDistanceAct = UpdateCoinDistanceAct;
