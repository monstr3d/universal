import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../Interfaces/IDesktop";
import { DataConsumerMeasurements } from "./DataConsumerMeasurements";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import { IStarted } from "./Interfaces/IStarted";


export class Recursive extends DataConsumerMeasurements implements IStarted, IPostSetArrow {
    protected inputs: IMeasurements[] = [];

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.typeName = "Recursive";
        this.types.push("ISarted");
        this.types.push("IPostSetArrow");
        this.types.push("Recursive");

    }
    startedStart(start: number): void {
        throw new OwnNotImplemented();
    }
    postSetArrow(): void {
        throw new OwnNotImplemented();
    }

    getAllMeasurements(): IMeasurements[] {
        return this.inputs;
    }
    addMeasurements(item: IMeasurements): void {
        this.inputs.push(item);
    }

}
