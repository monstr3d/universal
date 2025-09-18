import { IAction } from "../../Library/Interfaces/IAction";
import { RungeProcessor } from "../../Library/Measurements/DifferentialEquations/Processors/RungeProcessor";
import { IDataConsumer } from "../../Library/Measurements/Interfaces/IDataConsumer";
import { PefrormerMeasuremets } from "../../Library/Measurements/PefrormerMeasuremets";
import { Performer } from "../../Library/Performer";
import { DataRuntimeConsumerODE } from "../../Library/Runtime/DataRuntimeConsumerODE";
import { ODE_Feed } from "../ODE_Feed";

export class ODE_FeedAct extends ODE_Feed implements IAction {

    dc !: IDataConsumer;
    constructor() {
        super();
        this.dc = this.getCategoryObject("Chart") as unknown as IDataConsumer;
    }

    action(): void {
        this.performer.print(this.dc);
    }

    func(): boolean {
        return false;
    }


    public test(): void {
        try {
            let processor = new RungeProcessor();
            var runtime = new DataRuntimeConsumerODE(this.dc, processor);
            var p = new PefrormerMeasuremets();
            p.performFixedStepCalculation(runtime, 0, 0.1, 30, this, this);
        }
        catch (e: any) {
            let i = 0;
            //    throw new OwnNotImplemented();
        }
    }

    performer: Performer = new Performer();
}