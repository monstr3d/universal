import { IObject } from "../Interfaces/IObject";
import { IMeasurement } from "./Interfaces/IMeasurement";

export class ArrayMeasurement implements IMeasurement, IObject
{
    array : any [] = [];
    name: string = "";
    n: number = 0
    type !: any;
    types: string[] = ["ArrayMeasurement", "IMeasurement", "IObject"];

    protected className: string = "ArrayMeasurement";

    constructor(arrElement: any[], n: number, name: string, type: any)
    {
        this.n = n;
        this.name = name;
        this.type = type;
        
    }

    getClassName(): string {
        return this.className;
    }

    imlplementsType(type: string): boolean {
        return this.types.indexOf(type) >= 0;
    }
    getName(): string {
        return this.name;
    }

    getMeasurementName(): string {
        return this.name;
    }
    getMeasurementType() : any {
        return this.type;
    }
    getMeasurementValue() : any {
        return this.array[this.n];
    }
}

