import { IInitialValue } from "./IInitialValue";

export interface IInitialValueCollection
{
    getInitialValues(): IInitialValue[];
    resetInitialValues(): void;
    addInitialValue(value: IInitialValue): void;
}