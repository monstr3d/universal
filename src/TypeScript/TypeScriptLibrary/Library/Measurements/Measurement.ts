import { Operation } from "../Types/Operation";
import { IMeasurement } from "./IMeasurement";

export class Measurement implements IMeasurement
{

    name: string = "";

    type: any = undefined;

    operation!: Operation<any>;

    constructor(name: string, type: any, operation: Operation<any>) {
        this.name = name;
        this.type = type;
        this.operation = operation;
    }

    getName(): string {
        return this.name;
    }
    getType() {
        return this.type;
    }
    getOperation(): Operation<any> {
        return this.operation;
    }

}