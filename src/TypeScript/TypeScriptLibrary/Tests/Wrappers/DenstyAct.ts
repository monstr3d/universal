import { Density } from "../Density";
import { IAction } from "../../Library/Interfaces/IAction";
import { RungeProcessor } from "../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { IMeasurement } from "../../Library/Measurements/Interfaces/IMeasurement";
import { IMeasurements } from "../../Library/Measurements/Interfaces/IMeasurements";
import { IFunc } from "../../Library/Interfaces/IFunc";


export class DensityAct extends Density implements IAction, IFunc<boolean> {

    dc !: IDataConsumer;

    measurement !: IMeasurement;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = this.getCategoryObject("Chart") as unknown as IDataConsumer;
        let m = this.getCategoryObject("A-transformation") as unknown as IMeasurements;
        this.measurement = m.getMeasurement(0);
    }

    action(): void {
 /*       var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();*/
        const a = this.measurement.getMeasurementValue();
        console.log(a);
    }

    func(): boolean {
        return false;
    }


    public test(): void {
        try {
            let processor = new RungeProcessor();
            var runtime = new DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets();
            p.performFixedStepCalculation(runtime, 1770457504, 1, 18000, this, this);
        }
        catch (e: any) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }
}