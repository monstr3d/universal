"use strict";
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
exports.GLGame = void 0;
const DrawMeshAction_1 = require("../Abstract3DGame/Factory/DrawMeshAction");
const DrawMeshGameCameraAcionConverter_1 = require("../Abstract3DGame/Objects/DrawMeshGameCameraAcionConverter");
const DrawMesh_1 = require("../Abstract3DGame/Factory/DrawMesh");
const mesh_1 = __importDefault(require("./common/mesh"));
const GLCamera_1 = require("./GLCamera");
const EngineGame_1 = require("../Game/Abstract/EngineGame");
class GLGame extends EngineGame_1.EngineGame {
    constructor(name, factory, engine, useLoader, canvas, options) {
        super(name, factory, engine, useLoader);
        this.nextSceneReady = false; // Whether the files requested by the next scene has been loaded or not 
        this.lastTick = 0; // The time of the last frame in milliseconds (used to calculate delta time)
        this.types.push("IGLContext");
        this.types.push("IGameActionConverterFactory");
        this.types.push("GLGame");
        this.typeName = "GLGame";
        this.canvas = canvas;
        var gl = this.canvas.getContext("webgl2", {
            preserveDrawingBuffer: true, // This will prevent the Browser from automatically clearing the frame buffer every frame
            alpha: true, // this will tell the browser that we want an alpha component in our frame buffer
            antialias: true, // this will tell the browser that we want antialiasing
            depth: true, // this will tell the browser that we want a depth buffer
            powerPreference: "high-performance",
            premultipliedAlpha: false, // This can be used if the canvas are going to be blended with the rest of the webpage (transparency)
            stencil: true // this will tell the browser that we want a stencil buffer
        }); // This command loads the WebGL2 context which we will use to draw
        if (gl != undefined) {
            this.gl = gl;
        }
        this.options = options;
        factory.removeFactory(this, "IGameActionConverterFactory");
    }
    getGameActionConverter(object) {
        return undefined;
    }
    cycle(time) {
        if (!this.isStarted)
            return;
        this.gl.clear(this.gl.COLOR_BUFFER_BIT | this.gl.DEPTH_BUFFER_BIT);
        super.cycle(time);
    }
    getGameActionConverterCamera(camera) {
        let cam = new GLCamera_1.GLCamera(camera.getFieldOfView(), camera.getNearDistance(), camera.getFarDistance(), camera.getCameraType());
        return new GLDrawMeshGameCameraAcionConverter(camera, this.gl, cam);
    }
}
exports.GLGame = GLGame;
class GLDrawMesh extends DrawMesh_1.DrawMesh {
    constructor(camera, glCamera, gl) {
        super(camera);
        this.gl = gl;
        this.glCamera = glCamera;
    }
    createAction(camera, mesh, frame) {
        return new GLDrawMeshAction(camera, mesh, frame, this.gl, this.glCamera);
    }
}
function createEmptyMesh(gl) {
    return new mesh_1.default(gl, [
        { attributeLocation: 0, buffer: "positions", size: 3, type: gl.FLOAT, normalized: false, stride: 0, offset: 0 },
        { attributeLocation: 1, buffer: "colors", size: 4, type: gl.UNSIGNED_BYTE, normalized: true, stride: 0, offset: 0 },
        { attributeLocation: 2, buffer: "texcoords", size: 2, type: gl.FLOAT, normalized: false, stride: 0, offset: 0 },
        { attributeLocation: 3, buffer: "normals", size: 3, type: gl.FLOAT, normalized: false, stride: 0, offset: 0 }
    ]);
}
/*
   glCamera !: GLCamera
    constructor(camera: BasicCamera, glCamera : GLCamera, gl: WebGL2RenderingContext) {
        super(camera)
        this.gl = gl
        this.glCamera = glCamera
    }
*/
class GLDrawMeshAction extends DrawMeshAction_1.DrawMeshAction {
    constructor(camera, mesh, frame, gl, glCamera) {
        super(camera, mesh, frame);
        this.gl = gl;
        this.glCamera = glCamera;
        this.meshGL = this.loadOBJMeshFromMesh(gl, mesh);
    }
    action() {
        let v = this.mesh.getVertices();
        this.performer.setInvertedCoorfinates2(this.vertices, v, this.frame);
    }
    loadOBJMeshFromMesh(gl, obj) {
        let mesh = createEmptyMesh(gl);
        let v = this.toOneDimensdional(obj.getVertices());
        let t = this.toOneDimensdional(obj.getTextures());
        let n = this.toOneDimensdional(obj.getNormals());
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
    toOneDimensdional(t) {
        return this.performer.toOneDimensdional(t);
    }
}
class GLDrawMeshGameCameraAcionConverter extends DrawMeshGameCameraAcionConverter_1.DrawMeshGameCameraAcionConverter {
    constructor(camera, gl, glCamera) {
        super(camera);
        this.gl = gl;
        this.glCamera = glCamera;
    }
    createDraw(camera) {
        return new GLDrawMesh(camera, this.glCamera, this.gl);
    }
}
//# sourceMappingURL=GLGame.js.map