"use strict";
var __createBinding = (this && this.__createBinding) || (Object.create ? (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    var desc = Object.getOwnPropertyDescriptor(m, k);
    if (!desc || ("get" in desc ? !m.__esModule : desc.writable || desc.configurable)) {
      desc = { enumerable: true, get: function() { return m[k]; } };
    }
    Object.defineProperty(o, k2, desc);
}) : (function(o, m, k, k2) {
    if (k2 === undefined) k2 = k;
    o[k2] = m[k];
}));
var __setModuleDefault = (this && this.__setModuleDefault) || (Object.create ? (function(o, v) {
    Object.defineProperty(o, "default", { enumerable: true, value: v });
}) : function(o, v) {
    o["default"] = v;
});
var __importStar = (this && this.__importStar) || (function () {
    var ownKeys = function(o) {
        ownKeys = Object.getOwnPropertyNames || function (o) {
            var ar = [];
            for (var k in o) if (Object.prototype.hasOwnProperty.call(o, k)) ar[ar.length] = k;
            return ar;
        };
        return ownKeys(o);
    };
    return function (mod) {
        if (mod && mod.__esModule) return mod;
        var result = {};
        if (mod != null) for (var k = ownKeys(mod), i = 0; i < k.length; i++) if (k[i] !== "default") __createBinding(result, mod, k[i]);
        __setModuleDefault(result, mod);
        return result;
    };
})();
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.Plane = Plane;
exports.SubdividedPlane = SubdividedPlane;
exports.WhiteCube = WhiteCube;
exports.Cube = Cube;
exports.Sphere = Sphere;
exports.LoadOBJMesh = LoadOBJMesh;
exports.LoadOBJMeshFromMesh = LoadOBJMeshFromMesh;
const Performer_1 = require("../../Performer");
const mesh_1 = __importDefault(require("./mesh"));
const OBJ = __importStar(require("webgl-obj-loader"));
// This file contain some helper classes to create simple meshes
//const BLACK = [0, 0, 0, 255];
//const RED = [255, 0, 0, 255];
//const GREEN = [0, 255, 0, 255];
//const BLUE = [0, 0, 255, 255];
//const YELLOW = [255, 255, 0, 255];
//const MAGENTA = [255, 0, 255, 255];
//const CYAN = [0, 255, 255, 255];
const WHITE = [255, 255, 255, 255];
function createEmptyMesh(gl) {
    return new mesh_1.default(gl, [
        { attributeLocation: 0, buffer: "positions", size: 3, type: gl.FLOAT, normalized: false, stride: 0, offset: 0 },
        { attributeLocation: 1, buffer: "colors", size: 4, type: gl.UNSIGNED_BYTE, normalized: true, stride: 0, offset: 0 },
        { attributeLocation: 2, buffer: "texcoords", size: 2, type: gl.FLOAT, normalized: false, stride: 0, offset: 0 },
        { attributeLocation: 3, buffer: "normals", size: 3, type: gl.FLOAT, normalized: false, stride: 0, offset: 0 }
    ]);
}
function Plane(gl, texCoords = { min: [0, 0], max: [1, 1] }) {
    let mesh = createEmptyMesh(gl);
    mesh.setBufferData("positions", new Float32Array([
        -1.0, 0.0, 1.0,
        1.0, 0.0, 1.0,
        1.0, 0.0, -1.0,
        -1.0, 0.0, -1.0,
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("colors", new Uint8Array([
        ...WHITE, ...WHITE, ...WHITE, ...WHITE
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("texcoords", new Float32Array([
        texCoords.min[0], texCoords.min[1],
        texCoords.max[0], texCoords.min[1],
        texCoords.max[0], texCoords.max[1],
        texCoords.min[0], texCoords.max[1]
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("normals", new Float32Array([
        0, 1, 0,
        0, 1, 0,
        0, 1, 0,
        0, 1, 0
    ]), gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array([
        0, 1, 2,
        2, 3, 0
    ]), gl.STATIC_DRAW);
    return mesh;
}
function SubdividedPlane(gl, resolution = 1, texCoords = { min: [0, 0], max: [1, 1] }) {
    if (typeof resolution === "number")
        resolution = [resolution, resolution];
    resolution = resolution.map((x) => x >= 1 ? x : 1);
    let positions = [], colors = [], texcoords = [], normals = [], indices = [];
    for (let i = 0; i <= resolution[0]; i++) {
        for (let j = 0; j <= resolution[1]; j++) {
            positions.push(2 * i / resolution[0] - 1, 0, 1 - 2 * j / resolution[1]);
            colors.push(...WHITE);
            texcoords.push(i / resolution[0] * (texCoords.max[0] - texCoords.min[0]) + texCoords.min[0], j / resolution[1] * (texCoords.max[1] - texCoords.min[1]) + texCoords.min[1]);
            normals.push(0, 1, 0);
        }
    }
    for (let i = 0; i < resolution[0]; i++) {
        for (let j = 0; j < resolution[1]; j++) {
            let index = j + i * (resolution[1] + 1);
            indices.push(index, index + resolution[1] + 1, index + resolution[1] + 2);
            indices.push(index + resolution[1] + 2, index + 1, index);
        }
    }
    let mesh = createEmptyMesh(gl);
    mesh.setBufferData("positions", new Float32Array(positions), gl.STATIC_DRAW);
    mesh.setBufferData("colors", new Uint8Array(colors), gl.STATIC_DRAW);
    mesh.setBufferData("texcoords", new Float32Array(texcoords), gl.STATIC_DRAW);
    mesh.setBufferData("normals", new Float32Array(normals), gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array(indices), gl.STATIC_DRAW);
    return mesh;
}
function WhiteCube(gl) {
    let mesh = createEmptyMesh(gl);
    mesh.setBufferData("positions", new Float32Array([
        //Upper Face
        -1, 1, -1,
        -1, 1, 1,
        1, 1, 1,
        1, 1, -1,
        //Lower Face
        -1, -1, -1,
        1, -1, -1,
        1, -1, 1,
        -1, -1, 1,
        //Right Face
        1, -1, -1,
        1, 1, -1,
        1, 1, 1,
        1, -1, 1,
        //Left Face
        -1, -1, -1,
        -1, -1, 1,
        -1, 1, 1,
        -1, 1, -1,
        //Front Face
        -1, -1, 1,
        1, -1, 1,
        1, 1, 1,
        -1, 1, 1,
        //Back Face
        -1, -1, -1,
        -1, 1, -1,
        1, 1, -1,
        1, -1, -1
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("colors", new Uint8Array([
        //Upper Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Lower Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Right Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Left Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Front Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Back Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
    ]), gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array([
        //Upper Face
        0, 1, 2, 2, 3, 0,
        //Lower Face
        4, 5, 6, 6, 7, 4,
        //Right Face
        8, 9, 10, 10, 11, 8,
        //Left Face
        12, 13, 14, 14, 15, 12,
        //Front Face
        16, 17, 18, 18, 19, 16,
        //Back Face
        20, 21, 22, 22, 23, 20,
    ]), gl.STATIC_DRAW);
    return mesh;
}
function Cube(gl) {
    let mesh = createEmptyMesh(gl);
    mesh.setBufferData("positions", new Float32Array([
        //Upper Face
        -1, 1, -1,
        -1, 1, 1,
        1, 1, 1,
        1, 1, -1,
        //Lower Face
        -1, -1, -1,
        1, -1, -1,
        1, -1, 1,
        -1, -1, 1,
        //Right Face
        1, -1, -1,
        1, 1, -1,
        1, 1, 1,
        1, -1, 1,
        //Left Face
        -1, -1, -1,
        -1, -1, 1,
        -1, 1, 1,
        -1, 1, -1,
        //Front Face
        -1, -1, 1,
        1, -1, 1,
        1, 1, 1,
        -1, 1, 1,
        //Back Face
        -1, -1, -1,
        -1, 1, -1,
        1, 1, -1,
        1, -1, -1
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("colors", new Uint8Array([
        //Upper Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Lower Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Right Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Left Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Front Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
        //Back Face
        ...WHITE, ...WHITE, ...WHITE, ...WHITE,
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("texcoords", new Float32Array([
        //Upper Face
        0, 1,
        0, 0,
        1, 0,
        1, 1,
        //Lower Face
        0, 0,
        1, 0,
        1, 1,
        0, 1,
        //Right Face
        1, 0,
        1, 1,
        0, 1,
        0, 0,
        //Left Face
        0, 0,
        1, 0,
        1, 1,
        0, 1,
        //Front Face
        0, 0,
        1, 0,
        1, 1,
        0, 1,
        //Back Face
        1, 0,
        1, 1,
        0, 1,
        0, 0
    ]), gl.STATIC_DRAW);
    mesh.setBufferData("normals", new Float32Array([
        //Upper Face
        0, 1, 0,
        0, 1, 0,
        0, 1, 0,
        0, 1, 0,
        //Lower Face
        0, -1, 0,
        0, -1, 0,
        0, -1, 0,
        0, -1, 0,
        //Right Face
        1, 0, 0,
        1, 0, 0,
        1, 0, 0,
        1, 0, 0,
        //Left Face
        -1, 0, 0,
        -1, 0, 0,
        -1, 0, 0,
        -1, 0, 0,
        //Front Face
        0, 0, 1,
        0, 0, 1,
        0, 0, 1,
        0, 0, 1,
        //Back Face
        0, 0, -1,
        0, 0, -1,
        0, 0, -1,
        0, 0, -1
    ]), gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array([
        //Upper Face
        0, 1, 2, 2, 3, 0,
        //Lower Face
        4, 5, 6, 6, 7, 4,
        //Right Face
        8, 9, 10, 10, 11, 8,
        //Left Face
        12, 13, 14, 14, 15, 12,
        //Front Face
        16, 17, 18, 18, 19, 16,
        //Back Face
        20, 21, 22, 22, 23, 20,
    ]), gl.STATIC_DRAW);
    return mesh;
}
function Sphere(gl, resolution = 32) {
    if (typeof resolution === "number")
        resolution = [2 * resolution, resolution];
    resolution = resolution.map((x) => x >= 1 ? x : 1);
    let positions = [], colors = [], texcoords = [], normals = [], indices = [];
    for (let i = 0; i <= resolution[0]; i++) {
        const theta = i / resolution[0] * 2 * Math.PI;
        const cos_theta = Math.cos(theta), sin_theta = Math.sin(theta);
        for (let j = 0; j <= resolution[1]; j++) {
            const phi = (j / resolution[1] - 0.5) * Math.PI;
            const cos_phi = Math.cos(phi), sin_phi = Math.sin(phi);
            const x = cos_theta * cos_phi, y = sin_phi, z = -sin_theta * cos_phi;
            positions.push(x, y, z);
            colors.push(...WHITE);
            texcoords.push(i / resolution[0], j / resolution[1]);
            normals.push(x, y, z);
        }
    }
    for (let i = 0; i < resolution[0]; i++) {
        for (let j = 0; j < resolution[1]; j++) {
            let index = j + i * (resolution[1] + 1);
            indices.push(index, index + resolution[1] + 1, index + resolution[1] + 2);
            indices.push(index + resolution[1] + 2, index + 1, index);
        }
    }
    let mesh = createEmptyMesh(gl);
    mesh.setBufferData("positions", new Float32Array(positions), gl.STATIC_DRAW);
    mesh.setBufferData("colors", new Uint8Array(colors), gl.STATIC_DRAW);
    mesh.setBufferData("texcoords", new Float32Array(texcoords), gl.STATIC_DRAW);
    mesh.setBufferData("normals", new Float32Array(normals), gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array(indices), gl.STATIC_DRAW);
    return mesh;
}
function LoadOBJMesh(gl, data) {
    let obj = new OBJ.Mesh(data);
    let mesh = createEmptyMesh(gl);
    mesh.setBufferData("positions", new Float32Array(obj.vertices), gl.STATIC_DRAW);
    mesh.setBufferData("texcoords", new Float32Array(obj.textures), gl.STATIC_DRAW);
    mesh.setBufferData("normals", new Float32Array(obj.vertexNormals), gl.STATIC_DRAW);
    let colors = new Uint8Array(obj.vertices.length * 4 / 3);
    colors.fill(255);
    mesh.setBufferData("colors", colors, gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array(obj.indices), gl.STATIC_DRAW);
    return mesh;
}
const performer = new Performer_1.Performer();
function toOneDimensdional(t) {
    return performer.toOneDimensdional(t);
}
function LoadOBJMeshFromMesh(gl, obj) {
    let mesh = createEmptyMesh(gl);
    let v = toOneDimensdional(obj.getVertices());
    let t = toOneDimensdional(obj.getTextures());
    let n = toOneDimensdional(obj.getNormals());
    mesh.setBufferData("positions", new Float32Array(v), gl.STATIC_DRAW);
    mesh.setBufferData("texcoords", new Float32Array(t), gl.STATIC_DRAW);
    mesh.setBufferData("normals", new Float32Array(n), gl.STATIC_DRAW);
    let colors = new Uint8Array(v.length * 4 / 3);
    colors.fill(255);
    let ind = [];
    mesh.setBufferData("colors", colors, gl.STATIC_DRAW);
    mesh.setElementsData(new Uint32Array(ind), gl.STATIC_DRAW);
    return mesh;
}
//# sourceMappingURL=mesh-utils.js.map