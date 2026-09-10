import type { IScene } from "../Game/Interfaces/IScene";
import type { IFactory } from "../Interfaces/IFactory";
import { GamePerformer } from "./GamePerformer";
export declare class ScenePerformer extends GamePerformer {
    scene: IScene;
    factory: IFactory;
    constructor(scene: IScene);
    createSceneAction(): void;
}
//# sourceMappingURL=ScenePerformer.d.ts.map