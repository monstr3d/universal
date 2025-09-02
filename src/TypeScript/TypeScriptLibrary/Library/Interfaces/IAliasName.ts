import { IAlias } from "./IAlias";

export interface IAliasName
{

    getAliasNameValue(): any;
    setAliasNameValue(value: any): void;
    getAlias(): IAlias;
    getNameOfAliasName(): string;
}
