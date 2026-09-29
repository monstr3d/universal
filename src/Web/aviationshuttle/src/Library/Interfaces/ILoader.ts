import type { IObject } from "./IObject";

export interface ILoader
{
    loadObject(parent: IObject, child: IObject): void
}