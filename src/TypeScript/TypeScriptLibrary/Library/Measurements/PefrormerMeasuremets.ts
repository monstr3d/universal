/* eslint-disable no-var */
/* eslint-disable @typescript-eslint/no-unused-vars */
/* eslint-disable @typescript-eslint/no-explicit-any */
import type { IAction } from "../Interfaces/IAction";
import type { IFunc } from "../Interfaces/IFunc";
import { Performer } from "../Performer";
import type { IDataRuntime } from "../Runtime/Interfaces/IDataRuntime";
import { DataConsumerBoolFunc } from "./DataConsumerBoolFunc";
import type { IArrayElementMeasurement } from "./Interfaces/IArrayElemetMeasurements";
import type { IDataConsumer } from "./Interfaces/IDataConsumer";
import type { IMeasurement } from "./Interfaces/IMeasurement";
import type { IMeasurements } from "./Interfaces/IMeasurements";
import type { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";
import { TimeMeasurementProvider } from "./TimeMeasurementProvider";

export class PefrormerMeasuremets
{

    performer: Performer = new Performer();

 

    public getArrayMeasurements(array: IArrayElementMeasurement): IMeasurement[] {
        var n = array.getMeasurementNames().length;
        var mea: IMeasurement[] = [];
        for (var i = 0; i < n; i++) {
          //  mea.push(new ArrayMeasurement(array, i));
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
            else
            {
                measurements.push(mea);
                let dc = mea as unknown as IDataConsumer;
                //     if (dc instanceof IDataConsumer)

            }
        }
        
    }


    public peformCondDCFixedStepCalculation(runtime: IDataRuntime, dataConsumer: IDataConsumer,
        conditionName: string, stop: IFunc<boolean>, start: number,
        step: number, steps: number, act: IAction): void
    {
        var cond = new DataConsumerBoolFunc(dataConsumer, conditionName);
        this.peformCondFixedStepCalculation(runtime,cond, stop, start, step, steps, act);
    }



    public peformCondFixedStepCalculation(runtime: IDataRuntime, condition: IFunc<boolean>, stop: IFunc<boolean>, start: number,
        step: number, steps: number, act: IAction): void
    {
        var tm: ITimeMeasurementProvider = new TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        runtime.startRuntime(start);
        var st = start;
        for (var i = 0; i < steps; i++)
        {
            if (stop.func()) return;
            tm.setTime(st);
            runtime.updateRuntime();
            if (condition.func())
            {
                act.action();
            }
            let s = st + step;
            if (i > 0)
            {
                runtime.stepRuntime(st, s);
            }
            st = s;
        }
    }

    public performFixedStepCalculation(runtime: IDataRuntime, start: number, step: number, steps: number,
        stop: IFunc<boolean>, act: IAction): void
    {
        let tm = new TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        runtime.startRuntime(start);
        var st = start;
        var curr = start;
        for (var i = 0; i < steps; i++)
        {
            if (stop.func()) return;
              
            tm.setTime(st);
            if (i > 0)
            {
                runtime.stepRuntime(curr, st);
                curr = st;
            }
            runtime.updateRuntime();
            act.action();
            st += step;
        }

    }
}