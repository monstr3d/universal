
import { IAction } from "../../Library/Interfaces/IAction";
import { IDataRuntime } from "../../Library/Interfaces/IDataRuntime";
import { IFactory } from "../../Library/Interfaces/IFactory";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { Motion6DFactory } from "../../Library/Motion6D/Motion6DFactory";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { Random } from "../Random";

export class RandomAct extends Random implements IAction
{
    dc!: IDataConsumer;
    factory: IFactory = new Motion6DFactory

    constructor() {
        super();
        var co = this.getCategoryObject("Chart")
        this.dc = co as unknown as IDataConsumer;
    }
    isEmptyAction(): boolean {
        return false
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        console.log(a);
    }
    func(): boolean {
        return false;
    }

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumerODE(this.dc, this.factory);
        var p: PerformerMeasuremets = new PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 1000, this, this);
    }
}