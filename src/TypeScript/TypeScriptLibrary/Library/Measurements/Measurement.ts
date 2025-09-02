import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IMeasurement } from "./Interfaces/IMeasurement";

export class Measurement implements IMeasurement {

    name: string = "";

    type !: any;

    constructor(name: string, type: any) {
        this.name = name;
        this.type = type;
        
    }
    getMeasurementName(): string {
        return this.name;
    }
    getMeasurementType() {
        return this.type;
    }

    getMeasurementValue() {
        throw new OwnNotImplemented();;
    }

}