import { IDataConsumer } from "./Library/Measurements/IDataConsumer";
import { PefrormerMeasuremets } from "./Library/Measurements/PefrormerMeasuremets";
import { DetaRuntimeConsumer } from "./Library/Measurements/Runtime/DetaRuntimeConsumer";
import { IDataRuntime } from "./Library/Measurements/Runtime/IDataRuntime";
import { Orbital } from "./src/Orbital";

export class OrbitAct extends Orbital {
    dc !: IDataConsumer;
    constructor() {
        super();
        this.dc = this.getCategoryObjects()[1] as unknown as IDataConsumer;

    }

    act(): void {
        var k = this.dc.getAllMeasurements();
        var a = k[0].getMeasurement(0).getMeasurementValue();
        var b = k[1].getMeasurement(0).getMeasurementValue();
    }

    public test(): void {
        var runtime: IDataRuntime = new DetaRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.peformCalculation(runtime, 0, 1, 3, this.act);
    }


}
