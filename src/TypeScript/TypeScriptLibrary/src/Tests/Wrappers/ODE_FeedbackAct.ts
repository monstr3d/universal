import { OwnNotImplemented } from "../../Library/ErrorHandler/OwnNotImplemented";
import { RungeProcessor } from "../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PerformerMeasuremets } from "../../Library/Measurements/PerformerMeasuremets";
import { Motion6DFactory } from "../../Library/Motion6D/Motion6DFactory";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { ODE_Feedback } from "../ODE_Feedback";

export class ODE_FeedbackAct extends ODE_Feedback
{
    dc! : IDataConsumer;
    constructor() {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2] as unknown as IDataConsumer;
    }

    action(): void {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }

    isEmptyAction(): boolean {
        return false
    }


    func(): boolean {
        return false;
    }


    public test(): void
    {
        try {
            let processor = new RungeProcessor();
            var runtime = new DataRuntimeConsumerODE(this.dc, new Motion6DFactory());
            var p = new PerformerMeasuremets()
            p.performFixedStepCalculation(runtime, 0, 0.4, 45, this, this);
        }
        catch (e: any)
        {
            throw new OwnNotImplemented();
        }
    }
}