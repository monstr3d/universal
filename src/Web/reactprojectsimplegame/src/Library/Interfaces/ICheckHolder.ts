import type { ICheck } from "./ICheck";

export interface ICheckHolder
{
    getCheck(): ICheck;
    setCheck(check: ICheck): void;
}