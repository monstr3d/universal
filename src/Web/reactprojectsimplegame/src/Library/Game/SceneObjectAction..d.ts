import type { IGameAction } from "../Game/Interfaces/IGameAction";
import type { IScene } from "../Game/Interfaces/IScene";
import type { ISceneObject } from "../Game/Interfaces/ISceneObject";
import type { IActionAddRemove } from "../Interfaces/IActionAddRemove";
import type { IActionT } from "../Interfaces/IActionT";
import type { IGameActionConverter } from "./Interfaces/IGameActionConverter";
import { GamePerformer } from "./GamePerformer";
export declare class SceneObjectAction implements IActionT<ISceneObject> {
    performer: GamePerformer;
    conv: IGameActionConverter;
    current: IActionT<ISceneObject>;
    actionT(t: ISceneObject): void;
    constructor(scene: IScene);
    isEmptyActionT(): boolean;
    gameAcion: IGameAction;
    scene: IScene;
    action: IActionAddRemove;
}
//# sourceMappingURL=SceneObjectAction..d.ts.map