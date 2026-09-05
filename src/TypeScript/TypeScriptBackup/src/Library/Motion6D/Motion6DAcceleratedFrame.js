"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Motion6DAcceleratedFrame = void 0;
const Motion6DFrame_1 = require("./Motion6DFrame");
class Motion6DAcceleratedFrame extends Motion6DFrame_1.Motion6DFrame {
    constructor() {
        super();
        this.relativeAcceleration = [0, 0, 0];
        this.acceleration = [0, 0, 0];
        this.angularAcceleration = [0, 0, 0];
        this.temp = [0, 0, 0];
        this.tempV = [0, 0, 0];
        this.typeName = "Motion6DAcceleratedFrame";
        this.types.push("IAcceleration");
        this.types.push("IAngularAcceleration");
        this.types.push("Motion6DAcceleratedFrame");
    }
    setReferenceFrame(baseFrame, relative) {
        super.setReferenceFrame(baseFrame, relative);
        let arn = this.performer.convertObject(relative, " IAngularAcceleration");
        let relativeVelocity = this.performer.convertObject(relative, "IVelocity");
        let baseAngulatVelocity = this.performer.convertObject(baseFrame, "IAngularVelocityMotion6D");
        let relativeAngularVelocity = this.performer.convertObject(relative, "IAngularVelocityMotion6D");
        var rp = this.getPosition();
        let m = this.getMatrix();
        let relativeOmega = relativeAngularVelocity[0].getOmega();
        let baseOmega = baseAngulatVelocity[0].getOmega();
        this.vp.vectorProduct(baseOmega, relativeVelocity[0].getVelocity(), this.tempV);
        let om2 = this.vp.square3d(baseOmega);
        let eps = arn[0].getAngularAcceleration();
        this.vp.vectorProduct(eps, rp, this.temp);
        for (let i = 0; i < 3; i++) {
            this.tempV[i] *= 2;
            this.tempV[i] += om2 * rp[i] + this.relativeAcceleration[i] + this.temp[i];
        }
        this.realMatrix.multiplyRight(m, this.tempV, this.acceleration);
        var relativeOrientation = relative;
        var relativeMatrix = relativeOrientation.getMatrix();
        this.realMatrix.multiplyLeft(baseOmega, relativeMatrix, this.temp);
        this.vp.vectorProduct(this.temp, relativeOmega, this.tempV);
        for (let i = 0; i < 3; i++) {
            this.temp[i] = eps[i] + this.tempV[i];
        }
        this.realMatrix.multiplyLeft(this.temp, m, this.angularAcceleration);
    }
    getAngularAcceleration() {
        return this.angularAcceleration;
    }
    getLineraAcceleration() {
        return this.acceleration;
        ;
    }
    getRelativeAcceleration() {
        return this.relativeAcceleration;
    }
}
exports.Motion6DAcceleratedFrame = Motion6DAcceleratedFrame;
//# sourceMappingURL=Motion6DAcceleratedFrame.js.map