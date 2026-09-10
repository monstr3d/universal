import type { IMesh } from '../../Abstract3DConverters/Interfaces/IMesh';
import Mesh from './mesh';
export declare function Plane(gl: WebGL2RenderingContext, texCoords?: {
    min: [number, number];
    max: [number, number];
}): Mesh;
export declare function SubdividedPlane(gl: WebGL2RenderingContext, resolution?: number | [number, number], texCoords?: {
    min: [number, number];
    max: [number, number];
}): Mesh;
export declare function WhiteCube(gl: WebGL2RenderingContext): Mesh;
export declare function Cube(gl: WebGL2RenderingContext): Mesh;
export declare function Sphere(gl: WebGL2RenderingContext, resolution?: number | [number, number]): Mesh;
export declare function LoadOBJMesh(gl: WebGL2RenderingContext, data: string): Mesh;
export declare function LoadOBJMeshFromMesh(gl: WebGL2RenderingContext, obj: IMesh): Mesh;
//# sourceMappingURL=mesh-utils.d.ts.map