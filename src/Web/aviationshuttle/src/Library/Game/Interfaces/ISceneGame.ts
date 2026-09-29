import { IGame } from "./IGame";
import type { IChildrenT } from "../../NamedTree/Interfaces/IChildrenT"
import type { IScene } from "./IScene"
import { IObjectCollection } from "../../Interfaces/IObjectCollection";

export interface ISceneGame extends IGame, IChildrenT<IScene>, IObjectCollection
{
    getScenes(): Map<string, IScene>

    addScene(name: string, scene: IScene): void



}