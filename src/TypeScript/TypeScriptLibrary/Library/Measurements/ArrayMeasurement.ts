import { IArrayElementMeasurement } from "./Interfaces/IArrayElemetMeasurements";
import { IMeasurement } from "./Interfaces/IMeasurement";

export class ArrayMeasurement implements IMeasurement {
    array !: [];
    name: string = "";
    type !: any;
    n: number 0;

    constructor(arrElement: IArrayElementMeasurement, n: number) {
        this.n = n;
        this.name = arrElement.getMeasurementNames()[n];
        this.type = arrElement.getMeasurementTypes()[n];
        this.array = arrElement.getMeasurementValues();
    }
    getName(): string {
        return this.name;
    }
    getType() {
        return this.type;
    }
    getMeasurementValue() {
        return this.array[this.n];
    }
}