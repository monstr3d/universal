import { AbstractGameAcionConverter } from "../../Game/GameActions/AbstractGameAcionConverter";
import type { IAction } from "../../Interfaces/IAction";
import { Game3DPerformer } from "../Game3DPerformer";
import type { IDrawMesh } from "../Interfaces/IDrawMesh";
export declare class DrawMeshActionConverter extends AbstractGameAcionConverter {
    protected game3DPerformer: Game3DPerformer;
    constructor(drawMesh: IDrawMesh);
    functT(s: IAction): IAction | undefined;
    drawMesh: IDrawMesh;
}
//# sourceMappingURL=DrawMeshActionConverter.d.ts.map