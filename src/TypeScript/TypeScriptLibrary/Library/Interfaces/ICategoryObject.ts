/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IDesktop } from "./IDesktop";

export interface ICategoryObject 
{
    getObject(): Object;

    setObject(obj: Object): void;

    getCategoryObjectName(): string;

    getDesktop(): IDesktop;

}