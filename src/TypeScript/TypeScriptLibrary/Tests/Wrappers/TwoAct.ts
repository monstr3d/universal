import { IAction } from "../../Library/Interfaces/IAction";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";
import { Two } from "../Two";

export class TwoAct extends Two implements IAction {
    dc !: IDataConsumer;
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1] as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }

    func(): boolean {
        return false;
    }


    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 1, 10, this, this);
    }
}