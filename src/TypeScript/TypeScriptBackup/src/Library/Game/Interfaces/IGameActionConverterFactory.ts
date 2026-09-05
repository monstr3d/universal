import type { IGameActionConverter } from "./IGameActionConverter";

export interface IGameActionConverterFactory {
    getGameActionConverter(object: any): IGameActionConverter | undefined
}