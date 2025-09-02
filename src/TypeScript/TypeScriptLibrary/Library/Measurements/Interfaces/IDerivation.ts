import { IMeasurement } from "./IMeasurement";

export interface IDerivation
{
    getDerivation(): IMeasurement;

    setDerivation(derivation: IMeasurement) : void
}
