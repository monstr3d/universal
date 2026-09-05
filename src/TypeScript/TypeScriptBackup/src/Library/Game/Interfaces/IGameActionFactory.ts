import type { IGameAction } from "./IGameAction";

export interface IGameActionFactory {
    getGameAction(object: any): IGameAction | undefined
}