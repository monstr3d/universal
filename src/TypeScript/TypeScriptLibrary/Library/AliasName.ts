import { IAlias } from "./Interfaces/IAlias";
import { IAliasBase } from "./Interfaces/IAliasBase";
import { IAliasName } from "./Interfaces/IAliasName";

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
        return this.alias.getAliasValue(this.name);
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