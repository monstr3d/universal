"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.Vector3Double = void 0;
const RealMatrix_1 = require("../RealMatrixProcessor/RealMatrix");
class Vector3Double {
    constructor(x) {
        this.copyFromArray(x, 0);
    }
    realMatrix = new RealMatrix_1.RealMatrix();
    x = [0, 0, 0];
    copyFromArray(array, offset) {
        for (let i = 0; i < 3; i++) {
            this.x[i] = array[i + offset];
        }
    }
    copyFrom(vector) {
        this.copyFromArray(vector.x, 0);
    }
    getNorm() {
        return this.realMatrix.getNorm(this.x);
    }
}
exports.Vector3Double = Vector3Double;
