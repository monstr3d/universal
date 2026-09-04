import { Measurement } from "./Measurement";

export class NumberMeasurement extends Measurement {


    constructor(name: string) {
        super(name, 0)
    }
}