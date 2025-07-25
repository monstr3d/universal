import { OwnNotImplemented } from "../ErrorHandler/OwnNotImplemented";
import { ICategoryArrow } from "../Interfaces/ICategoryArrow";
import { ICategoryObject } from "../Interfaces/ICategoryObject";
import { Performer } from "../Performer";
import { IDataConsumer } from "../Measurements/Interfaces/IDataConsumer";
import { IMeasurements } from "../Measurements/Interfaces/IMeasurements";
import { ITimeMeasurementConsumer } from "../Measurements/Interfaces/ITimeMeasurementConsumer";
import { ITimeMeasurementProvider } from "../Measurements/Interfaces/ITimeMeasurementProvider";
import { IDataRuntime } from "./Interfaces/IDataRuntime";
import { IStarted } from "../Measurements/Interfaces/IStarted";

export class DetaRuntimeConsumer implements IDataRuntime {

    performer: Performer = new Performer();

    protected timeProvider !: ITimeMeasurementProvider;

    protected measurements: IMeasurements[] = [];

    protected categoryObjects: ICategoryObject[] = [];

    protected cotegoryArrows: ICategoryArrow[] = [];

    protected started: IStarted[] = [];


    constructor(dataConsumer: IDataConsumer) {
        let nm: IMeasurements[] = [];
        this.add(dataConsumer, nm);
        for (let i = nm.length - 1; i >= 0; i--) {
            var n = nm[i];
            this.measurements.push(nm[i]);
            if (this.performer.implementsType(n, "ICategoryObject")) {
                this.categoryObjects.push(n as unknown as ICategoryObject);
            }
            if (this.performer.implementsType(n, "IStarted")) {
                this.started.push(n as unknown as IStarted);
            }

        }
        if (this.performer.implementsType(dataConsumer, "IMeasurements")) {
            this.measurements.push(dataConsumer as unknown as IMeasurements);
        }


    }
    getStarted(): IStarted[] {
        return this.started;
    }
    updateRuntime(): void {
        let n = this.measurements.length;
        for (let i = 0; i < n; i++) {
            this.measurements[i].updateMeasurements();
        }
    }
    refreshRuntime(): void {
        throw new OwnNotImplemented();
    }
    startRuntime(time: number): void {
        for (let st of this.started) {
            st.startedStart(time);
        }
    }
    setTimeProvider(timeProvider: ITimeMeasurementProvider): void {
        for (let m of this.measurements) {

            if (this.performer.implementsType(m, "ITimeMeasurementConsumer")) {
                let tm: ITimeMeasurementConsumer = m as unknown as ITimeMeasurementConsumer;
                tm.setTimeMeasurement(timeProvider)
            }
        }
    }

    getTimeProvider(): ITimeMeasurementProvider {
        return this.timeProvider;
    }
    getRumtimeObjects(): ICategoryObject[] {
        return this.categoryObjects;;
    }
    getRunimeArrows(): ICategoryArrow[] {
        return this.cotegoryArrows;
    }


 
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


