import { IObject } from "./IObject";

export interface IAssociatedObject
{
    getAssociatedObject(): IObject;
    setAssociatedObject(obj: IObject): void;
}