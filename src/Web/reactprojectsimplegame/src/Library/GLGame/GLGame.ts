import type { IFactory } from "../Interfaces/IFactory";
import type { IPlayEngine } from "../Interfaces/IPlayEngine";
import type { IMesh } from "../Abstract3DConverters/Interfaces/IMesh";
import type { GameOptions } from "./interfaces/IGameOptions";
import type { IGameActionConverter } from "../Game/Interfaces/IGameActionConverter";
import type { IGameActionConverterFactory } from "../Game/Interfaces/IGameActionConverterFactory";
import { DrawMeshAction } from "../Abstract3DGame/Factory/DrawMeshAction";
import { ReferenceFrame } from "../Motion6D/ReferenceFrame";
import { BasicCamera } from "../Motion6D/Visible/BasicCamera";
import { DrawMeshGameCameraAcionConverter } from "../Abstract3DGame/Objects/DrawMeshGameCameraAcionConverter";
import { DrawMesh } from "../Abstract3DGame/Factory/DrawMesh";
import  Mesh from "./common/mesh";
import { GLCamera } from "./GLCamera";
import { EngineGame } from "../Game/Abstract/EngineGame";
import { IGame } from "../Game/Interfaces/IGame";

export class GLGame extends EngineGame implements IGameActionConverterFactory {

    constructor(name: string, factory: IFactory, engine: IPlayEngine, useLoader: boolean,
        canvas: HTMLCanvasElement, options: GameOptions) {
        super(name, factory, engine, useLoader)
        this.types.push("IGLContext")
        this.types.push("IGameActionConverterFactory")
        this.types.push("GLGame")
        this.typeName = "GLGame"
        this.canvas = canvas
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
            this.gl = gl
        }
        this.options = options
        factory.removeFactory<IGameActionConverterFactory>(this, "IGameActionConverterFactory")
    }
    getGameActionConverter(object: any): IGameActionConverter | undefined {
        return undefined
    }

    cycle(time: number): void {
        if (!this.isStarted) return
        this.gl.clear(this.gl.COLOR_BUFFER_BIT | this.gl.DEPTH_BUFFER_BIT)
        super.cycle(time)
    }

 
    protected getGameActionConverterCamera(camera: BasicCamera): IGameActionConverter {
        let cam = new GLCamera(camera.getFieldOfView(),
            camera.getNearDistance(), camera.getFarDistance(), camera.getCameraType())
        return new GLDrawMeshGameCameraAcionConverter(camera, this.gl, cam)
    }

    
 
    canvas !: HTMLCanvasElement

    gl !: WebGL2RenderingContext

    nextSceneReady: boolean = false; // Whether the files requested by the next scene has been loaded or not 
    lastTick: number = 0; // The time of the last frame in milliseconds (used to calculate delta time)
    options !: GameOptions;

}


class GLDrawMesh extends DrawMesh {
    gl !: WebGL2RenderingContext
    glCamera !: GLCamera
    constructor(camera: BasicCamera, glCamera : GLCamera, gl: WebGL2RenderingContext) {
        super(camera)
        this.gl = gl
        this.glCamera = glCamera
    }

    protected createAction(camera: BasicCamera, mesh: IMesh, frame: ReferenceFrame): DrawMeshAction {
        return new GLDrawMeshAction(camera, mesh, frame, this.gl, this.glCamera)
    }



}

function createEmptyMesh(gl: WebGL2RenderingContext): Mesh {
    return new Mesh(gl, [
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
class GLDrawMeshAction extends DrawMeshAction {
    gl!: WebGL2RenderingContext;
    glCamera !: GLCamera

    meshGL!: Mesh;
    constructor(camera: BasicCamera, mesh: IMesh, frame: ReferenceFrame,
        gl: WebGL2RenderingContext, glCamera : GLCamera
) {
        super(camera, mesh, frame);
        this.gl = gl;
        this.glCamera = glCamera
        this.meshGL = this.loadOBJMeshFromMesh(gl, mesh);
    }
    action(): void {
        let v = this.mesh.getVertices();
        this.performer.setInvertedCoorfinates2(this.vertices, v, this.frame);
    }



    loadOBJMeshFromMesh(gl: WebGL2RenderingContext, obj: IMesh): Mesh{
        let mesh = createEmptyMesh(gl);
        let v = this.toOneDimensdional(obj.getVertices())
        let t = this.toOneDimensdional(obj.getTextures())
        let n = this.toOneDimensdional(obj.getNormals())
        mesh.setBufferData("positions", new Float32Array(v), gl.STATIC_DRAW);
        mesh.setBufferData("texcoords", new Float32Array(t), gl.STATIC_DRAW);
        mesh.setBufferData("normals", new Float32Array(n), gl.STATIC_DRAW);
        let colors = new Uint8Array(v.length * 4 / 3);
        colors.fill(255);
        let ind: number[] = [];
        mesh.setBufferData("colors", colors, gl.STATIC_DRAW);
        mesh.setElementsData(new Uint32Array(ind), gl.STATIC_DRAW);
        return mesh;

    }
    toOneDimensdional<T>(t: T[][]): T[] {
        return this.performer.toOneDimensdional(t)
    }
}


class GLDrawMeshGameCameraAcionConverter extends DrawMeshGameCameraAcionConverter {
    glCamera !: GLCamera

    gl !: WebGL2RenderingContext
    constructor(camera: BasicCamera, gl: WebGL2RenderingContext, glCamera : GLCamera) {
        super(camera)
        this.gl = gl
        this.glCamera = glCamera
    }

    protected createDraw(camera: BasicCamera): DrawMesh {
        return new GLDrawMesh(camera,  this.glCamera, this.gl)
    } 


}

