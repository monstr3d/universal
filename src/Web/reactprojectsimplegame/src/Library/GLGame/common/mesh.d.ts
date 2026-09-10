import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
export interface VertexDescriptor {
    attributeLocation: number;
    buffer: string;
    size: number;
    type: number;
    normalized: boolean;
    stride: number;
    offset: number;
}
export default class Mesh {
    gl: WebGL2RenderingContext;
    descriptors: VertexDescriptor[];
    VBOs: {
        [name: string]: WebGLBuffer;
    } | undefined;
    EBO: WebGLBuffer;
    VAO: WebGLVertexArrayObject;
    elementCount: number;
    elementType: number;
    mesh: IMesh;
    meshes: Mesh[];
    constructor(gl: WebGL2RenderingContext, descriptors: VertexDescriptor[]);
    dispose(): void;
    getChildren(): Mesh[];
    setBufferData(bufferName: string, bufferData: number | Int8Array | Int16Array | Int32Array | Uint8Array | Uint16Array | Uint32Array | Uint8ClampedArray | Float32Array | Float64Array | DataView | ArrayBuffer, usage: number): void;
    setElementsData(bufferData: Uint8Array | Uint16Array | Uint32Array | Uint8ClampedArray, usage: number): void;
    draw(mode?: number): void;
}
//# sourceMappingURL=mesh.d.ts.map