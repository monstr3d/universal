import { IAction } from "../Interfaces/IAction";
import { IFunc } from "../Interfaces/IFunc";
import { Performer } from "../Performer";
import { IDataRuntime } from "../Runtime/Interfaces/IDataRuntime";
import { DataConsumerBoolFunc } from "./DataConsumerBoolFunc";
import { IArrayElementMeasurement } from "./Interfaces/IArrayElemetMeasurements";
import { IDataConsumer } from "./Interfaces/IDataConsumer";
import { IMeasurement } from "./Interfaces/IMeasurement";
import { IMeasurements } from "./Interfaces/IMeasurements";
import { ITimeMeasurementProvider } from "./Interfaces/ITimeMeasurementProvider";
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
        conditionName: string,  start: number,
        step: number, steps: number, act: IAction): void
    {
        var cond = new DataConsumerBoolFunc(dataConsumer, conditionName);
        this.peformCondFixedStepCalculation(runtime,cond, start, step, steps, act);
    }



    public peformCondFixedStepCalculation(runtime: IDataRuntime, condition: IFunc<boolean>, start: number,
        step: number, steps: number, act: IAction): void
    {
        var tm: ITimeMeasurementProvider = new TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        runtime.startRuntime(start);
        var st = start;
        for (var i = 0; i < steps; i++)
        {
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

    public performFixedStepCalculation(runtime: IDataRuntime, start: number, step: number, steps: number, act: IAction): void
    {
        let tm = new TimeMeasurementProvider();
        runtime.setTimeProvider(tm);
        runtime.startRuntime(start);
        var st = start;
        var curr = start;
        for (var i = 0; i < steps; i++)
        {
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