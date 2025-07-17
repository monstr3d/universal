import { CategoryObject } from "../CategoryObject";
import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IPostSetArrow } from "../IPostSetArrow";

export class DataConsumer extends CategoryObject implements IDataConsumer, IPostSetArrow
{
    PostSetArrow(): void {
        try {
            throw new OwnNotImplemented();
        }
        catch (e: any) { }
    }

    private measurements: IMeasurements[] = [];

    getAllMeasurements(): IMeasurements[] {
        return this.measurements;
    }
    addMeasurements(item: IMeasurements): void {
        this.measurements.push(item);
    }

}
