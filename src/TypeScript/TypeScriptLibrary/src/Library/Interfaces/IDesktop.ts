/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { ICategoryArrow } from "./ICategoryArrow";
import type { ICategoryObject } from "./ICategoryObject";
import type { ICheck } from "./ICheck";
import type { IComponentCollection } from "./IComponentCollection";
import type { IObject } from "./IObject";

export interface IDesktop extends IComponentCollection
{

    addCategoryObject(obj: ICategoryObject): void;

    addCategoryArrow(arr: ICategoryArrow): void;

    addObject(obj: IObject): void;

    getCategoryObject(name: string): ICategoryObject;

    initializeTaksAsync(cancel: AbortController): Promise<void>;

    getCheck(): ICheck;

    setCheck(check: ICheck): void;

    finish(): void

}
