import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../IDesktop";
import { IPostSetArrow } from "../IPostSetArrow";
import { IDataConsumer } from "./IDataConsumer";
import { IMeasurements } from "./IMeasurements";
import { Measurements } from "./Measurements";

export class Recursive extends Measurements implements IDataConsumer, IPostSetArrow
{
    protected inputs: IMeasurements[] = [];

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);

    }
    postSetArrow(): void {
        throw new Error("Method not implemented.");
    }

    getAllMeasurements(): IMeasurements[] {
        return this.inputs;
    }
    addMeasurements(item: IMeasurements): void {
        this.inputs.push(item);
    }
    PostSetArrow(): void {
        try {
            throw new OwnNotImplemented();
        }
        catch (e: any) { }
    }

}
