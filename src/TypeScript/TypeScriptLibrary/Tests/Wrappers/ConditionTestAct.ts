import { FictiveDataConsumer } from "../../Library/Fiction/FictiveDataConsumer";
import { IAction } from "../../Library/Interfaces/IAction";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";
import { ConditionTest } from "../ConditionTest";

export class ConditionTestAct extends ConditionTest implements IAction
{
    dc: IDataConsumer = new FictiveDataConsumer();
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2] as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[1];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.peformCondDCFixedStepCalculation(runtime, this.dc, "Condition.Formula_1", 0, 0.01, 500, this);
    }
}
