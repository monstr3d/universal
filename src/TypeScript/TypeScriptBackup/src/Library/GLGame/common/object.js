"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const gl_matrix_1 = require("gl-matrix");
class Object3D {
    constructor() {
        //Move Controllers
        this.type = 'perspective';
        this.position = gl_matrix_1.vec3.fromValues(0, 0, 0);
        this.direction = gl_matrix_1.vec3.fromValues(0, 0, 1);
        this.up = gl_matrix_1.vec3.fromValues(0, 1, 0);
        this.perspectiveFoVy = Math.PI / 2;
        this.orthographicHeight = 10;
        this.aspectRatio = 1;
        this.near = 0.01;
        this.far = 1000;
    }
}
exports.default = Object3D;
//# sourceMappingURL=object.js.map