import type { IScene } from "../../Game/Interfaces/IScene";
import type { IObject } from "../../Interfaces/IObject";
import { Performer } from "../../Performer";
export declare class SceneHolder implements IObject {
    protected performer: Performer;
    constructor(scene: any);
    getName(): string;
    getClassName(): string;
    imlplementsType(type: string): boolean;
    protected typeName: string;
    protected types: string[];
    protected name: string;
    protected scene: IScene;
}
//# sourceMappingURL=SceneHolder.d.ts.map