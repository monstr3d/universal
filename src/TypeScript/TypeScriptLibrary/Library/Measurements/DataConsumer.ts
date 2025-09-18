import { CategoryObject } from "../CategoryObject";
import type { ICategoryObject } from "../Interfaces/ICategoryObject";
import { ICheck } from "../Interfaces/ICheck";
import type { ICheckHolder } from "../Interfaces/ICheckHolder";
import type { IDesktop } from "../Interfaces/IDesktop";
import type { IPostSetArrow } from "../Interfaces/IPostSetArrow";
import type { IPrintedObject } from "../Interfaces/IPrintedObject";
import type { IPrinter } from "../Interfaces/IPrinter";
import type { IDataConsumer } from "./Interfaces/IDataConsumer";
import type { IMeasurements } from "./Interfaces/IMeasurements";
import type { ITimeMeasurementConsumer } from "./Interfaces/ITimeMeasurementConsumer";
import type { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";

export class DataConsumer extends CategoryObject implements IDataConsumer, IPostSetArrow, ITimeMeasurementConsumer, IPrintedObject, ICheckHolder
{
    constructor(desktop: IDesktop, name: string)
    {
        super(desktop, name);
        this.typeName = "DataConsumer";
        this.types.push("DataConsumer");
        this.types.push("IDataConsumer");
        this.types.push("IPostSetArrow");
        this.types.push("ITimeMeasurementConsumer");
        this.types.push("IPrintedObject");
        this.types.push("ICheckHolder");
        this.tms = this;
        this.dataConsumer = this;
    }
    getCheck(): ICheck {
        return this.checker;
    }
    setCheck(check: ICheck): void {
        this.checker = check;
    }

    print(printer: IPrinter): void {
        for (var m of this.measurements) {
            let co = m as unknown as ICategoryObject;
            let s = co.getCategoryObjectName() + "\t";
            let n = m.getMeasurementsCount();
            for (let i = 0; i < n; i++) {
                var mm = m.getMeasurement(i);
                var v = mm.getMeasurementValue();
                s += v + "\t";
            }
            printer.print(s);
        }
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
