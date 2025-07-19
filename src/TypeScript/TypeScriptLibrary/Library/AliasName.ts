import { IAlias } from "./IAlias";
import { IAliasBase } from "./IAliasBase";
import { IAliasName } from "./IAliasName";

export class AliasName implements IAliasName
{

    alias !: IAlias;

    name: string = "";

    constructor(alias: IAlias, name: string) {
        this.alias = alias;
        this.name = name;
    }
    getAliasNameValue(): any
    {
        throw new Error("Method not implemented.");
    }


    setAliasNameValue(value: any): void {
    }
    getAliasBase(): IAliasBase {
        return this.alias;
    }
    getNameOfAliasName(): string {
        return this.name;
    }
}