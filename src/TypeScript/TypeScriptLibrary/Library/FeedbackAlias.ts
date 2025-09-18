/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IAliasName } from "./Interfaces/IAliasName";
import type { IFeedback } from "./Interfaces/IFeedback";
import type { IFeedbackAlias } from "./Interfaces/IFeedbackAlias";
import type { IValue } from "./Interfaces/IValue";

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

    protected value !: IValue;

    protected alias !: IAliasName;

}