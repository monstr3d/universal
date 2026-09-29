/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */

import type { IInitialValue } from "./Interfaces/IInitialValue";
import type { IInitialValueCollection } from "./Interfaces/IInitialValueCollection";

export class InitialValueCollection implements IInitialValueCollection
{

    addInitialValue(value: IInitialValue): void
    {
        this.values.push(value);
    }

    getInitialValues(): IInitialValue[]
    {
        return this.values;
    }

    resetInitialValues(): void
    {
        for (var item of this.values)
        {
            item.resetInitValue();
        }
    }

    protected values: IInitialValue[] = [];

}
