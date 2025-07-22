import { IDesktop } from "./IDesktop";

export interface ICategoryObject 
{
    getObject(): Object;
    setObject(obj: Object): void;
    getName(): string;

    getDesktop(): IDesktop;

}