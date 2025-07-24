import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../Interfaces/IDesktop";
import { DataConsumerMeasurements } from "./DataConsumerMeasurements";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { IPostSetArrow } from "../Interfaces/IPostSetArrow";


export class Recursive extends DataConsumerMeasurements implements IPostSetArrow {
    protected inputs: IMeasurements[] = [];

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);

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
