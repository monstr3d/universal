/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IAliasName } from "./Interfaces/IAliasName";
import type { IInitialValue } from "./Interfaces/IInitialValue";
import type { IValue } from "./Interfaces/IValue";


export class AliasInitialValue implements IInitialValue
{
    getInitValue()
    {
        return this.value.getIValue();
    }

    resetInitValue(): void
    {
        let x = this.alias.getAliasNameValue();
        if (x != undefined)
        {
            this.value.setIValue(x)
        }
    }

    constructor(alias: IAliasName, value: IValue)
    {
        this.alias = alias;
        this.value = value;
    }

    protected alias !: IAliasName;

    protected value !: IValue;
}
