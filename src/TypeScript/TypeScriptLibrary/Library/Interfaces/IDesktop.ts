/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { ICategoryArrow } from "./ICategoryArrow";
import type { ICategoryObject } from "./ICategoryObject";
import type { ICheck } from "./ICheck";
import type { IObject } from "./IObject";

export interface IDesktop
{
    getCategoryObjects(): ICategoryObject[];

    getCategoryArrows(): ICategoryArrow[];

    addCategoryObject(obj: ICategoryObject): void;

    addCategoryArrow(arr: ICategoryArrow): void;

    addObject(obj: IObject): void;

    getObjects(): IObject[];


    getCheck(): ICheck;

    setCheck(check: ICheck): void;

    getCategoryObject(name: string): ICategoryObject;

}
