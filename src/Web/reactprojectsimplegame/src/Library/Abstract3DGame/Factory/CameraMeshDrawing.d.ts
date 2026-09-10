import { EmptyObject } from "../../EmptyObject";
import type { IGameActionConverter } from "../../Game/Interfaces/IGameActionConverter";
import { BasicCamera } from "../../Motion6D/Visible/BasicCamera";
import type { ICameraMeshDrawing } from "../Interfaces/ICameraMeshDrawing";
export declare class CameraMeshDrawing extends EmptyObject implements ICameraMeshDrawing {
    constructor();
    functT(s: BasicCamera): IGameActionConverter | undefined;
    any: any;
}
//# sourceMappingURL=CameraMeshDrawing.d.ts.map