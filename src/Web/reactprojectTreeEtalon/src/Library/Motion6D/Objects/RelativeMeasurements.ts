import { CategoryObject } from "../../CategoryObject";
import { OwnError } from "../../ErrorHandler/OwnError";
import { MeasurementDerivation } from "../../Measurements/MeasurementDerivation";
import { RealMatrix } from "../../RealMatrixProcessor/RealMatrix";
import { EulerAngles } from "../../Vector3D/EulerAngles";
import { Vector3DProcessor } from "../../Vector3D/Vector3DProcessor";
import { EulerMeasurement } from "../Measurements/EulerMeasurement";
import { Motion6DAcceleratedFrame } from "../Motion6DAcceleratedFrame";
import { Motion6DPerformer } from "../Motion6DPerformer";
import { ReferenceFrame } from "../ReferenceFrame";
import { ActionArray } from "../../Utilities/Generic/ActionArray";
import type { IAction } from "../../Interfaces/IAction";
import type { IActionAddRemove } from "../../Interfaces/IActionAddRemove";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IPostSetArrow } from "../../Interfaces/IPostSetArrow";
import type { IMeasurement } from "../../Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "../../Measurements/Interfaces/IMeasurements";
import type { IAngularVelocityMotion6D } from "../Interfaces/IAngularVelocityMotion6D";
import type { IOrientation } from "../Interfaces/IOrientation";
import type { IPosition } from "../Interfaces/IPosition";
import type { IReferenceFrame } from "../Interfaces/IReferenceFrame";
import type { IVelocity } from "../Interfaces/IVelocity";
import { NumberMeasurement } from "../../Measurements/NumberMeasurement";
import { OwnNotImplemented } from "../../ErrorHandler/OwnNotImplemented";



export class RelativeMeasurements extends CategoryObject implements IMeasurements, IMeasurement, IPostSetArrow {

    m6dPerformer: Motion6DPerformer = new Motion6DPerformer();



    protected vp: Vector3DProcessor = new Vector3DProcessor();

    protected realMatrix: RealMatrix = new RealMatrix();

    protected own: ReferenceFrame = new Motion6DAcceleratedFrame();

    protected relative: number[] = [0, 0, 0];

    protected mPerformer: Motion6DPerformer = new Motion6DPerformer();

    protected angles: EulerAngles = new EulerAngles(0, 0, 0);

    coordMeasurements: IMeasurement[] = [];

    velocityMeasurements: IMeasurement[] = [];

    omegaMeasurements: IMeasurement[] = [];

    quaternionMeasurements: IMeasurement[] = [];

    angleMeasurements: IMeasurement[] = [];

    velocityArr: IVelocity[] = [];
    orientationArr: IOrientation[] = [];
    omArr: IAngularVelocityMotion6D[] = [];



    private names: string[] = [
        "x", "y", "z", "Distance",
        "Vx", "Vy", "Vz", "Velocity", "Q0", "Q1", "Q2", "Q3", "Roll", "Pitch", "Yaw",
        "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"
    ];


    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "RelativeMeasurements";
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.types.push("RelativeMeasurements");
        this.createActions();
        let em = new EulerMeasurement("", this.angles);
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


    postSetArrow(): void {
        this.createMeasurements();
    }



    getMeasurementName(): string {
        return "Frame";
    }
    getMeasurementType() {
        return "ReferenceFrame";
    }
    getMeasurementValue() {
        return this.relativeFrame;
    }


    getMeasurementsCount(): number {
        return this.measurements.length;
    }
    getMeasurement(i: number): IMeasurement {
        return this.measurements[i];
    }

    updateMeasurements(): void {
        this.performer.executeAction(this.updateAll);
        this.performer.executeAction(this.updFrame);
    }

    protected source!: IPosition

    protected target!: IPosition 

    protected vSource!: IVelocity 

    protected vTarget!: IVelocity 

    protected oSource!: IOrientation

    protected oTarget!: IOrientation 

    protected aSource!: IAngularVelocityMotion6D 


    protected aTarget !: IAngularVelocityMotion6D 

    protected relativePos: number[] = [0, 0, 0];

    protected relativeP: number[] = [0, 0, 0];

    protected relativeVelocity: number[] = [0, 0, 0];


    protected quaternion: number[] = [0, 0, 0, 0];

    protected measurementFrame!: IMeasurement;

    protected velocityScalar!: IMeasurement;

    protected distanceScalar!: IMeasurement


    protected measurements: IMeasurement[] = [];

    protected distance: number = 0;

    protected velocity: number = 0;

    protected targetFrame: ReferenceFrame = new ReferenceFrame();

    protected sourceFrame: ReferenceFrame = new ReferenceFrame();

    protected relativeFrame: ReferenceFrame = new ReferenceFrame();


    protected omegaRProduct: number[] = [0, 0, 0];
    protected matrixPosition: number[] = [0, 0, 0];
    protected matrixVelocity: number[] = [0, 0, 0];
    protected omegaRelative: number[] = [0, 0, 0];
    protected aux: number[] = [0, 0, 0];

    private angularVelocity!: IAngularVelocityMotion6D;

    private ivelocity!: IVelocity



    updFrame!: IAction


    updateAll!: IAction


    updateFrameAct!: IAction 

    updateFrameAngularVelocityAct!: IAction

    updateAngularVelocityAct!: IAction
    updateCoinVelocityAct!: IAction
    updateCoinDistanceAct!: IAction
    updateRelativePositionAct!: IAction
    updateOrientationCoordinatesAct!: IAction
    updateOrientationVelocityAct!: IAction
    updateQuaternionAct!: IAction
    addAngularVelocityAct!: IAction
    updateVelocityRotationAct!: IAction

    createActions(): void {
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

    public updateFrame(): void {
        this.performer.copyArray(this.relativePos, this.relativeFrame.getPosition());
        this.performer.copyArray(this.quaternion, this.relativeFrame.getQuaternion());
        this.vp.quaternionToeulerAngles(this.angles, this.quaternion);

    }

    public updateFrameAngularVelocity(): void {
        this.performer.copyArray(this.omegaRelative, this.angularVelocity.getOmega());
    }



    public updateAngularVelocity(): void {
        this.realMatrix.multiplyLeft(this.aTarget.getOmega(), this.relativeFrame.getMatrix(), this.aux);
        let om = this.aSource.getOmega();
        for (let i = 0; i < 3; i++) {
            this.omegaRelative[i] = om[i] - this.aux[i];
        }
    }

    public updateCoinVelocity(): void {
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

    public updateCoinDistance(): void {
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


    public updateRelativePosition(): void {
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


    protected getParameters(p: IPosition, velocity: IVelocity[], orientation: IOrientation[], om: IAngularVelocityMotion6D[]) {

        let pa = p;
        if (velocity.length > 0) velocity.pop();
        if (om.length > 0) om.pop();
        if (orientation.length > 0) orientation.pop();

        let rf = this.performer.convertObject<IReferenceFrame, IPosition>(p, "IReferenceFrame");
        if (rf.length > 0) {
            let pp = rf[0].getOwnFrame();
            if (pp === undefined) {
            }
            else {
                pa = pp;

            }
        }
        let vf = this.performer.convertObject<IVelocity, IPosition>(pa, "IVelocity");
        this.performer.reoplaceArrayValue<IVelocity>(vf, velocity);
        let oof = this.performer.convertObject<IOrientation, IPosition>(pa, "IOrientation");
        this.performer.reoplaceArrayValue<IOrientation>(oof, orientation);
        let omf = this.performer.convertObject<IAngularVelocityMotion6D, IPosition>(pa, "IAngularVelocityMotion6D");
        this.performer.reoplaceArrayValue<IAngularVelocityMotion6D>(omf, om);

    }

    public getDistance(): number {
        return this.distance;
    }

    public getOmega(): number[] {
        return this.omegaRelative;

    }

    public getQuaternion(): number[] {
        return this.quaternion;

    }

    public getCoordinate(): number[] {
        return this.relativePos;
    }


    public getVelocity(): number[] {
        return this.relativeVelocity;
    }

    public getVelocityScalar(): number {
        return this.velocity;
    }


    updateOrientation(x: number[], aux: number[]) {
        let m = this.oTarget.getMatrix();
        this.realMatrix.multiplyLeft(x, m, aux);
        this.performer.copyArray<number>(aux, x);
    }

    public updateOrientationCoordinates(): void {
        this.updateOrientation(this.relativePos, this.matrixPosition);
    }


    public updateOrientationVelocity(): void {
        this.updateOrientation(this.relativeVelocity, this.matrixVelocity);
    }

    public addAngularVelocity(): void {
        let om = this.aTarget.getOmega();
        this.vp.vectorProduct(this.relativePos, om, this.omegaRProduct);
        this.realMatrix.plusEqual(this.relativeVelocity, this.omegaRProduct);


    }
    public updateQuaternion(): void {
        this.vp.quaternionInvertMultiply(this.oTarget.getQuaternion(), this.oSource.getQuaternion(), this.quaternion);
        this.performer.copyArray<number>(this.quaternion, this.relativeFrame.getQuaternion());
        this.relativeFrame.setMatrix();

    }

    createAccMeasurements(): IMeasurement[] {
        return [];
    }



    createConside(): boolean {
        let ua: IActionAddRemove = new ActionArray();
        let rf = this.performer.convertObject<IReferenceFrame, IPosition>(this.target, "IReferenceFrame");
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
        let vs = this.performer.convertObject<IVelocity, IPosition>(this.source, "IVelocity");
        let vt = this.performer.convertObject<IVelocity, IPosition>(this.target, "IVelocity");

        if ((vs.length > 0) && (vt.length > 0)) {
            this.vSource = vs[0];
            this.vTarget = vt[0];
            ua.addAction(this.updateCoinVelocityAct);
        }
        let ot = this.performer.convertObject<IOrientation, IPosition>(this.target, "IOrientation");
        let os = this.performer.convertObject<IOrientation, IPosition>(this.source, "IOrientation");
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
            let vs = this.performer.convertObject<IVelocity, IPosition>(this.source, "IVelocity");
            let vt = this.performer.convertObject<IVelocity, IPosition>(this.target, "IVelocity");

            if ((vs.length > 0) && (vt.length > 0)) {
                ua.addAction(this.updateVelocityRotationAct);
            }

        }
        if (ua === undefined) {
        } else {
            this.updateAll = ua;
        }
        return true;
    }

    public updateVelocityRotation(): void {
        let f = this.m6dPerformer.getOwnFrame(this.target);
        if (f === undefined) {
        }
        else {
            f.calculateRotatedPosition(this.relativeVelocity, this.aux);
            this.performer.copyArray<number>(this.aux, this.relativeVelocity);
            this.performer.copyArray<number>(this.relativeVelocity, this.ivelocity.getVelocity());
        }
    }

    createCoordMeasurements(vel: IMeasurement[]): IMeasurement[] {
        let meas: IMeasurement[] = [];
        for (let i = 0; i < 3; i++) {
            if (vel.length < 3) {
                meas.push(this.coordMeasurements[i]);
            }
            else {
                meas.push(new MeasurementDerivation(this.coordMeasurements[i], this.velocityMeasurements[i]));
            }
        }
        if (vel.length < 3) {
            meas.push(new DistanceMeasurement(this.names[3], this));
        }
        else {
            meas.push(new MeasurementDerivation(new DistanceMeasurement(this.names[3], this),
                new VelocityScalarMeasurement(this.names[7], this)));
        }

        return meas;
    }

    createQuatenionMeasurements(): IMeasurement[] {
        if ((this.oSource === undefined) || (this.oTarget == undefined)) {
            return [];
        }
        return [this.quaternionMeasurements[0], this.quaternionMeasurements[1], this.quaternionMeasurements[2],
        this.quaternionMeasurements[3], this.angleMeasurements[0], this.angleMeasurements[1], this.angleMeasurements[2]];
    }

    createAngularVelicity(): IMeasurement[] {
        if ((this.aSource === undefined) || (this.aTarget === undefined)) {
            return [];
        }
        let measurements: IMeasurement[] = [];
        for (let i = 0; i < 3; i++) {
            measurements.push(this.omegaMeasurements[i]);
        }
        return measurements;
    }

    createVelocityMeasurements(acc: IMeasurement[]): IMeasurement[] {
        if ((this.vSource === undefined) || (this.vTarget === null)) {
            return [];
        }
        let meas: IMeasurement[] = [];
        for (let i = 0; i < 3; i++) {

            if (acc.length > 0) {
                meas.push(new MeasurementDerivation(this.velocityMeasurements[i], acc[i]));
            }
            else {
                meas.push(this.velocityMeasurements[i]);
            }
        }
        meas.push(this.velocityScalar);
        return meas;
    }

    public getSource(): IPosition {
        return this.source;
    }

    public getTarget(): IPosition {
        return this.target;
    }


    public setSource(value: IPosition): void {
        if (this.source != null && value != null) {
            throw new OwnError("Souce already exists", "", "");
        }
        this.source = value;
        this.getParameters(this.source, this.velocityArr, this.orientationArr, this.omArr);
        this.vSource = this.velocityArr[0];
        this.oSource = this.orientationArr[0];
        this.aSource = this.omArr[0];
        this.createMeasurements();

    }

    public setTaget(value: IPosition): void {
        if (this.target != null && value != null) {
            throw new OwnError("Souce already exists", "", "");
        }
        this.target = value;
        this.getParameters(this.target, this.velocityArr, this.orientationArr, this.omArr);
        this.vTarget = this.velocityArr[0];
        this.oTarget = this.orientationArr[0];
        this.aTarget = this.omArr[0];
        this.createMeasurements();

    }



    createMeasurements(): void {
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

    postCreateMeasurements(): void {
        let up: IActionAddRemove = new ActionArray();
        this.createConside();
        let acc = this.createAccMeasurements();
        let vel = this.createVelocityMeasurements(acc);
        let coord = this.createCoordMeasurements(vel);
        let m: IMeasurement[] = [];
        if (vel.length > 0) {
            this.performer.addArray<IMeasurement>(m, coord);
            this.performer.addArray<IMeasurement>(m, vel);
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
        let upf: IActionAddRemove = new ActionArray();
        upf.addAction(this.updateFrameAct);
        var av = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(this.relativeFrame, "IAngularVelocityMotion6D");
        if (av.length > 0) {
            this.angularVelocity = av[0];
            upf.addAction(this.updateFrameAngularVelocityAct);

        }
        var iv = this.performer.convertObject<IVelocity, ReferenceFrame>(this.relativeFrame, "IVelocity");
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

class RelativeMeasurement extends NumberMeasurement {
    protected relative !: RelativeMeasurements

    constructor(name: string, relative: RelativeMeasurements) {
        super(name)
        this.relative = relative;
    }
}

class RelativeMeasurementNumber extends RelativeMeasurement {
    num: number = 0;
    constructor(name: string, relative: RelativeMeasurements, num: number) {
        super(name, relative)
        this.num = num
    }
}

export class CoordMeasurement extends RelativeMeasurementNumber {
    constructor(name: string, relative: RelativeMeasurements, num: number) {
        super(name, relative, num)
    }

    getMeasurementValue() {
        return this.relative.getCoordinate()[this.num]
    }
}

export class VelocityMeasurement extends RelativeMeasurementNumber {
    constructor(name: string, relative: RelativeMeasurements, num: number) {
        super(name, relative, num)
    }

    getMeasurementValue() {
        return this.relative.getVelocity()[this.num]
    }

}
export class OmegaMeasurement extends RelativeMeasurementNumber {
    constructor(name: string, relative: RelativeMeasurements, num: number) {
        super(name, relative, num)
    }

    getMeasurementValue() {
        return this.relative.getOmega()[this.num]
    }

}

export class QuaternionMeasurement extends RelativeMeasurementNumber {
    constructor(name: string, relative: RelativeMeasurements, num: number) {
        super(name, relative, num)
    }

    getMeasurementValue() {
        return this.relative.getQuaternion()[this.num]
    }

}

export class DistanceMeasurement extends RelativeMeasurement {
    constructor(name: string, relative: RelativeMeasurements) {
        super(name, relative)
    }

    getMeasurementValue() {
        return this.relative.getDistance();
    }

}

export class VelocityScalarMeasurement extends RelativeMeasurement {
    constructor(name: string, relative: RelativeMeasurements) {
        super(name, relative)
    }

    getMeasurementValue() {
        return this.relative.getVelocityScalar();
    }

}



class UpdateAct implements IAction {

    relative !: RelativeMeasurements

    constructor(relative: RelativeMeasurements) {
        this.relative = relative;
    }
    action(): void {
        throw new OwnNotImplemented("UpdateAct");
    }
    isEmptyAction(): boolean { return false }

}

export class UpdateVelocityRotationAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateVelocityRotation()
    }
}

export class UpdateQuaternionAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateQuaternion()
    }

}
export class AddAngularVelocityAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.addAngularVelocity()
    }

}


export class UpdateOrientationCoordinatesAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateOrientationCoordinates()
    }

}

export class UpdateOrientationVelocityAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateOrientationVelocity();
    }

}




export class UpdateFrameAct extends UpdateAct {

   constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateFrame();
    }

}

export class UpdateFrameAngularVelocityAct extends UpdateAct {
    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateFrameAngularVelocity();
    }

}
export class UpdateAngularVelocityAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateAngularVelocity();
    }
}


export class UpdateCoinVelocityAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateCoinVelocity();
    }
}
export class UpdateRelativePositionAct extends UpdateAct  {
    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateRelativePosition();
    }

}

export class UpdateCoinDistanceAct extends UpdateAct {

    constructor(relative: RelativeMeasurements) {
        super(relative)
    }

    action(): void {
        this.relative.updateCoinDistance();
    }

}

