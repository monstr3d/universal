import { OwnNotImplemented } from "../../Library/ErrorHandler/OwnNotImplemented";
import { IAction } from "../../Library/Interfaces/IAction";
import { RungeProcessor } from "../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { OrbitalForecast } from "../../ExternalObjects/Algorithms/OrbitalForecastCalculation/OrbitalForecast";
import { Motion6DFactory } from "../../Library/Motion6D/Motion6DFactory";

export class OrbitaForecasAct extends OrbitalForecast implements IAction {

    dc !: IDataConsumer;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = this.getCategoryObject("Chart") as unknown as IDataConsumer;
    }
    isEmptyAction(): boolean {
        return false
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
        try {
            let processor = new RungeProcessor();
            var runtime = new DataRuntimeConsumerODE(this.dc, new Motion6DFactory());
            var p = new PerformerMeasuremets();
            p.peformCondDCFixedStepCalculation(runtime, this.dc, "Recursive.y", this, 0, 1, 18000, this);
        }
        catch (e: any)
        {
            let i = 0;
        //    throw new OwnNotImplemented();
        }
    }
}