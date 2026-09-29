
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IObject } from "./IObject";

export interface IAssociatedObject
{
    getAssociatedObject(): IObject;
    setAssociatedObject(obj: IObject): void;
}