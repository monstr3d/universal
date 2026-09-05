import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import type { IAction } from "../../Interfaces/IAction";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import { EmptyGame3DObject } from "../EmptyGame3DObject";
export declare class DrawMeshAction extends EmptyGame3DObject implements IAction {
    constructor(camera: BasicCamera, mesh: IMesh, frame: ReferenceFrame);
    action(): void;
    isEmptyAction(): boolean;
    protected camera: BasicCamera;
    protected mesh: IMesh;
    protected frame: ReferenceFrame;
    protected vertices: number[][];
    protected normals: number[][];
    protected textutes: number[][];
    protected near: number;
    protected far: number;
    protected field: number;
}
//# sourceMappingURL=DrawMeshAction.d.ts.map