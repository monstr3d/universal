import { ICategoryArrow } from "./ICategoryArrow";
import { ICategoryObject } from "./ICategoryObject";

export interface IDesktop
{
    getObjects(): ICategoryObject[];

    getArrows(): ICategoryArrow[];

    addObject(obj: ICategoryObject): void;

    addArrow(arr: ICategoryArrow): void;

    getName(): string;

}

