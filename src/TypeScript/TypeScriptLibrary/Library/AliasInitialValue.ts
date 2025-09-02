import { FictiveAliasName } from "./Fiction/FictiveAliasName";
import { IAliasName } from "./Interfaces/IAliasName";
import { IInitialValue } from "./Interfaces/IInitialValue";
import { IValue } from "./Interfaces/IValue";
import { FictiveVariable } from "./Measurements/Variables/FictiveVariable";


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

    protected alias: IAliasName = new FictiveAliasName();

    protected value: IValue = new FictiveVariable();
}
