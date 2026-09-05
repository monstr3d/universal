"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Motion6DFrame = void 0;
const RotatedFrame_1 = require("./RotatedFrame");
class Motion6DFrame extends RotatedFrame_1.RotatedFrame {
    constructor() {
        super();
        this.velocity = [0, 0, 0];
        this.hv = [0, 0, 0];
        //protected double[] relativeVelocity = new double[] { 0, 0, 0 };
        /// <summary>
        /// Derivation
        /// </summary>
        this.der = [0, 0, 0, 0];
        /// <summary>
        /// Quaternion derivation
        /// </summary>
        this.qd = [0, 0, 0, 0];
        this.typeName = "Motion6DFrame";
        this.types.push("IVelocity");
        this.types.push("Motion6DFrame");
    }
    getVelocity() {
        return this.velocity;
    }
    //         let ab = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(baseFrame, "IAngularVelocityMotion6D");
    setReferenceFrame(baseFrame, relative) {
        super.setReferenceFrame(baseFrame, relative);
        let baseOrientation = baseFrame;
        let baseVelocity = this.performer.convertObject(baseFrame, "IVelocity");
        let relativeVelocity = this.performer.convertObject(relative, "IVelocity");
        let baseAngular = this.performer.convertObject(baseFrame, "IAngularVelocityMotion6D");
        // let ra = this.performer.convertObject<IAngularVelocityMotion6D, ReferenceFrame>(relative, "IAngularVelocityMotion6D")
        let velocityBase = baseVelocity[0].getVelocity();
        let velocityRelative = relativeVelocity[0].getVelocity();
        let mb = baseOrientation.getMatrix();
        let om = baseAngular[0].getOmega();
        let pos = relative.getPosition();
        this.vp.vectorProduct(om, pos, this.hv);
        for (let i = 0; i < 3; i++) {
            this.velocity[i] = velocityBase[i];
            for (let j = 0; j < 3; j++) {
                this.velocity[i] += mb[i][j] * (velocityRelative[j] + this.hv[j]);
            }
        }
    }
}
exports.Motion6DFrame = Motion6DFrame;
//# sourceMappingURL=Motion6DFrame.js.map