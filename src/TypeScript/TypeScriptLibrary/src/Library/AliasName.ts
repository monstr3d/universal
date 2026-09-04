/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IAlias } from "./Interfaces/IAlias";
import type { IAliasName } from "./Interfaces/IAliasName";

export class AliasName implements IAliasName
{

    alias !: IAlias;

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