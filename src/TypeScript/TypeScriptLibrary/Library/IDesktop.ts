import { ICategoryArrow } from "./ICategoryArrow";
import { ICategoryObject } from "./ICategoryObject";
import { Check } from "./Types/Check";

export interface IDesktop
{
    getObjects(): ICategoryObject[];

    getArrows(): ICategoryArrow[];

    addObject(obj: ICategoryObject): void;

    addArrow(arr: ICategoryArrow): void;

    getName(): string;

    getCheck(): Check;

    setCheck(check: Check): void;

}

