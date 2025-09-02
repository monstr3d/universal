import { IDesktop } from "./IDesktop";

export interface ICategoryObject 
{
    getObject(): Object;

    setObject(obj: Object): void;

    getCategoryObjectName(): string;

    getDesktop(): IDesktop;

}