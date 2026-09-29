/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
export interface ITypeValue<T>
{
    getTypeValue(): T;
    setTypeValue(t: T): void;

}