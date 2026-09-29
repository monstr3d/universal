import type { ICategoryObject } from "./ICategoryObject";

export interface IAddRemove
{
    addRemoveObject(object: ICategoryObject, add: boolean): boolean
    getAddRemoveObjects(): ICategoryObject[]
}