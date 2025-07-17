import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../IDesktop";
import { IPostSetArrow } from "../IPostSetArrow";
import { Measurements } from "./Measurements";

export class Recursive extends Measurements implements IDataConsumer, IPostSetArrow
{
    protected inputs: IMeasurements[] = [];

    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);

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
