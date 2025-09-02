import { ICategoryObject } from "./ICategoryObject";
import { IDesktop } from "./IDesktop";

export interface ICategoryArrow
{
    getSource(): ICategoryObject; 

    getTarget(): ICategoryObject;

    setSource(source: ICategoryObject): void;

    setTarget(target: ICategoryObject): void;

    getArrowName(): string;

    getDesktop(): IDesktop;

}