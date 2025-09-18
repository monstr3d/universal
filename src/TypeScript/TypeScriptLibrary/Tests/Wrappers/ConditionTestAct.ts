import { IAction } from "../../Library/Interfaces/IAction";
import { IFunc } from "../../Library/Interfaces/IFunc";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";
import { ConditionTest } from "../ConditionTest";

export class ConditionTestAct extends ConditionTest implements IAction, IFunc<boolean>
{
    dc !: IDataConsumer;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2] as unknown as IDataConsumer;
    }
    func(): boolean {
        return false;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[1];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.peformCondDCFixedStepCalculation(runtime, this.dc, "Condition.Formula_1", this, 0, 0.01, 500, this);
    }
}
