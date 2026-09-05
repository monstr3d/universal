import { IAction } from "../../src/Library/Interfaces/IAction";
import { IDataRuntime } from "../../src/Library/Interfaces/IDataRuntime";
import { IDataConsumer } from "../../src/Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../src/Library/Measurements/PerformerMeasuremets";
import { DataRuntimeConsumer } from "../../src/Library/Runtime/DataRuntimeConsumer";
import { UniversalFactory } from "../../src/Library/UniversalFactory";
import { PI } from "../tests/PI";

export class PIAct extends PI implements IAction {

    dc! : IDataConsumer;
    constructor() {
        super();
        var co = this.getCategoryObject("Chart");
        this.dc = co as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
  
        console.log(a);
    }
    isEmptyAction(): boolean { return false }

    func(): boolean {
        return false;
    }


    public test(): void {
        
        var runtime: IDataRuntime = new DataRuntimeConsumer(this.dc, new UniversalFactory());
        var p: PerformerMeasuremets = new PerformerMeasuremets();
        p.performFixedStepCalculation(runtime, 0, 0.001, 1000, this, this);
    }


}