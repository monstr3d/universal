import { IDataConsumer } from "./IDataConsumer";
import { IMeasurements } from "./IMeasurements";
import { IDataRuntime } from "./Runtime/IDataRuntime";
import { ITimeMeasurementProvider } from "./ITimeMeasurementProvider";
import { TimeMeasurementProvider } from "./TimeMeasurementProvider";
import { IAction } from "../IAction";

export class PefrormerMeasuremets {

    getDependentPrivate(dataConsumer: IDataConsumer, measurements: IMeasurements[]): void {

        let m = dataConsumer.getAllMeasurements();
        for (let i = 0; i < m.length; i++) {
            let mea = m[i];
            if (measurements.find(mea => true) === undefined) {

            }
            else {
                measurements.push(mea);
                let dc = mea as unknown as IDataConsumer;
                //     if (dc instanceof IDataConsumer)

            }
        }
    }

    public peformCalculation(runtime: IDataRuntime, start: number, step: number, steps: number, act: IAction): void {
        var tm: ITimeMeasurementProvider = new TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        var st = start;
        for (var i = 0; i < steps; i++)
        {
            tm.setTime(st);
            runtime.updateRuntime();
            act.action();
            st += step;
        }

    }
}