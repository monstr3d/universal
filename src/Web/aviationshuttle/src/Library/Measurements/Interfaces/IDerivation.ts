/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IMeasurement } from "./IMeasurement";

export interface IDerivation
{
    getDerivation(): IMeasurement;

    setDerivation(derivation: IMeasurement) : void
}
