import { IAction } from "./Library/Interfaces/IAction";
import { IDataConsumer } from "./Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "./Library/Measurements/PefrormerMeasuremets";
import { DetaRuntimeConsumer } from "./Library/Runtime/DetaRuntimeConsumer";
import { IDataRuntime } from "./Library/Runtime/Interfaces/IDataRuntime";
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
        console.log(a, b);
    }

    public test(): void {
        var runtime: IDataRuntime = new DetaRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.peformFixedStepCalculation(runtime, 0, 1, 10, this);
    }
}
