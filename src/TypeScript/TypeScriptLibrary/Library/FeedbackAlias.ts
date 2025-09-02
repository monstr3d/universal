import { FictiveAliasName } from "./Fiction/FictiveAliasName";
import { FictiveValue } from "./Fiction/FictiveValue";
import { IAliasName } from "./Interfaces/IAliasName";
import { IFeedback } from "./Interfaces/IFeedback";
import { IFeedbackAlias } from "./Interfaces/IFeedbackAlias";
import { IValue } from "./Interfaces/IValue";

export class FeedbackAlias implements IFeedback, IFeedbackAlias
{
    constructor(alias: IAliasName, value: IValue)
    {
        this.alias = alias;
        this.value = value;
    }

    setFeedback(): void
    {
        var x = this.value.getIValue();
        if (x != undefined)
        {
            this.alias.setAliasNameValue(x);
        }
    }

    getFeedBackAlias(): IAliasName
    {
        return this.alias;
    }

    protected value: IValue = new FictiveValue();

    protected alias: IAliasName = new FictiveAliasName();

}