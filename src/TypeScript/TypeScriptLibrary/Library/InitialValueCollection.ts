import { IInitialValue } from "./Interfaces/IInitialValue";
import { IInitialValueCollection } from "./Interfaces/IInitialValueCollection";

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
