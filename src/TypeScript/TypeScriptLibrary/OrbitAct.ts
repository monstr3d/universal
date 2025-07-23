import { IAction } from "./Library/IAction";
import { IDataConsumer } from "./Library/Measurements/IDataConsumer";
import { PefrormerMeasuremets } from "./Library/Measurements/PefrormerMeasuremets";
import { DetaRuntimeConsumer } from "./Library/Measurements/Runtime/DetaRuntimeConsumer";
import { IDataRuntime } from "./Library/Measurements/Runtime/IDataRuntime";
import { Orbital } from "./src/Orbital";

export class OrbitAct extends Orbital implements IAction {
    dc !: IDataConsumer;
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1] as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
    }

    public test(): void {
        var runtime: IDataRuntime = new DetaRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.peformCalculation(runtime, 0, 1, 3, this);
    }
}
