import type { ISceneObject } from "../../Game/Interfaces/ISceneObject";
import type { ISceneObjectAction } from "../../Game/Interfaces/ISceneObjectAction";
import type { IFactory } from "../../Interfaces/IFactory";
import type { IObject } from "../../Interfaces/IObject";
import { AbstractGameObject } from "../Abstract/AbstractGameObject";
export declare abstract class AbstractSceneGameAction extends AbstractGameObject implements ISceneObjectAction {
    object: ISceneObject;
    add: IObject;
    constructor(object: ISceneObject, factory: IFactory | undefined);
    getActionSceneObject(): ISceneObject;
    abstract getActionSceneAdditionalObject(): IObject | undefined;
    abstract action(): void;
    isEmptyAction(): boolean;
}
//# sourceMappingURL=AbstractSceneGameAction.d.ts.map