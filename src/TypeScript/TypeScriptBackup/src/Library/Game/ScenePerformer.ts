import type { IScene } from "../Game/Interfaces/IScene";
import type { ISceneObject } from "../Game/Interfaces/ISceneObject";
import type { IFactory } from "../Interfaces/IFactory";
import { GamePerformer } from "./GamePerformer";
import { SceneObjectAction } from "./SceneObjectAction.";

export class ScenePerformer extends GamePerformer {
    scene!: IScene;
    factory!: IFactory;

    constructor(scene: IScene) {
        super();
        this.scene = scene;
        this.factory = scene.getConsumerFactory();
    }

    public createSceneAction(): void {
        var s = this.scene;
        var act = new SceneObjectAction(s);
        this.forEach<ISceneObject>(s, act, "ISceneObject");
    }
}
