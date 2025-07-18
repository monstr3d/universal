import { IAliasBase } from "./IAliasBase";

export interface IAliasName
{

    getAliasNameValue(): any;
    setAliasNameValue(value: any): void;
    getAliasBase(): IAliasBase;
    getNameOfAliasName(): string;
}
