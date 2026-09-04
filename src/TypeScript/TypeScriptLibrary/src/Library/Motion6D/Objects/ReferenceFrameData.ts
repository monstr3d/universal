import { ReferenceFrame } from "../ReferenceFrame";
import { RigidReferenceFrame } from "./RigidReferenceFrame";
import { NumberMeasurement } from "../../Measurements/NumberMeasurement";
import type { IDesktop } from "../../Interfaces/IDesktop";
import type { IDataConsumer } from "../../Measurements/Interfaces/IDataConsumer";
import type { IMeasurement } from "../../Measurements/Interfaces/IMeasurement";
import type { IMeasurements } from "../../Measurements/Interfaces/IMeasurements";
import type { IAngularVelocity } from "../../Vector3D/Interfaces/IAngularVelocity";
import type { IVelocity } from "../Interfaces/IVelocity";
import type { IDerivation } from "../../Measurements/Interfaces/IDerivation";
import type { IAcceleration } from "../Interfaces/IAcceleration";


export class ReferenceFrameData extends RigidReferenceFrame implements IDataConsumer, IMeasurements, IMeasurement {
    protected outmeasurements: IMeasurement[] = [];

    /// <summary>
    /// Names of parametrers
    /// </summary>
    parametersList: string[] = [];

    /// <summary>
    /// Auxiliary variable
    /// </summary>
    protected qd: number[][] = [[0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0], [0, 0, 0, 0]];

    /// <summary>
    /// Auxiliary variable
    /// </summary>
    private der: number[] = [0, 0, 0, 0];

    /// <summary>
    /// External measurements
    /// </summary>
    protected measurementsData: IMeasurements[] = [];

    /// <summary>
    /// Measurementrs
    /// </summary>
    protected measurements: IMeasurement[] = [];

    /// <summary>
    /// Second derivations
    /// </summary>
    protected secondDeri: number[] = [0, 0, 0, 0, 0, 0, 0];

    /// <summary>
    /// Second derivations' measurements
    /// </summary>
    protected secondDeriM: IMeasurement[] = [];

    /// <summary>
    /// Auxiliary variable
    /// </summary>
    protected angsec: number[] = [0, 0, 0, 0];

    protected om: number[] = [0, 0, 0]

    angularVelocity !: IAngularVelocity 

    velocityObject !: IVelocity 

    any : any
/*
    private coordDel: IFunc<any>[] = [];

    private oriDel: IFunc<any>[] = [];

    private velocityDel: IFunc<any>[] = [];

    private angularDel: IFunc<any>[] = [];

    private isReset: boolean = false;*/


    private names: string[] = [
        "x", "y", "z",
        "Vx", "Vy", "Vz", "Q0", "Q1", "Q2", "Q3",
        "OMx", "OMy", "OMz", "A11", "A12", "A13", "A21", "A22", "A23", "A31", "A32", "A33"
    ];

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "ReferenceFrameData";
        this.types.push("IDataConsumer");
        this.types.push("IMeasurements");
        this.types.push("IPostSetArrow");
        this.types.push("ReferenceFrameData");
    }


    resetDataConsumer(): void {
    }
    getMeasurementName(): string {
        return "Frame";
    }
    getMeasurementType() {
        return "Frame";
    }
    getMeasurementValue() {
        return this.own;
    }
    getMeasurementsCount(): number {
        return this.outmeasurements.length;
    }
    getMeasurement(i: number): IMeasurement {
        return this.outmeasurements[i];
    }
    updateMeasurements(): void {
    }



    updateReferenceFrame(): void {
        this.measuremrntPerformrer.fullReset(this);
        var rel = this.relative;
        var x = rel.getPosition();
       // var parent = this.getParentFrame();
        for (let i = 0; i < 3; i++) {
            var o = this.measurements[i].getMeasurementValue();
            if (o === undefined) {
                return;
            }
            x[i] = this.performer.convert<number, number>(o);

        }
        var vela = this.performer.convertObject<IVelocity, ReferenceFrame>(rel, "IVelocity");
        if (vela.length > 0) {
            var vel = vela[0];
            var v = vel.getVelocity();
            for (let i = 0; i < 3; i++) {
                let m = this.measurements[i];
                var dd = this.performer.convertObject<IDerivation, IMeasurement>(m, "IDerivation");
                if (dd.length > 0) {
                    var d = dd[0];
                    var der = d.getDerivation();
                    var val = der.getMeasurementValue();
                    var y = this.performer.convert<number, number>(val);
                    v[i] = y;
                }
            }
        }
        var qua = rel.getQuaternion();
        for (let i = 0; i < 4; i++) {
            let m = this.measurements[i + 3];
            var val = m.getMeasurementValue();
            var y = this.performer.convert<number, number>(val);
            qua[i] = y;

        }
        rel.setMatrix();
       // var matrix = rel.getMatrix()
        var anga = this.performer.convertObject<IAngularVelocity, ReferenceFrame>(rel, "IAngularVelocity");
        if (anga.length > 0) {
            let ang = anga[0];
            this.om[0] = ang.getAngularVelocityX()
            this.om[1] = ang.getAngularVelocityY()
            this.om[2] = ang.getAngularVelocityZ()
         //   var ora = this.performer.convertObject<IOrientation, ReferenceFrame>(rel, "IOrientation");
       //     var or = ora[0];
            for (let i = 0; i < 4; i++) {
                let m = this.measurements[i + 3];
                var dd = this.performer.convertObject<IDerivation, IMeasurement>(m, "IDerivation");
                var d = dd[0];
                var der = d.getDerivation();
                var val = der.getMeasurementValue();
                var y = this.performer.convert<number, number>(val);
                this.der[i] = y
            }
            this.vp.calculateDynamics(qua, this.der, this.om, this.qd)
        }
        if (vela.length > 0) {
            let aa = this.performer.convertObject<IAcceleration, ReferenceFrame>(rel, "IAcceleration");
            if (aa.length > 0) {
                var acc = aa[0];
               // var anc = this.performer.convertObject<IAngularAcceleration, ReferenceFrame>(rel, "IAngularAcceleration");
               // var angacc = anc[0].getAngularAcceleration();
                var linacc = acc.getRelativeAcceleration();
                for (let i = 0; i < 3; i++) {
                    let sd = this.secondDeriM[i].getMeasurementValue();
                    linacc[i] = this.performer.convert<number, number>(sd);
                }
                for (let i = 0; i < 4; i++) {
                    let sd = this.secondDeriM[i + 3].getMeasurementValue();
                    this.angsec[i] = this.performer.convert<number, number>(sd);
                }
                let av = anga[0];
                this.om[0] = av.getAngularVelocityX()
                this.om[1] = av.getAngularVelocityY()
                this.om[2] = av.getAngularVelocityZ()
                var rq = rel.getQuaternion();
                this.vp.calculateDynamics(rq, this.der,  this.om, this.qd);

            }
        }
        super.updateReferenceFrame()
    }  

    addMeasurement(measurement: IMeasurement): void {
        this.any = measurement
    }


    getAllMeasurements(): IMeasurements[] {
        return this.measurementsData;
    }
    addMeasurements(item: IMeasurements): void {
        this.measurementsData.push(item);
    }

    getFrame(): any {
        return this.own;
    }

    getX(): any {
        return this.own.getPosition()[0];
    }
    getY(): any {
        return this.own.getPosition()[1];
    }
    getZ(): any {
        return this.own.getPosition()[2];
    }

    getVx(): any {
        return this.velocityObject.getVelocity()[0];
    }

    getVy(): any {
        return this.velocityObject.getVelocity()[1];
    }

    getVz(): any {
        return this.velocityObject.getVelocity()[2];
    }

    getQ0(): any {
        return this.own.getQuaternion()[0];
    }
    getQ1(): any {
        return this.own.getQuaternion()[1];
    }
    getQ2(): any {
        return this.own.getQuaternion()[2];
    }
    getQ3(): any {
        return this.own.getQuaternion()[3];
    }

    getOmegaX(): any {
        return this.angularVelocity.getAngularVelocityX();
    }

    getOmegaY(): any {
        return this.angularVelocity.getAngularVelocityY();
    }

    getOmegaZ(): any {
        return this.angularVelocity.getAngularVelocityZ();
    }

    createMeasurements(): void {
        let lm: IMeasurement[] = [];
        lm.push(this);
        for (let i = 0; i < 3; i++) {
            this.outmeasurements.push(new Coordinate(this.names[i], i, this.own))
        }
        for (let i = 0; i < 4; i++) {
            this.outmeasurements.push(new QuaternionMeasurement(this.names[i + 6], i, this.own))
        }
        if (this.own.imlplementsType("IVelocity")) {
            for (let i = 0; i < 3; i++) {
                this.outmeasurements.push(new Velocity(this.names[i + 3], i, this.velocityObject))
            }

        }
        if (this.own.imlplementsType("IAngularVelocity")) {
            for (let i = 0; i < 3; i++) {
                this.outmeasurements.push(new AngularVelocity(this.names[i + 10], i, this.angularVelocity))
            }

        }
    }


}





class Coordinate extends NumberMeasurement {
    n: number = 0;
    frame: ReferenceFrame = new ReferenceFrame();
    constructor(name: string, n: number, frame: ReferenceFrame) {
        super(name)
        this.n = n;
        this.frame = frame

    }


    getMeasurementValue(): any {
        return this.frame.getPosition()[this.n];
    }
}
class QuaternionMeasurement extends NumberMeasurement {
    n: number = 0;
    frame: ReferenceFrame = new ReferenceFrame();
    constructor(name: string, n: number, frame: ReferenceFrame) {
        super(name)
        this.n = n;
        this.frame = frame

    }

    getMeasurementValue(): any {
        return this.frame.getQuaternion()[this.n];
    }
}
class Velocity extends NumberMeasurement {
    n: number = 0;
    velocity !: IVelocity 
    constructor(name: string, n: number, velocity: IVelocity) {
        super(name)
        this.n = n;
        this.velocity = velocity;

    }

    getMeasurementValue(): any {
        return this.velocity.getVelocity()[this.n]
    }
}

class AngularVelocity extends NumberMeasurement {
    n: number = 0;
    velocity!: IAngularVelocity
    constructor(name: string, n: number, velocity: IAngularVelocity) {
        super(name)
        this.n = n;
        this.velocity = velocity;

    }

    getMeasurementValue(): any {
        switch (this.n) {
            case 0: return this.velocity.getAngularVelocityX();
            case 1: return this.velocity.getAngularVelocityY();

        }
        return this.velocity.getAngularVelocityZ();
    }
}

