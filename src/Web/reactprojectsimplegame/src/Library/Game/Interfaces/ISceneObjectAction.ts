import type { IAction } from "../../Interfaces/IAction";
import type { IObject } from "../../Interfaces/IObject";
import type { ISceneObject } from "./ISceneObject";

export interface ISceneObjectAction extends IAction {
    getActionSceneObject(): ISceneObject
    getActionSceneAdditionalObject(): IObject | undefined
}