import { vec3, mat4 } from 'gl-matrix';
export declare class GLCamera {
    type: 'orthographic' | 'perspective';
    position: vec3;
    direction: vec3;
    up: vec3;
    perspectiveFoVy: number;
    orthographicHeight: number;
    aspectRatio: number;
    near: number;
    far: number;
    constructor(fieldOfView: number, near: number, far: number, type: 'orthographic' | 'perspective');
    mm: mat4;
    set ViewMatrix(m: mat4);
    get ViewMatrix(): mat4;
    get ProjectionMatrix(): mat4;
    get ViewProjectionMatrix(): mat4;
    setTarget(value: vec3): void;
    get right(): vec3;
}
//# sourceMappingURL=GLCamera.d.ts.map