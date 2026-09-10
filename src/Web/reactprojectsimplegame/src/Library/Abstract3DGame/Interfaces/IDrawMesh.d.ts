import type { IMesh } from "../../Abstract3DConverters/Interfaces/IMesh";
import type { IAction } from "../../Interfaces/IAction";
import { ReferenceFrame } from "../../Motion6D/ReferenceFrame";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
export interface IDrawMesh {
    drawMesh(mehshes: IMesh, frame: ReferenceFrame, camera: BasicCamera): IAction;
}
//# sourceMappingURL=IDrawMesh.d.ts.map