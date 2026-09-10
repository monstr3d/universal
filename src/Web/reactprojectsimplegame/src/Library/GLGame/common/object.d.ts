import Mesh from '../common/mesh';
import { mat4, vec3 } from 'gl-matrix';
export default class Object3D {
    mesh: Mesh;
    texture: WebGLTexture;
    tint: [number, number, number, number];
    currentModelMatrix: mat4;
    previousModelMatrix: mat4;
    type: 'orthographic' | 'perspective';
    position: vec3;
    direction: vec3;
    up: vec3;
    perspectiveFoVy: number;
    orthographicHeight: number;
    aspectRatio: number;
    near: number;
    far: number;
}
//# sourceMappingURL=object.d.ts.map