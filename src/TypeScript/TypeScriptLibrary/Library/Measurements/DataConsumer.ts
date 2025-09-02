import { CategoryObject } from "../CategoryObject";
import { IDesktop } from "../Interfaces/IDesktop";
import { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { ITimeMeasurementConsumer } from "./Interfaces/ITimeMeasurementConsumer";
import { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";

export class DataConsumer extends CategoryObject implements IDataConsumer, IPostSetArrow, ITimeMeasurementConsumer
{
    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "DataConsumer";
        this.types.push("DataConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("ITimeMeasurementConsumer");
        this.tms = this;
        this.dataConsumer = this;
    }

    getInternalTime(): number
    {
        var tm = this.timeMeasurement;

        return tm.getTime();
    }

  
    tms!: ITimeMeasurementConsumer; 

    timeMeasurement !: ITimeMeasurementProvider;

    success: boolean = true;

    protected dataConsumer !: IDataConsumer;

   
    
    getTimeMeasurement(): ITimeMeasurementProvider {
        return this.timeMeasurement;
    }

    setTimeMeasurement(measurement: ITimeMeasurementProvider): void {
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
