
import { IAction } from "../../Library/Interfaces/IAction";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumer } from "../../Library/Runtime/DataRuntimeConsumer";
import { IDataRuntime } from "../../Library/Runtime/Interfaces/IDataRuntime";

export class TestObjectTransformerSimpleAct { /*extends TestObjectTransformerSimple implements IAction
{
    dc! : IDataConsumer;
    constructor() {
        super();
        var co = this.getCategoryObject("Chart");
        this.dc = co as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[1];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        var c = k.getMeasurement(2).getMeasurementValue();
        console.log(a, b, c);
    }

    public test(): void {
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc);
        var p: PefrormerMeasuremets = new PefrormerMeasuremets();
        p.peformFixedStepCalculation(runtime, 0, 1, 60, this);
        console.log("+++++++++++++");
        runtime = new DataRuntimeConsumer(this.dc);
        p = new PefrormerMeasuremets();
        p.peformFixedStepCalculation(runtime, 0, 1, 60, this);

    }*/
}