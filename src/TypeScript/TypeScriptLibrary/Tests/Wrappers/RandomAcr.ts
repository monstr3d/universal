import { FictiveDataConsumer } from "../../Library/Fiction/FictiveDataConsumer";
import { IAction } from "../../Library/Interfaces/IAction";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";
import { Random } from "../Random";

export class RandomAct extends Random implements IAction
{
    dc: IDataConsumer = new FictiveDataConsumer();
    constructor() {
        super();
        var co = this.getCategoryObject("Chart")
        this.dc = co as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 1000, this);
    }
}