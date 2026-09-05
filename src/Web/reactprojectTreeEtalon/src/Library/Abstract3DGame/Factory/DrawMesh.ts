import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import { EmptyObject } from "../../EmptyObject";
import type { IAction } from "../../Interfaces/IAction";
import type { IFuncT } from "../../Interfaces/IFuncT";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import type { IDrawMesh } from "../Interfaces/IDrawMesh";
import { DrawMeshAction } from "./DrawMeshAction";

export  class DrawMesh extends EmptyObject implements IDrawMesh {
    constructor(camera: BasicCamera) {
        super("")
        this.typeName = "AbstractDrawMesh"
        this.types.push("IDrawMesh")
        this.types.push("AbstractDrawMesh")
        this.camera = camera
    }

    protected createAction(camera: BasicCamera, mesh: IMesh, frame: ReferenceFrame): DrawMeshAction {
        return new DrawMeshAction(camera, mesh, frame)
    }

    public drawMeshRecursively(mesh: IMesh, frame: ReferenceFrame): IAction | undefined {
        var int = new InternlalAction(this, frame);
        return this.performer.getActionFromNode(mesh, int)
    }

    public drawMesh(mesh: IMesh, frame: ReferenceFrame): IAction {
        return this.createAction(this.camera, mesh, frame)
    }

    camera!: BasicCamera
}

class InternlalAction implements IFuncT<IAction, IMesh>
{
    constructor(abs: DrawMesh, frame: ReferenceFrame) {
        this.abs = abs
        this.frame = frame;
    }
    functT(s: IMesh): IAction | undefined {
        return this.abs.drawMesh(s, this.frame)
    }

    abs !: DrawMesh
    frame !: ReferenceFrame
}

