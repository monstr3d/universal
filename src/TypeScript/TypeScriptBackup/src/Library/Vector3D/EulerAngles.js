"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.EulerAngles = void 0;
class EulerAngles {
    constructor(roll, pitch, yaw) {
        this.roll = 0;
        this.pitch = 0;
        this.yaw = 0;
        this.roll = roll;
        this.pitch = pitch;
        this.yaw = yaw;
    }
    getRoll() {
        return this.roll;
    }
    getPitch() {
        return this.pitch;
    }
    getYaw() {
        return this.yaw;
    }
    setRoll(roll) {
        this.roll = roll;
    }
    setPitch(pitch) {
        this.pitch = pitch;
    }
    setYaw(yaw) {
        this.yaw = yaw;
    }
}
exports.EulerAngles = EulerAngles;
//# sourceMappingURL=EulerAngles.js.map