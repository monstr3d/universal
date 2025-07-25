import { Check } from "../Types/Check";
import { ICategoryArrow } from "./ICategoryArrow";
import { ICategoryObject } from "./ICategoryObject";
import { IObject } from "./IObject";

export interface IDesktop
{
    getCategoryObjects(): ICategoryObject[];

    getCategoryArrows(): ICategoryArrow[];

    addCategoryObject(obj: ICategoryObject): void;

    addCategoryArrow(arr: ICategoryArrow): void;

    addObject(obj: IObject): void;

    getObjects(): IObject[];

    getCheck(): Check;

    setCheck(check: Check): void;

}
