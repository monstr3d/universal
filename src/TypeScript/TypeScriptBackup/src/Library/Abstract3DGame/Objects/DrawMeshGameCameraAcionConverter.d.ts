import { AbstractGameAcionConverter } from "../../Game/GameActions/AbstractGameAcionConverter";
import type { IAction } from "../../Interfaces/IAction";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import { DrawMesh } from "../Factory/DrawMesh";
export declare class DrawMeshGameCameraAcionConverter extends AbstractGameAcionConverter {
    constructor(camera: BasicCamera);
    protected createDraw(camera: BasicCamera): DrawMesh;
    functT(s: IAction): IAction | undefined;
    camera: BasicCamera;
}
//# sourceMappingURL=DrawMeshGameCameraAcionConverter.d.ts.map