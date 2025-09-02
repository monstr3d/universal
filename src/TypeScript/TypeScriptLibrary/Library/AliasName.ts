import { FictiveAlias } from "./Fiction/FictiveAlias";
import { IAlias } from "./Interfaces/IAlias";
import { IAliasName } from "./Interfaces/IAliasName";

export class AliasName implements IAliasName
{

    alias: IAlias = new FictiveAlias();

    name: string = "";

    constructor(alias: IAlias, name: string) {
        this.alias = alias;
        this.name = name;
    }
    getAlias(): IAlias {
        return this.alias;
    }
    getAliasNameValue(): any
    {
        return this.alias.getAliasValue(this.name);
    }


    setAliasNameValue(value: any): void
    {
        if (value != undefined)
        {
            this.alias.setAliasValue(this.name, value);
        }
    }

    getNameOfAliasName(): string {
        return this.name;
    }
}