import type { ISceneObjectAction } from "./ISceneObjectAction";

export interface ISceneObjectActionHolder {
    getSceneObjectAction() : ISceneObjectAction
}