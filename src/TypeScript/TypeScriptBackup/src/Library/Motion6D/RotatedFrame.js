"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.RotatedFrame = void 0;
const ReferenceFrame_1 = require("./ReferenceFrame");
class RotatedFrame extends ReferenceFrame_1.ReferenceFrame {
    constructor() {
        super();
        this.omega = [0, 0, 0];
        this.typeName = "RotatedFrame";
        this.types.push("IAngularVelocityMotion6D");
        this.types.push("RotatedFrame");
    }
    getOmega() {
        return this.omega;
    }
    setReferenceFrame(baseFrame, relative) {
        super.setReferenceFrame(baseFrame, relative);
        let ab = this.performer.convertObject(baseFrame, "IAngularVelocityMotion6D");
        let ar = this.performer.convertObject(relative, "IAngularVelocityMotion6D");
        let matrix = relative.getMatrix();
        let ob = ab[0].getOmega();
        let or = ar[0].getOmega();
        for (let i = 0; i < or.length; i++) {
            this.omega[i] = or[i];
            for (let j = 0; j < 3; j++) {
                this.omega[i] += matrix[i][j] * ob[j];
            }
        }
    }
}
exports.RotatedFrame = RotatedFrame;
//# sourceMappingURL=RotatedFrame.js.map