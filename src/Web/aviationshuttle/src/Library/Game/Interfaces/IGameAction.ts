import type { IAction } from "../../Interfaces/IAction";
import type { IFuncT } from "../../Interfaces/IFuncT";
import type { ISceneObject } from "./ISceneObject";

export interface IGameAction extends IFuncT<IAction | undefined, ISceneObject>
{

}