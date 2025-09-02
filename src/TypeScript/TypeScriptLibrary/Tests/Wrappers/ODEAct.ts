import { FictiveDataConsumer } from "../../Library/Fiction/FictiveDataConsumer";
import { RungeProcessor } from "../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { ODE } from "../ODE";

export class ODEAct extends ODE
{

    dc: IDataConsumer = new FictiveDataConsumer();
    constructor()
    {
        super();
        var o = this.getCategoryObjects();
        this.dc = o[2] as unknown as IDataConsumer;
    }

    action(): void
    {
        var k = this.dc.getAllMeasurements()[0];
        var a = k.getMeasurement(0).getMeasurementValue();
        var b = k.getMeasurement(1).getMeasurementValue();
        console.log(a, b);
    }

    public test(): void
    {
        try {
            let processor = new RungeProcessor();
            var runtime = new DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.4, 45, this);
        }
        catch (e: any)
        {
            let i = 0;
        }
    }
}