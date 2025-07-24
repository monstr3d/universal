import { IAction } from "../Interfaces/IAction";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";
import { IDataRuntime } from "../Runtime/Interfaces/IDataRuntime";
import { TimeMeasurementProvider } from "./TimeMeasurementProvider";

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

    public peformFixedStepCalculation(runtime: IDataRuntime, start: number, step: number, steps: number, act: IAction): void {
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