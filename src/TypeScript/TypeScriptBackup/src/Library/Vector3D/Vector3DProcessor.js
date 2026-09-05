"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vector3DProcessor = void 0;
const RealMatrix_1 = require("../RealMatrixProcessor/RealMatrix");
const CollectionProcessor_1 = require("../Utilities/Collections/CollectionProcessor");
class Vector3DProcessor {
    constructor() {
        // private idQuaternion: number[] = [1, 0, 0, 0];
        this.realMatrix = new RealMatrix_1.RealMatrix();
        this.collectionProcessor = new CollectionProcessor_1.CollectionProcessor();
    }
    quaternionNormalize(quaternion) {
        let a = 0;
        for (let q of quaternion) {
            a += q * q;
        }
        a = 1 / Math.sqrt(a);
        for (var i = 0; i < 4; i++) {
            quaternion[i] *= a;
        }
    }
    quaternionToeulerAngles(angles, quaternion) {
        this.quaternionToeulerAnglesXYZW(angles, quaternion[1], quaternion[2], quaternion[3], quaternion[0]);
    }
    quaternionToeulerAnglesXYZW(angles, x, y, z, w) {
        // roll (x-axis rotation)
        let sinr_cosp = 2 * (w * x + y * z);
        let cosr_cosp = 1 - 2 * (x * x + y * y);
        angles.setRoll(Math.atan2(sinr_cosp, cosr_cosp));
        // pitch (y-axis rotation)
        let sinp = 2 * (w * y - z * x);
        if (Math.abs(sinp) >= 1) {
            angles.setPitch(this.realMatrix.copySign(Math.PI / 2, sinp));
            //std::copysign(M_PI / 2, sinp); // use 90 degrees if out of range
        }
        else {
            angles.setPitch(Math.asin(sinp));
        }
        // yaw (z-axis rotation)
        let siny_cosp = 2 * (w * z + x * y);
        let cosy_cosp = 1 - 2 * (y * y + z * z);
        angles.setYaw(Math.atan2(siny_cosp, cosy_cosp));
    }
    rotateOmega(omega, quaternion, time) {
        let o = this.realMatrix.partialNorm(omega, 0, 3);
        let phi = 0.5 * o * time;
        let s = Math.sin(phi);
        quaternion[0] = Math.sqrt(1 - s * s);
        o = 1 / o;
        for (let i = 0; i < 3; i++) {
            quaternion[i + 1] = o * s * omega[i];
        }
    }
    square3d(x) {
        // !!! EXCEPTION DELETE
        if (x.length != 3) {
        }
        return x[0] * x[0] + x[1] * x[1] + x[2] * x[2];
    }
    vectorProduct(x, y, z) {
        z[0] = x[1] * y[2] - x[2] * y[1];
        z[1] = x[2] * y[0] - x[0] * y[2];
        z[2] = x[0] * y[1] - x[1] * y[0];
    }
    quaternionMultiply(x, y, z) {
        z[0] = x[0] * y[0] - x[1] * y[1] - x[2] * y[2] - x[3] * y[3];
        z[1] = x[0] * y[1] + x[1] * y[0] + x[2] * y[3] - x[3] * y[2];
        z[2] = x[0] * y[2] + x[2] * y[0] + x[3] * y[1] - x[1] * y[3];
        z[3] = x[0] * y[3] + x[3] * y[0] + x[1] * y[2] - x[2] * y[1];
    }
    quaternionInvertMultiply(x, y, z) {
        z[0] = x[0] * y[0] + x[1] * y[1] + x[2] * y[2] + x[3] * y[3];
        z[1] = x[0] * y[1] - x[1] * y[0] - x[2] * y[3] + x[3] * y[2];
        z[2] = x[0] * y[2] - x[2] * y[0] - x[3] * y[1] + x[1] * y[3];
        z[3] = x[0] * y[3] - x[3] * y[0] - x[1] * y[2] + x[2] * y[1];
    }
    quaternionInvertOmega(quaterinon, omegaIn, omegaOut) {
        omegaOut[0] = quaterinon[0] * omegaIn[0] - quaterinon[2] * omegaIn[2] + quaterinon[3] * omegaIn[1];
        omegaOut[1] = quaterinon[0] * omegaIn[1] - quaterinon[3] * omegaIn[0] + quaterinon[1] * omegaIn[2];
        omegaOut[2] = quaterinon[0] * omegaIn[2] - quaterinon[1] * omegaIn[1] + quaterinon[2] * omegaIn[0];
    }
    quaternionToMatrix(q, m, qq) {
        let norm = 1 / Math.sqrt(q[0] * q[0] + q[1] * q[1] + q[2] * q[2] + q[3] * q[3]);
        for (let i = 0; i < 4; i++) {
            q[i] *= norm;
        }
        for (let i = 0; i < 4; i++) {
            for (let j = 0; j <= i; j++) {
                qq[i][j] = q[i] * q[j];
            }
        }
        m[0][0] = qq[0][0] + qq[1][1] - qq[2][2] - qq[3][3];
        m[0][1] = 2 * (qq[2][1] - qq[3][0]);
        m[0][2] = 2 * (qq[2][0] + qq[3][1]);
        m[1][0] = 2 * (qq[3][0] + qq[2][1]);
        m[1][1] = qq[0][0] - qq[1][1] + qq[2][2] - qq[3][3];
        m[1][2] = 2 * (qq[3][2] - qq[1][0]);
        m[2][0] = 2 * (qq[3][1] - qq[2][0]);
        m[2][1] = 2 * (qq[1][0] + qq[3][2]);
        m[2][2] = qq[0][0] - qq[1][1] - qq[2][2] + qq[3][3];
    }
    calculateDynamics(q, der, omega, qd) {
        let norm = 1 / Math.sqrt(q[0] * q[0] + q[1] * q[1] + q[2] * q[2] + q[3] * q[3]);
        for (let i = 0; i < 4; i++) {
            q[i] *= norm;
            der[i] *= norm;
        }
        for (let i = 0; i < 4; i++) {
            for (let j = 0; j < 4; j++) {
                qd[i][j] = q[i] * der[j];
            }
        }
        omega[0] = 2 * (-qd[2][3] + qd[3][2] + qd[0][1] - qd[1][0]);
        omega[1] = 2 * (-qd[3][1] + qd[1][3] + qd[0][2] - qd[2][0]);
        omega[2] = 2 * (-qd[1][2] + qd[2][1] + qd[0][3] - qd[3][0]);
    }
    calculateDynamicsLong(q, der, m, omega, qq, qd) {
        this.calculateDynamics(q, der, omega, qd);
        for (let i = 0; i < 4; i++) {
            for (let j = 0; j <= i; j++) {
                qq[i][j] = q[i] * q[j];
            }
        }
        m[0][0] = qq[0][0] + qq[1][1] - qq[2][2] - qq[3][3];
        m[0][1] = 2 * (qq[2][1] - qq[3][0]);
        m[0][2] = 2 * (qq[2][0] + qq[3][1]);
        m[1][0] = 2 * (qq[3][0] + qq[2][1]);
        m[1][1] = qq[0][0] - qq[1][1] + qq[2][2] - qq[3][3];
        m[1][2] = 2 * (qq[3][2] - qq[1][0]);
        m[2][0] = 2 * (qq[3][1] - qq[2][0]);
        m[2][1] = 2 * (qq[1][0] + qq[3][2]);
        m[2][2] = qq[0][0] - qq[1][1] - qq[2][2] + qq[3][3];
    }
    calculateQuaternionDerivation(quaternion, omega, quaternionDerivation, auxQuaternion) {
        auxQuaternion[0] = 0;
        this.collectionProcessor.arrayCopy(omega, 0, auxQuaternion, 1, 3);
        this.quaternionMultiply(quaternion, auxQuaternion, quaternionDerivation);
        for (let i = 0; i < 4; i++) {
            quaternionDerivation[i] *= 0.5;
        }
    }
}
exports.Vector3DProcessor = Vector3DProcessor;
//# sourceMappingURL=Vector3DProcessor.js.map