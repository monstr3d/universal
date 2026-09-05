import type { IFactoryConsumer } from "../../Interfaces/IFactoryConsumer";
import type { IObject } from "../../Interfaces/IObject";
import type { IScene } from "./IScene";

export interface ISceneObject extends IObject, IFactoryConsumer {
    getScene(): IScene
    setScene(scene: IScene): void
}