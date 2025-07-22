import { ICategoryArrow } from "../../ICategoryArrow";
import { ICategoryObject } from "../../ICategoryObject";
import { Performer } from "../../Performer";
import { IDataConsumer } from "../IDataConsumer";
import { IMeasurements } from "../IMeasurements";
import { ITimeMeasurementConsumer } from "../ITimeMeasurementConsumer";
import { ITimeMeasurementProvider } from "../ITimeMeasurementProvider";
import { IDataRuntime } from "./IDataRuntime";

export class DetaRuntimeConsumer implements IDataRuntime
{

    performer: Performer = new Performer();
    constructor(dataConsumer: IDataConsumer)
    {
        let nm: IMeasurements[] = [];
        this.add(dataConsumer, nm);
        for (let i = nm.length - 1; i >= 0; i--) {
            this.measurements.push(nm[i]);
        }
        if (this.performer.implementsType(dataConsumer, "IMeasurements")) {
            this.measurements.push(dataConsumer as unknown as IMeasurements);
        }

    }
    updateRuntime(): void {
        let n = this.measurements.length;
        for (let i = 0; i < n; i++) this.measurements[i].updateMeasurements();
    }
    refreshRuntime(): void {
        throw new Error("Method not implemented.");
    }
    startRuntime(time: number): void {
        throw new Error("Method not implemented.");
    }
    setTimeProvider(timeProvider: ITimeMeasurementProvider): void {
        let n = this.measurements.length;
        for (let i = 0; i < n; i++) {
            let m = this.measurements[i];
            if (this.performer.implementsType(m, "ITimeMeasurementConsumer")) {
                let tm: ITimeMeasurementConsumer = m as unknown as ITimeMeasurementConsumer;
                tm.setTimeMeasurement(timeProvider.getTimeMeasurement())
            }
        }
    }

    getTimeProvider(): ITimeMeasurementProvider {
        return this.timeProvider;
    }
    getRumtimeObjects(): ICategoryObject[] {
        throw new Error("Method not implemented.");
    }
    getRunimeArrows(): ICategoryArrow[] {
        throw new Error("Method not implemented.");
    }


    protected timeProvider !: ITimeMeasurementProvider;

    protected measurements: IMeasurements[] = [];

    add(dc: IDataConsumer, measurements: IMeasurements[]): void
    {
        var m = dc.getAllMeasurements();
        var n = m.length;
        if (n != 0)
        {
            for (let i = 0; i < n; i++)
            {
                let mea = m[i];
                if (measurements.indexOf(mea) >= 0) {
                    continue;
                }
                measurements.push(mea);
                if (!this.performer.implementsType(mea, "IDataConsumer")) {
                    continue;
                }
                let c: IDataConsumer = mea as unknown as IDataConsumer;
                this.add(c, measurements);

            }
        }
        else
        {

        }
    }
}


