/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IObject } from "../../Interfaces/IObject";
import type { IValue } from "../../Interfaces/IValue";
import { Performer } from "../../Performer";
import type { IDerivation } from "../Interfaces/IDerivation";
import type { IMeasurement } from "../Interfaces/IMeasurement";


export class Variable implements IMeasurement, IObject, IValue, IDerivation
{
    value: any = new Object();

    type: any = new Object();

    name: string = "";

    className: string = "Variable";

    types: string[] = ["Variable", "IMeasurement", "IObject", "IValue", "IDerivation"];

    performer: Performer = new Performer();

    measurement !: IMeasurement;

    derivation ! : Variable;

    constructor(name: string, type: any, value: any) {
        this.name = name;
        this.type = type;
        this.value = value;

    }
    getIValue()
    {
        return this.value;
    }
    setIValue(value: any): void
    {
        this.value = value;
    }


    getClassName(): string
    {
        return this.className;
    }

    imlplementsType(type: string): boolean
    {
        return this.types.indexOf(type) >= 0;
    }

    getName(): string
    {
        return this.name;
    }

    getMeasurementName(): string {
        return this.name;
    }

    getMeasurementType()
    {
        return this.type;
    }

    getMeasurementValue()
    {
        return this.value;
    }

    getDerivation(): IMeasurement
    {
        return this.measurement;
    }

    setDerivation(derivation: IMeasurement): void
    {
        this.measurement = derivation;
    }
    setDerivationVarible(variable: Variable): void
    {
        this.derivation = variable;
    }


}
