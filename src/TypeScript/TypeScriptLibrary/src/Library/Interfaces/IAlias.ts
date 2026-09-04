/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
export interface IAlias
{
    getAliasNames() : string[];


    getAliasType(name: string): any;

    getAliasValue(name: string): any;

    setAliasValue(name: string, value: any): void;

}