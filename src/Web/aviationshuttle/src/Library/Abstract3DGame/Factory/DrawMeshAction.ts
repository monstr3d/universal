import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import type { IAction } from "../../Interfaces/IAction";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import { EmptyGame3DObject } from "../EmptyGame3DObject";

export class DrawMeshAction extends EmptyGame3DObject implements IAction {
    constructor(camera: BasicCamera, mesh: IMesh, frame: ReferenceFrame)
    {
        super("")
        this.types.push("IAction")
        this.types.push("DrawMeshAction")
        this.camera = camera
        this.mesh = mesh
        this.frame = frame
        this.near = camera.getNearDistance()
        this.far = camera.getFarDistance()
        this.field = camera.getFieldOfView()
        this.performer.createMirrorArray2(this.vertices, mesh.getVertices(), 0)
        this.performer.createMirrorArray2(this.textutes, mesh.getTextures(), 0)
        this.performer.createMirrorArray2(this.normals, mesh.getNormals(), 0)

    }
    action(): void {
        let v = this.mesh.getVertices()
        this.performer.setInvertedCoorfinates2(this.vertices, v, this.frame)
    }

    isEmptyAction(): boolean {
        return false
    }

    protected camera !: BasicCamera
    protected mesh!: IMesh
    protected frame!: ReferenceFrame

    protected vertices: number[][] = []

    protected normals: number[][] = []

    protected textutes: number[][] = []

    protected near: number = 0

    protected far: number = 0

    protected field: number = 0

}