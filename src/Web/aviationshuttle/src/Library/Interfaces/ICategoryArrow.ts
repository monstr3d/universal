/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { ICategoryObject } from "./ICategoryObject";
import type { IDesktop } from "./IDesktop";

export interface ICategoryArrow
{
    getSource(): ICategoryObject; 

    getTarget(): ICategoryObject;

    setSource(source: ICategoryObject): void;

    setTarget(target: ICategoryObject): void;

    getArrowName(): string;

    getDesktop(): IDesktop;

}