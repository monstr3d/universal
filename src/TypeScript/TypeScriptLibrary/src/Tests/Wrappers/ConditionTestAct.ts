import { IAction } from "../../Library/Interfaces/IAction";
import { IDataRuntime } from "../../Library/Interfaces/IDataRuntime";
import { IFactory } from "../../Library/Interfaces/IFactory";
import { IFunc } from "../../Library/Interfaces/IFunc";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { Motion6DFactory } from "../../Library/Motion6D/Motion6DFactory";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { ConditionTest } from "../ConditionTest";

export class ConditionTestAct extends ConditionTest implements IAction, IFunc<boolean>
{
    dc !: IDataConsumer;


    factory: IFactory = new Motion6DFactory
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

    isEmptyAction(): boolean {
        return false
    }


    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumerODE(this.dc, this.factory);
        var p: PerformerMeasuremets = new PerformerMeasuremets();
        p.peformCondDCFixedStepCalculation(runtime, this.dc, "Condition.Formula_1", this, 0, 0.01, 500, this);
    }
}
