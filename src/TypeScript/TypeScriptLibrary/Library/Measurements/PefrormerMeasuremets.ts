import { IAction } from "../Interfaces/IAction";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";
import { IDataRuntime } from "../Runtime/Interfaces/IDataRuntime";
import { TimeMeasurementProvider } from "./TimeMeasurementProvider";
import { Performer } from "../Performer";
import { IArrayElementMeasurement } from "./Interfaces/IArrayElemetMeasurements";
import { IMeasurement } from "./Interfaces/IMeasurement";
import { ArrayMeasurement } from "./ArrayMeasurement";

export class PefrormerMeasuremets {

    performer: Performer = new Performer();

    public getArrayMeasurements(array: IArrayElementMeasurement): IMeasurement[] {
        var n = array.getMeasurementNames().length;
        var mea: IMeasurement[] = [];
        for (var i = 0; i < n; i++) {
            mea.push(new ArrayMeasurement(array, i);
        }
        return mea;
    }

    public initStart(array: IArrayElementMeasurement, x: []): void {
        var n = x.length;
        var y = array.getMeasurementValues();
        for (var i = 0; i < n; i++) {
            y[i] = x[i];
        }
    }

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
        runtime.startRuntime(start);
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