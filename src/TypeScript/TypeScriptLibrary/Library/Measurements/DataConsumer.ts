import { CategoryObject } from "../CategoryObject";
import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { IDesktop } from "../IDesktop";
import { IPostSetArrow } from "../IPostSetArrow";
import { Operation } from "../Types/Operation";
import { IDataConsumer } from "./IDataConsumer";
import { IMeasurement } from "./IMeasurement";
import { IMeasurements } from "./IMeasurements";
import { ITimeMeasurementConsumer } from "./ITimeMeasurementConsumer";

export class DataConsumer extends CategoryObject implements IDataConsumer, IPostSetArrow, ITimeMeasurementConsumer
{
    constructor(desktop: IDesktop, name: string) {
        super(desktop, name);
        this.tms = this;
        this.timeOperation = this.performer.GetNumberTimeOperation(this);

      }
    getInternalTime(): number {
        return this.timeOperation();
    }

    tms!: ITimeMeasurementConsumer; 

    timeOperation !: Operation<number>;

    timeMeasurement !: IMeasurement;
   
    
    getTimeMeasutement(): IMeasurement {
        return this.timeMeasurement;
    }
    setTimeMeasutement(measurement: IMeasurement): void {
        this.timeMeasurement = measurement;            ;
    }
    postSetArrow(): void {

    }

    private measurements: IMeasurements[] = [];

    getAllMeasurements(): IMeasurements[] {
        return this.measurements;
    }
    addMeasurements(item: IMeasurements): void {
        this.measurements.push(item);
    }



}
