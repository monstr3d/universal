"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.GLCamera = void 0;
const gl_matrix_1 = require("gl-matrix");
class GLCamera {
    constructor(fieldOfView, near, far, type) {
        this.type = 'perspective';
        this.position = gl_matrix_1.vec3.fromValues(0, 0, 0);
        this.direction = gl_matrix_1.vec3.fromValues(0, 0, 1);
        this.up = gl_matrix_1.vec3.fromValues(0, 1, 0);
        this.perspectiveFoVy = Math.PI / 2;
        this.orthographicHeight = 10;
        this.aspectRatio = 1;
        this.near = 0.01;
        this.far = 1000;
        this.perspectiveFoVy = Math.PI * (fieldOfView / 180);
        this.near = near;
        this.far = far;
        this.type = type;
    }
    set ViewMatrix(m) {
        this.mm = m;
    }
    get ViewMatrix() { return gl_matrix_1.mat4.lookAt(gl_matrix_1.mat4.create(), this.position, gl_matrix_1.vec3.add(gl_matrix_1.vec3.create(), this.position, this.direction), this.up); }
    get ProjectionMatrix() {
        if (this.type === 'orthographic') {
            const halfH = this.orthographicHeight / 2;
            const halfW = halfH * this.aspectRatio;
            return gl_matrix_1.mat4.ortho(gl_matrix_1.mat4.create(), -halfW, halfW, -halfH, halfH, this.near, this.far);
        }
        else {
            return gl_matrix_1.mat4.perspective(gl_matrix_1.mat4.create(), this.perspectiveFoVy, this.aspectRatio, this.near, this.far);
        }
    }
    get ViewProjectionMatrix() {
        const V = this.ViewMatrix, P = this.ProjectionMatrix;
        return gl_matrix_1.mat4.mul(P, P, V);
    }
    setTarget(value) {
        gl_matrix_1.vec3.sub(this.direction, value, this.position);
    }
    get right() {
        const up = gl_matrix_1.vec3.normalize(gl_matrix_1.vec3.create(), this.up);
        return gl_matrix_1.vec3.cross(up, this.direction, up);
    }
}
exports.GLCamera = GLCamera;
//# sourceMappingURL=GLCamera.js.map