import type { IScene } from "../../Game/Interfaces/IScene";
import type { ILoader } from "../../Interfaces/ILoader";
import type { IObject } from "../../Interfaces/IObject";
import { Performer } from "../../Performer";
export declare class BasicGameLoader extends Performer implements ILoader {
    scene: IScene;
    object: IObject;
    loadObject(parent: IObject, child: IObject): void;
}
//# sourceMappingURL=BasicGameLoader.d.ts.map