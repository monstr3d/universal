/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IInitialValue } from "./IInitialValue";

export interface IInitialValueCollection
{
    getInitialValues(): IInitialValue[];
    resetInitialValues(): void;
    addInitialValue(value: IInitialValue): void;
}