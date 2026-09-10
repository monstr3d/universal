import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import { EmptyObject } from "../../EmptyObject";
import type { IAction } from "../../Interfaces/IAction";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import type { IDrawMesh } from "../Interfaces/IDrawMesh";
import { DrawMeshAction } from "./DrawMeshAction";
export declare class DrawMesh extends EmptyObject implements IDrawMesh {
    constructor(camera: BasicCamera);
    protected createAction(camera: BasicCamera, mesh: IMesh, frame: ReferenceFrame): DrawMeshAction;
    drawMeshRecursively(mesh: IMesh, frame: ReferenceFrame): IAction | undefined;
    drawMesh(mesh: IMesh, frame: ReferenceFrame): IAction;
    camera: BasicCamera;
}
//# sourceMappingURL=DrawMesh.d.ts.map