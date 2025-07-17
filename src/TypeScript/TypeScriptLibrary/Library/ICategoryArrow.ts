import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";

export interface ICategoryArrow
{
    getSource(): ICategoryObject; 

    getTagret(): ICategoryObject;

    setSource(source: ICategoryObject): void;

    setTarget(target: ICategoryObject): void;

    getName(): string;

    getDesktop(): IDesktop;

}